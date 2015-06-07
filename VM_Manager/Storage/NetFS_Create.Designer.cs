namespace VM_Manager.Storage
{
    partial class NetFS_Create
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
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.Target_Path_txt_bx = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Format_drp_dwn = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Host_Name_txt_bx = new System.Windows.Forms.TextBox();
            this.Source_Path_txt_bx = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(335, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Specify a storage location to be later split into virtual machine storage.";
            // 
            // Target_Path_txt_bx
            // 
            this.Target_Path_txt_bx.Location = new System.Drawing.Point(92, 19);
            this.Target_Path_txt_bx.Name = "Target_Path_txt_bx";
            this.Target_Path_txt_bx.Size = new System.Drawing.Size(369, 20);
            this.Target_Path_txt_bx.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Target Path:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Format:";
            // 
            // Format_drp_dwn
            // 
            this.Format_drp_dwn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Format_drp_dwn.FormattingEnabled = true;
            this.Format_drp_dwn.Items.AddRange(new object[] {
            "auto",
            "nfs",
            "glusterfs"});
            this.Format_drp_dwn.Location = new System.Drawing.Point(92, 45);
            this.Format_drp_dwn.Name = "Format_drp_dwn";
            this.Format_drp_dwn.Size = new System.Drawing.Size(121, 21);
            this.Format_drp_dwn.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Host Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Source Path:";
            // 
            // Host_Name_txt_bx
            // 
            this.Host_Name_txt_bx.Location = new System.Drawing.Point(92, 72);
            this.Host_Name_txt_bx.Name = "Host_Name_txt_bx";
            this.Host_Name_txt_bx.Size = new System.Drawing.Size(369, 20);
            this.Host_Name_txt_bx.TabIndex = 8;
            // 
            // Source_Path_txt_bx
            // 
            this.Source_Path_txt_bx.Location = new System.Drawing.Point(92, 98);
            this.Source_Path_txt_bx.Name = "Source_Path_txt_bx";
            this.Source_Path_txt_bx.Size = new System.Drawing.Size(369, 20);
            this.Source_Path_txt_bx.TabIndex = 9;
            // 
            // NetFS_Create
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Source_Path_txt_bx);
            this.Controls.Add(this.Host_Name_txt_bx);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Format_drp_dwn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Target_Path_txt_bx);
            this.Name = "NetFS_Create";
            this.Size = new System.Drawing.Size(467, 129);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Target_Path_txt_bx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Format_drp_dwn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Host_Name_txt_bx;
        private System.Windows.Forms.TextBox Source_Path_txt_bx;
    }
}
