using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VM_Manager.Domain
{
    public partial class Cpu_Ram_Create : UserControl, VM_Manager.Utilities.MultiStepBase
    {
        private Libvirt.CS_Objects.Host _connection;
        private Model.Virtual_Machine _Machine_Def;
      
        public Cpu_Ram_Create(Libvirt.CS_Objects.Host con, Model.Virtual_Machine d)
        {
            InitializeComponent();
            _connection = con;
            _Machine_Def = d;
            UpdateControls();
        }
        private void UpdateControls()
        {  
            Libvirt._virNodeInfo info;
            _connection.virNodeGetInfo(out info);
            Memory_num.Maximum = info.memory;
            Available_Memory_txt.Text = "Up to " + (info.memory/1024).ToString() + " MB available on the host";
            CPU_num.Maximum = info.cpus;
            Available_CPUs_txt.Text = "Up to " + info.cpus + " available on the host";
        }
        public bool Validate_Control()
        {
            if(Memory_num.Value > Memory_num.Maximum)
            {
                MessageBox.Show("Memory Cannot exceed the Maximum Available!");
                return false;
            }
            if(CPU_num.Value > CPU_num.Maximum)
            {
                MessageBox.Show("CPU count Cannot exceed the Maximum Available!");
                return false;
            }
            _Machine_Def.Ram = (int)Memory_num.Value;
            _Machine_Def.Cpu = (int)CPU_num.Value;
            return true;
        }
        public UserControl Next()
        {
            return new Storage_Create(_connection, _Machine_Def);
           
        }
        public bool Execute() { return true; }
    }
}
