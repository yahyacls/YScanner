using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;


namespace YScanner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
 
        private void button1_Click_1(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();

        }

        private void backgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(500);
            Ping ping;
            IPAddress ipadress;
            PingReply pingReply;
            IPHostEntry host;

            string name;

            Parallel.For(0, 255, (i, ParallelLoopState) =>
            {
                ping = new Ping();
                pingReply = ping.Send(textBox1.Text + i.ToString());
                this.BeginInvoke((Action)delegate ()
                {
                    if (pingReply.Status == IPStatus.Success)
                    {
                        try
                        {
                            ipadress = IPAddress.Parse(textBox1.Text + i.ToString());
                            host = Dns.GetHostEntry(ipadress);
                            name = host.HostName;
                            dataGridView1.Rows.Add();
                            int satir = dataGridView1.Rows.Count - 1;
                            dataGridView1.Rows[satir].Cells[0].Value = textBox1.Text + i.ToString();
                            dataGridView1.Rows[satir].Cells[1].Value = name;
                            dataGridView1.Rows[satir].Cells[2].Value = "Active";





                        }
                        catch (Exception ex)
                        {


                        }
                    }
                });


            });
        }
    }
}
