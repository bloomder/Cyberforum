using System;
using System.Windows.Forms;

namespace Textbox1
{
    public partial class Form1 : Form
    {
        int rez = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rez += Convert.ToInt32(textBox1.Text);
            textBox2.Text = rez.ToString();
        }
    }
}
