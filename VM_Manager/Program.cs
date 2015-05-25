using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace VM_Manager
{
    static class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool FreeConsole();

        [DllImport("kernel32", SetLastError = true)]
        static extern bool AttachConsole(int dwProcessId);
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);


        [STAThread]
        static void Main()
        {
            //Get a pointer to the forground window.  The idea here is that
            //IF the user is starting our application from an existing console
            //shell, that shell will be the uppermost window.  We'll get it
            //and attach to it
            IntPtr ptr = GetForegroundWindow();
            int u;
            GetWindowThreadProcessId(ptr, out u);
            var process = System.Diagnostics.Process.GetProcessById(u);
            if(process.ProcessName == "cmd")    //Is the uppermost window a cmd process?
            {
                AttachConsole(process.Id);
                //we have a console to attach to ..
                Console.WriteLine("hello. It looks like you started me from an existing console.");
            } else
            {
                //no console AND we're in console mode ... create a new console.
                AllocConsole();
                Console.WriteLine(@"hello. It looks like you double clicked me to start AND you want console mode.  Here's a new console.");
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Host_List());
            FreeConsole();
        }
    }
}
