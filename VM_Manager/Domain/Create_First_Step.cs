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
        private Libvirt.virConnectPtr _connection;
        public Create_First_Step(Libvirt.virConnectPtr con)
        {
            InitializeComponent();
            _connection = con;
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
        
            using(var pool = Libvirt.API.virDomainLookupByName(_connection, textBox2.Text))
            {
                if(pool.Pointer != IntPtr.Zero)
                {
                    MessageBox.Show("A VM with that name already exists, try another!");
                    return false;
                }
            }
            return true;
        }
        public UserControl Next()
        {
            return null;//NOT IMPLEMENTED YET!!
           
        }
        public bool Execute() { return true; }
    }
}
