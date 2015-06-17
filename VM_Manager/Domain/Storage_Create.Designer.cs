namespace VM_Manager.Domain
{
    partial class Storage_Create
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AutoStart_VM_chk = new System.Windows.Forms.CheckBox();
            this.Pool_ListBox = new System.Windows.Forms.ListBox();
            this.Volume_ListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Locate storage to use for this Virtual Machine";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(320, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Pool";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Volume";
            // 
            // AutoStart_VM_chk
            // 
            this.AutoStart_VM_chk.AutoSize = true;
            this.AutoStart_VM_chk.Location = new System.Drawing.Point(312, 206);
            this.AutoStart_VM_chk.Name = "AutoStart_VM_chk";
            this.AutoStart_VM_chk.Size = new System.Drawing.Size(89, 17);
            this.AutoStart_VM_chk.TabIndex = 18;
            this.AutoStart_VM_chk.Text = "AutoStart VM";
            this.AutoStart_VM_chk.UseVisualStyleBackColor = true;
            // 
            // Pool_ListBox
            // 
            this.Pool_ListBox.FormattingEnabled = true;
            this.Pool_ListBox.Location = new System.Drawing.Point(66, 16);
            this.Pool_ListBox.Name = "Pool_ListBox";
            this.Pool_ListBox.Size = new System.Drawing.Size(323, 82);
            this.Pool_ListBox.TabIndex = 19;
            this.Pool_ListBox.SelectedIndexChanged += new System.EventHandler(this.Pool_ListBox_SelectedIndexChanged);
            // 
            // Volume_ListBox
            // 
            this.Volume_ListBox.FormattingEnabled = true;
            this.Volume_ListBox.Location = new System.Drawing.Point(66, 109);
            this.Volume_ListBox.Name = "Volume_ListBox";
            this.Volume_ListBox.Size = new System.Drawing.Size(323, 95);
            this.Volume_ListBox.TabIndex = 20;
            // 
            // Storage_Create
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Volume_ListBox);
            this.Controls.Add(this.Pool_ListBox);
            this.Controls.Add(this.AutoStart_VM_chk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "Storage_Create";
            this.Size = new System.Drawing.Size(404, 226);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox AutoStart_VM_chk;
        private System.Windows.Forms.ListBox Pool_ListBox;
        private System.Windows.Forms.ListBox Volume_ListBox;
    }
}
