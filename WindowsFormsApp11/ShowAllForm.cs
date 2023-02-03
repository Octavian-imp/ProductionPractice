using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static WindowsFormsApp11.DB;
using static WindowsFormsApp11.Anim;

namespace WindowsFormsApp11
{
    public partial class ShowAllForm : Form
    {
        DB dataBase = new DB();

        public ShowAllForm()
        {
            InitializeComponent();
        }

        private void ShowAllForm_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string query = $"select * from Resources";

            SqlCommand command = new SqlCommand(query, dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();
            if (reader.GetName(0).Length > 0)
            {
                reader.Close();
                CreateColumns();
                RefreshDataGrid(dataGridView1);
            }
            else
            {
                MessageBox.Show("Соединение не установлено", "Провал(", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            dataBase.closeConnection();
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetInt32(2), record.GetInt32(3));
        }

        private void CreateColumns()
        {
            string query = $"select * from Resources";

            dataBase.openConnection();

            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                dataGridView1.Columns.Add("id", reader.GetName(0));
                dataGridView1.Columns.Add("name", reader.GetName(1));
                dataGridView1.Columns.Add("type", reader.GetName(2));
                dataGridView1.Columns.Add("quantity", reader.GetName(3));
            }
            reader.Close();
            dataBase.closeConnection();
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string query = $"select * from Resources";

            SqlCommand command= new SqlCommand(query, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
            dataBase.closeConnection();
        }

        private void button_MouseMove(object sender, MouseEventArgs e)
        {
            AnimButton_MouseMove(sender, e);
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            AnimButton_MouseLeave(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteForm deleteForm = new DeleteForm();
            deleteForm.Show();
        }
    }
}
