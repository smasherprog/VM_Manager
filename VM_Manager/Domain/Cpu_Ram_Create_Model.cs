using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_Manager.Domain
{
    public class Cpu_Ram_Create_Model : View_Model_To_Service
    {
        private Libvirt.Service.Interface.IService_Validator<Libvirt.Models.Concrete.CPU_Layout, Libvirt.CS_Objects.Host> _CPU_Layout_Validator;
        private Libvirt.Service.Interface.IService_Validator<Libvirt.Models.Concrete.Memory_Allocation, Libvirt.CS_Objects.Host> _Memory_Allocation_Validator;
        public Cpu_Ram_Create_Model(Libvirt.CS_Objects.Host con, Libvirt.Models.Concrete.Virtual_Machine d)
            : base(con, d)
        {
            _CPU_Layout_Validator = new Libvirt.Service.Concrete.CPU_Layout_Validator();
            _Memory_Allocation_Validator = new Libvirt.Service.Concrete.Memory_Allocation_Validator();
        }
        protected override bool Validate(Libvirt.Models.Interface.IValdiator v)
        {
            //model level validation
            Machine_Definition.Memory.Validate(v);
            Machine_Definition.CPU.Validate(v);
            if (v.IsValid())
            {
                //do a service level validation . . . 
                _Memory_Allocation_Validator.Validate(v, Machine_Definition.Memory, Connection);
                _CPU_Layout_Validator.Validate(v, Machine_Definition.CPU, Connection);
            }
            return v.IsValid();
        }
    }
}
