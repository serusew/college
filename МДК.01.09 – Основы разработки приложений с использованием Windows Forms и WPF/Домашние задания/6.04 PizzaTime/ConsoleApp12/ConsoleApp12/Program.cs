using System;
using System.Drawing;
using System.Windows.Forms;

namespace PizzaApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PizzaForm());
        }
    }

    public class PizzaForm : Form
    {
        Label labelMainTitle;
        Label labelPizzaType;
        ComboBox comboPizzaType;

        Label labelCount;
        NumericUpDown numericCount;

        Label labelAddities;
        CheckedListBox checkListAddities;

        Button buttonAddPizza;
        Button buttonOrder;

        public PizzaForm()
        {
            this.Text = "PizzaTime";
            this.Size = new Size(380, 520);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(100, 75, 145); 

            labelMainTitle = new Label();
            labelMainTitle.Text = "ЗАКАЗ ПИЦЦЫ";
            labelMainTitle.ForeColor = Color.Orange;
            labelMainTitle.Font = new Font("Arial", 16, FontStyle.Bold);
            labelMainTitle.Location = new Point(20, 15);
            labelMainTitle.Size = new Size(300, 35);
            this.Controls.Add(labelMainTitle);

            labelPizzaType = new Label();
            labelPizzaType.Text = "Выберите пиццу:";
            labelPizzaType.ForeColor = Color.White;
            labelPizzaType.Font = new Font("Arial", 10, FontStyle.Bold);
            labelPizzaType.Location = new Point(20, 65);
            labelPizzaType.Size = new Size(200, 20);
            this.Controls.Add(labelPizzaType);

            comboPizzaType = new ComboBox();
            comboPizzaType.Location = new Point(20, 90);
            comboPizzaType.Size = new Size(320, 25);
            comboPizzaType.Items.Add("PIPIRONI (Пепперони)");
            comboPizzaType.Items.Add("FOUR CHEESE (Четыре сыра)");
            comboPizzaType.Items.Add("MARGARITA (Маргарита)");
            comboPizzaType.SelectedIndex = 0; 
            this.Controls.Add(comboPizzaType);

         
            labelCount = new Label();
            labelCount.Text = "Количество:";
            labelCount.ForeColor = Color.White;
            labelCount.Font = new Font("Arial", 10, FontStyle.Bold);
            labelCount.Location = new Point(20, 135);
            labelCount.Size = new Size(200, 20);
            this.Controls.Add(labelCount);

            numericCount = new NumericUpDown();
            numericCount.Location = new Point(20, 160);
            numericCount.Size = new Size(100, 25);
            numericCount.Minimum = 1;
            numericCount.Maximum = 10;
            numericCount.Value = 1;
            this.Controls.Add(numericCount);

            labelAddities = new Label();
            labelAddities.Text = "Добавки:";
            labelAddities.ForeColor = Color.White;
            labelAddities.Font = new Font("Arial", 10, FontStyle.Bold);
            labelAddities.Location = new Point(20, 205);
            labelAddities.Size = new Size(200, 20);
            this.Controls.Add(labelAddities);

            checkListAddities = new CheckedListBox();
            checkListAddities.Location = new Point(20, 230);
            checkListAddities.Size = new Size(320, 100);
            checkListAddities.Items.Add("Double Cheese (Двойной сыр)");
            checkListAddities.Items.Add("Mayo (Майонез)");
            checkListAddities.Items.Add("Tomate (Помидоры)");
            checkListAddities.Items.Add("Onion (Лук)");
            checkListAddities.Items.Add("Peper (Перец)");
            checkListAddities.Items.Add("Cucumber (Огурец)");
            this.Controls.Add(checkListAddities);

            buttonAddPizza = new Button();
            buttonAddPizza.Text = "ДОБАВИТЬ ПИЦЦУ";
            buttonAddPizza.Location = new Point(20, 360);
            buttonAddPizza.Size = new Size(320, 35);
            buttonAddPizza.BackColor = Color.DeepSkyBlue;
            buttonAddPizza.ForeColor = Color.White;
            buttonAddPizza.Font = new Font("Arial", 10, FontStyle.Bold);
            buttonAddPizza.Click += new EventHandler(КнопкаДобавить_Клик);
            this.Controls.Add(buttonAddPizza);

            buttonOrder = new Button();
            buttonOrder.Text = "ОФОРМИТЬ ЗАКАЗ";
            buttonOrder.Location = new Point(20, 410);
            buttonOrder.Size = new Size(320, 40);
            buttonOrder.BackColor = Color.Orange;
            buttonOrder.ForeColor = Color.White;
            buttonOrder.Font = new Font("Arial", 11, FontStyle.Bold);
            buttonOrder.Click += new EventHandler(КнопкаЗаказ_Клик);
            this.Controls.Add(buttonOrder);
        }

        private void КнопкаДобавить_Клик(object sender, EventArgs e)
        {
            string названиеПиццы = comboPizzaType.SelectedItem.ToString();
            string штук = numericCount.Value.ToString();

            MessageBox.Show("Добавлено в корзину: " + названиеПиццы + " — " + штук + " шт.", "Корзина");
        }

        private void КнопкаЗаказ_Клик(object sender, EventArgs e)
        {
            string выбраннаяПицца = comboPizzaType.SelectedItem.ToString();
            string колво = numericCount.Value.ToString();

            string добавки = "";
            for (int i = 0; i < checkListAddities.CheckedItems.Count; i++)
            {
                добавки = добавки + "\n— " + checkListAddities.CheckedItems[i].ToString();
            }

            if (добавки == "")
            {
                добавки = "\n(без добавок)";
            }

            string итог = "Ваш заказ принят!\n\nПицца: " + выбраннаяПицца +
                          "\nКоличество: " + колво + " шт.\nДобавки:" + добавки;

            MessageBox.Show(итог, "Успешный заказ!");
        }
    }
}