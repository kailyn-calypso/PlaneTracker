namespace PLaneTrackerGUI
{
    public partial class Form1View : Form
    {
        Image Airplane1;
        Image Airplane2;

        bool goLeft, goRight, goUp, goDown;
        Plane Plane1 = new Plane(1, 50, 300, 50, 50);
        Plane Plane2 = new Plane(1, 50, 300, 50, 50);


        public Form1View()
        {
            InitializeComponent();

            this.BackgroundImage = Image.FromFile("AR_Map.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            Airplane1 = Image.FromFile("Airplane.png");

            // Hook up the key events
            this.KeyDown += new KeyEventHandler(KeyIsDown);
            this.KeyUp += new KeyEventHandler(KeyIsUp);

            this.Paint += new PaintEventHandler(FormPaintEvent);
        }
        private void TimerEvent(object sender, EventArgs e)
        {
            if (goLeft && Plane1.PositionX > 0)
            {
                Plane1.PositionX -= Plane1.Speed;
            }
            if (goRight && Plane1.PositionX + Plane1.Width < this.ClientSize.Width)
            {
                Plane1.PositionX += Plane1.Speed;
            }
            if (goUp && Plane1.PositionY > 0)
            {
                Plane1.PositionY -= Plane1.Speed;
            }
            if (goDown && Plane1.PositionY + Plane1.Height < this.ClientSize.Height)
            {
                Plane1.PositionY += Plane1.Speed;
            }
            //if (Plane1.averageT < 4)
            //{
            //    Plane1.averageX[Plane1.averageT] = Plane1.PositionX;
            //    Plane1.averageY[Plane1.averageT] = Plane1.PositionY;
            //    Plane1.averageT++;
            //}
            //else
            //{
            //    for (int i = 0; i < 4; i++)
            //    {

            //        if (i == 3)
            //        {
            //            Plane1.averageX[i] = Plane1.PositionX;
            //            Plane1.averageY[i] = Plane1.PositionY;
            //        }
            //        else
            //        {
            //            Plane1.averageX[i] = Plane1.averageX[i + 1];
            //            Plane1.averageY[i] = Plane1.averageY[i + 1];
            //        }
            //    }
            //}
                this.Invalidate();

            }
        }


        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            else if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                goUp = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                goDown = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            else if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            else if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            else if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
        }

        private void FormPaintEvent(object sender, PaintEventArgs e)
        {
            Graphics Canvas = e.Graphics;
            e.Graphics.DrawImage(this.BackgroundImage, 0, 0, this.ClientSize.Width, this.ClientSize.Height);
            Canvas.DrawImage(Airplane1, Plane1.PositionX, Plane1.PositionY, Plane1.Width, Plane1.Height);

        }

    }
}