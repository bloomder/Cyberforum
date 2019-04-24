//DrawPlanet_Win
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DrawPlanet_Win
{
    public partial class Form1 : Form
    {
        private int x = 12, y = 12;
        private Button[,] buttons = new Button[3, 3];
        private int player;
        public Form1()
        {
            InitializeComponent();
            this.Height = 800;
            this.Width = 900;
            player = 1;
            label1.Text = "Текущий ход: Игрок 1";
            for (int i = 0; i < buttons.Length / 3; i++)
            {
                for (int j = 0; j < buttons.Length / 3; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Size = new Size(200, 200);

                }
            }

            setButtons();

        }

        private void setButtons()
        {
            for (int i = 0; i < buttons.Length / 3; i++)
            {
                for (int j = 0; j < buttons.Length / 3; j++)
                {

                    buttons[i, j].Location = new Point(12 + 220 * j, 12 + 206 * i);
                    buttons[i, j].Click += button1_Click;

                    buttons[i, j].Font = new Font(new FontFamily("Times New Roman"), 155);






                    this.Controls.Add(buttons[i, j]);


                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (
                (sender.GetType().GetProperty("Text").GetValue(sender).ToString().Equals("X")) ||
                (sender.GetType().GetProperty("Text").GetValue(sender).ToString().Equals("O"))
               ) { }
            else
            {
                switch (player)
                {
                    case 1:
                        sender.GetType().GetProperty("Text").SetValue(sender, "X");
                        sender.GetType().GetProperty("ForeColor").SetValue(sender, System.Drawing.Color.Red);

                        player = 0;
                        label1.Text = "Текущий ход: Игрок 2";
                        break;
                    case 0:
                        sender.GetType().GetProperty("Text").SetValue(sender, "O");
                        sender.GetType().GetProperty("ForeColor").SetValue(sender, System.Drawing.Color.Green);
                        player = 1;
                        label1.Text = "Текущий ход: Игрок 1";
                        break;
                }
                //sender.GetType().GetProperty("Enabled").SetValue(sender, false);
                checkwin();
            }
        }
        private void checkwin()
        {
            if (buttons[0, 0].Text == buttons[0, 1].Text && buttons[0, 1].Text == buttons[0, 2].Text)
            {
                if (buttons[0, 0].Text != "")
                    MessageBox.Show("Вы победили!");
                return;
            }
            if (buttons[1, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[1, 2].Text)
            {
                if (buttons[1, 0].Text != "")
                    MessageBox.Show("Вы победили!");
                return;
            }
            if (buttons[2, 0].Text == buttons[2, 1].Text && buttons[2, 1].Text == buttons[2, 2].Text)
            {
                if (buttons[2, 0].Text != "")
                    MessageBox.Show("Вы победили!");
                return;
            }
            if (buttons[0, 0].Text == buttons[1, 0].Text && buttons[1, 0].Text == buttons[2, 0].Text)
            {
                if (buttons[0, 0].Text != "")
                    MessageBox.Show("Вы победили!");
                return;
            }
            if (buttons[0, 1].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 1].Text)
            {
                if (buttons[0, 1].Text != "")
                    MessageBox.Show("Вы победили!");
                return;
            }
            if (buttons[0, 2].Text == buttons[1, 2].Text && buttons[1, 2].Text == buttons[2, 2].Text)
            {
                if (buttons[0, 2].Text != "")
                    MessageBox.Show("Вы победили!");
                return;
            }
            if (buttons[0, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 2].Text)
            {
                if (buttons[0, 0].Text != "")
                    MessageBox.Show("Вы победили!");
                return;
            }
            if (buttons[2, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[0, 2].Text)
            {
                if (buttons[2, 0].Text != "")

                    MessageBox.Show("Вы победили!");
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j].Text = "";
                    buttons[i, j].Enabled = true;


                }
            }
        }

    }
}