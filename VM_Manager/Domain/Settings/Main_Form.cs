using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VM_Manager.Domain.Settings
{
    public partial class Main_Form : Form
    {
        private UserControl _CurrentControl = null;
        private Libvirt.Models.Concrete.Virtual_Machine _VM;
        public Main_Form(Libvirt.CS_Objects.Host h, string domainname)
        {
            InitializeComponent();         
            using (var item = h.virDomainLookupByName(domainname))
            {
                if (!item.IsValid)
                {
                    MessageBox.Show("Could not find the VM, Try refreshing the VM list.");
                    this.Close();
                }
                else
                {
                    var xmldesc = item.virDomainGetXMLDesc(Libvirt.virDomainXMLFlags.VIR_DEFAULT);
                    _VM = new Libvirt.Models.Concrete.Virtual_Machine();
                    var d = System.Xml.Linq.XDocument.Parse(xmldesc);
                    _VM.From_XML(d.Root);
                    
                }
            }
            _CurrentControl = new Overview(_VM);
            panel1.Controls.Add(_CurrentControl);
       
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                if (listView1.SelectedItems[0].Text == "Overview" && _CurrentControl.GetType() != typeof(Overview))
                {
                    panel1.Controls.Clear();
                    _CurrentControl = new Overview(_VM);
                    panel1.Controls.Add(_CurrentControl);
                }
                else if (listView1.SelectedItems[0].Text == "Boot" && _CurrentControl.GetType() != typeof(Boot))
                {
                    panel1.Controls.Clear();
                    _CurrentControl = new Boot(_VM);
                    panel1.Controls.Add(_CurrentControl);
                }
                else if (listView1.SelectedItems[0].Text == "Processor" && _CurrentControl.GetType() != typeof(Processor))
                {
                    panel1.Controls.Clear();
                    _CurrentControl = new Processor(_VM);
                    panel1.Controls.Add(_CurrentControl);
                }
            }
        }
    }
}