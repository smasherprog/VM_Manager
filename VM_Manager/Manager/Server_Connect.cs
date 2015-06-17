using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Data.Linq;

namespace VM_Manager.Manager
{
    public partial class Server_Connect : Form
    {
        private Libvirt.virConnectAuthCallback _authcallback;
        public Action<Libvirt.CS_Objects.Host> On_NewServerConnect_CB;
        public Server_Connect()
        {
            InitializeComponent();
            _authcallback = virConnectAuthCallback;
        }

        private int virConnectAuthCallback(ref Libvirt._virConnectCredential[] cred, uint ncred, IntPtr cbdata)
        {
            for (int i = 0; i < ncred; i++)
            {
                switch (cred[i].type)
                {
                    case Libvirt.virConnectCredentialType.VIR_CRED_AUTHNAME:
                        // Fill the user name
                        Console.WriteLine("VIR_CRED_AUTHNAME");
                        break;
                    case Libvirt.virConnectCredentialType.VIR_CRED_PASSPHRASE:
                        // Fill the password
                        Console.WriteLine("VIR_CRED_PASSPHRASE");
                        break;
                    default:
                        return -1;
                }
            }
            return 0;
        }
        private async void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(comboBox1.SelectedItem as string) || string.IsNullOrWhiteSpace(comboBox2.SelectedItem as string) || string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("You must select the URI parts and complete the host text box");
                    return;
                }
                var authstrcut = new Libvirt._virConnectAuth();
                authstrcut.cbdata = IntPtr.Zero;
                authstrcut.credtype = new Libvirt.virConnectCredentialType[] {
                        Libvirt.virConnectCredentialType.VIR_CRED_AUTHNAME, 
                        Libvirt.virConnectCredentialType.VIR_CRED_PASSPHRASE
                    };
                authstrcut.ncredtype = 4 * authstrcut.credtype.Length;
                authstrcut.cb = _authcallback;
                var connecturi = (comboBox1.SelectedItem as string) + "+" + (comboBox2.SelectedItem as string) + "://" + textBox1.Text;
                Console.WriteLine("Connecting to . . : '" + connecturi);

                //if (!string.IsNullOrWhiteSpace(Login_txt_bx.Text) || !string.IsNullOrWhiteSpace(Password_txt_bx.Text))
                //{
                //    //https://www.webvirtmgr.net/docs/ shows how to set up a login/password authentication...
                //    if (!string.IsNullOrWhiteSpace(Login_txt_bx.Text) && !string.IsNullOrWhiteSpace(Password_txt_bx.Text))
                //    {
                //        var _connection = await Libvirt.CS_Objects.Host.virConnectOpenAuth(connecturi, authstrcut, Libvirt.virConnectFlags.VIR_DEFAULT);
                //        if (_connection.IsValid && On_NewServerConnect_CB != null)
                //        {
                //            On_NewServerConnect_CB(_connection);
                //            this.Close();
                //        }
                //        else
                //        {
                //            _connection.Dispose();
                //            MessageBox.Show("Unable to connect!");
                //        }
                //    }
                //    else MessageBox.Show("You must enter a login and password!");
                //}
                //else
                // {
                //use anonymous connection
                // http://pineapplesoftware.blogspot.com/2012/11/configuring-unsecure-remote-access-to.html shows how to set up an anonymous connection --THIS IS UNSECURE, but good to get started!
                var _connection = await Libvirt.CS_Objects.Host.virConnectOpen(connecturi);
                if (_connection.IsValid && On_NewServerConnect_CB != null)
                {
                    On_NewServerConnect_CB(_connection);
                    this.Close();
                }
                else
                {
                    _connection.Dispose();
                    MessageBox.Show("Unable to connect!");
                }
                // }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to connect!");
            }

        }
    }
}
