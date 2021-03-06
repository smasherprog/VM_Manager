﻿namespace VM_Manager.Manager
{
    partial class VM_Manager_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("VM-Manager");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VM_Manager_Main));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.VM_ImageList = new System.Windows.Forms.ImageList(this.components);
            this.VM_Context_Strip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.VM_Manager_ContextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.VM_Server_ContextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Pool_Contet_MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.Pool_Listing_Context = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.VM_Listing_Context = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.graceFullToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forcedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rebootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newVolumeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newVMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.VM_Context_Strip.SuspendLayout();
            this.VM_Manager_ContextStrip.SuspendLayout();
            this.VM_Server_ContextStrip.SuspendLayout();
            this.Pool_Contet_MenuStrip.SuspendLayout();
            this.Pool_Listing_Context.SuspendLayout();
            this.VM_Listing_Context.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.VM_ImageList;
            this.treeView1.Location = new System.Drawing.Point(13, 13);
            this.treeView1.Name = "treeView1";
            treeNode1.ImageKey = "Dedicated-Servers-icon.png";
            treeNode1.Name = "Root";
            treeNode1.SelectedImageKey = "Dedicated-Servers-icon.png";
            treeNode1.Text = "VM-Manager";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(238, 675);
            this.treeView1.TabIndex = 0;
            this.treeView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseUp);
            // 
            // VM_ImageList
            // 
            this.VM_ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("VM_ImageList.ImageStream")));
            this.VM_ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.VM_ImageList.Images.SetKeyName(0, "LTKp6EA5c.png");
            this.VM_ImageList.Images.SetKeyName(1, "Dedicated-Servers-icon.png");
            this.VM_ImageList.Images.SetKeyName(2, "harddrive.png");
            this.VM_ImageList.Images.SetKeyName(3, "Storage_Pool_lg.png");
            this.VM_ImageList.Images.SetKeyName(4, "computer_Active_lg.png");
            this.VM_ImageList.Images.SetKeyName(5, "computer_Unactive_lg.png");
            this.VM_ImageList.Images.SetKeyName(6, "51874.png");
            this.VM_ImageList.Images.SetKeyName(7, "database.png");
            this.VM_ImageList.Images.SetKeyName(8, "monitor.png");
            // 
            // VM_Context_Strip
            // 
            this.VM_Context_Strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem1,
            this.moveToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.VM_Context_Strip.Name = "VM_Context_Strup";
            this.VM_Context_Strip.Size = new System.Drawing.Size(130, 158);
            // 
            // VM_Manager_ContextStrip
            // 
            this.VM_Manager_ContextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem1});
            this.VM_Manager_ContextStrip.Name = "VM_Manager_ContextStrip";
            this.VM_Manager_ContextStrip.Size = new System.Drawing.Size(169, 26);
            // 
            // VM_Server_ContextStrip
            // 
            this.VM_Server_ContextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disconnectToolStripMenuItem,
            this.detailsToolStripMenuItem});
            this.VM_Server_ContextStrip.Name = "VM_Server_ContextStrip";
            this.VM_Server_ContextStrip.Size = new System.Drawing.Size(134, 48);
            // 
            // Pool_Contet_MenuStrip
            // 
            this.Pool_Contet_MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newVolumeToolStripMenuItem,
            this.startToolStripMenuItem1,
            this.stopToolStripMenuItem,
            this.deleteToolStripMenuItem1});
            this.Pool_Contet_MenuStrip.Name = "Pool_Contet_MenuStrip";
            this.Pool_Contet_MenuStrip.Size = new System.Drawing.Size(143, 92);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(257, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(896, 675);
            this.panel1.TabIndex = 4;
            // 
            // Pool_Listing_Context
            // 
            this.Pool_Listing_Context.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.Pool_Listing_Context.Name = "Pool_Listing_Context";
            this.Pool_Listing_Context.Size = new System.Drawing.Size(126, 48);
            // 
            // VM_Listing_Context
            // 
            this.VM_Listing_Context.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newVMToolStripMenuItem,
            this.refreshToolStripMenuItem1});
            this.VM_Listing_Context.Name = "VM_Listing_Context";
            this.VM_Listing_Context.Size = new System.Drawing.Size(120, 48);
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Image = global::VM_Manager.Properties.Resources.connect_established;
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Image = global::VM_Manager.Properties.Resources.applications_system;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Image = global::VM_Manager.Properties.Resources.player_play;
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem1
            // 
            this.stopToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graceFullToolStripMenuItem,
            this.forcedToolStripMenuItem,
            this.rebootToolStripMenuItem});
            this.stopToolStripMenuItem1.Image = global::VM_Manager.Properties.Resources.connect_creating_256;
            this.stopToolStripMenuItem1.Name = "stopToolStripMenuItem1";
            this.stopToolStripMenuItem1.Size = new System.Drawing.Size(129, 22);
            this.stopToolStripMenuItem1.Text = "ShutDown";
            // 
            // graceFullToolStripMenuItem
            // 
            this.graceFullToolStripMenuItem.Image = global::VM_Manager.Properties.Resources.shutdown;
            this.graceFullToolStripMenuItem.Name = "graceFullToolStripMenuItem";
            this.graceFullToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.graceFullToolStripMenuItem.Text = "GraceFull";
            this.graceFullToolStripMenuItem.ToolTipText = "Gracefull shutdown sends a signal to the OS letting it shut down properly, this d" +
    "oes not work in all cases.";
            this.graceFullToolStripMenuItem.Click += new System.EventHandler(this.graceFullToolStripMenuItem_Click);
            // 
            // forcedToolStripMenuItem
            // 
            this.forcedToolStripMenuItem.Image = global::VM_Manager.Properties.Resources.exit__1_;
            this.forcedToolStripMenuItem.Name = "forcedToolStripMenuItem";
            this.forcedToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.forcedToolStripMenuItem.Text = "Forced";
            this.forcedToolStripMenuItem.ToolTipText = "Forced shut down is the same as pressing the power button on a machine.";
            this.forcedToolStripMenuItem.Click += new System.EventHandler(this.forcedToolStripMenuItem_Click);
            // 
            // rebootToolStripMenuItem
            // 
            this.rebootToolStripMenuItem.Image = global::VM_Manager.Properties.Resources.gnome_session_reboot;
            this.rebootToolStripMenuItem.Name = "rebootToolStripMenuItem";
            this.rebootToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.rebootToolStripMenuItem.Text = "Reboot";
            // 
            // moveToolStripMenuItem
            // 
            this.moveToolStripMenuItem.Image = global::VM_Manager.Properties.Resources.ic_arrow_round_move_down;
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            this.moveToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.moveToolStripMenuItem.Text = "Migrate";
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Image = global::VM_Manager.Properties.Resources.pencil;
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::VM_Manager.Properties.Resources.deletered;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // connectToolStripMenuItem1
            // 
            this.connectToolStripMenuItem1.Image = global::VM_Manager.Properties.Resources.server_connect;
            this.connectToolStripMenuItem1.Name = "connectToolStripMenuItem1";
            this.connectToolStripMenuItem1.Size = new System.Drawing.Size(168, 22);
            this.connectToolStripMenuItem1.Text = "Connect to Server";
            this.connectToolStripMenuItem1.Click += new System.EventHandler(this.connectToolStripMenuItem1_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Image = global::VM_Manager.Properties.Resources.disconnect;
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // detailsToolStripMenuItem
            // 
            this.detailsToolStripMenuItem.Image = global::VM_Manager.Properties.Resources.view_details;
            this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            this.detailsToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.detailsToolStripMenuItem.Text = "Details";
            this.detailsToolStripMenuItem.Click += new System.EventHandler(this.detailsToolStripMenuItem_Click);
            // 
            // newVolumeToolStripMenuItem
            // 
            this.newVolumeToolStripMenuItem.Image = global::VM_Manager.Properties.Resources.add;
            this.newVolumeToolStripMenuItem.Name = "newVolumeToolStripMenuItem";
            this.newVolumeToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.newVolumeToolStripMenuItem.Text = "New Volume";
            this.newVolumeToolStripMenuItem.Click += new System.EventHandler(this.newVolumeToolStripMenuItem_Click);
            // 
            // startToolStripMenuItem1
            // 
            this.startToolStripMenuItem1.Image = global::VM_Manager.Properties.Resources.player_play;
            this.startToolStripMenuItem1.Name = "startToolStripMenuItem1";
            this.startToolStripMenuItem1.Size = new System.Drawing.Size(142, 22);
            this.startToolStripMenuItem1.Text = "Start";
            this.startToolStripMenuItem1.Click += new System.EventHandler(this.startToolStripMenuItem1_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Image = global::VM_Manager.Properties.Resources.stop1normalred;
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Image = global::VM_Manager.Properties.Resources.deletered;
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(142, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem1_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = global::VM_Manager.Properties.Resources.add;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.newToolStripMenuItem.Text = "New Pool";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = global::VM_Manager.Properties.Resources.arrow_refresh;
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // newVMToolStripMenuItem
            // 
            this.newVMToolStripMenuItem.Image = global::VM_Manager.Properties.Resources.add;
            this.newVMToolStripMenuItem.Name = "newVMToolStripMenuItem";
            this.newVMToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.newVMToolStripMenuItem.Text = "New VM";
            this.newVMToolStripMenuItem.Click += new System.EventHandler(this.newVMToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem1
            // 
            this.refreshToolStripMenuItem1.Image = global::VM_Manager.Properties.Resources.arrow_refresh;
            this.refreshToolStripMenuItem1.Name = "refreshToolStripMenuItem1";
            this.refreshToolStripMenuItem1.Size = new System.Drawing.Size(119, 22);
            this.refreshToolStripMenuItem1.Text = "Refresh";
            this.refreshToolStripMenuItem1.Click += new System.EventHandler(this.refreshToolStripMenuItem1_Click);
            // 
            // VM_Manager_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 694);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.treeView1);
            this.Name = "VM_Manager_Main";
            this.Text = "VM Manager";
            this.VM_Context_Strip.ResumeLayout(false);
            this.VM_Manager_ContextStrip.ResumeLayout(false);
            this.VM_Server_ContextStrip.ResumeLayout(false);
            this.Pool_Contet_MenuStrip.ResumeLayout(false);
            this.Pool_Listing_Context.ResumeLayout(false);
            this.VM_Listing_Context.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ContextMenuStrip VM_Context_Strip;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip VM_Manager_ContextStrip;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip VM_Server_ContextStrip;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ImageList VM_ImageList;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip Pool_Contet_MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem newVolumeToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip Pool_Listing_Context;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip VM_Listing_Context;
        private System.Windows.Forms.ToolStripMenuItem newVMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem graceFullToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forcedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rebootToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}