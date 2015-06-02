namespace VM_Manager.Storage
{
    partial class Storage_Pool_Listing
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label23 = new System.Windows.Forms.Label();
            this.Storage_Delete_Volume_btn = new System.Windows.Forms.Button();
            this.Storage_Create_Volume_btn = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.Storage_Default_txt = new System.Windows.Forms.Label();
            this.Storage_Pool_Type_txt = new System.Windows.Forms.Label();
            this.Storage_Pool_Location_txt = new System.Windows.Forms.Label();
            this.Storage_Pool_State_txt = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.Storage_AutoStart_ck = new System.Windows.Forms.CheckBox();
            this.Volume_ListView = new System.Windows.Forms.ListView();
            this.Sotrage_Column_Volume = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Storage_Column_Allocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Sotrage_Column_Size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Sotrage_Column_Format = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Sotrage_Column_Used_By = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox6.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(8, 100);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(132, 20);
            this.label23.TabIndex = 19;
            this.label23.Text = "Storage Volumes";
            // 
            // Storage_Delete_Volume_btn
            // 
            this.Storage_Delete_Volume_btn.Enabled = false;
            this.Storage_Delete_Volume_btn.Location = new System.Drawing.Point(305, 100);
            this.Storage_Delete_Volume_btn.Name = "Storage_Delete_Volume_btn";
            this.Storage_Delete_Volume_btn.Size = new System.Drawing.Size(90, 23);
            this.Storage_Delete_Volume_btn.TabIndex = 16;
            this.Storage_Delete_Volume_btn.Text = "Delete Volume";
            this.Storage_Delete_Volume_btn.UseVisualStyleBackColor = true;
            this.Storage_Delete_Volume_btn.Click += new System.EventHandler(this.Storage_Delete_Volume_btn_Click_1);
            // 
            // Storage_Create_Volume_btn
            // 
            this.Storage_Create_Volume_btn.Location = new System.Drawing.Point(186, 100);
            this.Storage_Create_Volume_btn.Name = "Storage_Create_Volume_btn";
            this.Storage_Create_Volume_btn.Size = new System.Drawing.Size(113, 23);
            this.Storage_Create_Volume_btn.TabIndex = 15;
            this.Storage_Create_Volume_btn.Text = "Create Volume";
            this.Storage_Create_Volume_btn.UseVisualStyleBackColor = true;
            this.Storage_Create_Volume_btn.Click += new System.EventHandler(this.Storage_Create_Volume_btn_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.tableLayoutPanel5);
            this.groupBox6.Location = new System.Drawing.Point(3, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(894, 94);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Pool Details";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.06798F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.93202F));
            this.tableLayoutPanel5.Controls.Add(this.label17, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.label18, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.label19, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.label20, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.Storage_Default_txt, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.Storage_Pool_Type_txt, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.Storage_Pool_Location_txt, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.Storage_Pool_State_txt, 1, 3);
            this.tableLayoutPanel5.Controls.Add(this.label21, 0, 4);
            this.tableLayoutPanel5.Controls.Add(this.Storage_AutoStart_ck, 1, 4);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 5;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(888, 75);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Default";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 13);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(55, 13);
            this.label18.TabIndex = 1;
            this.label18.Text = "Pool Type";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(3, 26);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(48, 13);
            this.label19.TabIndex = 2;
            this.label19.Text = "Location";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(3, 39);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(32, 13);
            this.label20.TabIndex = 3;
            this.label20.Text = "State";
            // 
            // Storage_Default_txt
            // 
            this.Storage_Default_txt.AutoSize = true;
            this.Storage_Default_txt.Location = new System.Drawing.Point(163, 0);
            this.Storage_Default_txt.Name = "Storage_Default_txt";
            this.Storage_Default_txt.Size = new System.Drawing.Size(41, 13);
            this.Storage_Default_txt.TabIndex = 4;
            this.Storage_Default_txt.Text = "label21";
            // 
            // Storage_Pool_Type_txt
            // 
            this.Storage_Pool_Type_txt.AutoSize = true;
            this.Storage_Pool_Type_txt.Location = new System.Drawing.Point(163, 13);
            this.Storage_Pool_Type_txt.Name = "Storage_Pool_Type_txt";
            this.Storage_Pool_Type_txt.Size = new System.Drawing.Size(41, 13);
            this.Storage_Pool_Type_txt.TabIndex = 5;
            this.Storage_Pool_Type_txt.Text = "label22";
            // 
            // Storage_Pool_Location_txt
            // 
            this.Storage_Pool_Location_txt.AutoSize = true;
            this.Storage_Pool_Location_txt.Location = new System.Drawing.Point(163, 26);
            this.Storage_Pool_Location_txt.Name = "Storage_Pool_Location_txt";
            this.Storage_Pool_Location_txt.Size = new System.Drawing.Size(41, 13);
            this.Storage_Pool_Location_txt.TabIndex = 6;
            this.Storage_Pool_Location_txt.Text = "label23";
            // 
            // Storage_Pool_State_txt
            // 
            this.Storage_Pool_State_txt.AutoSize = true;
            this.Storage_Pool_State_txt.Location = new System.Drawing.Point(163, 39);
            this.Storage_Pool_State_txt.Name = "Storage_Pool_State_txt";
            this.Storage_Pool_State_txt.Size = new System.Drawing.Size(41, 13);
            this.Storage_Pool_State_txt.TabIndex = 7;
            this.Storage_Pool_State_txt.Text = "label24";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(3, 52);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(54, 13);
            this.label21.TabIndex = 8;
            this.label21.Text = "AutoStart:";
            // 
            // Storage_AutoStart_ck
            // 
            this.Storage_AutoStart_ck.AutoSize = true;
            this.Storage_AutoStart_ck.Location = new System.Drawing.Point(163, 55);
            this.Storage_AutoStart_ck.Name = "Storage_AutoStart_ck";
            this.Storage_AutoStart_ck.Size = new System.Drawing.Size(65, 17);
            this.Storage_AutoStart_ck.TabIndex = 9;
            this.Storage_AutoStart_ck.Text = "On Boot";
            this.Storage_AutoStart_ck.UseVisualStyleBackColor = true;
            // 
            // Volume_ListView
            // 
            this.Volume_ListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.Volume_ListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Volume_ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Sotrage_Column_Volume,
            this.Storage_Column_Allocation,
            this.Sotrage_Column_Size,
            this.Sotrage_Column_Format,
            this.Sotrage_Column_Used_By});
            this.Volume_ListView.FullRowSelect = true;
            this.Volume_ListView.Location = new System.Drawing.Point(12, 123);
            this.Volume_ListView.Name = "Volume_ListView";
            this.Volume_ListView.Size = new System.Drawing.Size(882, 507);
            this.Volume_ListView.TabIndex = 13;
            this.Volume_ListView.UseCompatibleStateImageBehavior = false;
            this.Volume_ListView.View = System.Windows.Forms.View.Details;
            this.Volume_ListView.SelectedIndexChanged += new System.EventHandler(this.Volume_ListView_SelectedIndexChanged_1);
            // 
            // Sotrage_Column_Volume
            // 
            this.Sotrage_Column_Volume.Text = "Volume";
            this.Sotrage_Column_Volume.Width = 169;
            // 
            // Storage_Column_Allocation
            // 
            this.Storage_Column_Allocation.Text = "Allocated";
            // 
            // Sotrage_Column_Size
            // 
            this.Sotrage_Column_Size.Text = "Size";
            // 
            // Sotrage_Column_Format
            // 
            this.Sotrage_Column_Format.Text = "Format";
            this.Sotrage_Column_Format.Width = 98;
            // 
            // Sotrage_Column_Used_By
            // 
            this.Sotrage_Column_Used_By.Text = "Used By";
            this.Sotrage_Column_Used_By.Width = 144;
            // 
            // Storage_Pool_Listing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label23);
            this.Controls.Add(this.Storage_Delete_Volume_btn);
            this.Controls.Add(this.Storage_Create_Volume_btn);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.Volume_ListView);
            this.Name = "Storage_Pool_Listing";
            this.Size = new System.Drawing.Size(900, 633);
            this.groupBox6.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button Storage_Delete_Volume_btn;
        private System.Windows.Forms.Button Storage_Create_Volume_btn;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label Storage_Default_txt;
        private System.Windows.Forms.Label Storage_Pool_Type_txt;
        private System.Windows.Forms.Label Storage_Pool_Location_txt;
        private System.Windows.Forms.Label Storage_Pool_State_txt;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox Storage_AutoStart_ck;
        private System.Windows.Forms.ListView Volume_ListView;
        private System.Windows.Forms.ColumnHeader Sotrage_Column_Volume;
        private System.Windows.Forms.ColumnHeader Storage_Column_Allocation;
        private System.Windows.Forms.ColumnHeader Sotrage_Column_Size;
        private System.Windows.Forms.ColumnHeader Sotrage_Column_Format;
        private System.Windows.Forms.ColumnHeader Sotrage_Column_Used_By;
    }
}
