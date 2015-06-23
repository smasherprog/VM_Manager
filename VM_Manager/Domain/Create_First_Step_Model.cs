using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_Manager.Domain
{
    public class Create_First_Step_Model : View_Model_To_Service
    {
        private Libvirt.Service.Interface.IService_Validator<Libvirt.Models.Concrete.General_Metadata, Libvirt.CS_Objects.Host> _General_Metadata_Validator;

        public Create_First_Step_Model(Libvirt.CS_Objects.Host con, Libvirt.Models.Concrete.Virtual_Machine d)
            : base(con, d)
        {
            _General_Metadata_Validator = new Libvirt.Service.Concrete.General_Metadata_Validator();

        }
        protected override bool Validate(Libvirt.Models.Interface.IValdiator v)
        {
            _Machine_Definition.Metadata.Validate(v);
            if (v.IsValid())
            {
                _General_Metadata_Validator.Validate(v, _Machine_Definition.Metadata, Connection);
            }
            return v.IsValid();
        }
    }
}
