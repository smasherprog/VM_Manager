using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VM_Manager.Utilities;

namespace VM_Manager.Storage
{
    public partial class NetFS_Create : UserControl, Dialog_Helper
    {
        private Libvirt.CS_Objects.Host _connection;
        private string _poolname;
        public NetFS_Create(Libvirt.CS_Objects.Host con, string name)
        {
            InitializeComponent();
            _connection = con;
            _poolname = name;
        }
        public UserControl Forward()
        {
            return null;
        }
        public UserControl Back()
        {
            return null;
        }
        public bool Validate_Control()
        {
            if (string.IsNullOrWhiteSpace(Target_Path_txt_bx.Text))
            {
                MessageBox.Show("Name cannot be empty!");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Host_Name_txt_bx.Text))
            {
                MessageBox.Show("Host Name cannot be empty!");
                return false;
            }
            var pingSender = new System.Net.NetworkInformation.Ping();
            try
            {
                var reply = pingSender.Send(Host_Name_txt_bx.Text, 2000);
                if (reply.Status != System.Net.NetworkInformation.IPStatus.Success)
                {
                    MessageBox.Show("Host is not reachable", "Host Does not Exist");
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Host Does not Exist");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Source_Path_txt_bx.Text))
            {
                MessageBox.Show("Source cannot be empty!");
                return false;
            }
            if (Format_drp_dwn.SelectedItem == null)
            {
                MessageBox.Show("Format cannot be empty!");
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
            var stpool = "<pool type=\"netfs\"><name>" + _poolname + "</name>";
            stpool += "<source><host name='" + Host_Name_txt_bx.Text + "'/><dir path='" + Source_Path_txt_bx.Text + "'/><format type='" + Format_drp_dwn.SelectedItem.ToString() + "'/></source>";
            stpool += "<target><path>" + Target_Path_txt_bx.Text + "</path></target></pool>";
            using (var pooldef = _connection.virStoragePoolDefineXML(stpool))
            {
                var suc = pooldef.virStoragePoolBuild(Libvirt.virStoragePoolBuildFlags.VIR_STORAGE_POOL_BUILD_NEW);
                suc = pooldef.virStoragePoolCreate();

                if (suc == 0)
                {
                    pooldef.virStoragePoolSetAutostart(1);
                    MessageBox.Show("Successfully Created Pool");
                    return true;
                }
                else
                {
                    MessageBox.Show("Failed to Created the Pool");
                    return false;
                }

            }

        }
    }
}
