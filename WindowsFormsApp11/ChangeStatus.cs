using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using static WindowsFormsApp11.Anim;

namespace WindowsFormsApp11
{
    public partial class ChangeStatus : Form
    {
        DB dataBase = new DB();
        public ChangeStatus()
        {
            InitializeComponent();
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            AnimButton_MouseLeave(sender, e);
        }

        private void button_MouseMove(object sender, MouseEventArgs e)
        {
            AnimButton_MouseMove(sender, e);
        }

        private void ChangeStatus_Load(object sender, EventArgs e)
        {
            string fillStatusesQuery = $"SELECT name FROM statuses ORDER BY id ASC";
            dataBase.openConnection();
            SqlCommand command = new SqlCommand(fillStatusesQuery, dataBase.getConnection());
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader.GetString(0));
            }
            reader.Close();
            dataBase.closeConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(textBox1.Text, out id))
            {
                dataBase.openConnection();
                DateTime date = DateTime.Today;
                string changeStatusQuery = $"UPDATE journal SET date_completion='{date.ToString("yyyy-MM-dd")}', status_id='{comboBox1.SelectedIndex + 1}' where id={id}";
                SqlCommand command = new SqlCommand(changeStatusQuery, dataBase.getConnection());
                command.ExecuteNonQuery();
                MessageBox.Show("Статус заявки успешно изменен", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataBase.closeConnection();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка! Неверный тип данных. Допустимы только числа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
