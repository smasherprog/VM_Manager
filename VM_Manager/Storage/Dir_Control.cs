﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VM_Manager.Storage
{
    public partial class Dir_Control : UserControl, VM_Manager.Utilities.Dialog_Helper
    {
        private Libvirt.CS_Objects.Host _connection;
        private string _poolname;
        public Dir_Control(Libvirt.CS_Objects.Host con, string name)
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
            var model = new Libvirt.Models.Concrete.Storage_Pool();
            model.name = _poolname;
            var obj = new Libvirt.Models.Concrete.Storage_Pool_Dir();
            obj.target_path = textBox1.Text;
            model.Storage_Pool_Item = obj;

            using (var pooldef = _connection.virStoragePoolDefineXML(model))
            {
                var suc = pooldef.virStoragePoolBuild(Libvirt.virStoragePoolBuildFlags.VIR_STORAGE_POOL_BUILD_NEW);
                suc = pooldef.virStoragePoolCreate();

                if(suc == 0)
                {
                    pooldef.virStoragePoolSetAutostart(1);
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
