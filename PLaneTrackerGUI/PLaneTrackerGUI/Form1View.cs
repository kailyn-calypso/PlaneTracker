namespace PLaneTrackerGUI
{
    public partial class Form1View : Form
    {
        Image Airplane;
        bool goLeft, goRight, goUp, goDown;
        int speed = 10;
        int positionX = 50;
        int positionY = 200;
        int height = 100;
        int width = 100;

        public Form1View()
        {
            InitializeComponent();

            this.BackgroundImage = Image.FromFile("AR_Map.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            Airplane = Image.FromFile("Airplane.png");

            // Hook up the key events
            this.KeyDown += new KeyEventHandler(KeyIsDown);
            this.KeyUp += new KeyEventHandler(KeyIsUp);

            this.Paint += new PaintEventHandler(FormPaintEvent);
        }
        private void TimerEvent(object sender, EventArgs e)
        {
            if (goLeft && positionX > 0)
            {
                positionX -= speed;
            }
            if (goRight && positionX + width < this.ClientSize.Width)
            {
                positionX += speed;
            }
            if (goUp && positionY > 0)
            {
                positionY -= speed;
            }
            if (goDown && positionY + height < this.ClientSize.Height)
            {
                positionY += speed;
            }
            this.Invalidate();

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
            Canvas.DrawImage(Airplane, positionX, positionY, width, height);

        }
        
    }
}