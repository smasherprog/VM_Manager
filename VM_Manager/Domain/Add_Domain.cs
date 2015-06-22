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

        private readonly Libvirt.CS_Objects.Host _connection;
        private UserControl _CurrentControl;
        private int Page = 1;
        private Libvirt.Models.Concrete.Virtual_Machine _Machine_Def = new Libvirt.Models.Concrete.Virtual_Machine();
        public Action<Libvirt.Models.Concrete.Virtual_Machine> OnVM_Create_Attempt;
        public Add_Domain(Libvirt.CS_Objects.Host con)
        {
            InitializeComponent();
            _connection = con;
            _CurrentControl = new Create_First_Step(new VM_Manager.Utilities.End_Control(), _connection, _Machine_Def);
            panel1.Controls.Add(_CurrentControl);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var contr = _CurrentControl as VM_Manager.Utilities.Dialog_Helper;
            if (contr != null)
            {
                var next = contr.Forward();
                if (next != null)
                {
                    if (next.GetType() == typeof(VM_Manager.Utilities.End_Control))
                    {//reached the end.. close dialog
                        if (OnVM_Create_Attempt != null) OnVM_Create_Attempt(_Machine_Def);
                        this.Close();//all done
                    }
                    else
                    {
                        panel1.Controls.Remove(_CurrentControl);
                        Page += 1;
                        Step_txt.Text = "Step " + Page.ToString() + " of 5";
                        if (Page >= 5)
                            this.button1.Text = "Finish";
                        _CurrentControl = next;
                        panel1.Controls.Add(_CurrentControl);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var contr = _CurrentControl as VM_Manager.Utilities.Dialog_Helper;
            if (contr != null)
            {
                var next = contr.Back();
                if (next != null)
                {
                    if (next.GetType() != typeof(VM_Manager.Utilities.End_Control))
                    {
                        panel1.Controls.Remove(_CurrentControl);
                        Page -= 1;
                        Step_txt.Text = "Step " + Page.ToString() + " of 5";
                        if (Page < 5)
                            this.button1.Text = "Forward";
                        _CurrentControl = next;
                        panel1.Controls.Add(_CurrentControl);
                    }
                }
            }
        }

    }
}
