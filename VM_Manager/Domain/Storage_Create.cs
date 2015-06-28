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
    public partial class Storage_Create : UserControl, Dialog_Helper
    {
        private View_Model_To_Service _Storage_Create_Model;
        private UserControl _Previous;
        public Storage_Create(UserControl p, Libvirt.CS_Objects.Host con, Libvirt.Models.Concrete.Virtual_Machine d)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            _Previous = p;
            _Storage_Create_Model = new Storage_Create_Model(con, d);

            Init_Controls();

        }
        public UserControl Forward()
        {

            var previtem = _Storage_Create_Model.Machine_Definition.Devices.Devices.FirstOrDefault();
            _Storage_Create_Model.Machine_Definition.Devices.Devices.Clear();// clear everything 
            var de = new Libvirt.Models.Concrete.Device();
            de.Device_Bus_Type = Libvirt.Models.Concrete.Device.Device_Bus_Types.virtio;
            de.Device_Device_Type = Libvirt.Models.Concrete.Device.Device_Device_Types.disk;
            de.Device_Type = Libvirt.Models.Concrete.Device.Device_Types.volume;
            de.Driver_Cache_Type = Libvirt.Models.Concrete.Device.Driver_Cache_Types._default;
            de.Driver_Type = Libvirt.Models.Concrete.Device.Driver_Types.raw;
            de.ReadOnly = false;
            de.Snapshot_Type = Libvirt.Models.Concrete.Device.Snapshot_Types._default;
            var source = new Libvirt.Models.Concrete.Device_Source_Volume();
            source.pool = Pool_ListBox.SelectedItem != null ? Pool_ListBox.SelectedItem.ToString() : "";
            source.volume = Volume_ListBox.SelectedItem != null ? Volume_ListBox.SelectedItem.ToString() : "";
            source.Source_Startup_Policy = Libvirt.Models.Concrete.Device.Source_Startup_Policies.mandatory;
            de.Source = source;

            _Storage_Create_Model.Machine_Definition.Devices.Add(de);// add this .. NOW VALIDATE!!
            if (_Storage_Create_Model.Validate())
            {
                _Storage_Create_Model.Machine_Definition.Devices.Add(previtem);//add the previous item back
                var tmpxml = _Storage_Create_Model.Machine_Definition.To_XML();

                using (var domain = _Storage_Create_Model.Connection.virDomainDefineXML(_Storage_Create_Model.Machine_Definition))
                {
                    if (domain.IsValid)
                    {
                        if (AutoStart_VM_chk.Checked)
                        {
                            if (domain.virDomainCreate() == 0)
                            {
                                MessageBox.Show("Successfully created and started the new VM!");
                                return new End_Control();//marker to signal the end
                            }
                            else
                            {
                                MessageBox.Show("Successfully created the VM, but was unable to start it. Check the error logs");
                                return new End_Control();//marker to signal the end
                            }
                        }
                        else
                        {
                            MessageBox.Show("Successfully created the new VM!");
                            return new End_Control();//marker to signal the end
                        }
                    }
                    else
                    {
                        MessageBox.Show("Unable to create the VM, please check the error logs!");
                    }
                }

            }
            else
            {
                _Storage_Create_Model.Machine_Definition.Devices.Devices.Clear();// clear everything, bad attempt
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
            _Storage_Create_Model.Connection.virConnectListAllStoragePools(out pools, Libvirt.virConnectListAllStoragePoolsFlags.VIR_CONNECT_LIST_STORAGE_POOLS_ACTIVE);

            foreach (var item in pools)
            {
                Libvirt._virStoragePoolInfo poolinfo;
                item.virStoragePoolGetInfo(out poolinfo);
                var poolname = item.virStoragePoolGetName();
                item.Dispose();
                Pool_ListBox.Items.Add(poolname);
            }
        }


        private void Pool_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Volume_ListBox.Items.Clear();
            var selected = Pool_ListBox.SelectedItem != null ? Pool_ListBox.SelectedItem.ToString() : "";
            if (string.IsNullOrWhiteSpace(selected))
                return;
            using (var pool = _Storage_Create_Model.Connection.virStoragePoolLookupByName(selected))
            {
                if (pool.IsValid)
                {
                    Libvirt.CS_Objects.Storage_Volume[] volumes;
                    if (pool.virStoragePoolListAllVolumes(out volumes) > 0)
                    {
                        foreach (var item in volumes)
                        {
                            var volpath = item.virStorageVolGetPath();
                            if (volpath.EndsWith(".img"))
                                Volume_ListBox.Items.Add(item.virStorageVolGetName());
                            item.Dispose();
                        }
                    }
                }
            }
        }
    }
}
