using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_Manager.Utilities
{
    public class Libvirt_EventLoop : IDisposable
    {
        private System.Threading.Thread _EventLoop;
        private bool KeepRunningLoop = true;

        private Libvirt.virFreeCallback _FuncDeclare_To_Keep_GC_From_Collecting_free;
        private Libvirt.virEventTimeoutCallback _FuncDeclare_To_Keep_GC_From_Collecting;
        private int TimerHandle = -1;
        public Libvirt_EventLoop()
        {
            _FuncDeclare_To_Keep_GC_From_Collecting = virEventTimeoutCallback;
            _FuncDeclare_To_Keep_GC_From_Collecting_free = DummyFree;
            Libvirt.API.virEventRegisterDefaultImpl();
            TimerHandle = Libvirt.API.virEventAddTimeout(1000, _FuncDeclare_To_Keep_GC_From_Collecting, IntPtr.Zero, _FuncDeclare_To_Keep_GC_From_Collecting_free);
            if (TimerHandle < 0) {
                System.Windows.Forms.MessageBox.Show("Could not register callback for event loop. This will lead to instability within the program.");
            }
            else
            {
                _EventLoop = new System.Threading.Thread(EventLoop);
                _EventLoop.Start();
            }

        }
        void DummyFree(IntPtr opaque)
        {
            //Does nothing on purpose!
        }
        void virEventTimeoutCallback(int timer, IntPtr opaque)
        {
            //Does nothing on purpose, this is to keep the event rundefault from blocking for ever
        }
        void EventLoop()
        {
            while (KeepRunningLoop)
            {
                try
                {
                    KeepRunningLoop = Libvirt.API.virEventRunDefaultImpl() == 0;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
        }
        public void Dispose()
        {
            KeepRunningLoop = false;   
            if (_EventLoop != null)
            {
                _EventLoop.Join(1000); 
                _EventLoop = null;
            }
            Libvirt.API.virEventRemoveTimeout(TimerHandle);
        }
    }
}
