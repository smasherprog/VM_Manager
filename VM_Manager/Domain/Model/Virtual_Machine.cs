using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VM_Manager.Domain.Model
{
    public class Virtual_Machine
    {
        public General_Metadata Metadata { get; set; }
        public BIOS_Bootloader BootLoader { get; set; }
        public CPU_Layout CPU { get; set; }
        public Memory_Allocation Memory { get; set; }
        public Features System_Features { get; set; }
        public string iso_Path { get; set; }
       
    
        public string storage_path { get; set; }
        public bool StartOnCreate { get; set; }
        public bool Created { get; set; }
    }
}
