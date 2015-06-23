using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_Manager.Domain
{
    public class Storage_Create_Model : View_Model_To_Service
    {
        private Libvirt.Service.Interface.IService_Validator<Libvirt.Models.Concrete.Device, Libvirt.CS_Objects.Host> _Device_Validator;
        public Storage_Create_Model(Libvirt.CS_Objects.Host con, Libvirt.Models.Concrete.Virtual_Machine d)
            : base(con, d)
        {
            _Device_Validator = new Libvirt.Service.Concrete.Device_Validator();
        }
        protected override bool Validate(Libvirt.Models.Interface.IValdiator v)
        {
            foreach (var item in _Machine_Definition.Devices)
            {
                item.Validate(v);
                if (v.IsValid())
                {
                    _Device_Validator.Validate(v, item, Connection);
                }
            }
            return v.IsValid();
        }
    }
}
