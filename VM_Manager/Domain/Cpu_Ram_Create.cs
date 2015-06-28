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
    public partial class Cpu_Ram_Create : UserControl, Dialog_Helper
    {
        private View_Model_To_Service _Local_Media_Create_Model;
        private UserControl _Previous;
        public Cpu_Ram_Create(UserControl p, Libvirt.CS_Objects.Host con, Libvirt.Models.Concrete.Virtual_Machine d)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            _Previous = p;
            _Local_Media_Create_Model = new Cpu_Ram_Create_Model(con, d);
            UpdateControls();    
            
            Memory_num.DataBindings.Add(
                Safe_Property.GetPropertyInfo(Memory_num, a => a.Value).Name,
                d.Memory,
                Safe_Property.GetPropertyInfo(d.Memory, a => a.memory).Name, false, DataSourceUpdateMode.OnPropertyChanged);
            CPU_num.DataBindings.Add(
                Safe_Property.GetPropertyInfo(CPU_num, a => a.Value).Name,
                d.CPU,
                Safe_Property.GetPropertyInfo(d.CPU, a => a.vCpu_Count).Name, false, DataSourceUpdateMode.OnPropertyChanged);
        }
        public UserControl Forward()
        {
            if (_Local_Media_Create_Model.Validate())
            {
                return new Storage_Create(this, _Local_Media_Create_Model.Connection, _Local_Media_Create_Model.Machine_Definition);
            }
            else
            {
                foreach (var item in _Local_Media_Create_Model.Errors)
                {
                    Control c = null;
                    if (item.Key.ToLower().Contains("memory")) c = Memory_num;
                    if (item.Key.ToLower().Contains("cpu")) c = CPU_num;
                    if (c != null)
                    {
                        foreach (var r in item.Value)
                        {
                            errorProvider1.SetError(c, r);
                        }
                    }
                }
            }
            return null;
        }
        public UserControl Back()
        {
            return _Previous;
        }
        private void UpdateControls()
        {
            Libvirt._virNodeInfo info;
            _Local_Media_Create_Model.Connection.virNodeGetInfo(out info);
            Memory_num.Maximum = info.memory;
            Available_Memory_txt.Text = "Up to " + (info.memory / 1024).ToString() + " MB available on the host";
            CPU_num.Maximum = info.cpus;
            Available_CPUs_txt.Text = "Up to " + info.cpus + " available on the host";
        }

    }
}
