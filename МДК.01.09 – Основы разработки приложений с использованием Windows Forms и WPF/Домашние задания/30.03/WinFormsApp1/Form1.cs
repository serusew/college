namespace WinFormsApp1
{
    public partial class formMain : Form
    {
        private int orderCounter = 1;
        public formMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textPickup.Text == "")
            {
                MessageBox.Show("Введите адрес подачи!");
                return;
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите адрес назначения!");
                return;
            }
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите класс автомобиля!");
                return;
            }
            string order = "Заказ #" + orderCounter + ": " +
                           textPickup.Text + " → " + textBox1.Text +
                           ", " + comboBox1.Text +
                           ", " + numericUpDown1.Value + " пасс.";

            history.Items.Add(order);
            orderCounter = orderCounter + 1;
            textPickup.Text = "";
            textBox1.Text = "";
            MessageBox.Show("Такси заказано!", "Успех");
        }

        private void destin_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
