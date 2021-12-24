using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KINOKINOKINO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Purify()
        {
            bunifuTextBox1.Text = "";
            bunifuTextBox2.Text = "";
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Guest guest = new Guest();
            guest.Show();
            this.Hide();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            Cashier cash = new Cashier();
            if (bunifuTextBox1.Text == "Admin" && bunifuTextBox2.Text == "Admin")
            {
                admin.Show();
                this.Hide();
            }
            else if (bunifuTextBox1.Text == "Cashier" && bunifuTextBox2.Text == "Cashier")
            {
                cash.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверный логин и пароль");
                Purify();
            }
        }
    }
}
