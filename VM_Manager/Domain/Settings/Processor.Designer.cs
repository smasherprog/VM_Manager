namespace VM_Manager.Domain.Settings
{
    partial class Processor
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
            this.label1 = new System.Windows.Forms.Label();
            this.vCPU_trackbr = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.vCPU_trackbr)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "vCPUs";
            // 
            // vCPU_trackbr
            // 
            this.vCPU_trackbr.Location = new System.Drawing.Point(49, 3);
            this.vCPU_trackbr.Name = "vCPU_trackbr";
            this.vCPU_trackbr.Size = new System.Drawing.Size(370, 45);
            this.vCPU_trackbr.TabIndex = 1;
            // 
            // Processor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.vCPU_trackbr);
            this.Controls.Add(this.label1);
            this.Name = "Processor";
            this.Size = new System.Drawing.Size(504, 145);
            ((System.ComponentModel.ISupportInitialize)(this.vCPU_trackbr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar vCPU_trackbr;

    }
}
