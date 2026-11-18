using System;
using System.Drawing;
using System.Windows.Forms;

namespace CurrencyApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Application.Run(new CurrencyForm());
        }
    }

    public class CurrencyForm : Form
    {
        Label labelTitle;

     
        Label labelRates;
        Label labelBtc;
        Label labelEth;
        Label labelLtc;

 
        Label labelConverterTitle;
        TextBox textAmount;
        ComboBox comboFrom;
        ComboBox comboTo;
        Button buttonConvert;
        Label labelResult;

        Panel panelChart;

        public CurrencyForm()
        {
            this.Text = "Курсы Валют и Конвертер";
            this.Size = new Size(550, 480);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(24, 24, 36); 

            labelTitle = new Label();
            labelTitle.Text = "Мониторинг Валют";
            labelTitle.ForeColor = Color.White;
            labelTitle.Font = new Font("Arial", 16, FontStyle.Bold);
            labelTitle.Location = new Point(20, 15);
            labelTitle.Size = new Size(300, 30);
            this.Controls.Add(labelTitle);

            labelRates = new Label();
            labelRates.Text = "Текущие курсы:";
            labelRates.ForeColor = Color.DarkGray;
            labelRates.Font = new Font("Arial", 10, FontStyle.Bold);
            labelRates.Location = new Point(20, 60);
            labelRates.Size = new Size(150, 20);
            this.Controls.Add(labelRates);

            labelBtc = new Label();
            labelBtc.Text = "Bitcoin (BTC):  62,345 USD  ( -4.02% )";
            labelBtc.ForeColor = Color.OrangeRed;
            labelBtc.Font = new Font("Arial", 10, FontStyle.Regular);
            labelBtc.Location = new Point(20, 85);
            labelBtc.Size = new Size(250, 20);
            this.Controls.Add(labelBtc);

            labelEth = new Label();
            labelEth.Text = "Ethereum (ETH):  3,554 USD  ( +3.67% )";
            labelEth.ForeColor = Color.LightGreen;
            labelEth.Font = new Font("Arial", 10, FontStyle.Regular);
            labelEth.Location = new Point(20, 110);
            labelEth.Size = new Size(250, 20);
            this.Controls.Add(labelEth);

            labelLtc = new Label();
            labelLtc.Text = "Litecoin (LTC):  86.40 USD  ( +1.24% )";
            labelLtc.ForeColor = Color.LightGreen;
            labelLtc.Font = new Font("Arial", 10, FontStyle.Regular);
            labelLtc.Location = new Point(20, 135);
            labelLtc.Size = new Size(250, 20);
            this.Controls.Add(labelLtc);

            labelConverterTitle = new Label();
            labelConverterTitle.Text = "Быстрая Конвертация:";
            labelConverterTitle.ForeColor = Color.DarkGray;
            labelConverterTitle.Font = new Font("Arial", 10, FontStyle.Bold);
            labelConverterTitle.Location = new Point(20, 180);
            labelConverterTitle.Size = new Size(200, 20);
            this.Controls.Add(labelConverterTitle);

            textAmount = new TextBox();
            textAmount.Location = new Point(20, 205);
            textAmount.Size = new Size(80, 20);
            textAmount.Text = "1";
            this.Controls.Add(textAmount);

            comboFrom = new ComboBox();
            comboFrom.Location = new Point(110, 205);
            comboFrom.Size = new Size(70, 20);
            comboFrom.Items.Add("BTC");
            comboFrom.Items.Add("ETH");
            comboFrom.Items.Add("LTC");
            comboFrom.SelectedIndex = 0;
            this.Controls.Add(comboFrom);

            Label labelArrow = new Label();
            labelArrow.Text = "=>";
            labelArrow.ForeColor = Color.White;
            labelArrow.Location = new Point(190, 208);
            labelArrow.Size = new Size(30, 20);
            this.Controls.Add(labelArrow);

            comboTo = new ComboBox();
            comboTo.Location = new Point(220, 205);
            comboTo.Size = new Size(70, 20);
            comboTo.Items.Add("USD");
            comboTo.SelectedIndex = 0;
            this.Controls.Add(comboTo);

            buttonConvert = new Button();
            buttonConvert.Text = "Перевести";
            buttonConvert.Location = new Point(300, 203);
            buttonConvert.Size = new Size(90, 24);
            buttonConvert.BackColor = Color.FromArgb(80, 70, 120);
            buttonConvert.ForeColor = Color.White;
            buttonConvert.Click += new EventHandler(КнопкаПеревода_Клик);
            this.Controls.Add(buttonConvert);

            labelResult = new Label();
            labelResult.Text = "Результат: ...";
            labelResult.ForeColor = Color.Yellow;
            labelResult.Font = new Font("Arial", 11, FontStyle.Bold);
            labelResult.Location = new Point(20, 240);
            labelResult.Size = new Size(350, 25);
            this.Controls.Add(labelResult);

            Label labelChartTitle = new Label();
            labelChartTitle.Text = "График изменения (BTC/USD):";
            labelChartTitle.ForeColor = Color.DarkGray;
            labelChartTitle.Font = new Font("Arial", 10, FontStyle.Bold);
            labelChartTitle.Location = new Point(20, 280);
            labelChartTitle.Size = new Size(250, 20);
            this.Controls.Add(labelChartTitle);

            panelChart = new Panel();
            panelChart.Location = new Point(20, 305);
            panelChart.Size = new Size(490, 110);
            panelChart.BackColor = Color.FromArgb(15, 15, 25);
            panelChart.Paint += new PaintEventHandler(РисованиеГрафика);
            this.Controls.Add(panelChart);
        }

        private void КнопкаПеревода_Клик(object sender, EventArgs e)
        {
            double количество = 0;
            if (double.TryParse(textAmount.Text, out количество) == false)
            {
                MessageBox.Show("Введите правильное число элементов!", "Ошибка");
                return;
            }

            string изЧего = comboFrom.SelectedItem.ToString();
            double курс = 0;

            if (изЧего == "BTC")
            {
                курс = 62345;
            }
            else if (изЧего == "ETH")
            {
                курс = 3554;
            }
            else if (изЧего == "LTC")
            {
                курс = 86.40;
            }

            double итого = количество * курс;
            labelResult.Text = "Результат: " + итого.ToString("N2") + " USD";
        }

        private void РисованиеГрафика(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen розовоеПеро = new Pen(Color.FromArgb(235, 30, 120), 2);

            Point[] точки = new Point[]
            {
                new Point(10, 80),
                new Point(80, 50),
                new Point(150, 90),
                new Point(220, 20),
                new Point(290, 75),
                new Point(360, 60),
                new Point(450, 85)
            };

            Pen сероеПеро = new Pen(Color.FromArgb(40, 40, 50), 1);
            g.DrawLine(сероеПеро, 0, 35, 490, 35);
            g.DrawLine(сероеПеро, 0, 70, 490, 70);

            g.DrawLines(розовоеПеро, точки);
        }
    }
}