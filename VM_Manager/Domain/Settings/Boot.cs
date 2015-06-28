using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VM_Manager.Domain.Settings
{
    public partial class Boot : UserControl
    {
        private Libvirt.Models.Concrete.Virtual_Machine _VM;
        public Boot(Libvirt.Models.Concrete.Virtual_Machine vm)
        {
            InitializeComponent();  
            this.Dock = DockStyle.Fill;
            _VM = vm;
            BuildInfo();
    
        }
        void BuildInfo()
        {
          
        }
    }
}
