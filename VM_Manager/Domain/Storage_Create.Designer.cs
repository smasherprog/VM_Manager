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
            this.Pool_Combobox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Volume_Combobox = new System.Windows.Forms.ComboBox();
            this.AutoStart_VM_chk = new System.Windows.Forms.CheckBox();
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
            // Pool_Combobox
            // 
            this.Pool_Combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Pool_Combobox.FormattingEnabled = true;
            this.Pool_Combobox.Location = new System.Drawing.Point(56, 19);
            this.Pool_Combobox.Name = "Pool_Combobox";
            this.Pool_Combobox.Size = new System.Drawing.Size(323, 21);
            this.Pool_Combobox.TabIndex = 14;
            this.Pool_Combobox.SelectedIndexChanged += new System.EventHandler(this.Pool_Combobox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Pool";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Volume";
            // 
            // Volume_Combobox
            // 
            this.Volume_Combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Volume_Combobox.FormattingEnabled = true;
            this.Volume_Combobox.Location = new System.Drawing.Point(56, 47);
            this.Volume_Combobox.Name = "Volume_Combobox";
            this.Volume_Combobox.Size = new System.Drawing.Size(323, 21);
            this.Volume_Combobox.TabIndex = 17;
            // 
            // AutoStart_VM_chk
            // 
            this.AutoStart_VM_chk.AutoSize = true;
            this.AutoStart_VM_chk.Location = new System.Drawing.Point(299, 93);
            this.AutoStart_VM_chk.Name = "AutoStart_VM_chk";
            this.AutoStart_VM_chk.Size = new System.Drawing.Size(89, 17);
            this.AutoStart_VM_chk.TabIndex = 18;
            this.AutoStart_VM_chk.Text = "AutoStart VM";
            this.AutoStart_VM_chk.UseVisualStyleBackColor = true;
            // 
            // Storage_Create
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AutoStart_VM_chk);
            this.Controls.Add(this.Volume_Combobox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Pool_Combobox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "Storage_Create";
            this.Size = new System.Drawing.Size(404, 113);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Pool_Combobox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Volume_Combobox;
        private System.Windows.Forms.CheckBox AutoStart_VM_chk;
    }
}
