using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VM_Manager.Storage
{
    public partial class Add_Storage_Volume : Form
    {
        private readonly Libvirt.CS_Objects.Storage_Pool _PoolPtr;
        private readonly Libvirt.CS_Objects.Host _connectionptr;
        private Libvirt.virStreamSourceFunc _ReaderCallback;
        public Action<string, bool> OnPool_Create_Attempt;

        public Add_Storage_Volume(Libvirt.CS_Objects.Storage_Pool ptr, Libvirt.CS_Objects.Host conptr)
        {
            _PoolPtr = ptr;
            _connectionptr = conptr;
            InitializeComponent();

            Libvirt._virStoragePoolInfo info;
            ptr.virStoragePoolGetInfo(out info);
            Max_Capacity_Numeric.Maximum = info.available / 1000000;//convert to Megabytes
            Max_Capacity_Numeric.Minimum = 100;
            Allocation_Numeric.Maximum = info.available / 1000000;//convert to Megabytes
            Allocation_Numeric.Minimum = 0;
            _ReaderCallback = Read_CB;
            AvailSpaceLabel.Text = ptr.virStoragePoolGetName() + "'s available space: " + VM_Manager.Utilities.Formatting.Format((long)info.available);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Name cannot be empty!");
                return;
            }
            foreach(var item in textBox1.Text)
            {
                if(!Char.IsLetter(item) && item != '_')
                {
                    MessageBox.Show("Name can only contain letters or underscores!");
                    return;
                }
            }
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("You must select a format!");
                return;
            }
            if(string.IsNullOrWhiteSpace(comboBox1.SelectedItem.ToString()))
            {
                MessageBox.Show("You must select a format!");
                return;
            }
            var finalname = textBox1.Text + ".img";
            var allocunit = "MB";
            var alloc_space = (long)Allocation_Numeric.Value;
            var max_capacity = (long)Max_Capacity_Numeric.Value;
            var alloctype = comboBox1.SelectedItem.ToString();
            if(comboBox1.SelectedItem.ToString() == "iso")
            {
                finalname = textBox1.Text + ".iso";
                alloctype = "raw";
                try
                {
                    var fileinfo = new System.IO.FileInfo(iso_filepath_txt.Text);
                    max_capacity = alloc_space = fileinfo.Length;
                    allocunit = "B";
                } catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }


            var volstring = "<volume type='file'><name>" + finalname + "</name><allocation unit='" + allocunit + "'>" + (alloc_space).ToString() + "</allocation>";
            volstring += "<capacity unit='" + allocunit + "'>" + (max_capacity).ToString() + "</capacity>";
            volstring += "<target><format type='" + alloctype + "'/></target></volume>";

            using (var storagevol = _PoolPtr.virStorageVolCreateXML(volstring, Libvirt.virStorageVolCreateFlags.VIR_DEFAULT))
            {
                if(storagevol.IsValid)
                {
                  
                    if(comboBox1.SelectedItem.ToString() == "iso")
                    {
                        var uploaddiag = new Upload_Progress(_connectionptr, storagevol, iso_filepath_txt.Text);
                        uploaddiag.Start();
                        uploaddiag.ShowDialog();
                        OnPool_Create_Attempt(finalname, true);
                        MessageBox.Show("Successfully uploaded the ISO and created the Volume!");
                    } else
                    {
                        OnPool_Create_Attempt(finalname, true);
                        MessageBox.Show("Successfully created Volume!");
                    }
                    this.Close();
                } else
                {
                    OnPool_Create_Attempt(finalname, false);
                    MessageBox.Show("Failed to create the Volume!");
                }
            }
        }
        private int Read_CB(Libvirt.virStreamPtr st, IntPtr data, uint nbytes, IntPtr @opaque)
        {
            return 0;
            //var remainingbytes = fstream.Length - fstream.Position;
            //if(remainingbytes < nbytes)
            //    nbytes = (uint)remainingbytes;
            //var dat = new byte[nbytes];
            //var bread = fstream.Read(dat, 0, (int)nbytes);
            //System.Runtime.InteropServices.Marshal.Copy(dat, 0, data, bread);
            //Debug.WriteLine("returning  " + bread);
            //return bread;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            iso_filepath_txt.Text = "";
            if(comboBox1.SelectedItem.ToString() == "iso")
            {
                Max_Capacity_Numeric.Enabled = Allocation_Numeric.Enabled = false;
                filebrowse_btn.Visible = true;
                filextension.Text = ".iso";
            } else
            {
                Max_Capacity_Numeric.Enabled = Allocation_Numeric.Enabled = true;
                filebrowse_btn.Visible = false;
                filextension.Text = ".img";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                iso_filepath_txt.Text = openFileDialog1.FileName;
            }
        }
    }
}
