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
    public partial class Guest : Form
    {
        public Guest()
        {
            InitializeComponent();
        }

        private void Guest_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kINOKINOKINODataSet1.Жанр". При необходимости она может быть перемещена или удалена.
            this.жанрTableAdapter.Fill(this.kINOKINOKINODataSet1.Жанр);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kINOKINOKINODataSet1.Места". При необходимости она может быть перемещена или удалена.
            this.местаTableAdapter.Fill(this.kINOKINOKINODataSet1.Места);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kINOKINOKINODataSet1.Список_реализованных_билетов". При необходимости она может быть перемещена или удалена.
            this.список_реализованных_билетовTableAdapter.Fill(this.kINOKINOKINODataSet1.Список_реализованных_билетов);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kINOKINOKINODataSet1.Фильмы". При необходимости она может быть перемещена или удалена.
            this.фильмыTableAdapter.Fill(this.kINOKINOKINODataSet1.Фильмы);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kINOKINOKINODataSet1.Сеанс_на_фильм". При необходимости она может быть перемещена или удалена.
            this.сеанс_на_фильмTableAdapter.Fill(this.kINOKINOKINODataSet1.Сеанс_на_фильм);
        }


        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Form form1 = new Form1();
            this.Close();
            form1.Show();
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
            фильмыBindingSource.Filter = "Название_фильма like '" + bunifuTextBox1.Text + "%'";
        }

        private void bunifuDataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {
            сеанснафильмBindingSource.Filter = string.Format("Дата = '{0:yyyy-MM-dd}'", bunifuDatepicker1.Value);
        }
    }
}
