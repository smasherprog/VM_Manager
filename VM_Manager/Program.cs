using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VM_Manager
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            using(var cons = new VM_Manager.Utilities.DebugConsole())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new VM_Manager.Manager.VM_Manager_Main());
            }
        }
    }
}
