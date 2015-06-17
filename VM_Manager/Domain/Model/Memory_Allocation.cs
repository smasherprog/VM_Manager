using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_Manager.Domain.Model
{
    public class Memory_Allocation
    {
        public int maxMemory { get; set; }//in MB
        public int Memory { get; set; }//in MB
        public int currentMemory { get; set; }//in MB
    }
}
