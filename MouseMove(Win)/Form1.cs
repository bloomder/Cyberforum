using System.Windows.Forms;

namespace MouseMove_Win_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {            
            label1.Text = "X-" + e.X.ToString() + " Y-" + e.Y.ToString();
        }
    }
}
