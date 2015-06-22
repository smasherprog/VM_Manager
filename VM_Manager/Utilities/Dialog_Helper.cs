using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_Manager.Utilities
{
    public class End_Control : System.Windows.Forms.UserControl
    {
        public End_Control()
        {

        }
    }
    public interface Dialog_Helper
    {
        System.Windows.Forms.UserControl Forward();
        System.Windows.Forms.UserControl Back();

    }

}
