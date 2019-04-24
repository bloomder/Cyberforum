using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GrafficsTXT_Win_
{
    public partial class Form1 : Form
    {
        double myX, myY;
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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(myX.ToString() +"\r\n"+ myY.ToString());
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
            chart1.GetToolTipText += chart_GetToolTipText;
        }
        private void chart_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            // Если текст в подсказке уже есть, то ничего не меняем.
            if (!String.IsNullOrWhiteSpace(e.Text))
                return;

            Console.WriteLine(e.HitTestResult.ChartElementType);

            switch (e.HitTestResult.ChartElementType)
            {
                case ChartElementType.DataPoint:
                case ChartElementType.DataPointLabel:
                case ChartElementType.Gridlines:
                case ChartElementType.Axis:
                case ChartElementType.TickMarks:
                case ChartElementType.PlottingArea:
                    // Первый ChartArea
                    var area = chart1.ChartAreas[0];

                    // Его относительные координаты (в процентах от размеров Chart)
                    var areaPosition = area.Position;

                    // Переводим в абсолютные
                    var areaRect = new RectangleF(areaPosition.X * chart1.Width / 100, areaPosition.Y * chart1.Height / 100,
                        areaPosition.Width * chart1.Width / 100, areaPosition.Height * chart1.Height / 100);

                    // Область построения (в процентах от размеров area)
                    var innerPlot = area.InnerPlotPosition;

                    double x = area.AxisX.Minimum +
                                (area.AxisX.Maximum - area.AxisX.Minimum) * (e.X - areaRect.Left - innerPlot.X * areaRect.Width / 100) /
                                (innerPlot.Width * areaRect.Width / 100);
                    double y = area.AxisY.Maximum -
                                (area.AxisY.Maximum - area.AxisY.Minimum) * (e.Y - areaRect.Top - innerPlot.Y * areaRect.Height / 100) /
                                (innerPlot.Height * areaRect.Height / 100);

                    //Console.WriteLine("{0:F2} {1:F2}", x, y);
                    myX = x;
                    myY = y;
                    e.Text = String.Format("{0:F2} {1:F2}", x, y);
                    break;
            }
        }
    }
}
