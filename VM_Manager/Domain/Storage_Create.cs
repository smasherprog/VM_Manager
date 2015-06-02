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
       private Libvirt.virConnectPtr _connection;
        private Model.Virtual_Machine _Machine_Def;
        public Storage_Create(Libvirt.virConnectPtr con, Model.Virtual_Machine d)
        {
            InitializeComponent();
            _connection = con;
            _Machine_Def = d;
            Init_Controls();
        }
        private void Init_Controls()
        {
            Libvirt.virStoragePoolPtr[] pools;
            Libvirt.API.virConnectListAllStoragePools(_connection, out pools, Libvirt.virConnectListAllStoragePoolsFlags.VIR_CONNECT_LIST_STORAGE_POOLS_ACTIVE);

            foreach(var item in pools)
            {
                Libvirt._virStoragePoolInfo poolinfo;
                Libvirt.API.virStoragePoolGetInfo(item, out poolinfo);
                var poolname = Libvirt.API.virStoragePoolGetName(item);
                item.Dispose();
                Pool_Combobox.Items.Add(poolname);
            }
        }
        public bool Validate_Control()
        {
            if(Volume_Combobox.Items.Count<0)
            {
                MessageBox.Show("You must select an img file!");
                return false;
            }

            var selected = Volume_Combobox.SelectedItem != null ? Volume_Combobox.SelectedItem.ToString() : "";
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

        private void Pool_Combobox_SelectedIndexChanged(object sender, EventArgs e)
        { 
            Volume_Combobox.Items.Clear();
            var selected = Pool_Combobox.SelectedItem != null ? Pool_Combobox.SelectedItem.ToString() : "";
            if(string.IsNullOrWhiteSpace(selected))
                return;
            using(var pool = Libvirt.API.virStoragePoolLookupByName(_connection, selected))
            {
                if(pool.Pointer != IntPtr.Zero)
                {
                    Libvirt.virStorageVolPtr[] volumes;
                    if(Libvirt.API.virStoragePoolListAllVolumes(pool, out volumes) > 0)
                    {
                        foreach(var item in volumes)
                        {
                            var volpath = Libvirt.API.virStorageVolGetPath(item);
                            if(volpath.EndsWith(".img"))
                                Volume_Combobox.Items.Add(volpath);
                            item.Dispose();
                        }
                    }
                }
            }
        }
    }
}
