using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsApp11.Anim;
using System.Data.SqlClient;

namespace WindowsFormsApp11
{
    public partial class AddForm : Form
    {
        DB dataBase = new DB();

        public AddForm()
        {
            InitializeComponent();
        }

        private void textBox_MouseMove(object sender, MouseEventArgs e)
        {
            AnimTextBox_MouseMove(sender, e);
        }

        private void textBox_MouseLeave(object sender, EventArgs e)
        {
            AnimTextBox_MouseLeave(sender, e);
        }

        private void comboBox_MouseMove(object sender, MouseEventArgs e)
        {
            AnimComboBox_MouseMove(sender, e);
        }

        private void comboBox_MouseLeave(object sender, EventArgs e)
        {
            AnimComboBox_MouseLeave(sender, e);
        }

        private void button_MouseMove(object sender, MouseEventArgs e)
        {
            AnimButton_MouseMove(sender, e);
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            AnimButton_MouseLeave(sender, e);
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            dataBase.openConnection();
            string fillComboBoxItemsQuery = $"select name from types order by id asc";
            SqlCommand fillComboBoxItemsCommand = new SqlCommand(fillComboBoxItemsQuery, dataBase.getConnection());
            SqlDataReader reader = fillComboBoxItemsCommand.ExecuteReader();
            while (reader.Read())
            {
                RefreshItemsComboBox(comboBox1, reader);
            }
            reader.Close();
            dataBase.closeConnection();
        }

        private void RefreshItemsComboBox(ComboBox comboBox, IDataRecord record)
        {
            comboBox.Items.Add($"{record.GetString(0)}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();
            string name = textBox1.Text;
            int quantity;
            if (int.TryParse(textBox2.Text, out quantity))
            {
                int IdType = comboBox1.SelectedIndex + 1;
                string type = comboBox1.Text;
                string addQuery = $"insert into resources (name, type, quantity) values ('{name}','{IdType}','{quantity}')";
                SqlCommand addQueryCommand = new SqlCommand(addQuery, dataBase.getConnection());
                addQueryCommand.ExecuteNonQuery();
                MessageBox.Show($"Добавлена запись:\n Наименование:'{name}'\n Тип устройства:'{type}'\n Количество: {quantity}","Успешно)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Неверный тип данных! Введите число", "Ошибка(", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataBase.closeConnection();
        }
    }
}
