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
    public partial class Cashier : Form
    {
        public Cashier()
        {
            InitializeComponent();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Form form1 = new Form1();
            this.Close();
            form1.Show();
        }

        private void Cashier_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kINOKINOKINODataSet1.Жанр". При необходимости она может быть перемещена или удалена.
            this.жанрTableAdapter.Fill(this.kINOKINOKINODataSet1.Жанр);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kINOKINOKINODataSet1.Места". При необходимости она может быть перемещена или удалена.
            this.местаTableAdapter1.Fill(this.kINOKINOKINODataSet1.Места);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kINOKINOKINODataSet1.Список_реализованных_билетов". При необходимости она может быть перемещена или удалена.
            this.список_реализованных_билетовTableAdapter.Fill(this.kINOKINOKINODataSet1.Список_реализованных_билетов);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kINOKINOKINODataSet1.Фильмы". При необходимости она может быть перемещена или удалена.
            this.фильмыTableAdapter1.Fill(this.kINOKINOKINODataSet1.Фильмы);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kINOKINOKINODataSet1.Сеанс_на_фильм". При необходимости она может быть перемещена или удалена.
            this.сеанс_на_фильмTableAdapter.Fill(this.kINOKINOKINODataSet1.Сеанс_на_фильм);
        }
        public void Upd()
        {
            this.жанрTableAdapter.Fill(this.kINOKINOKINODataSet1.Жанр);
            this.местаTableAdapter1.Fill(this.kINOKINOKINODataSet1.Места);
            this.сеанс_на_фильмTableAdapter.Fill(this.kINOKINOKINODataSet1.Сеанс_на_фильм);
            this.список_реализованных_билетовTableAdapter.Fill(this.kINOKINOKINODataSet1.Список_реализованных_билетов);
            this.фильмыTableAdapter1.Fill(this.kINOKINOKINODataSet1.Фильмы);
            bunifuTextBox1.Text = "";
            bunifuTextBox2.Text = "";
        }

        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {
            сеанснафильмBindingSource.Filter = string.Format("Дата = '{0:yyyy-MM-dd}'", bunifuDatepicker1.Value);
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            bunifuPages1.SelectedIndex = 0;
            bunifuDatepicker1.Show();
            bunifuTextBox1.Show();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            bunifuPages1.SelectedIndex = 1;
            bunifuDatepicker1.Hide();
            bunifuTextBox1.Hide();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            try
            {
                KINOKINOKINODataSet1TableAdapters.QueriesTableAdapter sp = new KINOKINOKINODataSet1TableAdapters.QueriesTableAdapter();
                sp.INS_Список_реализованных_билетов(Convert.ToInt32(bunifuTextBox2.Text), Convert.ToInt32(bunifuDropdown1.SelectedValue));
                Upd();
            }
            catch
            {
                MessageBox.Show("Билет продан");
            }
        }

        private void bunifuTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            фильмыBindingSource.Filter = "Название_фильма like '" + bunifuTextBox1.Text + "%'";
        }
    }
}
