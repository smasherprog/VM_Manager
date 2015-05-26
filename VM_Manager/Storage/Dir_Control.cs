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
    public partial class Dir_Control : UserControl, VM_Manager.Utilities.MultiStepBase
    {
        private Libvirt.virConnectPtr _connection;
        private string _poolname;
        public Dir_Control(Libvirt.virConnectPtr con, string name)
        {
            InitializeComponent();
            _connection = con;
            _poolname = name;
        }

        public bool Validate_Control()
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Name cannot be empty!");
                return false;
            }
            return true;
        }
        public UserControl Next()
        {
            return null;//all done!
        }
        public bool Execute()
        {
            var stpool = "<pool type=\"dir\"><name>" + _poolname + "</name><target><path>" + textBox1.Text + "</path></target></pool>";
            using(var pooldef = Libvirt.API.virStoragePoolDefineXML(_connection, stpool))
            {
                var suc = Libvirt.API.virStoragePoolBuild(pooldef, Libvirt.virStoragePoolBuildFlags.VIR_STORAGE_POOL_BUILD_NEW);
                suc = Libvirt.API.virStoragePoolCreate(pooldef);

                if(suc == 0)
                {
                    Libvirt.API.virStoragePoolSetAutostart(pooldef, 1);
                    MessageBox.Show("Successfully Created Pool");
                    return true;
                } else
                {
                    MessageBox.Show("Failed to Created the Pool");
                    return false;
                }

            }

        }
    }
}
