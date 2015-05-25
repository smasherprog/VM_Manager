namespace VM_Manager
{
    partial class Connection_Details
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.Overview = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.hypervisor = new System.Windows.Forms.Label();
            this.hostname = new System.Windows.Forms.Label();
            this.connectionuri = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.CpuModel = new System.Windows.Forms.Label();
            this.systemmemory = new System.Windows.Forms.Label();
            this.numcpus = new System.Windows.Forms.Label();
            this.cpumhz = new System.Windows.Forms.Label();
            this.cpucores = new System.Windows.Forms.Label();
            this.cputhreads = new System.Windows.Forms.Label();
            this.Overview.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Overview
            // 
            this.Overview.Controls.Add(this.tabPage1);
            this.Overview.Controls.Add(this.tabPage2);
            this.Overview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Overview.Location = new System.Drawing.Point(0, 0);
            this.Overview.Name = "Overview";
            this.Overview.SelectedIndex = 0;
            this.Overview.Size = new System.Drawing.Size(851, 627);
            this.Overview.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(843, 601);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Overview";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.chart1);
            this.groupBox3.Location = new System.Drawing.Point(6, 142);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(829, 234);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "CPU Usage";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 16);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(823, 215);
            this.chart1.TabIndex = 8;
            this.chart1.Text = "CPU Usage:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chart2);
            this.groupBox2.Location = new System.Drawing.Point(8, 382);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(828, 227);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Memory Usage";
            // 
            // chart2
            // 
            this.chart2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(3, 16);
            this.chart2.Name = "chart2";
            this.chart2.Size = new System.Drawing.Size(822, 208);
            this.chart2.TabIndex = 9;
            this.chart2.Text = "chart2";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(823, 130);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Basic Details";
            // 
            // hypervisor
            // 
            this.hypervisor.AutoSize = true;
            this.hypervisor.Location = new System.Drawing.Point(110, 46);
            this.hypervisor.Name = "hypervisor";
            this.hypervisor.Size = new System.Drawing.Size(45, 16);
            this.hypervisor.TabIndex = 4;
            this.hypervisor.Text = "label1";
            // 
            // hostname
            // 
            this.hostname.AutoSize = true;
            this.hostname.Location = new System.Drawing.Point(110, 23);
            this.hostname.Name = "hostname";
            this.hostname.Size = new System.Drawing.Size(45, 16);
            this.hostname.TabIndex = 3;
            this.hostname.Text = "label1";
            // 
            // connectionuri
            // 
            this.connectionuri.AutoSize = true;
            this.connectionuri.Location = new System.Drawing.Point(110, 0);
            this.connectionuri.Name = "connectionuri";
            this.connectionuri.Size = new System.Drawing.Size(45, 16);
            this.connectionuri.TabIndex = 2;
            this.connectionuri.Text = "label8";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(842, 619);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.41985F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.58015F));
            this.tableLayoutPanel1.Controls.Add(this.hypervisor, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.hostname, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.connectionuri, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 21);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(525, 67);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Connection:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Hostname:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Hypervospr:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.59155F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.40845F));
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.CpuModel, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.systemmemory, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.numcpus, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.cpumhz, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.cpucores, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.cputhreads, 1, 5);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(532, 9);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(285, 121);
            this.tableLayoutPanel2.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Model:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Memory:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "Cpus:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "Mhz:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 16);
            this.label8.TabIndex = 4;
            this.label8.Text = "Cores:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 21);
            this.label9.TabIndex = 5;
            this.label9.Text = "Threads:";
            // 
            // CpuModel
            // 
            this.CpuModel.AutoSize = true;
            this.CpuModel.Location = new System.Drawing.Point(70, 0);
            this.CpuModel.Name = "CpuModel";
            this.CpuModel.Size = new System.Drawing.Size(52, 16);
            this.CpuModel.TabIndex = 6;
            this.CpuModel.Text = "label10";
            // 
            // systemmemory
            // 
            this.systemmemory.AutoSize = true;
            this.systemmemory.Location = new System.Drawing.Point(70, 20);
            this.systemmemory.Name = "systemmemory";
            this.systemmemory.Size = new System.Drawing.Size(52, 16);
            this.systemmemory.TabIndex = 7;
            this.systemmemory.Text = "label10";
            // 
            // numcpus
            // 
            this.numcpus.AutoSize = true;
            this.numcpus.Location = new System.Drawing.Point(70, 40);
            this.numcpus.Name = "numcpus";
            this.numcpus.Size = new System.Drawing.Size(52, 16);
            this.numcpus.TabIndex = 8;
            this.numcpus.Text = "label10";
            // 
            // cpumhz
            // 
            this.cpumhz.AutoSize = true;
            this.cpumhz.Location = new System.Drawing.Point(70, 60);
            this.cpumhz.Name = "cpumhz";
            this.cpumhz.Size = new System.Drawing.Size(52, 16);
            this.cpumhz.TabIndex = 9;
            this.cpumhz.Text = "label10";
            // 
            // cpucores
            // 
            this.cpucores.AutoSize = true;
            this.cpucores.Location = new System.Drawing.Point(70, 80);
            this.cpucores.Name = "cpucores";
            this.cpucores.Size = new System.Drawing.Size(52, 16);
            this.cpucores.TabIndex = 10;
            this.cpucores.Text = "label10";
            // 
            // cputhreads
            // 
            this.cputhreads.AutoSize = true;
            this.cputhreads.Location = new System.Drawing.Point(70, 100);
            this.cputhreads.Name = "cputhreads";
            this.cputhreads.Size = new System.Drawing.Size(52, 16);
            this.cputhreads.TabIndex = 11;
            this.cputhreads.Text = "label10";
            // 
            // Connection_Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 627);
            this.Controls.Add(this.Overview);
            this.Name = "Connection_Details";
            this.Text = "Host Details";
            this.Overview.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Overview;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label connectionuri;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label hypervisor;
        private System.Windows.Forms.Label hostname;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label CpuModel;
        private System.Windows.Forms.Label systemmemory;
        private System.Windows.Forms.Label numcpus;
        private System.Windows.Forms.Label cpumhz;
        private System.Windows.Forms.Label cpucores;
        private System.Windows.Forms.Label cputhreads;

    }
}