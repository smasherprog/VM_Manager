﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Data.Linq;

namespace VM_Manager
{


    public partial class Host_List : Form
    {
        private Libvirt.virConnectAuthCallback _authcallback;
        private Libvirt.virConnectPtr _connection;
        public Host_List()
        {
            InitializeComponent();
            _authcallback = virConnectAuthCallback;
            this.FormClosing += Form1_FormClosing;
        }

        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _connection.Dispose();
        }

        private int virConnectAuthCallback(ref Libvirt._virConnectCredential[] cred, uint ncred, IntPtr cbdata)
        {
            for(int i = 0; i < ncred; i++)
            {
                switch(cred[i].type)
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
        private void btnConnect_Click(object sender, EventArgs e)
        {
            var authstrcut = new Libvirt._virConnectAuth();
            authstrcut.cbdata = IntPtr.Zero;
            authstrcut.credtype = new Libvirt.virConnectCredentialType[] {
                    Libvirt.virConnectCredentialType.VIR_CRED_AUTHNAME, 
                    Libvirt.virConnectCredentialType.VIR_CRED_PASSPHRASE
                };
            authstrcut.ncredtype = 4 * authstrcut.credtype.Length;
            authstrcut.cb = _authcallback;
            Console.WriteLine("Connecting to . . : '" + textBox1.Text);
            _connection = Libvirt.API.virConnectOpen(textBox1.Text);

            if(_connection.Pointer != IntPtr.Zero)
            {
                button1.Enabled = true;
                Console.WriteLine("Connected!");
            } else
            {
                button1.Enabled = false;
                Console.WriteLine("Unable to connect!");
            }

            string[] names;

            Libvirt.API.virConnectListDefinedDomains(_connection, out names, 10);
            foreach(var item in names)
            {
                Console.WriteLine(item);
            }
            int[] domainids;
            Libvirt.API.virConnectListDomains(_connection, out domainids, 10);
            foreach(var item in domainids)
            {
                using(var domainptr = Libvirt.API.virDomainLookupByID(_connection, item))
                {
                    if(domainptr.Pointer != IntPtr.Zero)
                    {
                        string domainName = Libvirt.API.virDomainGetName(domainptr);
                        Console.WriteLine("Domain Name: '" + domainName + "', ID: " + item);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new Connection_Details(_connection);
            f.Show();
        }

    }
}
