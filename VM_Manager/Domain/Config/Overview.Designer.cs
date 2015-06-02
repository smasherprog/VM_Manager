namespace VM_Manager.Domain.Config
{
    partial class Overview
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.UUID_txt = new System.Windows.Forms.Label();
            this.Name_txtbx = new System.Windows.Forms.TextBox();
            this.Desc_txtbx = new System.Windows.Forms.TextBox();
            this.Status_txt = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.Hypervisor_txt = new System.Windows.Forms.Label();
            this.Architecture_txt = new System.Windows.Forms.Label();
            this.Emulator_txt = new System.Windows.Forms.Label();
            this.Firemware_txt = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Basic Details";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "UUID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Status:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Description";
            // 
            // UUID_txt
            // 
            this.UUID_txt.AutoSize = true;
            this.UUID_txt.Location = new System.Drawing.Point(83, 26);
            this.UUID_txt.Name = "UUID_txt";
            this.UUID_txt.Size = new System.Drawing.Size(35, 13);
            this.UUID_txt.TabIndex = 5;
            this.UUID_txt.Text = "label6";
            // 
            // Name_txtbx
            // 
            this.Name_txtbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Name_txtbx.Location = new System.Drawing.Point(83, 3);
            this.Name_txtbx.Name = "Name_txtbx";
            this.Name_txtbx.Size = new System.Drawing.Size(445, 20);
            this.Name_txtbx.TabIndex = 6;
            // 
            // Desc_txtbx
            // 
            this.Desc_txtbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Desc_txtbx.Location = new System.Drawing.Point(83, 55);
            this.Desc_txtbx.Name = "Desc_txtbx";
            this.Desc_txtbx.Size = new System.Drawing.Size(445, 20);
            this.Desc_txtbx.TabIndex = 7;
            // 
            // Status_txt
            // 
            this.Status_txt.AutoSize = true;
            this.Status_txt.Location = new System.Drawing.Point(83, 39);
            this.Status_txt.Name = "Status_txt";
            this.Status_txt.Size = new System.Drawing.Size(35, 13);
            this.Status_txt.TabIndex = 8;
            this.Status_txt.Text = "label7";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.06849F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.93151F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Desc_txtbx, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.Status_txt, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.Name_txtbx, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.UUID_txt, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(25, 23);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(531, 82);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "Hypervisor Details";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.16479F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.83521F));
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label10, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label11, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label12, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.Hypervisor_txt, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.Architecture_txt, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.Emulator_txt, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.Firemware_txt, 1, 3);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(25, 127);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(534, 59);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Hypervisor:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Architecture:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Emulator:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 39);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Firemware:";
            // 
            // Hypervisor_txt
            // 
            this.Hypervisor_txt.AutoSize = true;
            this.Hypervisor_txt.Location = new System.Drawing.Point(100, 0);
            this.Hypervisor_txt.Name = "Hypervisor_txt";
            this.Hypervisor_txt.Size = new System.Drawing.Size(41, 13);
            this.Hypervisor_txt.TabIndex = 4;
            this.Hypervisor_txt.Text = "label13";
            // 
            // Architecture_txt
            // 
            this.Architecture_txt.AutoSize = true;
            this.Architecture_txt.Location = new System.Drawing.Point(100, 13);
            this.Architecture_txt.Name = "Architecture_txt";
            this.Architecture_txt.Size = new System.Drawing.Size(41, 13);
            this.Architecture_txt.TabIndex = 5;
            this.Architecture_txt.Text = "label14";
            // 
            // Emulator_txt
            // 
            this.Emulator_txt.AutoSize = true;
            this.Emulator_txt.Location = new System.Drawing.Point(100, 26);
            this.Emulator_txt.Name = "Emulator_txt";
            this.Emulator_txt.Size = new System.Drawing.Size(41, 13);
            this.Emulator_txt.TabIndex = 6;
            this.Emulator_txt.Text = "label15";
            // 
            // Firemware_txt
            // 
            this.Firemware_txt.AutoSize = true;
            this.Firemware_txt.Location = new System.Drawing.Point(100, 39);
            this.Firemware_txt.Name = "Firemware_txt";
            this.Firemware_txt.Size = new System.Drawing.Size(41, 13);
            this.Firemware_txt.TabIndex = 7;
            this.Firemware_txt.Text = "label16";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Operating System";
            // 
            // Overview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Name = "Overview";
            this.Size = new System.Drawing.Size(559, 578);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label UUID_txt;
        private System.Windows.Forms.TextBox Name_txtbx;
        private System.Windows.Forms.TextBox Desc_txtbx;
        private System.Windows.Forms.Label Status_txt;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label Hypervisor_txt;
        private System.Windows.Forms.Label Architecture_txt;
        private System.Windows.Forms.Label Emulator_txt;
        private System.Windows.Forms.Label Firemware_txt;
        private System.Windows.Forms.Label label6;
    }
}
