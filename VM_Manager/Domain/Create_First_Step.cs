using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VM_Manager.Utilities;

namespace VM_Manager.Domain
{
    public partial class Create_First_Step : UserControl, Dialog_Helper
    {
        private View_Model_To_Service _Create_First_Step_Model;
        private UserControl _Previous;
        public Create_First_Step(UserControl p, Libvirt.CS_Objects.Host con, Libvirt.Models.Concrete.Virtual_Machine d)
        {
            InitializeComponent(); 
            this.Dock = DockStyle.Fill;
            _Previous = p;
            _Create_First_Step_Model = new Create_First_Step_Model(con, d);
            textBox2.DataBindings.Add(
                Safe_Property.GetPropertyInfo(textBox2, a => a.Text).Name,
                d.Metadata,
                Safe_Property.GetPropertyInfo(d.Metadata, a => a.name).Name, false, DataSourceUpdateMode.OnPropertyChanged);



        }
        public UserControl Forward()
        {
            if (_Create_First_Step_Model.Validate())
            {
                if (Local_Install.Checked)
                {
                    return new Local_Media_Create(this, _Create_First_Step_Model.Connection, _Create_First_Step_Model.Machine_Definition);
                }
            }
            else
            {
                foreach(var item in _Create_First_Step_Model.Errors){
                    foreach(var r in item.Value){
                        errorProvider1.SetError(textBox2, r);
                    }
                }
            }
            return null;
        }
        public UserControl Back()
        {
            return _Previous;
        }
    }
}
