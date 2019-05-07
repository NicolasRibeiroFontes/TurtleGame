namespace TurtleGame.Models
{
    public class Position
    {
        public Position() { }

        public Position(int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
        }

        public int PositionX { get; set; }
        public int PositionY { get; set; }
    }
}
