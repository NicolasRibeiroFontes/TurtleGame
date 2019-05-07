using System.Collections.Generic;
using System.Text;
using TurtleGame.Enums;
using TurtleGame.Services;

namespace TurtleGame.Models
{
    public class Config
    {
        public string Name { get; set; }
        public Position Position { get; set; }
        public Directions Direction { get; set; }
        public List<Mine> Mines { get; set; }
        public Position Board { get; set; }
        public Position Exit { get; set; }

        public string Convert()
        {
            var infoConfig = new StringBuilder();

            infoConfig.AppendLine(string.Format("{0} | Position: {1}.{2} | Direction: {3}", Name, Position.PositionX, Position.PositionY, Direction));
            infoConfig.AppendLine(string.Format("Mines: "));

            foreach (var item in Mines)
            {
                infoConfig.AppendLine(string.Format("Position: {0}.{1}", item.Position.PositionX, item.Position.PositionY));
            }

            return infoConfig.ToString();
        }

        public string Move()
        {
            switch (Direction)
            {
                case Directions.North:
                    Log.ShowLog(Position, Position = new Position(Position.PositionX - 1, Position.PositionY));
                    break;
                case Directions.South:
                    Log.ShowLog(Position, Position = new Position(Position.PositionX + 1, Position.PositionY));
                    break;
                case Directions.East:
                    Log.ShowLog(Position, Position = new Position(Position.PositionX, Position.PositionY + 1));
                    break;
                case Directions.West:
                    Log.ShowLog(Position, Position = new Position(Position.PositionX, Position.PositionY - 1));
                    break;
            }

            return "";
        }

        public void Rotate()
        {
            Directions oldDirection = Direction;

            switch (Direction)
            {
                case Directions.North:
                    Direction = Directions.East;
                    break;
                case Directions.East:
                    Direction = Directions.South;
                    break;
                case Directions.South:
                    Direction = Directions.West;
                    break;
                case Directions.West:
                    Direction = Directions.North;
                    break;
                default:
                    break;
            }
            Log.ShowLog(oldDirection, Direction);
        }
    }
}
