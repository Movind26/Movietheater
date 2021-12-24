using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace KINOKINOKINO
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        public BindingList<Seans> sen = new BindingList<Seans>();

        private void Admin_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kINOKINOKINODataSet1.Жанр". При необходимости она может быть перемещена или удалена.
            this.жанрTableAdapter.Fill(this.kINOKINOKINODataSet1.Жанр);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kINOKINOKINODataSet1.Фильмы". При необходимости она может быть перемещена или удалена.
            this.фильмыTableAdapter.Fill(this.kINOKINOKINODataSet1.Фильмы);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kINOKINOKINODataSet1.Места". При необходимости она может быть перемещена или удалена.
            this.местаTableAdapter.Fill(this.kINOKINOKINODataSet1.Места);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kINOKINOKINODataSet1.Зал". При необходимости она может быть перемещена или удалена.
            this.залTableAdapter.Fill(this.kINOKINOKINODataSet1.Зал);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kINOKINOKINODataSet1.Сеанс_на_фильм". При необходимости она может быть перемещена или удалена.
            this.сеанс_на_фильмTableAdapter.Fill(this.kINOKINOKINODataSet1.Сеанс_на_фильм);
            //dataGridView1.DataSource = sen;
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kINOKINOKINODataSet1.Сеанс". При необходимости она может быть перемещена или удалена.
            this.сеансTableAdapter.Fill(this.kINOKINOKINODataSet1.Сеанс);

        }
        private void Upd()
        {
            this.жанрTableAdapter.Fill(this.kINOKINOKINODataSet1.Жанр);
            this.фильмыTableAdapter.Fill(this.kINOKINOKINODataSet1.Фильмы);
            this.местаTableAdapter.Fill(this.kINOKINOKINODataSet1.Места);
            this.залTableAdapter.Fill(this.kINOKINOKINODataSet1.Зал);
            this.сеанс_на_фильмTableAdapter.Fill(this.kINOKINOKINODataSet1.Сеанс_на_фильм);
            this.сеансTableAdapter.Fill(this.kINOKINOKINODataSet1.Сеанс);
        }
        public class Seans
        {
            public int Номер_сеанса { get; set; }
            public DateTime Дата { get; set; }
            public decimal Доплата_за_3D { get; set; }
        }
        private void dataGridView1_DataError_1(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Некорректные данные");
        }

        private void bunifuButton1_Click(object sender, EventArgs e) //кнопка закрыть
        {
            Form form1 = new Form1();
            this.Close();
            form1.Show();
        }

        #region Переходы по вкладкам
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            bunifuPages1.SelectedIndex = 0;
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            bunifuPages1.SelectedIndex = 2;
        }
        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            bunifuPages1.SelectedIndex = 1;
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            bunifuPages1.SelectedIndex = 3;
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            bunifuPages1.SelectedIndex = 4;
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            bunifuPages1.SelectedIndex = 5;
        }

        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
            bunifuPages1.SelectedIndex = 6;
        }
        #endregion
        
        #region Поиск
        private void bunifuTextBox1_TextChanged(object sender, EventArgs e) //поиск по названию
        {
            //(bunifuDataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Название_фильма LIKE '{0}%'", bunifuTextBox1.Text);
        }
        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e) //поиск по дате
        {
            сеанснафильмBindingSource.Filter = string.Format("Дата = '{0:yyyy-MM-dd}'", bunifuDatepicker1.Value);
        }
        #endregion

        #region Добавление
        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            try
            {
                KINOKINOKINODataSet1TableAdapters.QueriesTableAdapter sp = new KINOKINOKINODataSet1TableAdapters.QueriesTableAdapter();
                sp.INS_Фильмы(Convert.ToInt32(bunifuDropdown1.SelectedValue), bunifuTextBox3.Text, bunifuTextBox2.Text);
                Upd();
            }
            catch
            {
                MessageBox.Show("Некорректные данные");
            }
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            try
            {
                KINOKINOKINODataSet1TableAdapters.QueriesTableAdapter sp = new KINOKINOKINODataSet1TableAdapters.QueriesTableAdapter();
                sp.INS_Жанр(bunifuTextBox4.Text);
                Upd();
            }
            catch
            {
                MessageBox.Show("Некорректные данные");
            }
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            try
            {
                KINOKINOKINODataSet1TableAdapters.QueriesTableAdapter sp = new KINOKINOKINODataSet1TableAdapters.QueriesTableAdapter();
                sp.INS_Сеанс_на_фильм(Convert.ToInt32(bunifuDropdown3.SelectedValue), Convert.ToInt32(bunifuDropdown2.SelectedValue), Convert.ToDateTime(bunifuDatepicker2.Value), Convert.ToDecimal(bunifuTextBox5.Text));
                Upd();
            }
            catch
            {
                MessageBox.Show("Некорректные данные");
            }
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            try
            {
                KINOKINOKINODataSet1TableAdapters.QueriesTableAdapter sp = new KINOKINOKINODataSet1TableAdapters.QueriesTableAdapter();
                sp.INS_зал(bunifuTextBox6.Text);
                Upd();
            }
            catch
            {
                MessageBox.Show("Некорректные данные");
            }
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            try
            {
                KINOKINOKINODataSet1TableAdapters.QueriesTableAdapter sp = new KINOKINOKINODataSet1TableAdapters.QueriesTableAdapter();
                sp.INS_Места(Convert.ToInt32(bunifuDropdown4.SelectedValue), bunifuTextBox10.Text, Convert.ToInt32(bunifuTextBox9.Text), Convert.ToInt32(bunifuTextBox8.Text), Convert.ToDecimal(bunifuTextBox7.Text));
                Upd();
            }
            catch
            {
                MessageBox.Show("Некорректные данные");
            }
        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            try
            {
                KINOKINOKINODataSet1TableAdapters.QueriesTableAdapter sp = new KINOKINOKINODataSet1TableAdapters.QueriesTableAdapter();
                sp.INS_Сеанс(Convert.ToInt32(bunifuDropdown5.SelectedValue), Convert.ToDateTime(bunifuDatepicker3.Value), Convert.ToDateTime(bunifuDatepicker4.Value), bunifuTextBox13.Text, bunifuTextBox12.Text, bunifuTextBox11.Text);
                Upd();
            }
            catch
            {
                MessageBox.Show("Некорректные данные");
            }
        }
        #endregion

        #region Редактирование
        private void bunifuButton9_Click(object sender, EventArgs e)
        {
            KINOKINOKINODataSet1TableAdapters.QueriesTableAdapter queries = new KINOKINOKINODataSet1TableAdapters.QueriesTableAdapter();
            queries.UPD_Сеанс_на_фильм(Convert.ToInt32(bunifuDataGridView2.CurrentRow.Cells[0].Value), Convert.ToInt32(bunifuDropdown3.SelectedValue), Convert.ToInt32(bunifuDropdown2.SelectedValue), Convert.ToDateTime(bunifuDatepicker2.Value), Convert.ToDecimal(bunifuTextBox5.Text));
            Upd();
        }
        private void bunifuButton11_Click(object sender, EventArgs e)
        {
            KINOKINOKINODataSet1TableAdapters.QueriesTableAdapter queries = new KINOKINOKINODataSet1TableAdapters.QueriesTableAdapter();
            queries.UPD_Фильмы(Convert.ToInt32(bunifuDataGridView3.CurrentRow.Cells[0].Value), Convert.ToInt32(bunifuDropdown1.SelectedValue), bunifuTextBox3.Text, bunifuTextBox2.Text);
            Upd();
        }
        private void bunifuButton13_Click(object sender, EventArgs e)
        {
            KINOKINOKINODataSet1TableAdapters.QueriesTableAdapter queries = new KINOKINOKINODataSet1TableAdapters.QueriesTableAdapter();
            queries.UPD_Жанр(Convert.ToInt32(bunifuDataGridView4.CurrentRow.Cells[0].Value), bunifuTextBox4.Text);
            Upd();
        }
        private void bunifuButton15_Click(object sender, EventArgs e)
        {
            KINOKINOKINODataSet1TableAdapters.QueriesTableAdapter queries = new KINOKINOKINODataSet1TableAdapters.QueriesTableAdapter();
            queries.UPD_Зал(Convert.ToInt32(bunifuDataGridView5.CurrentRow.Cells[0].Value), bunifuTextBox6.Text);
            Upd();
        }
        private void bunifuButton17_Click(object sender, EventArgs e)
        {
            KINOKINOKINODataSet1TableAdapters.QueriesTableAdapter queries = new KINOKINOKINODataSet1TableAdapters.QueriesTableAdapter();
            queries.UPD_Места(Convert.ToInt32(bunifuDataGridView6.CurrentRow.Cells[0].Value), Convert.ToInt32(bunifuDropdown4.SelectedValue), bunifuTextBox10.Text, Convert.ToInt32(bunifuTextBox9.Text), Convert.ToInt32(bunifuTextBox8.Text), Convert.ToDecimal(bunifuTextBox7.Text));
            Upd();
        }
        private void bunifuButton19_Click(object sender, EventArgs e)
        {
            KINOKINOKINODataSet1TableAdapters.QueriesTableAdapter queries = new KINOKINOKINODataSet1TableAdapters.QueriesTableAdapter();
            queries.UPD_Сеанс(Convert.ToInt32(bunifuDataGridView7.CurrentRow.Cells[0].Value), Convert.ToInt32(bunifuDropdown5.SelectedValue), Convert.ToDateTime(bunifuDatepicker3.Value), Convert.ToDateTime(bunifuDatepicker4.Value), bunifuTextBox13.Text, bunifuTextBox12.Text, bunifuTextBox11.Text);
            Upd();
        }
        #endregion

        #region Удаление
        private void bunifuButton8_Click(object sender, EventArgs e)
        {
            KINOKINOKINODataSet1TableAdapters.QueriesTableAdapter queries = new KINOKINOKINODataSet1TableAdapters.QueriesTableAdapter();
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                queries.DEL_Сеанс_на_фильм(Convert.ToInt32(bunifuDataGridView2.CurrentRow.Cells[0].Value));
                Upd();
            }
            else
            {
                MessageBox.Show("Выберите данные");
            }
        }
        private void bunifuButton10_Click(object sender, EventArgs e)
        {
            KINOKINOKINODataSet1TableAdapters.QueriesTableAdapter queries = new KINOKINOKINODataSet1TableAdapters.QueriesTableAdapter();
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                queries.DEL_Фильмы(Convert.ToInt32(bunifuDataGridView3.CurrentRow.Cells[0].Value));
                Upd();
            }
            else
            {
                MessageBox.Show("Выберите данные");
            }
        }
        private void bunifuButton12_Click(object sender, EventArgs e)
        {
            KINOKINOKINODataSet1TableAdapters.QueriesTableAdapter queries = new KINOKINOKINODataSet1TableAdapters.QueriesTableAdapter();
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                queries.DEL_жанр(Convert.ToInt32(bunifuDataGridView4.CurrentRow.Cells[0].Value));
                Upd();
            }
            else
            {
                MessageBox.Show("Выберите данные");
            }
        }
        private void bunifuButton14_Click(object sender, EventArgs e)
        {
            KINOKINOKINODataSet1TableAdapters.QueriesTableAdapter queries = new KINOKINOKINODataSet1TableAdapters.QueriesTableAdapter();
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //queries.DEL_зал(Convert.ToInt32(bunifuDataGridView5.CurrentRow.Cells[0].Value));
                Upd();
            }
            else
            {
                MessageBox.Show("Выберите данные");
            }
        }

        private void bunifuButton16_Click(object sender, EventArgs e)
        {
            KINOKINOKINODataSet1TableAdapters.QueriesTableAdapter queries = new KINOKINOKINODataSet1TableAdapters.QueriesTableAdapter();
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //queries.DEL_места(Convert.ToInt32(bunifuDataGridView6.CurrentRow.Cells[0].Value));
                Upd();
            }
            else
            {
                MessageBox.Show("Выберите данные");
            }
        }

        private void bunifuButton18_Click(object sender, EventArgs e)
        {
            KINOKINOKINODataSet1TableAdapters.QueriesTableAdapter queries = new KINOKINOKINODataSet1TableAdapters.QueriesTableAdapter();
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                queries.DEL_сеанс(Convert.ToInt32(bunifuDataGridView7.CurrentRow.Cells[0].Value));
                Upd();
            }
            else
            {
                MessageBox.Show("Выберите данные");
            }
        }


        #endregion

        #region Корректность ввода

        #region Сеанс на фильм
        private void bunifuTextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Правильными символами считаются цифры,
            // запятая, <Enter> и <Backspace>.
            // Будем считать правильным символом
            // также точку, но заменим ее запятой.
            // Остальные символы запрещены.
            // Чтобы запрещенный символ не отображался 
            // в поле редактирования, присвоим 
            // значение true свойству Handled параметра e

            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                // цифра
                return;
            }

            if (e.KeyChar == '.')
            {
                // точку заменим запятой
                e.KeyChar = ',';
            }

            if (e.KeyChar == ',')
            {
                if (bunifuTextBox5.Text.IndexOf(',') != -1)
                {
                    // запятая уже есть в поле редактирования
                    e.Handled = true;
                }
                return;
            }

            if (Char.IsControl(e.KeyChar))
            {
                // <Enter>, <Backspace>, <Esc>
                if (e.KeyChar == (char)Keys.Enter)
                    // нажата клавиша <Enter>
                    // установить курсор на кнопку OK
                    bunifuButton4.Focus();
                return;
            }

            // остальные символы запрещены
            e.Handled = true;
        }

        private void bunifuTextBox5_TextChange(object sender, EventArgs e)
        {
            bunifuTextBox5.MaxLength = 3;
        }
        #endregion

        #region Фильмы
        private void bunifuTextBox3_TextChange(object sender, EventArgs e)
        {
            bunifuTextBox3.MaxLength = 50;
        }

        private void bunifuTextBox2_TextChange(object sender, EventArgs e)
        {
            bunifuTextBox2.MaxLength = 50;
        }
        #endregion

        #region Жанры
        private void bunifuTextBox4_TextChange(object sender, EventArgs e)
        {
            bunifuTextBox4.MaxLength = 50;
        }

        #endregion

        #region Залы
        private void bunifuTextBox6_TextChange(object sender, EventArgs e)
        {
            bunifuTextBox6.MaxLength = 50;
        }
        #endregion

        #region Места

        private void bunifuTextBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                // цифра
                return;
            }

            if (e.KeyChar == '.')
            {
                // точку заменим запятой
                e.KeyChar = ',';
            }

            if (e.KeyChar == ',')
            {
                if (bunifuTextBox5.Text.IndexOf(',') != -1)
                {
                    // запятая уже есть в поле редактирования
                    e.Handled = true;
                }
                return;
            }

            if (Char.IsControl(e.KeyChar))
            {
                // <Enter>, <Backspace>, <Esc>
                if (e.KeyChar == (char)Keys.Enter)
                    // нажата клавиша <Enter>
                    // установить курсор на кнопку OK
                    bunifuButton6.Focus();
                return;
            }

            // остальные символы запрещены
            e.Handled = true;
        }

        private void bunifuTextBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                // цифра
                return;
            }

            if (e.KeyChar == '.')
            {
                // точку заменим запятой
                e.KeyChar = ',';
            }

            if (e.KeyChar == ',')
            {
                if (bunifuTextBox5.Text.IndexOf(',') != -1)
                {
                    // запятая уже есть в поле редактирования
                    e.Handled = true;
                }
                return;
            }

            if (Char.IsControl(e.KeyChar))
            {
                // <Enter>, <Backspace>, <Esc>
                if (e.KeyChar == (char)Keys.Enter)
                    // нажата клавиша <Enter>
                    // установить курсор на кнопку OK
                    bunifuButton6.Focus();
                return;
            }

            // остальные символы запрещены
            e.Handled = true;
        }

        private void bunifuTextBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                // цифра
                return;
            }

            if (e.KeyChar == '.')
            {
                // точку заменим запятой
                e.KeyChar = ',';
            }

            if (e.KeyChar == ',')
            {
                if (bunifuTextBox5.Text.IndexOf(',') != -1)
                {
                    // запятая уже есть в поле редактирования
                    e.Handled = true;
                }
                return;
            }

            if (Char.IsControl(e.KeyChar))
            {
                // <Enter>, <Backspace>, <Esc>
                if (e.KeyChar == (char)Keys.Enter)
                    // нажата клавиша <Enter>
                    // установить курсор на кнопку OK
                    bunifuButton6.Focus();
                return;
            }

            // остальные символы запрещены
            e.Handled = true;
        }
        private void bunifuTextBox10_TextChange(object sender, EventArgs e)
        {
            bunifuTextBox10.MaxLength = 20;
        }

        private void bunifuTextBox9_TextChange(object sender, EventArgs e)
        {
            bunifuTextBox9.MaxLength = 2;
        }

        private void bunifuTextBox8_TextChange(object sender, EventArgs e)
        {
            bunifuTextBox8.MaxLength = 2;
        }

        private void bunifuTextBox7_TextChange(object sender, EventArgs e)
        {
            bunifuTextBox7.MaxLength = 10;
        }
        #endregion

        #region Сеансы
        private void bunifuTextBox13_TextChange(object sender, EventArgs e)
        {
            bunifuTextBox13.MaxLength = 1;
        }

        private void bunifuTextBox12_TextChange(object sender, EventArgs e)
        {
            bunifuTextBox12.MaxLength = 1;
        }

        private void bunifuTextBox11_TextChange(object sender, EventArgs e)
        {
            bunifuTextBox11.MaxLength = 1;
        }
        #endregion

        #endregion

        #region Экспорт в Excel
        private void ExportToExcel()
        {
            //Excel xl = new Excel(); //создаем инстанс

            xl.FileOpen("c:\\file1.xlsx"); //открываем файл

            var row1Cell6Value = xl.Rows[0][5]; //вытягиваем значение из 1 строки 6й ячейки

            xl.AddRow("asdf", "asdffffff", "5"); //добавляем еще одну строку с 3мя ячейками

            xl.FileSave("c:\\file2.xlsx"); //сохраняем файл
        }

        #endregion
    }
}