using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_Manager.Domain
{
    public class Storage_Create_Model : View_Model_To_Service
    {
        public Storage_Create_Model(Libvirt.CS_Objects.Host con, Libvirt.Models.Concrete.Virtual_Machine d)
            : base(con, d)
        {

        }
        protected override bool Validate(Libvirt.Models.Interface.IValdiator v)
        {
            foreach (var item in _Machine_Definition.Devices)
            {
                item.Validate(v);
                if (v.IsValid())
                {
                    if (item.Source.GetType() == typeof(Libvirt.Models.Concrete.Device_Source_Volume))
                    {
                        var src = item.Source as Libvirt.Models.Concrete.Device_Source_Volume;
                        using (var pool = Connection.virStoragePoolLookupByName(src.pool))
                        {

                            if (!pool.IsValid) v.AddError("Device_Source_Volume.pool", "Pool is invalid!");

                            using (var volume = pool.virStorageVolLookupByName(src.volume))
                            {
                                if (!volume.IsValid) v.AddError("Device_Source_Volume.volume", "Volume is invalid!");
                            }
                        }
                    }
                }
            }
            return v.IsValid();
        }
    }
}
