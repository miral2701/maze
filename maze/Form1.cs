using System.Drawing;

namespace maze
{
    public partial class Form1 : Form
    {
        string[] arr = new string[] { "00000000000000000000000000000", "01111111100000000000000000000", "00000000111111111110000000000", "00000000000000000011111111111", "00000000000000000000000000000", "00000000000000000000000000000", "00000000000000000000000000000", "00000000000000000000000000000" };
        Graphics g;
        int X = 0; int Y = 0;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Location = new Point(X + 20, Y + 20);

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            Brush brush = new SolidBrush(Color.White);
            Brush brush2 = new SolidBrush(Color.Black);
            int x = 0;
            int y = 0;
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                foreach (char a in arr[i])
                {
                    if (a == '1' && count == 0)
                    {
                        //pictureBox1.Top = y;
                        //pictureBox1.Left = x;
                        X = x;
                        Y = y;

                        x += 20;
                        count++;
                    }
                    else if (a == '1' && count != 0)
                    {
                        g.FillRectangle(brush, x, y, 20, 20);
                        x += 20;

                    }
                    else
                    {
                        g.FillRectangle(brush2, x, y, 20, 20);
                        x += 20;

                    }
                }

                x = 0;
                y += 20;
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.W)
            {
                pictureBox1.BackColor = Color.DarkSlateBlue;
                X -= 20;
                pictureBox1.Top -= Y;
                pictureBox1.Left += X;
            }
            if (e.KeyValue == (char)Keys.A)
            {
                Y -= 20;
                pictureBox1.BackColor = Color.Aqua;
                pictureBox1.Top += Y;
                pictureBox1.Left -= X;

            }
            if (e.KeyValue == (char)Keys.S)
            {
                pictureBox1.BackColor = Color.DarkSlateBlue;
                X -= 20;
                pictureBox1.Top += Y;
                pictureBox1.Left += X;
            }
            if (e.KeyValue == (char)Keys.D)
            {
                Y -= 20;
                pictureBox1.BackColor = Color.Aqua;
                pictureBox1.Top += Y;
                pictureBox1.Left += X;
            }

            if (pictureBox1.Left == 20 * arr[1].Length)
            {
                MessageBox.Show("You win");
                pictureBox1.Location = new Point(20, 20);

            }


            if ((arr[pictureBox1.Top / 20][pictureBox1.Left / 20]) == '0')
            {
                MessageBox.Show("You lose");
                pictureBox1.Location = new Point(20, 20);

            }




        }
    }
}