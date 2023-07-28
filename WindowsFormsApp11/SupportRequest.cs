using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static WindowsFormsApp11.Anim;

namespace WindowsFormsApp11
{
    public partial class SupportRequest : Form
    {
        DB dataBase = new DB();
        public SupportRequest()
        {
            InitializeComponent();
        }

        private void SupportRequest_Load(object sender, EventArgs e)
        {
            dataBase.openConnection();
            string fillStatusComboBoxQuery = $"select name from statuses";
            SqlCommand command = new SqlCommand(fillStatusComboBoxQuery, dataBase.getConnection());
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                RefreshItemsComboBox(comboBox1, reader);
            }
            reader.Close();
            dataBase.closeConnection();
        }

        private void RefreshItemsComboBox(ComboBox comboBox, IDataRecord record)
        {
            comboBox.Items.Add(record.GetString(0));
        }

        private void comboBox_MouseLeave(object sender, EventArgs e)
        {
            AnimComboBox_MouseLeave(sender, e);
        }

        private void comboBox_MouseMove(object sender, MouseEventArgs e)
        {
            AnimComboBox_MouseMove(sender, e);
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            AnimButton_MouseLeave(sender, e);
        }

        private void button_MouseMove(object sender, MouseEventArgs e)
        {
            AnimButton_MouseMove(sender, e);
        }

        private void textBox_MouseMove(object sender, MouseEventArgs e)
        {
            AnimTextBox_MouseMove(sender, e);
        }

        private void textBox_MouseLeave(object sender, EventArgs e)
        {
            AnimTextBox_MouseLeave(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();
            int idResource, quantity;
            if (int.TryParse(textBox1.Text, out idResource) && int.TryParse(textBox2.Text, out quantity))
            {
                string status = comboBox1.Text;
                int idStatus = comboBox1.SelectedIndex + 1;
                string supportRequestQuery = $"insert into journal (id_resource, quantity, status_id) values ('{idResource}','{quantity}','{idStatus}')";
                SqlCommand command = new SqlCommand(supportRequestQuery, dataBase.getConnection());
                command.ExecuteNonQuery();
                MessageBox.Show("Запрос на обслуживание аппаратного средств(-а) успешно создан", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный тип данных! Поля 'ID устройства' и 'Количество' должны быть числами", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataBase.closeConnection();
        }
    }
}
