using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*Спроектировано и разработано Octavian-imp*/

namespace WindowsFormsApp11
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.DarkOrange;
            button1.ForeColor = Color.White;
            button1.Cursor = Cursors.Hand;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightGray;
            button1.ForeColor = Color.Black;
            button1.Cursor = Cursors.Default;
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.BackColor = Color.DarkOrange;
            button2.ForeColor = Color.White;
            button2.Cursor = Cursors.Hand;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.LightGray;
            button2.ForeColor = Color.Black;
            button2.Cursor = Cursors.Default;
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            button3.BackColor = Color.DarkOrange;
            button3.ForeColor = Color.White;
            button3.Cursor = Cursors.Hand;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.LightGray;
            button3.ForeColor = Color.Black;
            button3.Cursor = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ShowAllForm().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new AddForm().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new DeleteForm().Show();
        }
    }
}
