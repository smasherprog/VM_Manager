using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public Main_Form()
        {
            InitializeComponent();
            _CurrentControl= new General();
            panel1.Controls.Add(_CurrentControl);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                if (listView1.SelectedItems[0].Text == "General" && _CurrentControl.GetType() != typeof(General))
                {
                    panel1.Controls.Clear();
                    _CurrentControl = new General();
                    panel1.Controls.Add(_CurrentControl);
                }
            }
        }
    }
}
