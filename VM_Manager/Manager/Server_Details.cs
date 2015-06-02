using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace VM_Manager.Manager
{
    public partial class Server_Details : Form
    {
        private Libvirt.virConnectPtr _connection;
        private System.Threading.Thread _pollthread = null;
        private bool _keep_polling = true;
        private Int64 Counter = 0;
        private Libvirt.virErrorFunc _Global_ErrorHandler;//this is needed otherwise the GC reclaims it
        public Server_Details(Libvirt.virConnectPtr connection)
        {
            InitializeComponent();

            _connection = connection;
            _Global_ErrorHandler = virErrorFunc;
            Libvirt.API.virConnSetErrorFunc(_connection, IntPtr.Zero, _Global_ErrorHandler);
            _pollthread = new System.Threading.Thread(UpdateStats);
            _pollthread.Start();
            this.FormClosing += Connection_Details_FormClosing;


            Host_TabControl.SelectedIndexChanged += Host_TabControl_SelectedIndexChanged;
            FIllGeneralInfo();

        }

        void Host_TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Host_TabControl.SelectedIndex == 2)
            {//storage tab
                UpdateStorageTab();
            } else if(Host_TabControl.SelectedIndex == 4)
            {
                VM_List_panel.Controls.Add(new Domain.List_Virtual_Machines(_connection));
            } else
            {
                VM_List_panel.Controls.Clear();
            }

        }

        void virErrorFunc(IntPtr userData, Libvirt.virErrorPtr error)
        {
            var realerror = Libvirt.API.MarshalErrorPtr(error);
            Debug.WriteLine(realerror.message);
        }

        void Connection_Details_FormClosing(object sender, FormClosingEventArgs e)
        {
            _keep_polling = false;
            if(_pollthread != null)
            {
                _pollthread.Join(2000);
                _pollthread = null;
            }
        }
        void FIllGeneralInfo()
        {
            connectionuri.Text = Libvirt.API.virConnectGetURI(_connection);
            hostname.Text = Libvirt.API.virConnectGetHostname(_connection);
            hypervisor.Text = Libvirt.API.virConnectGetType(_connection);
            Libvirt._virNodeInfo info;
            Libvirt.API.virNodeGetInfo(_connection, out info);
            CpuModel.Text = info.model;
            systemmemory.Text = VM_Manager.Utilities.Formatting.Format(info.memory);
            numcpus.Text = info.cpus.ToString();
            cpumhz.Text = info.mhz.ToString();
            cpucores.Text = info.cores.ToString();
            cputhreads.Text = info.threads.ToString();
            ///////INTERFACE TAB
            string[] interfaces;
            Libvirt.API.virConnectListDefinedInterfaces(_connection, out interfaces, 10);
            foreach(var item in interfaces)
            {
                Network_Interfaces.Items.Add(item);
            }
            Libvirt.API.virConnectListInterfaces(_connection, out interfaces, 10);
            foreach(var item in interfaces)
            {
                Network_Interfaces.Items.Add(item);
            }
            /////////STORAGE TAB

        }
        void UpdateStorageTab()
        {
            Pool_Listing.Items.Clear();
            Libvirt.virStoragePoolPtr[] pools;
            Libvirt.API.virConnectListAllStoragePools(_connection, out pools, Libvirt.virConnectListAllStoragePoolsFlags.VIR_CONNECT_LIST_STORAGE_POOLS_ACTIVE | Libvirt.virConnectListAllStoragePoolsFlags.VIR_CONNECT_LIST_STORAGE_POOLS_INACTIVE);

            foreach(var item in pools)
            {
                Libvirt._virStoragePoolInfo poolinfo;
                Libvirt.API.virStoragePoolGetInfo(item, out poolinfo);
                var poolname = Libvirt.API.virStoragePoolGetName(item);
                item.Dispose();
                Pool_Listing.Items.Add(poolname);
            }
        }
        void UpdateStats()
        {
            while(_keep_polling)
            {
                try
                {
                    Counter += 1;
                    Libvirt._virNodeCPUStats[] cpustats = null;
                    Libvirt.API.virNodeGetCPUStats(_connection, -1, out cpustats, 0);
                    Libvirt._virNodeMemoryStats[] memstats = null;
                    Libvirt.API.virNodeGetMemoryStats(_connection, -1, out memstats, 0);

                    chart1.Invoke((MethodInvoker)delegate
                    {

                        foreach(var item in cpustats)
                        {
                            if(!chart1.Series.Any(a => a.Name == item.field))
                            {
                                var series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
                                series1.ChartArea = "ChartArea1";
                                series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                                series1.Legend = "Legend1";
                                series1.Name = item.field;

                                chart1.Series.Add(series1);
                            }
                            chart1.Series[item.field].Points.AddXY(Counter, item.value);
                        }
                        foreach(var item in memstats)
                        {
                            if(!chart2.Series.Any(a => a.Name == item.field))
                            {
                                var series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
                                series1.ChartArea = "ChartArea1";
                                series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
                                series1.Legend = "Legend1";
                                series1.Name = item.field;
                                chart2.Series.Add(series1);
                            }
                            chart2.Series[item.field].Points.AddXY(Counter, item.value);
                        }
                    });
                } catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                System.Threading.Thread.Sleep(1000);
            }
        }


        private void Pool_Listing_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Pool_Listing.SelectedItems.Count > 0)
            {
                UpdateStorageInfo(Pool_Listing.SelectedItems[0].ToString());
                Stop_Storage_Pool_btn.Enabled = button1.Enabled = Storage_Create_Volume_btn.Enabled = true;
            } else
            {
                Stop_Storage_Pool_btn.Enabled = button1.Enabled = Storage_Create_Volume_btn.Enabled = false;
            }

        }
        private void UpdateStorageInfo(string name)
        {
            Volume_ListView.Items.Clear();
            using(var pool = Libvirt.API.virStoragePoolLookupByName(_connection, name))
            {
                if(pool.Pointer != IntPtr.Zero)
                {
                    Libvirt._virStoragePoolInfo info;
                    Libvirt.API.virStoragePoolGetInfo(pool, out info);
                    Storage_Pool_State_txt.Text = info.state.ToString();
                    int autostart = 0;
                    Libvirt.API.virStoragePoolGetAutostart(pool, out autostart);
                    Storage_AutoStart_ck.Checked = autostart == 1;
                    if(Storage_AutoStart_ck.Checked)
                    {
                        Storage_AutoStart_ck.Text = "On Boot";
                    } else
                    {
                        Storage_AutoStart_ck.Text = "Never";
                    }

                    Storage_Default_txt.Text = VM_Manager.Utilities.Formatting.Format((long)info.available) + " Free / " + VM_Manager.Utilities.Formatting.Format((long)(info.capacity - info.available)) + " in Use ";
                    Libvirt.virStorageVolPtr[] volumes;
                    if(Libvirt.API.virStoragePoolListAllVolumes(pool, out volumes) > 0)
                    {
                        foreach(var item in volumes)
                        {
                            Libvirt._virStorageVolInfo volinfo;
                            Libvirt.API.virStorageVolGetInfo(item, out volinfo);
                            var volname = Libvirt.API.virStorageVolGetName(item);
                            var li = new ListViewItem(new string[] { volname, VM_Manager.Utilities.Formatting.Format((long)volinfo.allocation), VM_Manager.Utilities.Formatting.Format((long)volinfo.capacity), volinfo.type.ToString() });
                            Volume_ListView.Items.Add(li);
                            item.Dispose();
                        }
                    }

                }
                if(Volume_ListView.Items.Count > 0)
                    Volume_ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                else
                    Volume_ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void Create_Storage_Pool_btn_Click(object sender, EventArgs e)
        {
            var fs = new VM_Manager.Storage.Add_Storage_Pool(_connection);
            fs.ShowDialog();
        }

        private void Stop_Storage_Pool_btn_Click(object sender, EventArgs e)
        {
            if(Pool_Listing.SelectedItems.Count > 0 && MessageBox.Show("Are you sure that you want to STOP the selected pool?", "STOP POOL", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                using(var pool = Libvirt.API.virStoragePoolLookupByName(_connection, Pool_Listing.SelectedItems[0].ToString()))
                {
                    Libvirt.API.virStoragePoolDestroy(pool);
                }
            }
            button1.Enabled = Stop_Storage_Pool_btn.Enabled = false;
        }

        private void Delete_Storage_Pool_btn_Click(object sender, EventArgs e)
        {
            if(Pool_Listing.SelectedItems.Count > 0 && MessageBox.Show("Are you sure that you want to delete the selected pool?", "DELETE POOL", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                using(var pool = Libvirt.API.virStoragePoolLookupByName(_connection, Pool_Listing.SelectedItems[0].ToString()))
                {
                    Libvirt.API.virStoragePoolUndefine(pool);
                    Pool_Listing.Items.Remove(Pool_Listing.SelectedItems[0]);
                }
            }
            button1.Enabled = Stop_Storage_Pool_btn.Enabled = false;
        }

        private void Storage_Create_Volume_btn_Click(object sender, EventArgs e)
        {
            if(Pool_Listing.SelectedItems.Count > 0)
            {
                using(var pool = Libvirt.API.virStoragePoolLookupByName(_connection, Pool_Listing.SelectedItems[0].ToString()))
                {
                    if(pool.Pointer != IntPtr.Zero)
                    {
                        var f = new VM_Manager.Storage.Add_Storage_Volume(pool, _connection);
                        f.ShowDialog();
                    }
                }
            }
        }

        private void Volume_ListView_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(Volume_ListView.SelectedItems.Count > 0)
            {
                Storage_Delete_Volume_btn.Enabled = true;
            } else
            {
                Storage_Delete_Volume_btn.Enabled = false;
            }

        }

        private void Storage_Delete_Volume_btn_Click(object sender, EventArgs e)
        {

            if(Pool_Listing.SelectedItems.Count > 0 && Volume_ListView.SelectedItems.Count > 0 && MessageBox.Show("Are you sure that you want to delete the selected Volume?", "DELETE VOLUME", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                using(var pool = Libvirt.API.virStoragePoolLookupByName(_connection, Pool_Listing.SelectedItems[0].ToString()))
                {
                    if(pool.Pointer != IntPtr.Zero)
                    {
                        using(var volume = Libvirt.API.virStorageVolLookupByName(pool, Volume_ListView.SelectedItems[0].SubItems[0].Text))
                        {
                            if(volume.Pointer != IntPtr.Zero)
                            {
                                if(Libvirt.API.virStorageVolDelete(volume) == 0)
                                {
                                    MessageBox.Show("Successfully Deleted Volume!");
                                } else
                                {
                                    MessageBox.Show("Failed to Delete Volume!");
                                }
                            }
                        }
                    }
                }
            }
        }


        private void Create_VM_btn_Click(object sender, EventArgs e)
        {
            var f = new VM_Manager.Domain.Add_Domain(_connection);
            f.ShowDialog();
        }
    }
}
