using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VM_Manager.Storage
{
    public partial class Create_First_Step : UserControl, VM_Manager.Utilities.MultiStepBase
    {
        private Libvirt.CS_Objects.Host _connection;
        public Create_First_Step(Libvirt.CS_Objects.Host con)
        {
            InitializeComponent();
            _connection = con;
        }

        public bool Validate_Control()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Name cannot be empty!");
                return false;
            }
            foreach (var item in textBox1.Text)
            {
                if (!Char.IsLetter(item) && item != '_')
                {
                    MessageBox.Show("Name can only contain letters or underscores!");
                    return false;
                }
            }
            using (var pool = _connection.virStoragePoolLookupByName(textBox1.Text))
            {
                if (pool.IsValid)
                {
                    MessageBox.Show("A pool with that name already exists, try another!");
                    return false;
                }
            }
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("You must selected a Pool Type!");
                return false;
            }
            return true;
        }
        public UserControl Next()
        {

            if (comboBox1.SelectedItem.ToString().Contains("Dir:"))
                return new Dir_Control(_connection, textBox1.Text);
            else if (comboBox1.SelectedItem.ToString().Contains("Netfs:"))
                return new NetFS_Create(_connection, textBox1.Text);
            return null;

        }
        public bool Execute() { return true; }
    }
}
