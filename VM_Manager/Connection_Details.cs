using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VM_Manager
{
    public partial class Connection_Details : Form
    {
        private Libvirt.virConnectPtr _connection;
        private System.Threading.Thread _pollthread = null;
        private bool _keep_polling = true;
        private Int64 Counter = 0;
        public Connection_Details(Libvirt.virConnectPtr connection)
        {
            InitializeComponent();
            _connection = connection;

            _pollthread = new System.Threading.Thread(UpdateStats);
            _pollthread.Start();
            this.FormClosing += Connection_Details_FormClosing;
            FIllGeneralInfo();
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
            connectionuri.Text= Libvirt.API.virConnectGetURI(_connection);
            hostname.Text =  Libvirt.API.virConnectGetHostname(_connection);
            hypervisor.Text = Libvirt.API.virConnectGetType(_connection);
            Libvirt._virNodeInfo info;
            Libvirt.API.virNodeGetInfo(_connection, out info);
            CpuModel.Text = info.model;
            systemmemory.Text = info.memory.ToString() + "KB";
            numcpus.Text = info.cpus.ToString();
            cpumhz.Text = info.mhz.ToString();
            cpucores.Text = info.cores.ToString();
            cputhreads.Text = info.threads.ToString();
      
     
        }
        void UpdateStats()
        {
            if(!_keep_polling)
                return;
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
            UpdateStats();

        }

        void GetcurrentPools()
        {
            //int numOfStoragePools = Libvirt.API.virConnectNumOfDefinedStoragePools(_connection);
            //if(numOfStoragePools > 0)
            //{
            //    string[] storagePoolsNames = null;
            //    int listStoragePools = Libvirt.API.virConnectListDefinedStoragePools(_connection, out storagePoolsNames, numOfStoragePools);

            //    foreach(string storagePoolName in storagePoolsNames)
            //        listBox1.Items.Add(storagePoolName);
            //} else
            //{
            //    MessageBox.Show("Unable to get the number of storage pools");
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var stpool = "<pool type=\"dir\"><name>virtotherimages</name><target><path>/var/lib/virt/othertest</path></target></pool>";
            var pooldef = Libvirt.API.virStoragePoolDefineXML(_connection, stpool);
            var suc = Libvirt.API.virStoragePoolBuild(pooldef, Libvirt.virStoragePoolBuildFlags.VIR_STORAGE_POOL_BUILD_NEW);
            Libvirt.PInvoke.virStoragePoolFree(pooldef);
        }

    


    }
}
