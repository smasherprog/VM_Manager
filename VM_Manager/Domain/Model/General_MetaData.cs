using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_Manager.Domain.Model
{
    public class General_Metadata
    {
        public enum Domain_Types { XEN, KVM};
        public Domain_Types type { get; set; }
        public string uuid { get; set; }
        public string title { get; set; }
        public string description { get; set; }

    }
}
