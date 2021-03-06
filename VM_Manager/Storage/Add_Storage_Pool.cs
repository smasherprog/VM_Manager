﻿using System;
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
        private readonly Libvirt.CS_Objects.Host _connection;
        private UserControl _CurrentControl;
        public Add_Storage_Pool(Libvirt.CS_Objects.Host con)
        {
            InitializeComponent();
            _connection = con;
            _CurrentControl = new Create_First_Step(_connection);
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
                        this.Close();//all done
                    }
                    else
                    {
                        panel1.Controls.Remove(_CurrentControl);
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
                        this.button1.Text = "Forward";
                        _CurrentControl = next;
                        panel1.Controls.Add(_CurrentControl);
                    }
                }
            }
        }
    }
}
