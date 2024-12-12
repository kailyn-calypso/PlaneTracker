namespace PLaneTrackerGUI
{
    public partial class Form1View : Form
    {
        Image Airplane;
        bool goLeft, goRight, goUp, goDown;
        int speed = 10;
        int positionX=200;
        int positionY=200;
        int height=50;
        int width = 50;

        public Form1View()
        {
            InitializeComponent();

            this.BackgroundImage = Image.FromFile("AR_Map.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            Airplane = Image.FromFile("Arrow.png");
        }
        private void TimerEvent(object sender, EventArgs e)
        {
            if (goLeft && positionX>0)
            {
                positionX -= speed;
            }

        }


        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            else if(e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                goUp = true;
            }
            else if ( e.KeyCode == Keys.Down)
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
            Canvas.DrawImage (Airplane, positionX, positionY, width, height);
            
        }
    }
}