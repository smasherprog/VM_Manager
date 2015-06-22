namespace VM_Manager.Domain
{
    partial class Create_First_Step
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
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Local_Install = new System.Windows.Forms.RadioButton();
            this.Network_Install = new System.Windows.Forms.RadioButton();
            this.PXE_Install = new System.Windows.Forms.RadioButton();
            this.Import_Disk_Install = new System.Windows.Forms.RadioButton();
            this.generalMetadataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.generalMetadataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(281, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Choose how you would like to install the Operating System";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Enter your virtual machine details";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Name:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(67, 16);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(268, 20);
            this.textBox2.TabIndex = 8;
            // 
            // Local_Install
            // 
            this.Local_Install.AutoSize = true;
            this.Local_Install.Checked = true;
            this.Local_Install.Location = new System.Drawing.Point(67, 69);
            this.Local_Install.Name = "Local_Install";
            this.Local_Install.Size = new System.Drawing.Size(224, 17);
            this.Local_Install.TabIndex = 9;
            this.Local_Install.TabStop = true;
            this.Local_Install.Text = "Local install media (ISO image or CDROM)";
            this.Local_Install.UseVisualStyleBackColor = true;
            // 
            // Network_Install
            // 
            this.Network_Install.AutoSize = true;
            this.Network_Install.Enabled = false;
            this.Network_Install.Location = new System.Drawing.Point(67, 92);
            this.Network_Install.Name = "Network_Install";
            this.Network_Install.Size = new System.Drawing.Size(198, 17);
            this.Network_Install.TabIndex = 10;
            this.Network_Install.TabStop = true;
            this.Network_Install.Text = "Network Install (HTTP, FTP, or NFS)";
            this.Network_Install.UseVisualStyleBackColor = true;
            // 
            // PXE_Install
            // 
            this.PXE_Install.AutoSize = true;
            this.PXE_Install.Enabled = false;
            this.PXE_Install.Location = new System.Drawing.Point(67, 115);
            this.PXE_Install.Name = "PXE_Install";
            this.PXE_Install.Size = new System.Drawing.Size(120, 17);
            this.PXE_Install.TabIndex = 11;
            this.PXE_Install.TabStop = true;
            this.PXE_Install.Text = "Network Boot (PXE)";
            this.PXE_Install.UseVisualStyleBackColor = true;
            // 
            // Import_Disk_Install
            // 
            this.Import_Disk_Install.AutoSize = true;
            this.Import_Disk_Install.Enabled = false;
            this.Import_Disk_Install.Location = new System.Drawing.Point(67, 138);
            this.Import_Disk_Install.Name = "Import_Disk_Install";
            this.Import_Disk_Install.Size = new System.Drawing.Size(147, 17);
            this.Import_Disk_Install.TabIndex = 12;
            this.Import_Disk_Install.TabStop = true;
            this.Import_Disk_Install.Text = "Import exisiting disk image";
            this.Import_Disk_Install.UseVisualStyleBackColor = true;
            // 
            // generalMetadataBindingSource
            // 
            this.generalMetadataBindingSource.DataSource = typeof(Libvirt.Models.Concrete.General_Metadata);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Create_First_Step
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Import_Disk_Install);
            this.Controls.Add(this.PXE_Install);
            this.Controls.Add(this.Network_Install);
            this.Controls.Add(this.Local_Install);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "Create_First_Step";
            this.Size = new System.Drawing.Size(404, 163);
            ((System.ComponentModel.ISupportInitialize)(this.generalMetadataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.RadioButton Local_Install;
        private System.Windows.Forms.RadioButton Network_Install;
        private System.Windows.Forms.RadioButton PXE_Install;
        private System.Windows.Forms.RadioButton Import_Disk_Install;
        private System.Windows.Forms.BindingSource generalMetadataBindingSource;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
