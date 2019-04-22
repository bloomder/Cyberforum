using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DrawSquare_Win
{
    public partial class Form1 : Form
    {
        Graphics graf;
        int m_X, m_Y;
        List<SquareDraw> list;
        bool znak;
        public Brush[] p_brush = new Brush[3] { Brushes.Red, Brushes.Blue, Brushes.Green };
        int razm = 50;
        public Form1()
        {
            InitializeComponent();
            graf = pictureBox1.CreateGraphics();
            
            list = new List<SquareDraw>();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            lb1.Text = m_X.ToString();
            lb2.Text = m_Y.ToString();
            
            znak = true;
            if (list.Count != 0)
            {
                foreach (SquareDraw item in list)
                {
                    item.X = item.X;
                    m_X = m_X;
                    item.Y = item.Y;
                    m_Y = m_Y;
                    if (
                         ( (m_X>=item.X) && (m_X<=item.X+razm) ) && ( (m_Y>=item.Y) && (m_Y<=item.Y+razm) )
                       )
                    {
                        graf.Clear(pictureBox1.BackColor);
                        switch(item.count_color)
                        {
                            case 1:
                                item.brush = Brushes.Blue; item.count_color = 2;
                                graf.FillRectangle(item.brush, item.X, item.Y, razm, razm);
                                break;
                            case 2:
                                item.brush = Brushes.Green; item.count_color = 3;
                                graf.FillRectangle(item.brush, item.X, item.Y, razm, razm);
                                break;
                            case 3:
                                item.brush = Brushes.Red; item.count_color = 1;
                                graf.FillRectangle(item.brush, item.X, item.Y, razm, razm);
                                break;

                        }
                        foreach (SquareDraw item2 in list)
                        {
                            graf.FillRectangle(item2.brush, item2.X, item2.Y, razm, razm);
                        }
                        znak = false;
                    }                    
                }
                if(znak==true)
                {
                    graf.FillRectangle(Brushes.Red, m_X, m_Y, razm, razm);
                    list.Add(new SquareDraw() { X = m_X, Y = m_Y, brush = Brushes.Red, count_color = 1 });
                }
            }
            else
            {
                graf.FillRectangle(Brushes.Red, m_X, m_Y, razm, razm);
                list.Add(new SquareDraw() { X = m_X, Y = m_Y, brush=Brushes.Red, count_color=1 });                
            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            m_X = e.X;
            m_Y = e.Y;
        }
    }
    class SquareDraw
    {
        public int X;
        public int Y;
        public Brush brush;
        public int count_color;
    }
}
