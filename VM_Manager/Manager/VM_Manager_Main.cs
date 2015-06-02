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
        private List<Libvirt.virConnectPtr> _Connections = new List<Libvirt.virConnectPtr>();

        public VM_Manager_Main()
        {
            InitializeComponent();
            this.FormClosing += VM_Manager_Main_FormClosing;
        }

        void VM_Manager_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
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
            Libvirt.virConnectPtr con;
            con.Pointer = IntPtr.Zero;
            if (treeView1.SelectedNode != null)
            {
                if (treeView1.SelectedNode.Tag != null)
                {
                    if (treeView1.SelectedNode.Tag.GetType() == typeof(Libvirt.virConnectPtr))
                    {
                        con = (Libvirt.virConnectPtr)treeView1.SelectedNode.Tag;
                    }
                }
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
                    else if (node.Name == "Pool" && con.Pointer != IntPtr.Zero)
                    {
                        using (var item = Libvirt.API.virStoragePoolLookupByName(con, node.Text))
                        {
                            Libvirt._virStoragePoolInfo info;
                            Libvirt.API.virStoragePoolGetInfo(item, out info);
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
                    else if (node.Name == "VM" && con.Pointer != IntPtr.Zero)
                    {
                        using (var item = Libvirt.API.virDomainLookupByName(con, node.Text))
                        {
                            Libvirt._virDomainInfo info;
                            Libvirt.API.virDomainGetInfo(item, out info);

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
                else if (node.Name == "Pool" && con.Pointer != IntPtr.Zero)
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
        private void PopulatePools(TreeNode parent, Libvirt.virConnectPtr ptr)
        {
            Libvirt.virStoragePoolPtr[] pools;
            Libvirt.API.virConnectListAllStoragePools(ptr, out pools, Libvirt.virConnectListAllStoragePoolsFlags.VIR_CONNECT_LIST_STORAGE_POOLS_ACTIVE | Libvirt.virConnectListAllStoragePoolsFlags.VIR_CONNECT_LIST_STORAGE_POOLS_INACTIVE);

            foreach (var item in pools)
            {
                var poolnode = new TreeNode(Libvirt.API.virStoragePoolGetName(item), 3, 3);
                poolnode.Name = "Pool";
                poolnode.Tag = ptr;
                parent.Nodes.Add(poolnode);
                PopulateVolumes(poolnode, item);
                item.Dispose();
            }
        }
        private void PopulateVolumes(TreeNode parent, Libvirt.virStoragePoolPtr ptr)
        {
            Libvirt.virStorageVolPtr[] volumes;
            if (Libvirt.API.virStoragePoolListAllVolumes(ptr, out volumes) > 0)
            {
                foreach (var vol in volumes)
                {
                    var volname = Libvirt.API.virStorageVolGetName(vol);
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
        private void PopulateVMs(TreeNode parent, Libvirt.virConnectPtr ptr)
        {

            Libvirt.virDomainPtr[] vms;
            Libvirt.API.virConnectListAllDomains(ptr, out vms, Libvirt.virConnectListAllDomainsFlags.VIR_CONNECT_LIST_DOMAINS_ACTIVE | Libvirt.virConnectListAllDomainsFlags.VIR_CONNECT_LIST_DOMAINS_INACTIVE);
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
        private void AddNewServer(Libvirt.virConnectPtr ptr)
        {

            if (ptr.Pointer != IntPtr.Zero)
            {
                var newhostname = Libvirt.API.virConnectGetHostname(ptr);
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

                        var vmnode = new TreeNode("VMs", 4, 4);
                        vmnode.Tag = ptr;
                        vmnode.Name = "VM_List";
                        newnode.Nodes.Add(vmnode);

                        PopulateVMs(vmnode, ptr);

                        var poolnode = new TreeNode("Pools", 4, 4);
                        poolnode.Tag = ptr;
                        poolnode.Name = "Pool_List";
                        newnode.Nodes.Add(poolnode);

                        PopulatePools(poolnode, ptr);
                        _Connections.Add(ptr);
                    }
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
                if (treeView1.SelectedNode.Tag != null)
                {
                    if (treeView1.SelectedNode.Tag.GetType() == typeof(Libvirt.virConnectPtr))
                    {
                        var nodetoremove = treeView1.SelectedNode;
                        var con = (Libvirt.virConnectPtr)nodetoremove.Tag;
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

        }

        private void virtualMachineToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void hardDriveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                if (treeView1.SelectedNode.Tag != null)
                {
                    Libvirt.virStoragePoolPtr[] pools;
                    Libvirt.API.virConnectListAllStoragePools((Libvirt.virConnectPtr)treeView1.SelectedNode.Tag, out pools, Libvirt.virConnectListAllStoragePoolsFlags.VIR_CONNECT_LIST_STORAGE_POOLS_ACTIVE);
                    if (pools.Length > 0)
                    {
                        var f = new VM_Manager.Storage.Add_Storage_Volume(pools.FirstOrDefault(), (Libvirt.virConnectPtr)treeView1.SelectedNode.Tag);
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
                if (treeView1.SelectedNode.Tag != null)
                {
                    if (treeView1.SelectedNode.Tag.GetType() == typeof(Libvirt.virConnectPtr))
                    {
                        var f = new Server_Details((Libvirt.virConnectPtr)treeView1.SelectedNode.Tag);
                        f.Show();
                    }
                }
            }
        }





        private void startToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                if (treeView1.SelectedNode.Tag != null)
                {
                    if (treeView1.SelectedNode.Tag.GetType() == typeof(Libvirt.virConnectPtr))
                    {
                        var poolname = treeView1.SelectedNode.Text;
                        if (MessageBox.Show("Are you sure that you want to Start the selected pool: '" + poolname + "'?", "START POOL", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            using (var pool = Libvirt.API.virStoragePoolLookupByName((Libvirt.virConnectPtr)treeView1.SelectedNode.Tag, poolname))
                            {
                                if (Libvirt.API.virStoragePoolCreate(pool) == 0)
                                {
                                    MessageBox.Show("Pool Started!");
                                }
                            }
                        }
                    }
                }
            }
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                if (treeView1.SelectedNode.Tag != null)
                {
                    if (treeView1.SelectedNode.Tag.GetType() == typeof(Libvirt.virConnectPtr))
                    {
                        var poolname = treeView1.SelectedNode.Text;
                        if (MessageBox.Show("Are you sure that you want to STOP the selected pool: '" + poolname + "'?", "STOP POOL", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            using (var pool = Libvirt.API.virStoragePoolLookupByName((Libvirt.virConnectPtr)treeView1.SelectedNode.Tag, poolname))
                            {
                                if (Libvirt.API.virStoragePoolDestroy(pool) == 0)
                                {
                                    MessageBox.Show("Pool Stopped");
                                }
                            }
                        }
                    }
                }
            }
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                if (treeView1.SelectedNode.Tag != null)
                {
                    if (treeView1.SelectedNode.Tag.GetType() == typeof(Libvirt.virConnectPtr))
                    {
                        var poolname = treeView1.SelectedNode.Text;
                        if (MessageBox.Show("Are you sure that you want to DELETE the selected pool: '" + poolname + "'?", "DELETE POOL", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            using (var pool = Libvirt.API.virStoragePoolLookupByName((Libvirt.virConnectPtr)treeView1.SelectedNode.Tag, poolname))
                            {
                                if (Libvirt.API.virStoragePoolUndefine(pool) == 0)
                                {
                                    treeView1.SelectedNode.Parent.Nodes.Remove(treeView1.SelectedNode);
                                    MessageBox.Show("Pool delete!");
                                }
                            }
                        }
                    }
                }
            }
        }


        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                if (treeView1.SelectedNode.Tag != null)
                {
                    if (treeView1.SelectedNode.Tag.GetType() == typeof(Libvirt.virConnectPtr))
                    {
                        var f = new VM_Manager.Storage.Add_Storage_Pool((Libvirt.virConnectPtr)treeView1.SelectedNode.Tag);
                        f.ShowDialog();
                    }
                }
            }
        }

        private void newVMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                if (treeView1.SelectedNode.Tag != null)
                {
                    if (treeView1.SelectedNode.Tag.GetType() == typeof(Libvirt.virConnectPtr))
                    {
                        var f = new VM_Manager.Domain.Add_Domain((Libvirt.virConnectPtr)treeView1.SelectedNode.Tag);
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
            }
        }

        private void newVolumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                if (treeView1.SelectedNode.Tag != null)
                {
                    if (treeView1.SelectedNode.Tag.GetType() == typeof(Libvirt.virConnectPtr))
                    {
                        var con = (Libvirt.virConnectPtr)treeView1.SelectedNode.Tag;
                        using (var pool = Libvirt.API.virStoragePoolLookupByName(con, treeView1.SelectedNode.Text))
                        {
                            if (pool.Pointer != IntPtr.Zero)
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
            }
        }

        private void refreshToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                if (treeView1.SelectedNode.Tag != null)
                {
                    if (treeView1.SelectedNode.Tag.GetType() == typeof(Libvirt.virConnectPtr))
                    {
                        var con = (Libvirt.virConnectPtr)treeView1.SelectedNode.Tag;
                        treeView1.SelectedNode.Nodes.Clear();
                        PopulateVMs(treeView1.SelectedNode, con);
                    }
                }
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                if (treeView1.SelectedNode.Tag != null)
                {
                    if (treeView1.SelectedNode.Tag.GetType() == typeof(Libvirt.virConnectPtr))
                    {
                        var con = (Libvirt.virConnectPtr)treeView1.SelectedNode.Tag;
                        treeView1.SelectedNode.Nodes.Clear();
                        PopulatePools(treeView1.SelectedNode, con);
                    }
                }
            }
        }

        private void stopToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (treeView1.SelectedNode != null)
            {
                if (treeView1.SelectedNode.Tag != null)
                {
                    if (treeView1.SelectedNode.Tag.GetType() == typeof(Libvirt.virConnectPtr))
                    {
                        var con = (Libvirt.virConnectPtr)treeView1.SelectedNode.Tag;
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
                                using (var dominaptr = Libvirt.API.virDomainLookupByName(con, treeView1.SelectedNode.Text))
                                {
                                    startInfo.Arguments = " spice://" + Libvirt.API.virConnectGetURI(con).Split('/')[2] + ":" + ( 5900).ToString();
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                            Process.Start(startInfo);
                        }
                    }
                }
            }
        }
    }
}
