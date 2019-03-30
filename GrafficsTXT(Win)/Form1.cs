using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrafficsTXT_Win_
{
    public partial class Form1 : Form
    {

        string file, str,st;
        StreamReader sr;
        int count = 0, cou = 0;
        Task task;
        Info info;
        struct Info
        {
            public float X;
            public float Y;
            public float Z;
        }
        public Form1()
        {            
            InitializeComponent();
        }
        public void Graffics()
        {
            if(chart1.InvokeRequired)
            {
                chart1.Invoke(new Action(() => chart1.Series[0].Points.AddXY(info.X, info.Y)));
            }
            else
            {
                chart1.Series[0].Points.AddXY(info.X, info.Y);
            }
            if (chart2.InvokeRequired)
            {
                chart2.Invoke(new Action(() => chart2.Series[0].Points.AddXY(info.X, info.Z)));
            }
            else
            {
                chart2.Series[0].Points.AddXY(info.X, info.Z);
            }
        }
        public void Method()
        {            
            sr = new StreamReader(file, Encoding.Default);
            info = new Info();cou = 0;
            while ((str = sr.ReadLine()) != null)
            {
                cou++;
                count = 0; st = ""; str = str.Replace(".", ",");
                for (int i = 0; i < str.Length; i++)
                {
                    if ((str[i].Equals(' ')) || (str[i].Equals('\t')) || (i == (str.Length - 1)))
                    {
                        if ((i == (str.Length - 1))) st += str[i];
                        switch (count)
                        {
                            case 0:
                                info.X = Convert.ToSingle(st); st = "";
                                break;
                            case 1:
                                info.Y = Convert.ToSingle(st); st = "";
                                break;
                            case 2:
                                info.Z = Convert.ToSingle(st); st = "";
                                break;
                        }
                        count++;
                    }
                    else
                    {
                        st += str[i];
                    }
                }
                Graffics();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart2.Series[0].Points.Clear();

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            file = openFileDialog1.FileName;
            task = new Task(Method);
            button1.Visible = false;
            task.Start();
            //task.Wait();
            this.WindowState = FormWindowState.Maximized;
            button1.Location = new Point(0,0);
            //------------
            chart1.Location = new Point(10, 30);
            chart1.Width = this.Width - 50;
            chart1.Height = 300;
            chart1.Visible = true;
            //-------------
            chart2.Location = new Point(10, 400);
            chart2.Width = this.Width - 50;
            chart2.Height = 300;
            button1.Visible = true;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }
    }
}
