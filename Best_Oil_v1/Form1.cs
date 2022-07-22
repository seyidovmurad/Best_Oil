using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Best_Oil
{
    public partial class Form1 : Form
    {
        List<Food> foods;
        private double gasPrice = 0;
        private double SumGasPrice = 0;
        private double SumFoodPrice = 0;
        public Form1()
        {
            InitializeComponent();
            foods = new List<Food>
            {
                new Food("Hot Dog", 1.4),
                new Food("Hamburger",2.4),
                new Food("French Fries",2),
                new Food("Coke",1.1)
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cmb_GasList.DropDownStyle = ComboBoxStyle.DropDownList;
            Cmb_GasList.Items.AddRange((new List<Gas>
            {
               new Gas("AI-92",1),
               new Gas("AI-95",1.4),
               new Gas("Premium",1.6),
               new Gas("Diesel",0.9)
            }).ToArray());
            Cmb_GasList.Items.RemoveAt(0);
            Cmb_GasList.Text = Cmb_GasList.Items[0].ToString();
            
        }

        private void Cmb_GasList_SelectedIndexChanged(object sender, EventArgs e)
        {
            gasPrice = (Cmb_GasList.SelectedItem as Gas).Price;
            Txtb_GasPrice.Text = gasPrice.ToString("C2");
            if (Rb_GasPrice.Checked)
                Txtb_Gas_TextChanged(Txtb_GasPrice, null);
            else if (Rb_Litre.Checked)
                Txtb_Gas_TextChanged(Txtb_Litre, null);
        }

        private void Rb_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rb)
            {
                if (rb.Text == "Litre")
                {
                    Txtb_Litre.Enabled = true;
                    Txtb_Price.Enabled = false;
                    Txtb_Price.Text = default;
                }
                else if (rb.Text == "Price")
                {
                    Txtb_Litre.Enabled = false;
                    Txtb_Price.Enabled = true;
                    Txtb_Litre.Text = default;
                }
            }
        }

        private void Txtb_Gas_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox text && !string.IsNullOrWhiteSpace(text.Text))
            {
                if (Rb_Litre.Checked)
                {
                    SumGasPrice = Convert.ToInt32(text.Text) * gasPrice;
                    Lbl_GasPriceSum.Text = SumGasPrice.ToString("C2");
                    Lbl_GasLitreSum.Text = text.Text;
                }
                else if (Rb_GasPrice.Checked)
                {
                    SumGasPrice = Convert.ToDouble(text.Text);
                    Lbl_GasPriceSum.Text = text.Text;
                    Lbl_GasLitreSum.Text = (Convert.ToDouble(text.Text) / gasPrice).ToString("C2");
                }
            }
            else
            {
                SumGasPrice = 0;
                Lbl_GasPriceSum.Text = "$0";
                Lbl_GasLitreSum.Text = "$0";
            }
            Lbl_SumPrice.Text = (SumGasPrice + SumFoodPrice).ToString("C2");
        }

        private void Txtb_Litre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && e.KeyChar.ToString() != Keys.Back.ToString())
            {
                e.Handled = true;
            }
        }

        private void Txtb_Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && e.KeyChar.ToString() != Keys.Back.ToString())
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void Chckb_Food1_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox check)
            {
                switch (check.Text)
                {
                    case "Hot Dog":
                        Txtb_FoodAmnt1.Enabled = check.Checked;
                        if (!check.Checked)
                            Txtb_FoodAmnt1.Text = "0";
                        break;
                    case "Hamburger":
                        Txtb_FoodAmnt2.Enabled = check.Checked;
                        if (!check.Checked)
                            Txtb_FoodAmnt2.Text = "0";
                        break;
                    case "French Fries":
                        Txtb_FoodAmnt3.Enabled = check.Checked;
                        if (!check.Checked)
                            Txtb_FoodAmnt3.Text = "0";
                        break;
                    case "Coke":
                        Txtb_FoodAmnt4.Enabled = check.Checked;
                        if (!check.Checked)
                            Txtb_FoodAmnt4.Text = "0";
                        break;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox box)
            {
                int a;
                if (string.IsNullOrWhiteSpace(box.Text))
                    a = 0;
                else
                    a = Convert.ToInt32(box.Text);
                switch (box.Name)
                {
                    case "Txtb_FoodAmnt1":
                        foods[0].Amount = a;
                        break;
                    case "Txtb_FoodAmnt2":
                        foods[1].Amount = a;
                        break;
                    case "Txtb_FoodAmnt3":
                        foods[2].Amount = a;
                        break;
                    case "Txtb_FoodAmnt4":
                        foods[3].Amount = a;
                        break;
                }
                SumFoodPrice = 0;
                foreach (var food in foods)
                {
                    SumFoodPrice += food.Amount * food.Price;
                }
                Lbl_SumFoodPrice.Text = SumFoodPrice.ToString("C2");
            }
            Lbl_SumPrice.Text = (SumGasPrice + SumFoodPrice).ToString("C2");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you for choosing us");
            Application.Restart();
        }
    }
}
