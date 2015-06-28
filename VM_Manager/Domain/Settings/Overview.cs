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
    public partial class Overview : UserControl
    {
        private Libvirt.Models.Concrete.Virtual_Machine _VM;
        public Overview(Libvirt.Models.Concrete.Virtual_Machine vm)
        {
            InitializeComponent();  
            this.Dock = DockStyle.Fill;
            _VM = vm;
            BuildInfo();
    
        }
        void BuildInfo()
        {
            name_txtbx.Text = _VM.Metadata.name;
            uuid_lbl.Text = _VM.Metadata.uuid;
            title_txtbx.Text = _VM.Metadata.title;
            description_txtbx.Text = _VM.Metadata.description;
        }
    }
}
