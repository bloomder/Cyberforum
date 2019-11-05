using System.Drawing;
using System.Windows.Forms;

namespace Locations_Controls
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ("Ss".Contains(e.KeyChar.ToString()))
            {
                Control_Location(sender, 0, 1);//Down
            }
            if ("Aa".Contains(e.KeyChar.ToString()))
            {
                Control_Location(sender, -1, 0);//"Left"
            }
            if ("Ww".Contains(e.KeyChar.ToString()))
            {
                Control_Location(sender, 0, -1);//"Up"
            }
            if ("Dd".Contains(e.KeyChar.ToString()))
            {
                Control_Location(sender, 1, 0);//"Right"
            }
        }

        private void Control_Location(object sender, int x, int y)
        {
            Control myControl;
            Point p;
            myControl=sender as Control;
            bool Sdvig = true;
            if (myControl != null)
            {
                if(myControl.Name.Equals("button1"))
                {
                    bt1_X.Text = myControl.Location.X.ToString();
                    bt1_Y.Text = myControl.Location.Y.ToString();
                }
                if (myControl.Name.Equals("button2"))
                {
                    bt2_X.Text = myControl.Location.X.ToString();
                    bt2_Y.Text = myControl.Location.Y.ToString();
                }
                
                foreach (Control item in this.Controls)
                {
                    if(item is Button)
                    {
                        if (!myControl.Equals(item))
                        {
                            if (
                                 ((myControl.Location.X - x) == (item.Location.X - item.Width)) ||
                                 ((myControl.Location.X + x) == (item.Location.X + item.Width)) ||
                                 ((myControl.Location.X - x) == (item.Location.X + item.Width)) ||
                                 ((myControl.Location.X + x) == (item.Location.X - item.Width)) ||

                                 ((myControl.Location.Y - y) == (item.Location.Y - item.Height)) ||
                                 ((myControl.Location.Y + y) == (item.Location.Y + item.Height)) ||
                                 ((myControl.Location.Y - y) == (item.Location.Y + item.Height)) ||
                                 ((myControl.Location.Y + y) == (item.Location.Y - item.Height)) 
                               )
                            {
                                MessageBox.Show("Попал");
                                Sdvig = false;
                                break;
                            }
                        }
                    }
                    
                }
                if(Sdvig)
                {
                    p = new Point(myControl.Location.X + x, myControl.Location.Y + y);
                    myControl.Location = p;
                }
            }
        }
    }
}
