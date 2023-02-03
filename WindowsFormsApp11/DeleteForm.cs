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
    public partial class DeleteForm : Form
    {
        DB dataBase = new DB();
        public DeleteForm()
        {
            InitializeComponent();
        }

        private void textBox_MouseLeave(object sender, EventArgs e)
        {
            AnimTextBox_MouseLeave(sender, e);
        }

        private void textBox_MouseMove(object sender, MouseEventArgs e)
        {
            AnimTextBox_MouseMove(sender, e);
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            AnimButton_MouseLeave(sender, e);
        }

        private void button_MouseMove(object sender, MouseEventArgs e)
        {
            AnimButton_MouseMove(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();
            int id;
            if (int.TryParse(textBox1.Text, out id))
            {
                //TODO: сделать обработку ошибки в случае если такого id нет if exists(select id from Resources where id = '{id}')
                string deleteQuery = $"delete from Resources where id = '{id}'";
                SqlCommand commandDelete = new SqlCommand(deleteQuery, dataBase.getConnection());
                int rowsCount = commandDelete.ExecuteNonQuery();
                if (rowsCount == 0)
                {
                    MessageBox.Show("Ошибка! Такой записи не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Предмет удален!", "Запись успешно удалена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                dataBase.closeConnection();
            }
            else
            {
                MessageBox.Show("Введен неверный тип данных. Попробуйте еще раз, 'ID' явлется числовым полем");
            }
        }
    }
}
