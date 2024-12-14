using System.Data;

namespace PLaneTrackerGUI
{
    public partial class Form1View : Form
    {

        Image AirplaneLeft;
        Image AirplaneRight;
        Image WarningAirplaneLeft;
        Image WarningAirplaneRight;
        Image CrashAirplane;
        Image DotLeft;
        Image DotRight;
        Image Crash;
        //button speed tracking variable
        int speedCounter;
        int warningDistance;
        //variable declaration for state
        bool goLeftJ, goRightL, goUpI, goDownK;
        bool goLeftA, goRightD, goUpW, goDownS;
        bool start = true;
        //two object plane created
        Plane Plane1 = new Plane(10, 1000, 300, 100, 100);
        Plane Plane2 = new Plane(10, 50, 300, 100, 100);


        public Form1View()
        {
            InitializeComponent();

            IJKLWinning.Visible = false;
            WASDWinning.Visible = false;
            Instructions.Visible = false;
            GameTimer.Enabled = false;
            MoveTimer.Enabled = false;

            this.BackgroundImage = Image.FromFile("AR_MapNormal.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;



            AirplaneLeft = Image.FromFile("AirplaneLeft.png");
            AirplaneRight = Image.FromFile("AirplaneRight.png");
            WarningAirplaneLeft = Image.FromFile("WarningAirplaneLeft.png");
            WarningAirplaneRight = Image.FromFile("WarningAirplaneRight.png");
            CrashAirplane = Image.FromFile("CrashAirplane.png");
            DotLeft = Image.FromFile("ArrowLeft.png");
            DotRight = Image.FromFile("ArrowRight.png");
            Crash = Image.FromFile("Crash.png");

            // Hook up the key events
            this.KeyDown += new KeyEventHandler(KeyIsDown);
            this.KeyUp += new KeyEventHandler(KeyIsUp);

            this.Paint += new PaintEventHandler(FormPaintHandler);
        }


        private void TimerEvent(object sender, EventArgs e)
        {
            //Movement plane 1
            //left if not at edge
            if (goLeftJ && Plane1.PositionX > 0)
            {
                Plane1.PositionX -= Plane1.Speed;
            }

            //right if not at egs
            if (goRightL && Plane1.PositionX + Plane1.Width < this.ClientSize.Width)
            {
                Plane1.PositionX += Plane1.Speed;
            }
            //Up if not at edge
            if (goUpI && Plane1.PositionY > 0)
            {

                Plane1.PositionY -= Plane1.Speed;
            }
            //Down if not at edge
            if (goDownK && Plane1.PositionY + Plane1.Height < this.ClientSize.Height)
            {
                Plane1.PositionY += Plane1.Speed;
            }
            //Movement plane 2
            //left if not at edge
            if (goLeftA && Plane2.PositionX > 0)
            {
                Plane2.PositionX -= Plane2.Speed;
            }
            //right if not at egs
            if (goRightD && Plane2.PositionX + Plane2.Width < this.ClientSize.Width)
            {
                Plane2.PositionX += Plane2.Speed;
            }
            //Up if not at edge
            if (goUpW && Plane2.PositionY > 0)
            {
                Plane2.PositionY -= Plane2.Speed;
            }
            //Down if not at edge
            if (goDownS && Plane2.PositionY + Plane2.Height < this.ClientSize.Height)
            {
                Plane2.PositionY += Plane2.Speed;
            }
            if (Plane1.AverageT < 4)
            {
                Plane1.AverageX[Plane1.AverageT] = Plane1.PositionX;
                Plane1.AverageY[Plane1.AverageT] = Plane1.PositionY;
                Plane1.AverageT++;
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {

                    if (i == 3)
                    {
                        Plane1.AverageX[i] = Plane1.PositionX;
                        Plane1.AverageY[i] = Plane1.PositionY;
                        Plane2.AverageX[i] = Plane2.PositionX;
                        Plane2.AverageY[i] = Plane2.PositionY;
                    }
                    else
                    {
                        Plane1.AverageX[i] = Plane1.AverageX[i + 1];
                        Plane1.AverageY[i] = Plane1.AverageY[i + 1];
                        Plane2.AverageX[i] = Plane2.AverageX[i + 1];
                        Plane2.AverageY[i] = Plane2.AverageY[i + 1];

                    }
                }
            }

            this.Refresh();
        }


        private void KeyIsDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.J)
            {
                goLeftJ = true;
            }
            else if (e.KeyCode == Keys.L)
            {
                goRightL = true;
            }
            else if (e.KeyCode == Keys.I)
            {
                goUpI = true;
            }
            else if (e.KeyCode == Keys.K)
            {
                goDownK = true;
            }
            if (e.KeyCode == Keys.A)
            {
                goLeftA = true;
            }
            else if (e.KeyCode == Keys.D)
            {
                goRightD = true;
            }
            else if (e.KeyCode == Keys.W)
            {
                goUpW = true;
            }
            else if (e.KeyCode == Keys.S)
            {
                goDownS = true;
            }

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.J)
            {
                goLeftJ = false;
            }
            else if (e.KeyCode == Keys.L)
            {
                goRightL = false;
            }
            else if (e.KeyCode == Keys.I)
            {
                goUpI = false;
            }
            else if (e.KeyCode == Keys.K)
            {
                goDownK = false;
            }
            if (e.KeyCode == Keys.A)
            {
                goLeftA = false;
            }
            else if (e.KeyCode == Keys.D)
            {
                goRightD = false;
            }
            else if (e.KeyCode == Keys.W)
            {
                goUpW = false;
            }
            else if (e.KeyCode == Keys.S)
            {
                goDownS = false;
            }
        }

        private async void FormPaintHandler(object sender, PaintEventArgs e)
        {

            int[] x1 = new int[3];
            x1 = Plane1.LocationPredictX(Plane1.AverageX, Plane1.PositionX);
            int[] y1 = new int[3];
            y1 = Plane1.LocationPredictX(Plane1.AverageY, Plane1.PositionY);
            int[] x2 = new int[3];
            x2 = Plane2.LocationPredictX(Plane2.AverageX, Plane2.PositionX);
            int[] y2 = new int[3];
            y2 = Plane2.LocationPredictX(Plane2.AverageY, Plane2.PositionY);
            double predictDistanceX = Math.Abs(x1[2] - x2[2]);
            double predictDistanceY = Math.Abs(y1[2] - y2[2]);

            double DistanceX = Math.Abs(Plane1.PositionX - Plane2.PositionX);
            double DistanceY = Math.Abs(Plane1.PositionY - Plane2.PositionY);
            Graphics Canvas = e.Graphics;

            e.Graphics.DrawImage(this.BackgroundImage, 0, 0, this.ClientSize.Width, this.ClientSize.Height);

            if (start)
            {

                Instructions.Visible = true;
                start = false;
                await Task.Delay(1);
                Task.Delay(10000).Wait();
                MoveTimer.Enabled = true;
                GameTimer.Enabled = true;
                Instructions.Visible = false;

            }
            else
            {


                if (x1[2] - x1[1] <= 0)
                {
                    if (predictDistanceX < warningDistance && predictDistanceY < warningDistance)
                        Canvas.DrawImage(WarningAirplaneLeft, Plane1.PositionX, Plane1.PositionY, Plane1.Width, Plane1.Height);

                    else
                        Canvas.DrawImage(AirplaneLeft, Plane1.PositionX, Plane1.PositionY, Plane1.Width, Plane1.Height);

                    for (int i = 0; i < 3; i++)
                    {
                        Canvas.DrawImage(DotLeft, x1[i], y1[i] + Plane1.Height / 2, 20, 20);
                    }
                }
                if (x1[2] - x1[1] > 0)
                {
                    if (predictDistanceX < warningDistance && predictDistanceY < warningDistance)
                        Canvas.DrawImage(WarningAirplaneRight, Plane1.PositionX, Plane1.PositionY, Plane1.Width, Plane1.Height);
                    else
                        Canvas.DrawImage(AirplaneRight, Plane1.PositionX, Plane1.PositionY, Plane1.Width, Plane1.Height);

                    for (int i = 0; i < 3; i++)
                    {
                        Canvas.DrawImage(DotRight, x1[i] + Plane1.Width, y1[i] + Plane1.Height / 2, 20, 20);
                    }
                }
                if (x2[2] - x2[1] >= 0)
                {
                    if (predictDistanceX < warningDistance && predictDistanceY < warningDistance)
                        Canvas.DrawImage(WarningAirplaneRight, Plane2.PositionX, Plane2.PositionY, Plane2.Width, Plane2.Height);
                    else
                        Canvas.DrawImage(AirplaneRight, Plane2.PositionX, Plane2.PositionY, Plane2.Width, Plane2.Height);


                    for (int i = 0; i < 3; i++)
                    {
                        Canvas.DrawImage(DotRight, x2[i] + Plane2.Width, y2[i] + Plane2.Height / 2, 20, 20);
                    }
                }
                if (x2[2] - x2[1] < 0)
                {
                    if (predictDistanceX < warningDistance && predictDistanceY < warningDistance)
                        Canvas.DrawImage(WarningAirplaneLeft, Plane2.PositionX, Plane2.PositionY, Plane2.Width, Plane2.Height);
                    else
                        Canvas.DrawImage(AirplaneLeft, Plane2.PositionX, Plane2.PositionY, Plane2.Width, Plane2.Height);

                    for (int i = 0; i < 3; i++)
                    {
                        Canvas.DrawImage(DotLeft, x2[i], y2[i] + Plane2.Height / 2, 20, 20);
                    }
                }
                if (DistanceX < Plane1.Width && DistanceY < Plane1.Height)
                {
                    Canvas.DrawImage(CrashAirplane, Plane1.PositionX, Plane1.PositionY, Plane1.Width, Plane1.Height);
                    Canvas.DrawImage(CrashAirplane, Plane2.PositionX, Plane2.PositionY, Plane2.Width, Plane2.Height);
                    Canvas.DrawImage(Crash, Plane2.PositionX, Plane1.PositionY, 300, 300);
                    WASDWinning.Visible = true;
                    await Task.Delay(1);
                    Task.Delay(10000).Wait();
                    this.Close();
                }
            }

        }


        private void SpeedButton_Click(object sender, EventArgs e)
        {
            if (speedCounter == 0)
            {
                Plane1.Speed = 5;
                Plane2.Speed = 5;
                SpeedButton.Text = "Speed: 5";
                speedCounter++;

            }
            else if (speedCounter == 1)
            {
                Plane1.Speed = 10;
                Plane2.Speed = 10;
                SpeedButton.Text = "Speed: 10";
                speedCounter++;
            }
            else
            {
                Plane1.Speed = 20;
                Plane2.Speed = 20;
                SpeedButton.Text = "Speed: 20";
                speedCounter = 0;
            }
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!msg.HWnd.Equals(this.Handle) &&
                (keyData == Keys.Left ||
                keyData == Keys.Up ||
                keyData == Keys.Right ||
                keyData == Keys.Down)
                )
                return false;
            return base.ProcessCmdKey(ref msg, keyData);
        }



        private void mediumWarning_CheckedChanged(object sender, EventArgs e)
        {
            warningDistance = 100;
        }

        private void shortWarning_CheckedChanged(object sender, EventArgs e)
        {
            warningDistance = 50;
        }

        private void longWarning_CheckedChanged(object sender, EventArgs e)
        {
            warningDistance = 200;
        }

        async private void EventGameTimer(object sender, EventArgs e)
        {
            IJKLWinning.Visible = true;
            await Task.Delay(1);
            Task.Delay(10000).Wait();
            this.Close();
        }
    }
}