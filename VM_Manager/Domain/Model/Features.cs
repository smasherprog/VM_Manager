using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_Manager.Domain.Model
{
    public class Features
    {
        public bool pae { get; set; }
        public bool acpi { get; set; }
        public bool apic { get; set; }
        public bool hap { get; set; }
  

    }
}
