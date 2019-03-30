using System;
using System.Windows.Forms;

namespace ComboBox_Win_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                if (!(comboBox1.SelectedIndex <= comboBox2.SelectedIndex - 1))
                {
                    comboBox2.SelectedIndex = -1;
                    MessageBox.Show("НЕЛЬЗЯ!!!");
                }
            }
            else
            {
                comboBox2.SelectedIndex=-1;
                MessageBox.Show("Выберете время отправления!!!");                
            }
        }
    }
}
