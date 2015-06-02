using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VM_Manager.Domain
{
    public partial class Add_Domain : Form
    {
        
        private readonly Libvirt.virConnectPtr _connection;
        private UserControl _CurrentControl;
        private int Page = 1;
        private Model.Virtual_Machine _Machine_Def = new Model.Virtual_Machine();
        public Action<Model.Virtual_Machine> OnVM_Create_Attempt;
        public Add_Domain(Libvirt.virConnectPtr con)
        {
            InitializeComponent();
            _connection = con;
            _CurrentControl = new Create_First_Step(_connection, _Machine_Def);
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
                    panel1.Controls.Remove(_CurrentControl);
                    if(next != null)
                    {
                        Page += 1;
                        Step_txt.Text = "Step " + Page.ToString() + " of 5";
                        if(Page >= 5)
                            this.button1.Text = "Finish";
                        _CurrentControl = next;
                        panel1.Controls.Add(_CurrentControl);
                
                    } else
                    {
                        if (OnVM_Create_Attempt != null) OnVM_Create_Attempt(_Machine_Def);
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
