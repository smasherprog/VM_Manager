namespace VM_Manager.Domain
{
    partial class Cpu_Ram_Create
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
            this.Memory_num = new System.Windows.Forms.NumericUpDown();
            this.CPU_num = new System.Windows.Forms.NumericUpDown();
            this.Available_Memory_txt = new System.Windows.Forms.Label();
            this.Available_CPUs_txt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Memory_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CPU_num)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Choose Memory and CPU settings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Memory (RAM):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "CPUs:";
            // 
            // Memory_num
            // 
            this.Memory_num.Increment = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.Memory_num.Location = new System.Drawing.Point(108, 24);
            this.Memory_num.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.Memory_num.Minimum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.Memory_num.Name = "Memory_num";
            this.Memory_num.Size = new System.Drawing.Size(63, 20);
            this.Memory_num.TabIndex = 9;
            this.Memory_num.Value = new decimal(new int[] {
            512,
            0,
            0,
            0});
            // 
            // CPU_num
            // 
            this.CPU_num.Location = new System.Drawing.Point(108, 67);
            this.CPU_num.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CPU_num.Name = "CPU_num";
            this.CPU_num.Size = new System.Drawing.Size(63, 20);
            this.CPU_num.TabIndex = 10;
            this.CPU_num.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Available_Memory_txt
            // 
            this.Available_Memory_txt.AutoSize = true;
            this.Available_Memory_txt.Location = new System.Drawing.Point(105, 47);
            this.Available_Memory_txt.Name = "Available_Memory_txt";
            this.Available_Memory_txt.Size = new System.Drawing.Size(180, 13);
            this.Available_Memory_txt.TabIndex = 11;
            this.Available_Memory_txt.Text = "Up to 1024 MB available on the host";
            // 
            // Available_CPUs_txt
            // 
            this.Available_CPUs_txt.AutoSize = true;
            this.Available_CPUs_txt.Location = new System.Drawing.Point(105, 94);
            this.Available_CPUs_txt.Name = "Available_CPUs_txt";
            this.Available_CPUs_txt.Size = new System.Drawing.Size(87, 13);
            this.Available_CPUs_txt.TabIndex = 12;
            this.Available_CPUs_txt.Text = "Up to 2 available";
            // 
            // Cpu_Ram_Create
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Available_CPUs_txt);
            this.Controls.Add(this.Available_Memory_txt);
            this.Controls.Add(this.CPU_num);
            this.Controls.Add(this.Memory_num);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Cpu_Ram_Create";
            this.Size = new System.Drawing.Size(291, 107);
            ((System.ComponentModel.ISupportInitialize)(this.Memory_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CPU_num)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown Memory_num;
        private System.Windows.Forms.NumericUpDown CPU_num;
        private System.Windows.Forms.Label Available_Memory_txt;
        private System.Windows.Forms.Label Available_CPUs_txt;
    }
}
