using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_Manager.Domain.Model
{
    public class CPU_Layout
    {
        public int vCpu_Count { get; set; }
        public int Socket_Count { get; set;}
        public int Core_Count { get; set; }
        public int THread_Count { get; set; }
    }
}
