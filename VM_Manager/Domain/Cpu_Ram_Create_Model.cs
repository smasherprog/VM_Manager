using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_Manager.Domain
{
    public class Cpu_Ram_Create_Model : View_Model_To_Service
    {
        public Cpu_Ram_Create_Model(Libvirt.CS_Objects.Host con, Libvirt.Models.Concrete.Virtual_Machine d)
            : base(con, d)
        {

        }
        protected override bool Validate(Libvirt.Models.Interface.IValdiator v)
        {
            Libvirt._virNodeInfo info;
            Connection.virNodeGetInfo(out info);
            var maxmemory = (info.memory / 1024);

            if (Machine_Definition.Memory.maxMemory > maxmemory)
            {
                v.AddError("Memory.maxMemory", "Cannot exceed the Maximum Available!");
            }
            if (Machine_Definition.Memory.memory > Machine_Definition.Memory.maxMemory)
            {
                v.AddError("Memory.memory", "Cannot exceed the Maximum Available!");
            }
            if (Machine_Definition.CPU.vCpu_Count >= info.cpus)
            {
                v.AddError("Memory.memory", "Cannot exceed the Maximum Available!");
            }
            Machine_Definition.Memory.Validate(v);
            Machine_Definition.CPU.Validate(v);
            return v.IsValid();
        }
    }
}
