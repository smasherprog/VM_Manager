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
    public partial class Local_Media_Create : UserControl, VM_Manager.Utilities.MultiStepBase
    {
        private Libvirt.CS_Objects.Host _connection;
        private Model.Virtual_Machine _Machine_Def;
        public Local_Media_Create(Libvirt.CS_Objects.Host con, Model.Virtual_Machine d)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
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
                Pool_SelectBox.Items.Add(poolname);
            }
        }
        public bool Validate_Control()
        {
            if(Volume_SelectBox.Items.Count<0)
            {
                MessageBox.Show("You must select an ISO!");
                return false;
            }

            var selected = Volume_SelectBox.SelectedItem != null ? Volume_SelectBox.SelectedItem.ToString() : "";
            if(!string.IsNullOrWhiteSpace(selected))
            {
                if(!selected.EndsWith(".iso")){
                    MessageBox.Show("You must select an ISO!");
                    return false;
                }
            } else {
                MessageBox.Show("You must select an ISO!");
                return false;
            }
            _Machine_Def.iso_Path = selected;
            return true;
        }
        public UserControl Next()
        {
            return new Cpu_Ram_Create(_connection, _Machine_Def);
        }
        public bool Execute() { return true; }

        private void Pool_SelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Volume_SelectBox.Items.Clear();
            var selected = Pool_SelectBox.SelectedItem != null ? Pool_SelectBox.SelectedItem.ToString() : "";
            if (string.IsNullOrWhiteSpace(selected))
                return;
            using (var pool = _connection.virStoragePoolLookupByName(selected))
            {
                if (pool.IsValid)
                {
                    Libvirt.CS_Objects.Storage_Volume[] volumes;
                    if (pool.virStoragePoolListAllVolumes(out volumes) > 0)
                    {
                        foreach (var item in volumes)
                        {
                            var volpath = item.virStorageVolGetPath();
                            if (volpath.EndsWith(".iso"))
                                Volume_SelectBox.Items.Add(volpath);
                            item.Dispose();
                        }
                    }
                }
            }
        }
    }
}
