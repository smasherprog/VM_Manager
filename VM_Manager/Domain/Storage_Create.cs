using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VM_Manager.Domain
{
    public partial class Storage_Create : UserControl, VM_Manager.Utilities.MultiStepBase
    {
        private Libvirt.CS_Objects.Host _connection;
        private Model.Virtual_Machine _Machine_Def;
        public Storage_Create(Libvirt.CS_Objects.Host con, Model.Virtual_Machine d)
        {
            InitializeComponent();
            _connection = con;
            _Machine_Def = d;
            Init_Controls();
        }
        private void Init_Controls()
        {
            Libvirt.CS_Objects.Storage_Pool[] pools;
            _connection.virConnectListAllStoragePools(out pools, Libvirt.virConnectListAllStoragePoolsFlags.VIR_CONNECT_LIST_STORAGE_POOLS_ACTIVE);

            foreach(var item in pools)
            {
                Libvirt._virStoragePoolInfo poolinfo;
                item.virStoragePoolGetInfo(out poolinfo);
                var poolname = item.virStoragePoolGetName();
                item.Dispose();
                Pool_ListBox.Items.Add(poolname);
            }
        }
        public bool Validate_Control()
        {
            if(Volume_ListBox.Items.Count<0)
            {
                MessageBox.Show("You must select an img file!");
                return false;
            }

            var selected = Volume_ListBox.SelectedItem != null ? Volume_ListBox.SelectedItem.ToString() : "";
            if(!string.IsNullOrWhiteSpace(selected))
            {
                if(!selected.EndsWith(".img")){
                    MessageBox.Show("You must select an img file!");
                    return false;
                }
            } else {
                MessageBox.Show("You must select an img file!");
                return false;
            }
            _Machine_Def.storage_path = selected;
            _Machine_Def.StartOnCreate = AutoStart_VM_chk.Checked;
            return true;
        }
        public UserControl Next()
        {
            if(API.Service.Create_VM(_connection, _Machine_Def))
            {
                MessageBox.Show("Successfully Created VM!");
            }
            return null;
        }
        public bool Execute() { return true; }

        private void Pool_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        { 
            Volume_ListBox.Items.Clear();
            var selected = Pool_ListBox.SelectedItem != null ? Pool_ListBox.SelectedItem.ToString() : "";
            if(string.IsNullOrWhiteSpace(selected))
                return;
            using (var pool = _connection.virStoragePoolLookupByName(selected))
            {
                if(pool.IsValid)
                {
                    Libvirt.CS_Objects.Storage_Volume[] volumes;
                    if (pool.virStoragePoolListAllVolumes(out volumes) > 0)
                    {
                        foreach(var item in volumes)
                        {
                            var volpath = item.virStorageVolGetPath();
                            if(volpath.EndsWith(".img"))
                                Volume_ListBox.Items.Add(volpath);
                            item.Dispose();
                        }
                    }
                }
            }
        }

   
    }
}
