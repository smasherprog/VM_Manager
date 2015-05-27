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
        private readonly Libvirt.virStoragePoolPtr _PoolPtr;
        private readonly Libvirt.virConnectPtr _connectionptr;
        private Libvirt.virStreamSourceFunc _ReaderCallback;


        public Add_Storage_Volume(Libvirt.virStoragePoolPtr ptr, Libvirt.virConnectPtr conptr)
        {
            _PoolPtr = ptr;
            _connectionptr = conptr;
            InitializeComponent();

            Libvirt._virStoragePoolInfo info;
            Libvirt.API.virStoragePoolGetInfo(ptr, out info);
            Max_Capacity_Numeric.Maximum = info.available / 1000000;//convert to Megabytes
            Max_Capacity_Numeric.Minimum = 100;
            Allocation_Numeric.Maximum = info.available / 1000000;//convert to Megabytes
            Allocation_Numeric.Minimum = 0;
            _ReaderCallback = Read_CB;
            AvailSpaceLabel.Text = Libvirt.API.virStoragePoolGetName(ptr) + "'s available space: " + VM_Manager.Utilities.Formatting.Format((long)info.available);
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
                ////ISO NOT DONE YET....
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

            using(var storagevol = Libvirt.API.virStorageVolCreateXML(_PoolPtr, volstring, Libvirt.virStorageVolCreateFlags.VIR_STORAGE_VOL_CREATE_DEFAULT))
            {
                if(storagevol.Pointer != IntPtr.Zero)
                {
                    MessageBox.Show("Successfully created Volume!");
                    if(comboBox1.SelectedItem.ToString() == "iso")
                    {
                        using(var st = Libvirt.API.virStreamNew(_connectionptr, Libvirt.virStreamFlags.VIR_STREAM_NONBLOCK))
                        {
                            using(var localfs = new System.IO.FileStream(iso_filepath_txt.Text, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                            {
                                long chunksize = 65000;
                                var dat = new byte[chunksize];
                                var totalbytes = localfs.Length;
                                while(totalbytes > 0)
                                {
                                    var bytestoread = chunksize;
                                    if(totalbytes < bytestoread)
                                    {
                                        bytestoread = totalbytes;
                                    }
                                    var bread = (uint)localfs.Read(dat, 0, (int)bytestoread);
                                    var bytessent= Libvirt.API.virStreamSend(st, dat, bread);
                                    Debug.WriteLine("bytes readyfomdisk " + bread + "   bytes sent " + bytessent);
                                    totalbytes -= bread;
                                }

                                Libvirt.API.virStreamFinish(st);
                            }
                        }
                    }
                    this.Close();
                } else
                {
                    MessageBox.Show("Failed to create the Volume!");
                }
            }
        }
        //NEEED TO FIX OVERFLOW ERROR BELOW FOR FILES LARGER THAN 32 bits
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
