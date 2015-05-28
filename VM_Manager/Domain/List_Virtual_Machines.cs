using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VM_Manager.Domain
{
    public partial class List_Virtual_Machines : UserControl
    {
        private readonly Libvirt.virConnectPtr _connection;
        public List_Virtual_Machines(Libvirt.virConnectPtr con)
        {
            _connection = con;
            InitializeComponent();
            Init_Controls();
        }
        private void Init_Controls()
        {
            listView1.Items.Clear();
            Libvirt.virDomainPtr[] vms;
            Libvirt.API.virConnectListAllDomains(_connection, out vms, Libvirt.virConnectListAllDomainsFlags.VIR_CONNECT_LIST_DOMAINS_ACTIVE | Libvirt.virConnectListAllDomainsFlags.VIR_CONNECT_LIST_DOMAINS_INACTIVE);
            foreach(var item in vms)
            {
                Libvirt.API.virDomainGetName(item);
                Libvirt._virDomainInfo info;
                Libvirt.API.virDomainGetInfo(item, out info);

                System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] { "", Libvirt.API.virDomainGetName(item), info.state.ToString() }, info.state == Libvirt.virDomainState.VIR_DOMAIN_RUNNING ? 1 : 0);
                listView1.Items.Add(listViewItem1);
                item.Dispose();
            }

        }
    }
}
