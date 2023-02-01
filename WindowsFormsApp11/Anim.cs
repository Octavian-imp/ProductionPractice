using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp11
{
    internal class Anim
    {
        //Анимация для кнопок
        public static void AnimButton_MouseMove(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.DarkOrange;
            btn.ForeColor = Color.White;
            btn.Cursor = Cursors.Hand;
        }
      
        public static void AnimButton_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.LightGray;
            btn.ForeColor = Color.Black;
            btn.Cursor = Cursors.Default;
        }
        
        //Анимация для полей
        public static void AnimTextBox_MouseMove(object sender, MouseEventArgs e)
        {
            TextBox txt = sender as TextBox;
            txt.BackColor = Color.LightGray;
        }

        public static void AnimTextBox_MouseLeave(object sender, EventArgs e)
        {
            TextBox txt= sender as TextBox; 
            txt.BackColor= Color.DimGray;
        }

        //Анимация для выпадающих списков с выбором значения
        public static void AnimComboBox_MouseMove(object sender, MouseEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            cmb.BackColor = Color.LightGray;
        }

        public static void AnimComboBox_MouseLeave(object sender, EventArgs e)
        {
            ComboBox cmb= sender as ComboBox;
            cmb.BackColor= Color.DimGray;
        }
    }
}
