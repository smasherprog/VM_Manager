namespace VM_Manager.Storage
{
    partial class Add_Storage_Volume
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.filextension = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Max_Capacity_Numeric = new System.Windows.Forms.NumericUpDown();
            this.AvailSpaceLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Allocation_Numeric = new System.Windows.Forms.NumericUpDown();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.filebrowse_btn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.iso_filepath_txt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Max_Capacity_Numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Allocation_Numeric)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "New Storage Volume";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(73, 64);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(264, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(324, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Create a storage unit that can be used directly by a virtual machine.";
            // 
            // filextension
            // 
            this.filextension.AutoSize = true;
            this.filextension.Location = new System.Drawing.Point(343, 67);
            this.filextension.Name = "filextension";
            this.filextension.Size = new System.Drawing.Size(26, 13);
            this.filextension.TabIndex = 3;
            this.filextension.Text = ".img";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Name:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "raw",
            "cow",
            "qcow",
            "qcow2",
            "qed",
            "vmdk",
            "vpc",
            "iso"});
            this.comboBox1.Location = new System.Drawing.Point(73, 91);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(264, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Format:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(172, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Storage Volume Quota";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(321, 169);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Finish";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Max_Capacity_Numeric
            // 
            this.Max_Capacity_Numeric.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.Max_Capacity_Numeric.Location = new System.Drawing.Point(115, 152);
            this.Max_Capacity_Numeric.Name = "Max_Capacity_Numeric";
            this.Max_Capacity_Numeric.Size = new System.Drawing.Size(82, 20);
            this.Max_Capacity_Numeric.TabIndex = 9;
            // 
            // AvailSpaceLabel
            // 
            this.AvailSpaceLabel.AutoSize = true;
            this.AvailSpaceLabel.Location = new System.Drawing.Point(46, 132);
            this.AvailSpaceLabel.Name = "AvailSpaceLabel";
            this.AvailSpaceLabel.Size = new System.Drawing.Size(35, 13);
            this.AvailSpaceLabel.TabIndex = 10;
            this.AvailSpaceLabel.Text = "label7";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Max Capacity:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(53, 180);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Allocation:";
            // 
            // Allocation_Numeric
            // 
            this.Allocation_Numeric.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.Allocation_Numeric.Location = new System.Drawing.Point(115, 178);
            this.Allocation_Numeric.Name = "Allocation_Numeric";
            this.Allocation_Numeric.Size = new System.Drawing.Size(82, 20);
            this.Allocation_Numeric.TabIndex = 12;
            this.toolTip1.SetToolTip(this.Allocation_Numeric, "This will Pre allocate the space requested. If 0 is selected, the entire capacity" +
        " is pre allocated. This is a performance optimization.");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(204, 153);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "MB";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(204, 180);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "MB";
            // 
            // filebrowse_btn
            // 
            this.filebrowse_btn.Location = new System.Drawing.Point(343, 89);
            this.filebrowse_btn.Name = "filebrowse_btn";
            this.filebrowse_btn.Size = new System.Drawing.Size(53, 23);
            this.filebrowse_btn.TabIndex = 16;
            this.filebrowse_btn.Text = "Browse";
            this.filebrowse_btn.UseVisualStyleBackColor = true;
            this.filebrowse_btn.Visible = false;
            this.filebrowse_btn.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "iso files|*.iso";
            // 
            // iso_filepath_txt
            // 
            this.iso_filepath_txt.AutoSize = true;
            this.iso_filepath_txt.Location = new System.Drawing.Point(73, 45);
            this.iso_filepath_txt.Name = "iso_filepath_txt";
            this.iso_filepath_txt.Size = new System.Drawing.Size(0, 13);
            this.iso_filepath_txt.TabIndex = 17;
            // 
            // Add_Storage_Volume
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 204);
            this.Controls.Add(this.iso_filepath_txt);
            this.Controls.Add(this.filebrowse_btn);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Allocation_Numeric);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.AvailSpaceLabel);
            this.Controls.Add(this.Max_Capacity_Numeric);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.filextension);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Add_Storage_Volume";
            this.Text = "Add_Storage_Volume";
            ((System.ComponentModel.ISupportInitialize)(this.Max_Capacity_Numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Allocation_Numeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label filextension;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown Max_Capacity_Numeric;
        private System.Windows.Forms.Label AvailSpaceLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown Allocation_Numeric;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button filebrowse_btn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label iso_filepath_txt;
    }
}