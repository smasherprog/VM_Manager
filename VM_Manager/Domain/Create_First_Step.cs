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
    public partial class Create_First_Step : UserControl, VM_Manager.Utilities.MultiStepBase
    {
        private Libvirt.CS_Objects.Host _connection;
        private Model.Virtual_Machine _Machine_Def;
        public Create_First_Step(Libvirt.CS_Objects.Host con, Model.Virtual_Machine d)
        {
            InitializeComponent();
            _connection = con;
            _Machine_Def = d;
        }

        public bool Validate_Control()
        {
            if(string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Name cannot be empty!");
                return false;
            }
            foreach(var item in textBox2.Text)
            {
                if(!Char.IsLetter(item) && item != '_')
                {
                    MessageBox.Show("Name can only contain letters or underscores!");
                    return false;
                }
            }

            using (var pool = _connection.virDomainLookupByName(textBox2.Text))
            {
                if(pool.IsValid)
                {
                    MessageBox.Show("A VM with that name already exists, try another!");
                    return false;
                }
            }
            _Machine_Def.Name = textBox2.Text;
            return true;
        }
        public UserControl Next()
        {
            if(Local_Install.Checked)
            {
                return new Local_Media_Create(_connection, _Machine_Def);
            }
            return null;//NOT IMPLEMENTED YET!!
           
        }
        public bool Execute() { 
            
            return true; 
        }

    }
}
