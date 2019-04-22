using System.Windows.Forms;

namespace EventTextBoxs_Win
{
    public partial class Form1 : Form
    {
        TextBox tb;
        public Form1()
        {
            InitializeComponent();
            // Или так
            foreach (Control control in Controls)
            {
                tb = control as TextBox;
                if (tb != null)
                {// Надо учесть что все TextBox не имеют события KeyPress
                    tb.KeyPress += textBox_KeyPress;
                }// Иначе KeyPress дважды вызовится
            }
            // Или так, если нужны определенные текстбоксы
            for (int i = 0; i < 3; i++)
            {
                (Controls["textBox" + i.ToString()] as TextBox).KeyPress += textBox_KeyPress;
            }   
        }
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
    }
}
