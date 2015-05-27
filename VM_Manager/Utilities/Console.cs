using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace VM_Manager.Utilities
{
    public class DebugConsole : IDisposable
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


        public DebugConsole()
        {
            IntPtr ptr = GetForegroundWindow();
            int u;
            GetWindowThreadProcessId(ptr, out u);
            var process = System.Diagnostics.Process.GetProcessById(u);
            if(process.ProcessName == "cmd")    //Is the uppermost window a cmd process?
            {
                AttachConsole(process.Id);
                //we have a console to attach to ..
                Console.WriteLine("Starting debug console. . . ");
            } else
            {
                //no console AND we're in console mode ... create a new console.
                AllocConsole();
                Console.WriteLine(@"hello. It looks like you double clicked me to start AND you want console mode.  Here's a new console.");
            }
        }

        public void Dispose()
        {
            FreeConsole();
        }
    }
}
