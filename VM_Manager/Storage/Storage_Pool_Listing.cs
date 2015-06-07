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
        private Libvirt.CS_Objects.Host _connection;
        private string _poolname;
        public Storage_Pool_Listing(Libvirt.CS_Objects.Host con, string storagepoolname)
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();
            Refresh(con, storagepoolname);
        }
        public void Refresh(Libvirt.CS_Objects.Host con, string storagepoolname)
        {
            _connection = con;
            _poolname = storagepoolname;
            UpdateStorageInfo();
        }
        private void UpdateStorageInfo()
        {
            Volume_ListView.Items.Clear();
            using (var pool = _connection.virStoragePoolLookupByName(_poolname))
            {
                if (pool.IsValid)
                {
                    Libvirt._virStoragePoolInfo info;
                    pool.virStoragePoolGetInfo(out info);
                    Storage_Pool_State_txt.Text = info.state.ToString();
                    int autostart = 0;
                    pool.virStoragePoolGetAutostart(out autostart);
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
                    Libvirt.CS_Objects.Storage_Volume[] volumes;
                    if (pool.virStoragePoolListAllVolumes(out volumes) > 0)
                    {
                        foreach (var item in volumes)
                        {
                            Libvirt._virStorageVolInfo volinfo;
                            item.virStorageVolGetInfo(out volinfo);
                            var volname = item.virStorageVolGetName();
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
            using (var pool = _connection.virStoragePoolLookupByName(_poolname))
            {
                if (pool.IsValid)
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
                using (var pool = _connection.virStoragePoolLookupByName(_poolname))
                {
                    if (pool.IsValid)
                    {
                        using (var volume = pool.virStorageVolLookupByName(Volume_ListView.SelectedItems[0].SubItems[0].Text))
                        {
                            if (volume.IsValid)
                            {
                                if (volume.virStorageVolDelete() == 0)
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
