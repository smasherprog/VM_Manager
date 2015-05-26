using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VM_Manager.Storage
{
    public partial class Add_Storage_Pool : Form
    {
        private Libvirt.virConnectPtr _connection;
        private UserControl _CurrentControl;
        public Add_Storage_Pool(Libvirt.virConnectPtr con)
        {
            InitializeComponent();
            _connection = con;
            _CurrentControl = new Create_First_Step(_connection);
            panel1.Controls.Add(_CurrentControl);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var contr = _CurrentControl as VM_Manager.Utilities.MultiStepBase;
            if(contr != null && contr.Validate_Control())
            {
                if(contr.Execute())
                {
                    var next = contr.Next();
                    this.button1.Text = "Finish";
                    panel1.Controls.Remove(_CurrentControl);
                    if(next != null)
                    {
                        _CurrentControl = next;
                        panel1.Controls.Add(_CurrentControl);
                    } else
                    {
                        this.Close();//all done
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
