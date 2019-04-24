using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadFile
{
    struct Info
    {
        public string FIO;
        public string Book;
        public string Izd;
        public int Year;
    }
    public partial class Form1 : Form
    {
        StreamReader sr;
        StreamWriter sw;
        string file, str;
        string st0 = "Фролов Е. Г.        Ворд                          Дрофа     1920";
        string st1 = "12345678901234567890 23456789012345678901234567890 234567890 234";
        List<string> list_name = new List<string>();
        List<Info> list = new List<Info>();
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            file = openFileDialog1.FileName;
            sr = new StreamReader(file, Encoding.Default);
            sw = new StreamWriter((file.Replace(".", "1.")), false, Encoding.Default);
            Info i1 = new Info();
            while((str=sr.ReadLine())!=null)
            {
                str = "\"" + str + "\",";
                sw.WriteLine(str);
                /*
                i1.FIO = str.Substring(0, 20);
                i1.Book = str.Substring(20, 30);
                i1.Izd = str.Substring(50, 10);
                i1.Year = Convert.ToInt32(str.Substring(60, 4));
                list.Add(i1);
                */
            }
            sr.Close();
            sw.Close();
        }
    }
}
