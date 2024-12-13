namespace PLaneTrackerGUI
{
    public class Plane
    {
  
        public int Speed { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int averageT = 0;
        public int[] averageX = new int[3];
        public int[] averageY = new int[3];
        public Plane (int inSpeed, int inPositionX1, int inPositionY1, int inHeight, int inWidth)
        {
            Speed = inSpeed;
            PositionX = inPositionX1;
            PositionY = inPositionY1;
            Height = inHeight;
            Width = inWidth;
        }
        public int[] LocationPredictX()
        {
            return new int[0];
        }
    }
}