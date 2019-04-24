using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form1Button
{
    public partial class Form1 : Form
    {
        int a = 0;
        int[] arr;
        Random rand = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                a = int.Parse(textBox1.Text);
                arr = new int[a];
                label3.Text = "";
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = rand.Next(0, 100);
                    label3.Text += arr[i].ToString() + " ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
    }
    
}
