using System;
using System.Drawing;
using System.Windows.Forms;

namespace SystemMonitorApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MonitorForm());
        }
    }

    public class MonitorForm : Form
    {
        Label labelTitle;
        Label labelCpu;
        Label labelRam;
        Panel panelChart;
        Timer updateTimer;

        int currentCpu = 15;
        int currentRam = 60;
        Random rand = new Random();

        int[] cpuHistory = new int[] { 15, 20, 18, 25, 22, 17, 19, 24, 21, 15 };

        public MonitorForm()
        {
            this.Text = "System Monitor";
            this.Size = new Size(450, 420);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(28, 28, 40); 

            labelTitle = new Label();
            labelTitle.Text = "SYSTEM MONITOR";
            labelTitle.ForeColor = Color.Cyan;
            labelTitle.Font = new Font("Arial", 16, FontStyle.Bold);
            labelTitle.Location = new Point(20, 15);
            labelTitle.Size = new Size(300, 30);
            this.Controls.Add(labelTitle);

            labelCpu = new Label();
            labelCpu.Text = "CPU USAGE: " + currentCpu + "%";
            labelCpu.ForeColor = Color.White;
            labelCpu.Font = new Font("Arial", 12, FontStyle.Bold);
            labelCpu.Location = new Point(40, 65);
            labelCpu.Size = new Size(160, 25);
            this.Controls.Add(labelCpu);

            labelRam = new Label();
            labelRam.Text = "RAM USAGE: " + currentRam + "%";
            labelRam.ForeColor = Color.White;
            labelRam.Font = new Font("Arial", 12, FontStyle.Bold);
            labelRam.Location = new Point(240, 65);
            labelRam.Size = new Size(160, 25);
            this.Controls.Add(labelRam);

            Label labelChartTitle = new Label();
            labelChartTitle.Text = "CPU percent history:";
            labelChartTitle.ForeColor = Color.DarkGray;
            labelChartTitle.Font = new Font("Arial", 10, FontStyle.Regular);
            labelChartTitle.Location = new Point(20, 120);
            labelChartTitle.Size = new Size(200, 20);
            this.Controls.Add(labelChartTitle);

            panelChart = new Panel();
            panelChart.Location = new Point(20, 145);
            panelChart.Size = new Size(390, 180);
            panelChart.BackColor = Color.FromArgb(18, 18, 26);
            panelChart.Paint += new PaintEventHandler(РисованиеГрафика);
            this.Controls.Add(panelChart);

            updateTimer = new Timer();
            updateTimer.Interval = 1000;
            updateTimer.Tick += new EventHandler(ОбновлениеДанных);
            updateTimer.Start();
        }

        private void ОбновлениеДанных(object sender, EventArgs e)
        {
            currentCpu = rand.Next(10, 45);
            currentRam = rand.Next(55, 68);

            labelCpu.Text = "CPU USAGE: " + currentCpu + "%";
            labelRam.Text = "RAM USAGE: " + currentRam + "%";

            for (int i = 0; i < 9; i++)
            {
                cpuHistory[i] = cpuHistory[i + 1];
            }
            cpuHistory[9] = currentCpu;

            panelChart.Invalidate();
        }

        private void РисованиеГрафика(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Pen синееПеро = new Pen(Color.Cyan, 2);
            Pen сераяСетка = new Pen(Color.FromArgb(40, 40, 50), 1);

            g.DrawLine(сераяСетка, 0, 45, 390, 45);
            g.DrawLine(сераяСетка, 0, 90, 390, 90);
            g.DrawLine(сераяСетка, 0, 135, 390, 135);

            for (int i = 0; i < 9; i++)
            {
                int x1 = i * 40 + 15;
                int y1 = 180 - (cpuHistory[i] * 3);

                int x2 = (i + 1) * 40 + 15;
                int y2 = 180 - (cpuHistory[i + 1] * 3);

                g.DrawLine(синееПеро, x1, y1, x2, y2);
            }
        }
    }
}