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

namespace WindowsFormsApp11
{
    public partial class DeleteForm : Form
    {
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
    }
}
