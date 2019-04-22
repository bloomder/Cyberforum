using DelTextFile_Win.Source;
using System;
using System.Windows.Forms;

namespace DelTextFile_Win
{
    public partial class Form1 : Form
    {
        FileClass fc;
        string text;
        string[] mas_txt;
        public Form1()
        {
            InitializeComponent();
            fc = new FileClass(@"1.txt");
        }
        private void Obrabotka(string a)
        {
            text = text.Replace("\r", "");
            mas_txt = text.Split(new char[] { '\n' });
            for (int i = 0; i < mas_txt.Length; i++)
            {
                if(mas_txt[i].IndexOf("Текст")!=-1)
                {
                    comboBox1.Items.Add(mas_txt[i]);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)// Кнопка "Считать"
        {
            text = "";
            fc.Read(ref text);
            if (text != "") { Obrabotka(text); }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            for (int i = 0; i < mas_txt.Length; i++)
            {
                if (mas_txt[i] == comboBox1.SelectedItem.ToString())
                {
                    for (int j = i+1; j < mas_txt.Length; j++)
                    {
                        if (mas_txt[j].IndexOf("Текст") != -1)
                        {
                            i = j = mas_txt.Length;                            
                        }
                        else { richTextBox1.Text += mas_txt[j] + "\r\n" ; }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)// Кнопка "Дозаписать"
        {            
            fc.WriteEnd(comboBox1.Text);
            fc.WriteEnd(richTextBox1.Text);
            comboBox1.Items.Clear();
            fc.Read(ref text);
            Obrabotka(text);
        }

        private void button3_Click(object sender, EventArgs e)// Кнопка "Изменить"
        {
            fc.ReWrite();
            for (int i = 0; i < mas_txt.Length; i++)
            {
                if(mas_txt[i]==comboBox1.Text)
                {
                    fc.WriteEnd(mas_txt[i]);
                    fc.WriteEnd(richTextBox1.Text); i++;
                    for (;  i< mas_txt.Length; i++)
                    {
                        if (mas_txt[i].IndexOf("Текст") != -1) { i--; break; }
                    }
                }
                else
                {
                    fc.WriteEnd(mas_txt[i]);
                }
            }
            comboBox1.Items.Clear();
            fc.Read(ref text);
            Obrabotka(text);
        }

        private void button4_Click(object sender, EventArgs e)// Удалить этот текст
        {
            fc.ReWrite();
            for (int i = 0; i < mas_txt.Length; i++)
            {
                if (mas_txt[i] == comboBox1.Text)
                {
                    //fc.WriteEnd(mas_txt[i]);
                    //fc.WriteEnd(richTextBox1.Text);
                    i++;
                    for (; i < mas_txt.Length; i++)
                    {
                        if (mas_txt[i].IndexOf("Текст") != -1) { i--; break; }
                    }
                }
                else
                {
                    fc.WriteEnd(mas_txt[i]);
                }
            }
            comboBox1.Items.Clear();
            fc.Read(ref text);
            Obrabotka(text);
        }
    }
}
