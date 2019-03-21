using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComboBox_DataGridView
{
    public partial class Form1 : Form
    {
        List<string> BMW = new List<string>() { "M3", "M5", "E30", "X5", "X6" };
        List<string> Lada = new List<string>() { "2101", "2105", "2106", "2109", "21015" };
        List<string> Toyota = new List<string>() { "Camry", "Corolla", "Rav4", "Supra" };
        public Form1()
        {
            InitializeComponent();
            List<string> Marka = new List<string>() { "BMW", "Lada", "Toyota" };
            foreach (string s in Marka){comboBox1.Items.Add(s);}
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedIndex)
            {
                case 0:
                    dataGridView1.Rows.Clear();
                    foreach (string item in BMW)
                    {
                        dataGridView1.Rows.Add(item);
                    }
                    break;
                case 1:
                    dataGridView1.Rows.Clear();
                    foreach (string item in Lada)
                    {
                        dataGridView1.Rows.Add(item);
                    }
                    break;
                case 2:
                    dataGridView1.Rows.Clear();
                    foreach (string item in Toyota)
                    {
                        dataGridView1.Rows.Add(item);
                    }
                    break;
            }
        }
    }
}
