using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VM_Manager.Manager
{
    public partial class VM_Manager_Main : Form
    {
        private List<Libvirt.CS_Objects.Host> _Connections = new List<Libvirt.CS_Objects.Host>();
        private VM_Manager.Utilities.Libvirt_EventLoop _Libvirt_EventLoop;
        private Libvirt.virErrorFunc _ErrorFunc;

        public VM_Manager_Main()
        {
            InitializeComponent();
            _Libvirt_EventLoop = new Utilities.Libvirt_EventLoop();
            _ErrorFunc = virErrorFunc;
            this.FormClosing += VM_Manager_Main_FormClosing;
        }
        void virErrorFunc(IntPtr userData, Libvirt.virErrorPtr error)
        {
            var realerror = Libvirt.API.MarshalErrorPtr(error);
            Debug.WriteLine(realerror.message);
        }

        void VM_Manager_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_Libvirt_EventLoop != null) _Libvirt_EventLoop.Dispose();
            _Libvirt_EventLoop = null;
            foreach (var item in _Connections)
            {
                try
                {
                    item.Dispose();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            _Connections.Clear();
        }
        private void ClearPanel()
        {
            foreach (UserControl item in panel1.Controls)
            {
                item.Dispose();
            }
            panel1.Controls.Clear();
        }
        private void treeView1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            TreeNode node = treeView1.GetNodeAt(p);
            treeView1.SelectedNode = node;
            Libvirt.CS_Objects.Host con = null;
            if (treeView1.SelectedNode != null)
            {
                con = treeView1.SelectedNode.Tag as Libvirt.CS_Objects.Host;
            }
            if (e.Button == MouseButtons.Right)
            {
                if (node != null)
                {
                    if (node.Text == "VM-Manager")
                    {
                        VM_Manager_ContextStrip.Show(treeView1, p);
                    }
                    else if (node.Name == "VM_Server")
                    {
                        VM_Server_ContextStrip.Show(treeView1, p);
                    }
                    else if (node.Name == "Pool" && con != null)
                    {
                        using (var item = con.virStoragePoolLookupByName(node.Text))
                        {
                            Libvirt._virStoragePoolInfo info;
                            item.virStoragePoolGetInfo(out info);
                            if (info.state == Libvirt.virStoragePoolState.VIR_STORAGE_POOL_RUNNING)
                            {
                                newVolumeToolStripMenuItem.Enabled = true;
                                startToolStripMenuItem1.Enabled = false;
                                stopToolStripMenuItem.Enabled = true;
                                deleteToolStripMenuItem1.Enabled = false;
                            }
                            else
                            {
                                newVolumeToolStripMenuItem.Enabled = false;
                                startToolStripMenuItem1.Enabled = true;
                                stopToolStripMenuItem.Enabled = false;
                                deleteToolStripMenuItem1.Enabled = true;
                            }
                            Pool_Contet_MenuStrip.Show(treeView1, p);
                        }

                    }
                    else if (node.Name == "Pool_List")
                    {
                        Pool_Listing_Context.Show(treeView1, p);
                    }
                    else if (node.Name == "VM_List")
                    {
                        VM_Listing_Context.Show(treeView1, p);
                    }
                    else if (node.Name == "VM" && con != null)
                    {
                        using (var item = con.virDomainLookupByName(node.Text))
                        {
                            Libvirt._virDomainInfo info;
                            item.virDomainGetInfo(out info);

                            if (info.state == Libvirt.virDomainState.VIR_DOMAIN_RUNNING)
                            {
                                startToolStripMenuItem.Enabled = false;
                                stopToolStripMenuItem1.Enabled = true;
                                deleteToolStripMenuItem.Enabled = false;
                                connectToolStripMenuItem.Enabled = true;
                            }
                            else
                            {
                                startToolStripMenuItem.Enabled = true;
                                stopToolStripMenuItem1.Enabled = false;
                                deleteToolStripMenuItem.Enabled = true;
                                connectToolStripMenuItem.Enabled = false;
                            }
                            VM_Context_Strip.Show(treeView1, p);
                        }
                        moveToolStripMenuItem.DropDownItems.Clear();
                        var listdropitems = new List<ToolStripItem>();
                        int counter = 0;
                        foreach (var server in _Connections.Where(a => a != con))
                        {
                            var drp = new System.Windows.Forms.ToolStripMenuItem();

                            drp.Image = global::VM_Manager.Properties.Resources.forward;
                            drp.Name = "MoveVmToServer" + (counter++).ToString();
                            drp.Size = new System.Drawing.Size(152, 22);
                            drp.Text = server.virConnectGetHostname();
                            drp.Tag = server;//destination server
                            drp.Visible = true;
                            drp.ToolTipText = "This will migrate a VM from its current Host to the Selected Host";
                            drp.Click += new System.EventHandler(this.migrateStripMenuItem_Click);
                            listdropitems.Add(drp);

                        }
                        if (listdropitems.Any())
                        {
                            moveToolStripMenuItem.DropDownItems.AddRange(listdropitems.ToArray());
                            moveToolStripMenuItem.Invalidate();
                        }
                    }
                }
            }



            if (node != null)
            {
                if (node.Text == "VM-Manager")
                {
                    panel1.Controls.Add(new Server_Listing());
                }
                else if (node.Name == "VM")
                {
                    panel1.Controls.Add(new Server_Listing());
                }
                else if (node.Name == "Pool" && con != null)
                {
                    var panelcontrol = panel1.Controls.OfType<Storage.Storage_Pool_Listing>();
                    if (panelcontrol.Any())
                    {
                        panelcontrol.FirstOrDefault().Refresh(con, node.Text);
                    }
                    else
                    {
                        ClearPanel();
                        panel1.Controls.Add(new Storage.Storage_Pool_Listing(con, node.Text));
                    }
                }
            }


        }

        private void migrateStripMenuItem_Click(object sender, EventArgs e)
        {
            var obj = sender as System.Windows.Forms.ToolStripMenuItem;
            Libvirt.CS_Objects.Host source = null;

            string vmname = "";
            if (treeView1.SelectedNode != null)
            {
                source = treeView1.SelectedNode.Tag as Libvirt.CS_Objects.Host;
                if (source != null) vmname = treeView1.SelectedNode.Text;
            }
            else return;
            if (source == null) return;


            var destination = obj.Tag as Libvirt.CS_Objects.Host;
            if (destination == null) return;

            using (var sourcevm = source.virDomainLookupByName(vmname))
            {
                if (sourcevm.IsValid)
                {
                    Libvirt._virDomainInfo stats;
                    sourcevm.virDomainGetInfo(out stats);

                    var flags = Libvirt.virDomainMigrateFlags.VIR_MIGRATE_ABORT_ON_ERROR |
                    Libvirt.virDomainMigrateFlags.VIR_MIGRATE_UNDEFINE_SOURCE |
                    Libvirt.virDomainMigrateFlags.VIR_MIGRATE_PEER2PEER |
                    Libvirt.virDomainMigrateFlags.VIR_MIGRATE_TUNNELLED;

                    if (stats.state == Libvirt.virDomainState.VIR_DOMAIN_RUNNING || stats.state == Libvirt.virDomainState.VIR_DOMAIN_PAUSED)
                    {
                        flags |= Libvirt.virDomainMigrateFlags.VIR_MIGRATE_LIVE;
                    }
                    else
                    {

                    }

                    using (var destvm = sourcevm.virDomainMigrate(destination, flags, null, null, 0))
                    {
                        if (destvm.IsValid)
                        {
                            MessageBox.Show("Migration Successfull!!");
                        }
                        else
                        {
                            MessageBox.Show("Migration FAILED!!");
                        }

                    }
                }
            }
        }
        private void PopulatePools(TreeNode parent, Libvirt.CS_Objects.Host ptr, bool force_refresh = false)
        {
            Libvirt.CS_Objects.Storage_Pool[] pools;
            ptr.virConnectListAllStoragePools(out pools, Libvirt.virConnectListAllStoragePoolsFlags.VIR_CONNECT_LIST_STORAGE_POOLS_ACTIVE | Libvirt.virConnectListAllStoragePoolsFlags.VIR_CONNECT_LIST_STORAGE_POOLS_INACTIVE);

            foreach (var item in pools)
            {
                if (force_refresh)
                {
                    item.virStoragePoolRefresh();
                 
                }
                var poolnode = new TreeNode(item.virStoragePoolGetName(), 3, 3);
                poolnode.Name = "Pool";
                poolnode.Tag = ptr;
                parent.Nodes.Add(poolnode);
                PopulateVolumes(poolnode, item);
                item.Dispose();
            }
        }
        private void PopulateVolumes(TreeNode parent, Libvirt.CS_Objects.Storage_Pool ptr)
        {
            Libvirt.CS_Objects.Storage_Volume[] volumes;
            if (ptr.virStoragePoolListAllVolumes(out volumes) > 0)
            {
                foreach (var vol in volumes)
                {
                    var volname = vol.virStorageVolGetName();
                    TreeNode volnode = null;
                    if (volname.ToLower().EndsWith(".iso")) volnode = new TreeNode(volname, 6, 6);
                    else volnode = new TreeNode(volname, 2, 2);
                    volnode.Name = "vol";
                    volnode.Tag = ptr;
                    parent.Nodes.Add(volnode);
                    vol.Dispose();
                }
            }
        }
        private void PopulateVMs(TreeNode parent, Libvirt.CS_Objects.Host ptr)
        {
            Libvirt.virDomainPtr[] vms;
            ptr.virConnectListAllDomains(out vms, Libvirt.virConnectListAllDomainsFlags.VIR_CONNECT_LIST_DOMAINS_ACTIVE | Libvirt.virConnectListAllDomainsFlags.VIR_CONNECT_LIST_DOMAINS_INACTIVE);
            foreach (var item in vms)
            {
                var name = Libvirt.API.virDomainGetName(item);
                Libvirt._virDomainInfo info;
                Libvirt.API.virDomainGetInfo(item, out info);
                var imgindex = info.state == Libvirt.virDomainState.VIR_DOMAIN_RUNNING ? 4 : 5;
                var poolnode = new TreeNode(name, imgindex, imgindex);
                poolnode.Name = "VM";
                poolnode.Tag = ptr;
                parent.Nodes.Add(poolnode);
                item.Dispose();
            }
        }
        private void AddNewServer(Libvirt.CS_Objects.Host ptr)
        {
            var newhostname = ptr.virConnectGetHostname();
            ptr.virConnSetErrorFunc(_ErrorFunc);
            var newnode = new TreeNode(newhostname, 0, 0);
            newnode.Tag = ptr;
            newnode.Name = "VM_Server";
            var nodesfound = treeView1.Nodes.Find(newhostname, true);
            if (nodesfound != null)
            {
                if (nodesfound.Length > 0) return;//node already added
            }
            var node = treeView1.Nodes.Find("Root", false);
            if (node != null)
            {
                if (node.Length > 0)
                {
                    node[0].Nodes.Add(newnode);

                    var vmnode = new TreeNode("VMs", 8, 8);
                    vmnode.Tag = ptr;
                    vmnode.Name = "VM_List";
                    newnode.Nodes.Add(vmnode);

                    PopulateVMs(vmnode, ptr);

                    var poolnode = new TreeNode("Pools", 7, 7);
                    poolnode.Tag = ptr;
                    poolnode.Name = "Pool_List";
                    newnode.Nodes.Add(poolnode);

                    PopulatePools(poolnode, ptr);
                    _Connections.Add(ptr);
                }
            }

        }
        private void connectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var f = new Server_Connect();
            f.On_NewServerConnect_CB = AddNewServer;
            f.ShowDialog();
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                var nodetoremove = treeView1.SelectedNode;
                var con = nodetoremove.Tag as Libvirt.CS_Objects.Host;
                if (con != null)
                {
                    treeView1.SelectedNode.Tag = null;
                    treeView1.SelectedNode = null;
                    try
                    {
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                    _Connections.Remove(con);
                    treeView1.Nodes.Remove(nodetoremove);
                }
            }
        }

        private void virtualMachineToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void hardDriveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                var con = treeView1.SelectedNode.Tag as Libvirt.CS_Objects.Host;
                if (con != null)
                {
                    Libvirt.CS_Objects.Storage_Pool[] pools;
                    con.virConnectListAllStoragePools(out pools, Libvirt.virConnectListAllStoragePoolsFlags.VIR_CONNECT_LIST_STORAGE_POOLS_ACTIVE);
                    if (pools.Length > 0)
                    {
                        var f = new VM_Manager.Storage.Add_Storage_Volume(pools.FirstOrDefault(), con);
                        f.ShowDialog();
                    }
                    foreach (var item in pools)
                    {
                        item.Dispose();
                    }
                }
            }

        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                var con = treeView1.SelectedNode.Tag as Libvirt.CS_Objects.Host;
                if (con != null)
                {
                    var f = new Server_Details(con);
                    f.Show();
                }
            }
        }


        private void startToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                var con = treeView1.SelectedNode.Tag as Libvirt.CS_Objects.Host;
                if (con == null) return;
                var poolname = treeView1.SelectedNode.Text;
                if (MessageBox.Show("Are you sure that you want to Start the selected pool: '" + poolname + "'?", "START POOL", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    using (var pool = con.virStoragePoolLookupByName(poolname))
                    {
                        if (pool.virStoragePoolCreate() == 0)
                        {
                            MessageBox.Show("Pool Started!");
                        }
                    }
                }


            }
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                var con = treeView1.SelectedNode.Tag as Libvirt.CS_Objects.Host;
                if (con == null) return;
                var poolname = treeView1.SelectedNode.Text;
                if (MessageBox.Show("Are you sure that you want to STOP the selected pool: '" + poolname + "'?", "STOP POOL", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    using (var pool = con.virStoragePoolLookupByName(poolname))
                    {
                        if (pool.virStoragePoolDestroy() == 0)
                        {
                            MessageBox.Show("Pool Stopped");
                        }
                    }
                }
            }
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                var con = treeView1.SelectedNode.Tag as Libvirt.CS_Objects.Host;
                if (con == null) return;
                var poolname = treeView1.SelectedNode.Text;
                if (MessageBox.Show("Are you sure that you want to DELETE the selected pool: '" + poolname + "'?", "DELETE POOL", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    using (var pool = con.virStoragePoolLookupByName(poolname))
                    {
                        if (pool.virStoragePoolUndefine() == 0)
                        {
                            treeView1.SelectedNode.Parent.Nodes.Remove(treeView1.SelectedNode);
                            MessageBox.Show("Pool delete!");
                        }
                    }

                }
            }
        }


        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                var con = treeView1.SelectedNode.Tag as Libvirt.CS_Objects.Host;
                if (con == null) return;
                var f = new VM_Manager.Storage.Add_Storage_Pool(con);
                f.ShowDialog();
            }

        }

        private void newVMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                var con = treeView1.SelectedNode.Tag as Libvirt.CS_Objects.Host;
                if (con == null) return;
                var f = new VM_Manager.Domain.Add_Domain(con);
                f.OnVM_Create_Attempt = (a) =>
                {
                    if (a.Created)
                    {
                        var imgindex = a.StartOnCreate ? 4 : 5;
                        var poolnode = new TreeNode(a.Name, imgindex, imgindex);
                        poolnode.Name = "VM";
                        poolnode.Tag = treeView1.SelectedNode.Tag;
                        treeView1.SelectedNode.Nodes.Add(poolnode);
                    }
                };
                f.ShowDialog();
            }

        }

        private void newVolumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                var con = treeView1.SelectedNode.Tag as Libvirt.CS_Objects.Host;
                if (con == null) return;
                using (var pool = con.virStoragePoolLookupByName(treeView1.SelectedNode.Text))
                {
                    if (pool.IsValid)
                    {
                        var fs = new VM_Manager.Storage.Add_Storage_Volume(pool, con);
                        fs.OnPool_Create_Attempt = (volname, created) =>
                        {
                            if (created)
                            {
                                TreeNode volnode = null;
                                if (volname.ToLower().EndsWith(".iso")) volnode = new TreeNode(volname, 6, 6);
                                else volnode = new TreeNode(volname, 2, 2);
                                volnode.Name = "vol";
                                volnode.Tag = con;
                                treeView1.SelectedNode.Nodes.Add(volnode);
                            }
                        };
                        fs.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Pool no longer exists!");
                    }
                }
            }
        }

        private void refreshToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                var con = treeView1.SelectedNode.Tag as Libvirt.CS_Objects.Host;
                if (con == null) return;
                treeView1.SelectedNode.Nodes.Clear();
                PopulateVMs(treeView1.SelectedNode, con);

            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                var con = treeView1.SelectedNode.Tag as Libvirt.CS_Objects.Host;
                if (con == null) return;
                treeView1.SelectedNode.Nodes.Clear();
                PopulatePools(treeView1.SelectedNode, con, true);
            }

        }


        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (treeView1.SelectedNode != null)
            {
                var con = treeView1.SelectedNode.Tag as Libvirt.CS_Objects.Host;
                if (con == null) return;
                var dir = new System.IO.DirectoryInfo(@"C:\Program Files\");
                var firstdir = dir.GetDirectories().FirstOrDefault(a => a.Name.ToLower().Contains("virtviewer"));
                if (firstdir == null)
                {
                    try
                    {
                        dir = new System.IO.DirectoryInfo(@"C:\Program Files (x86)\");
                        firstdir = dir.GetDirectories().FirstOrDefault(a => a.Name.ToLower().Contains("virtviewer"));
                    }
                    catch (Exception ex)
                    {

                    }
                }
                if (firstdir == null)
                {
                    MessageBox.Show("You must install Virt-Viewer to connect to the VM!. Goto http://virt-manager.org/download/ and download the Windows MSI installer");
                }
                else
                {

                    var toexe = firstdir.FullName;
                    if (!toexe.EndsWith("\\") && !toexe.EndsWith("/"))
                    {
                        toexe += "\\";
                    }
                    toexe += "bin\\remote-viewer.exe";
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = toexe;

                    try
                    {
                        using (var dominaptr = con.virDomainLookupByName(treeView1.SelectedNode.Text))
                        {
                            startInfo.Arguments = " spice://" + con.virConnectGetURI().Split('/')[2] + ":" + (5900).ToString();
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    Process.Start(startInfo);
                }

            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                var con = treeView1.SelectedNode.Tag as Libvirt.CS_Objects.Host;
                if (con == null) return;
                using (var item = con.virDomainLookupByName(treeView1.SelectedNode.Text))
                {
                    if (!item.IsValid)
                    {
                        MessageBox.Show("Could not find the VM, unable to start. Try refreshing the VM list.");
                    }
                    else
                    {
                        item.virDomainCreate();
                    }


                }
            }
        }

        private void graceFullToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                var con = treeView1.SelectedNode.Tag as Libvirt.CS_Objects.Host;
                if (con == null) return;
                using (var item = con.virDomainLookupByName(treeView1.SelectedNode.Text))
                {
                    if (!item.IsValid)
                    {
                        MessageBox.Show("Could not find the VM, unable to Shutdown. Try refreshing the VM list.");
                    }
                    else
                    {
                        item.virDomainShutdownFlags(Libvirt.virDomainShutdownFlagValues.VIR_DOMAIN_SHUTDOWN_DEFAULT);
                    }
                }


            }
        }

        private void forcedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                var con = treeView1.SelectedNode.Tag as Libvirt.CS_Objects.Host;
                if (con == null) return;

                using (var item = con.virDomainLookupByName(treeView1.SelectedNode.Text))
                {
                    if (!item.IsValid)
                    {
                        MessageBox.Show("Could not find the VM, unable to Shutdown. Try refreshing the VM list.");
                    }
                    else
                    {
                        item.virDomainDestroyFlags(Libvirt.virDomainDestroyFlagsValues.VIR_DOMAIN_DESTROY_GRACEFUL);
                    }
                }


            }
        }
    }
}
