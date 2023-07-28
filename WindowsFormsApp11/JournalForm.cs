using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static WindowsFormsApp11.Anim;

namespace WindowsFormsApp11
{
    public partial class JournalForm : Form
    {
        DB dataBase = new DB();
        public JournalForm()
        {
            InitializeComponent();
        }

        private void JournalForm_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string journalQuery = $"select * from journal";

            SqlCommand command = new SqlCommand(journalQuery, dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();
            if (reader.GetName(0).Length > 0)
            {
                reader.Close();
                createColumns();
                refreshDataGrid(dataGridView1);
            }
        }

        private void createColumns()
        {
            string query = $"select * from journal";

            dataBase.openConnection();

            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                dataGridView1.Columns.Add("id", reader.GetName(0));
                dataGridView1.Columns.Add("id_resource", reader.GetName(1));
                dataGridView1.Columns.Add("date_create", reader.GetName(2));
                dataGridView1.Columns.Add("quantity", reader.GetName(3));
                dataGridView1.Columns.Add("date_completion", reader.GetName(4));
                dataGridView1.Columns.Add("status_id", reader.GetName(5));
            }
            reader.Close();
            dataBase.closeConnection();
        }

        private void refreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string query = $"select * from journal";

            SqlCommand command = new SqlCommand(query, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                readSingleRow(dgw, reader);
            }
            reader.Close();
            dataBase.closeConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            refreshDataGrid(dataGridView1);
        }

        private void readSingleRow(DataGridView dgw, IDataReader record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetInt32(1), Convert.ToDateTime(record.GetDateTime(2)).ToString("dd/MM/yyyy"), record.GetInt32(3), Convert.ToDateTime(record.GetDateTime(4)).ToString("dd/MM/yyyy"), record.GetInt32(5));
        }

        private void button_MouseMove(object sender, MouseEventArgs e)
        {
            AnimButton_MouseMove(sender, e);
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            AnimButton_MouseLeave(sender, e);
        }
    }
}
