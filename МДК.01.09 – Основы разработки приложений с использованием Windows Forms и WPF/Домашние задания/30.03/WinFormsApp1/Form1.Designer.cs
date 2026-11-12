namespace WinFormsApp1
{
    partial class formMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            textPickup = new TextBox();
            destin = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            comboBox1 = new ComboBox();
            numericUpDown1 = new NumericUpDown();
            history = new ListBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Lime;
            button1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new Point(131, 524);
            button1.Name = "button1";
            button1.Size = new Size(209, 61);
            button1.TabIndex = 0;
            button1.Text = "Заказать такси";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textPickup
            // 
            textPickup.Location = new Point(200, 58);
            textPickup.Name = "textPickup";
            textPickup.Size = new Size(241, 27);
            textPickup.TabIndex = 1;
            // 
            // destin
            // 
            destin.AutoSize = true;
            destin.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            destin.Location = new Point(26, 54);
            destin.Name = "destin";
            destin.Size = new Size(144, 28);
            destin.TabIndex = 2;
            destin.Text = "Адрес подачи:\r\n";
            destin.Click += destin_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(200, 125);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(241, 27);
            textBox1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(41, 121);
            label1.Name = "label1";
            label1.Size = new Size(109, 28);
            label1.TabIndex = 4;
            label1.Text = "Куда едем:\r\n";
            label1.Click += label1_Click;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Эконом", "Комфорт", "Бизнес" });
            comboBox1.Location = new Point(59, 224);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 5;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(258, 224);
            numericUpDown1.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(150, 27);
            numericUpDown1.TabIndex = 6;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // history
            // 
            history.FormattingEnabled = true;
            history.Location = new Point(12, 329);
            history.Name = "history";
            history.Size = new Size(458, 144);
            history.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(128, 255, 128);
            label2.Location = new Point(151, 605);
            label2.Name = "label2";
            label2.Size = new Size(174, 20);
            label2.TabIndex = 8;
            label2.Text = "Готов к приёму заказов\r\n";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(258, 190);
            label3.Name = "label3";
            label3.Size = new Size(142, 31);
            label3.TabIndex = 9;
            label3.Text = "пассажиров";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(99, 190);
            label4.Name = "label4";
            label4.Size = new Size(71, 31);
            label4.TabIndex = 10;
            label4.Text = "класс";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(140, 284);
            label5.Name = "label5";
            label5.Size = new Size(185, 31);
            label5.TabIndex = 11;
            label5.Text = "история заказов";
            // 
            // formMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(482, 653);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(history);
            Controls.Add(numericUpDown1);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(destin);
            Controls.Add(textPickup);
            Controls.Add(button1);
            Name = "formMain";
            Text = "Calculator";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textPickup;
        private Label destin;
        private TextBox textBox1;
        private Label label1;
        private ComboBox comboBox1;
        private NumericUpDown numericUpDown1;
        private ListBox history;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}
