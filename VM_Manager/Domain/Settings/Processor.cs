using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VM_Manager.Utilities;

namespace VM_Manager.Domain.Settings
{
    public partial class Processor : UserControl
    {
        private Libvirt.Models.Concrete.Virtual_Machine _VM;
        public Processor(Libvirt.Models.Concrete.Virtual_Machine vm)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            _VM = vm;
            cpu_type_combobx.SelectedIndex = 5;
            BuildInfo();
            this.Disposed += Processor_Disposed;
        }

        void Processor_Disposed(object sender, EventArgs e)
        {

            var b = Libvirt.Models.Concrete.CPU_Layout.CPU_Models.qemu64;
            if (cpu_type_combobx.SelectedItem != null)
            {
                Enum.TryParse(cpu_type_combobx.SelectedItem.ToString(), true, out b);
            }
            _VM.CPU.Cpu_Model = b;
        }
        void BuildInfo()
        {
            vCPU_trackbr.DataBindings.Add(
                Safe_Property.GetPropertyInfo(vCPU_trackbr, a => a.Value).Name,
                _VM.CPU,
                Safe_Property.GetPropertyInfo(_VM.CPU, a => a.vCpu_Count).Name, false, DataSourceUpdateMode.OnPropertyChanged);
        }
    }
}
