using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VM_Manager.Storage
{
    public partial class Upload_Progress : Form
    {
        private readonly Libvirt.CS_Objects.Storage_Volume _storage_ptr;
        private readonly Libvirt.CS_Objects.Host _connectionptr;
        private readonly string filepath;
        private System.Threading.Thread _uploadthread;
        private bool _keeprunning = false;
        public Upload_Progress(Libvirt.CS_Objects.Host hostptr, Libvirt.CS_Objects.Storage_Volume volptr, string fpath)
        {
            InitializeComponent();
            _storage_ptr = volptr;
            _connectionptr = hostptr;
            filepath = fpath;
            this.FormClosing += Upload_Progress_FormClosing;
        }

        void Upload_Progress_FormClosing(object sender, FormClosingEventArgs e)
        {
            Stop();
        }
        private void Stop()
        {
            if(_uploadthread != null)
            {
                _keeprunning = false;
                _uploadthread.Join(2000);
                _keeprunning = false;
            }
            _uploadthread = null;
        }
        public void Start()
        {

            File_Name_txt.Text = "Uploading: " + filepath;
            _keeprunning = true;
            _uploadthread = new System.Threading.Thread(Run);
            _uploadthread.Start();
        }
        private void Run()
        {
            using (var st = _connectionptr.virStreamNew(Libvirt.virStreamFlags.VIR_STREAM_NONBLOCK))
            {
                using(var localfs = new System.IO.FileStream(filepath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {

                    var stupload = _storage_ptr.virStorageVolUpload(st, 0, (ulong)localfs.Length);
                    long chunksize = 65000;
                    var dat = new byte[chunksize];
                    var totalbytes = localfs.Length;
                    while(totalbytes > 0 && _keeprunning)
                    {
                        var bytestoread = chunksize;
                        if(totalbytes < bytestoread)
                        {
                            bytestoread = totalbytes;
                        }
                        var bread = (uint)localfs.Read(dat, 0, (int)bytestoread);
                        var bytessent = st.virStreamSend(dat, bread);
                        if(bytessent < 0)
                        {
                            st.virStreamAbort();
                            break;//get out!!
                        }
                        totalbytes -= (long)bread;
                        progressBar1.Invoke((MethodInvoker)delegate
                        {
                            progressBar1.Value = (int)((((double)localfs.Length - (double)totalbytes) / (double)localfs.Length)*100.0);
                            progressBar1.Update();
                        });
                    }
                    if(!_keeprunning)
                    {//if it was canceled abort as well
                        st.virStreamAbort();
                    }
                    st.virStreamFinish();
                }
            }
            this.Invoke((MethodInvoker)delegate
            {
                this.Close();//close me now!
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stop();
        }
    }
}
