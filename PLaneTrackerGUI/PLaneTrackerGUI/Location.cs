namespace PLaneTrackerGUI
{
    public class Plane
    {
  
        public int Speed { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int[] AverageX { get; set; }
        public int[] AverageY { get; set; }

         
        public Plane (int inSpeed, int inPositionX1, int inPositionY1, int inHeight, int inWidth)
        {
            Speed = inSpeed;
            PositionX = inPositionX1;
            PositionY = inPositionY1;
            Height = inHeight;
            Width = inWidth;
            for (int i=0;i<4;i++)
            {
                AverageX[i] = PositionX;
                AverageY[i]=PositionY;
            }
        }
        public int[] LocationPredictX(int[]aveX, int positionX)
        {
            int[] x = new int[3];
            int ave = 0;
            for (int i=0;i<3;i++)
            {
                ave += (aveX[i + 1] - aveX[i]);
            }
            for (int i = 1; i <= 3; i++)
            {
                x[i-1] = positionX + i*ave;
            }
            return x;
        }
        public int[] LocationPredictY(int[] aveY, int positionY)
        {
            int[] y = new int[3];
            int ave = 0;
            //calculate average difference 
            for (int i = 0; i < 3; i++)
            {
                ave += (aveY[i + 1] - aveY[i]);
            }
            for (int i = 1; i <= 3; i++)
            {
                y[i - 1] = positionY + i * ave;
            }
            return y;
        }
        public bool GoingRight(int[]x)
        {
            if (x[2] - x[1] > 0)
                return true;
            else
                return false;
        }
    }
}