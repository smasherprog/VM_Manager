using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VM_Manager.Domain
{
    public partial class List_Virtual_Machines : UserControl
    {
        private readonly Libvirt.virConnectPtr _connection;
        private System.Threading.Thread _pollthread = null;
        private bool _keep_polling = true;
        private Int64 Counter = 0;
        public List_Virtual_Machines(Libvirt.virConnectPtr con)
        {
            _connection = con;
            InitializeComponent();
    
            Init_Controls();
        }
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            Stop();
            base.Dispose(disposing);
        }
        private void Init_Controls()
        {
            listView1.Items.Clear();
            Libvirt.virDomainPtr[] vms;
            Libvirt.API.virConnectListAllDomains(_connection, out vms, Libvirt.virConnectListAllDomainsFlags.VIR_CONNECT_LIST_DOMAINS_ACTIVE | Libvirt.virConnectListAllDomainsFlags.VIR_CONNECT_LIST_DOMAINS_INACTIVE);
            foreach(var item in vms)
            {
                Libvirt.API.virDomainGetName(item);
                Libvirt._virDomainInfo info;
                Libvirt.API.virDomainGetInfo(item, out info);

                System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] { "", Libvirt.API.virDomainGetName(item), info.state.ToString() }, info.state == Libvirt.virDomainState.VIR_DOMAIN_RUNNING ? 1 : 0);
                listView1.Items.Add(listViewItem1);
                item.Dispose();
            }
            if(listView1.Items.Count > 0)
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            else
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Stop();
            _pollthread = new System.Threading.Thread(UpdateStats);
            _pollthread.Start();
        }
        void Stop()
        {
            _keep_polling = false;
            if(_pollthread != null)
            {
                _pollthread.Join(2000);
                _pollthread = null;
            }
        }
         void UpdateStats()
        {
            while(_keep_polling)
            {
                try
                {
                    Counter += 1;
                    Libvirt._virNodeCPUStats[] cpustats = null;
                    Libvirt.API.virNodeGetCPUStats(_connection, -1, out cpustats, 0);
                    Libvirt._virNodeMemoryStats[] memstats = null;
                    int parsm = 0;
                    Libvirt.API.virNodeGetMemoryStats(_connection, -1, out memstats, ref parsm);
                  
                    chart1.Invoke((MethodInvoker)delegate
                    {

                        foreach(var item in cpustats)
                        {
                            if(!chart1.Series.Any(a => a.Name == item.field))
                            {
                                var series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
                                series1.ChartArea = "ChartArea1";
                                series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                                series1.Legend = "Legend1";
                                series1.Name = item.field;

                                chart1.Series.Add(series1);
                            }
                            chart1.Series[item.field].Points.AddXY(Counter, item.value);
                        }
                        foreach(var item in memstats)
                        {
                            if(!chart2.Series.Any(a => a.Name == item.field))
                            {
                                var series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
                                series1.ChartArea = "ChartArea1";
                                series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
                                series1.Legend = "Legend1";
                                series1.Name = item.field;
                                chart2.Series.Add(series1);
                            }
                            chart2.Series[item.field].Points.AddXY(Counter, item.value);
                        }
                    });
                } catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
