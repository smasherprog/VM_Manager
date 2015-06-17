using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_Manager.Domain.Model
{
    public class BIOS_Bootloader
    {
        public string type { get; set; }
        public List<string> BootOrder { get; set; }
    }
}
