using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ChangeTxT_Win_
{
    public partial class Form1 : Form
    {
        string file ="One.txt";
        List<string> list = new List<string>();
        StreamWriter sw;
        public Form1()
        {
            InitializeComponent();
            CreateWrite();
        }
        private void CreateWrite()
        {
            list.Add("Текст 1");
            list.Add("Текст 2");
            list.Add("Текст 3");
            list.Add("Текст 2");
            list.Add("Текст 4");
            list.Add("Текст 5");
            list.Add("Текст 0");
            list.Add("Текст 1");
            list.Add("Текст 8");
            list.Add("Текст 10");
            list.Add("Текст 3");
            list.Add("Текст 11");
            list.Add("Текст 5");
            sw = new StreamWriter(file, false, Encoding.Default);
            for (int i = 0; i < list.Count; i++)
            {
                file = list[i];
                sw.WriteLine(file);
            }
            sw.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
