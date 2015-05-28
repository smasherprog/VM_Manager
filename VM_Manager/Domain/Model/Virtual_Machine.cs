using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VM_Manager.Domain.Model
{
    public class Virtual_Machine
    {
        public string Name { get; set; }
        public string iso_Path { get; set; }
        public int Ram { get; set; }
        public int Cpu { get; set; }
        public string storage_path { get; set; }
    }
}
