using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordWin
{
    public partial class Form1 : Form
    {
        string file, st, txt;
        long k = 0;
        WordClass wc;
        Task task;
        public Form1()
        {
            InitializeComponent();
        }
        class SettingsControls
        {
            public static void VisibleOn(Control obj)
            {
                if (obj.InvokeRequired)
                {
                    obj.Invoke(new Action(() => obj.Visible = true));
                }
                else
                {
                    obj.Visible = true;
                }
            }
            public static void EnableOn(Control obj)
            {
                if (obj.InvokeRequired)
                {
                    obj.Invoke(new Action(() => obj.Enabled = true));
                }
                else
                {
                    obj.Enabled = true;
                }
            }
            public static void EnableOff(Control obj)
            {
                if (obj.InvokeRequired)
                {
                    obj.Invoke(new Action(() => obj.Enabled = false));
                }
                else
                {
                    obj.Enabled = false;
                }
            }
            public static void RichTextBoxAdd(Control obj, string str)
            {
                str += "\n";
                if (obj.InvokeRequired)
                {
                    obj.Invoke(new Action(() => obj.Text += str));
                }
                else
                {
                    obj.Text += str;
                }
            }

        }
        private void button1_Click(object sender, System.EventArgs e)
        {
            Location = new Point(new Random().Next(1, 800), new Random().Next(1, 800));
            /*
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            file = openFileDialog1.FileName; richTextBox1.Clear();       
            if (!
                 (
                   (file.Substring(file.Length - 4) == "docx") ||
                   (file.Substring(file.Length - 3) == "doc")
                  )
               )
            {
                MessageBox.Show("Не Word файл!!!");
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                SettingsButton();
                SettingsRichTextBox();
                task = new Task(TaskMethod);
                task.Start();
                button1.Visible = false;
            }      
            */
        }
        private void ClearStringWord()
        {
            wc.word_doc.Paragraphs[1].Range.Delete();
            MessageBox.Show(wc.word_doc.Paragraphs.Count.ToString());
        }
        private void WriteWord()
        {
            file = Application.StartupPath + "\\Two.docx";
            wc = new WordClass(file);
            wc.OpenWordDoc(); st = "";
            if(richTextBox1.InvokeRequired)
            {
                richTextBox1.Invoke(new Action(() => k = richTextBox1.Text.Length));
                richTextBox1.Invoke(new Action(() => txt = richTextBox1.Text));
            }
            else
            {
                k = richTextBox1.Text.Length;
                txt = richTextBox1.Text;
            }
            for (int i = 0; i < k; i++)
            {
                if(txt[i].Equals('\n'))
                {
                    wc.word_doc.Paragraphs.Add((object)st); st = "";
                }
                else
                {
                    st += txt[i];
                }
            }
            wc.CloseWordDoc();
        }
        private void ReadWord()
        {
            for (int i = 0; i < wc.word_doc.Paragraphs.Count; i++)
            {
                SettingsControls.RichTextBoxAdd(richTextBox1, wc.word_doc.Paragraphs[i + 1].Range.Text);
            }
        }
        private void TaskMethod()
        {
            SettingsControls.EnableOff(richTextBox1);

            wc = new WordClass(file);
            wc.OpenWordDoc();
            ReadWord();
            wc.CloseWordDoc();
            WriteWord();
            SettingsControls.EnableOn(richTextBox1);
            SettingsControls.VisibleOn(button1);
            SettingsControls.VisibleOn(button2);
            SettingsControls.VisibleOn(button3);

        }
        private void SettingsButton()
        {
            button1.Location = new Point(10, 10);
            button2.Location = new Point(105, 10);
            button3.Location = new Point(185, 10);
        }
        private void SettingsRichTextBox()
        {
            richTextBox1.Location = new Point(10, 40);
            richTextBox1.Width = this.Width - 40;
            richTextBox1.Height = this.Height - 100;
            richTextBox1.Visible = true;
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            richTextBox1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
