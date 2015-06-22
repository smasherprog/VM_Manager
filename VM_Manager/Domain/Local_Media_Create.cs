using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VM_Manager.Utilities;

namespace VM_Manager.Domain
{
    public partial class Local_Media_Create : UserControl, Dialog_Helper
    {
        private View_Model_To_Service _Local_Media_Create_Model;
        private UserControl _Previous;
        public Local_Media_Create(UserControl p, Libvirt.CS_Objects.Host con, Libvirt.Models.Concrete.Virtual_Machine d)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill; 
            _Previous = p;
            _Local_Media_Create_Model = new Local_Media_Create_Model(con, d);  
            Init_Controls();          
        }
        public UserControl Forward()
        {
            _Local_Media_Create_Model.Machine_Definition.Devices.Clear();//remove any previous devices
            var de = new Libvirt.Models.Concrete.Device();
            de.Device_Bus_Type = Libvirt.Models.Concrete.Device.Device_Bus_Types.virtio;
            de.Device_Device_Type = Libvirt.Models.Concrete.Device.Device_Device_Types.cdrom;
            de.Device_Type = Libvirt.Models.Concrete.Device.Device_Types.volume;
            de.Driver_Cache_Type = Libvirt.Models.Concrete.Device.Driver_Cache_Types._default;
            de.Driver_Type = Libvirt.Models.Concrete.Device.Driver_Types.raw;
            de.ReadOnly = true;
            de.Snapshot_Type = Libvirt.Models.Concrete.Device.Snapshot_Types._default;
            var source = new Libvirt.Models.Concrete.Device_Source_Volume();
            source.pool = Pool_SelectBox.SelectedItem != null ? Pool_SelectBox.SelectedItem.ToString() : "";
            source.volume = Volume_SelectBox.SelectedItem != null ? Volume_SelectBox.SelectedItem.ToString() : "";
            source.Source_Startup_Policy = Libvirt.Models.Concrete.Device.Source_Startup_Policies.optional;
            de.Source = source;
            _Local_Media_Create_Model.Machine_Definition.Devices.Add(de);// add this .. NOW VALIDATE!!
            if (_Local_Media_Create_Model.Validate())
            {
                return new Cpu_Ram_Create(this, _Local_Media_Create_Model.Connection, _Local_Media_Create_Model.Machine_Definition);
            }
            else
            {
                foreach (var item in _Local_Media_Create_Model.Errors)
                {
                    foreach (var r in item.Value)
                    {
                        errorProvider1.SetError(Volume_SelectBox, r);
                    }
                }
            }
            return null;
        }
        public UserControl Back()
        {
            return _Previous;
        }
        private void Init_Controls()
        {
            Libvirt.CS_Objects.Storage_Pool[] pools;
            _Local_Media_Create_Model.Connection.virConnectListAllStoragePools(out pools, Libvirt.virConnectListAllStoragePoolsFlags.VIR_CONNECT_LIST_STORAGE_POOLS_ACTIVE);

            foreach(var item in pools)
            {
                Libvirt._virStoragePoolInfo poolinfo;
                item.virStoragePoolGetInfo(out poolinfo);
                var poolname = item.virStoragePoolGetName();
                item.Dispose();
                Pool_SelectBox.Items.Add(poolname);
            }
        }

        private void Pool_SelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Volume_SelectBox.Items.Clear();
            var selected = Pool_SelectBox.SelectedItem != null ? Pool_SelectBox.SelectedItem.ToString() : "";
            if (string.IsNullOrWhiteSpace(selected))
                return;
            using (var pool = _Local_Media_Create_Model.Connection.virStoragePoolLookupByName(selected))
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
                                Volume_SelectBox.Items.Add(item.virStorageVolGetName());
                            item.Dispose();
                        }
                    }
                }
            }
        }
    }
}
