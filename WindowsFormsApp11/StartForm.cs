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

/*Спроектировано и разработано Octavian-imp (ссылка на профиль GitHub: https://github.com/Octavian-imp )*/

namespace WindowsFormsApp11
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
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
