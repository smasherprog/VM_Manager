using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VM_Manager.Storage
{
    public partial class Storage_Pool_Listing : UserControl
    {
        private Libvirt.virConnectPtr _connection;
        private string _poolname;
        public Storage_Pool_Listing(Libvirt.virConnectPtr con, string storagepoolname)
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();
            Refresh(con, storagepoolname);
        }
        public void Refresh(Libvirt.virConnectPtr con, string storagepoolname)
        {
            _connection = con;
            _poolname = storagepoolname;
            UpdateStorageInfo();
        }
        private void UpdateStorageInfo()
        {
            Volume_ListView.Items.Clear();
            using (var pool = Libvirt.API.virStoragePoolLookupByName(_connection, _poolname))
            {
                if (pool.Pointer != IntPtr.Zero)
                {
                    Libvirt._virStoragePoolInfo info;
                    Libvirt.API.virStoragePoolGetInfo(pool, out info);
                    Storage_Pool_State_txt.Text = info.state.ToString();
                    int autostart = 0;
                    Libvirt.API.virStoragePoolGetAutostart(pool, out autostart);
                    Storage_AutoStart_ck.Checked = autostart == 1;
                    if (Storage_AutoStart_ck.Checked)
                    {
                        Storage_AutoStart_ck.Text = "On Boot";
                    }
                    else
                    {
                        Storage_AutoStart_ck.Text = "Never";
                    }

                    Storage_Default_txt.Text = VM_Manager.Utilities.Formatting.Format((long)info.available) + " Free / " + VM_Manager.Utilities.Formatting.Format((long)(info.capacity - info.available)) + " in Use ";
                    Libvirt.virStorageVolPtr[] volumes;
                    if (Libvirt.API.virStoragePoolListAllVolumes(pool, out volumes) > 0)
                    {
                        foreach (var item in volumes)
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
                if (Volume_ListView.Items.Count > 0)
                    Volume_ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                else
                    Volume_ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void Storage_Create_Volume_btn_Click(object sender, EventArgs e)
        {
            using (var pool = Libvirt.API.virStoragePoolLookupByName(_connection, _poolname))
            {
                if (pool.Pointer != IntPtr.Zero)
                {
                    var fs = new VM_Manager.Storage.Add_Storage_Volume(pool, _connection);
                    fs.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Pool no longer exists!");
                }
            }
      
        }

        private void Storage_Delete_Volume_btn_Click_1(object sender, EventArgs e)
        {

            if (Volume_ListView.SelectedItems.Count > 0 && MessageBox.Show("Are you sure that you want to delete the selected Volume?", "DELETE VOLUME", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                using (var pool = Libvirt.API.virStoragePoolLookupByName(_connection, _poolname))
                {
                    if (pool.Pointer != IntPtr.Zero)
                    {
                        using (var volume = Libvirt.API.virStorageVolLookupByName(pool, Volume_ListView.SelectedItems[0].SubItems[0].Text))
                        {
                            if (volume.Pointer != IntPtr.Zero)
                            {
                                if (Libvirt.API.virStorageVolDelete(volume) == 0)
                                {
                                    MessageBox.Show("Successfully Deleted Volume!");
                                }
                                else
                                {
                                    MessageBox.Show("Failed to Delete Volume!");
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Volume_ListView_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (Volume_ListView.SelectedItems.Count > 0)
            {
                Storage_Delete_Volume_btn.Enabled = true;
            }
            else
            {
                Storage_Delete_Volume_btn.Enabled = false;
            }
        }
    }
}
