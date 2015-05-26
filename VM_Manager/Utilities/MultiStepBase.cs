using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VM_Manager.Utilities
{
    public interface MultiStepBase
    {
        bool Execute();
        bool Validate_Control();
        UserControl Next();
    }
}
