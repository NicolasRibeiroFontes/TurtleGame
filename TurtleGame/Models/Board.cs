using System.Collections.Generic;
using System.Linq;
using TurtleGame.Enums;

namespace TurtleGame.Models
{
    public class Board
    {
        public int Width { get; set; }
        public int Heigth { get; set; }
        public List<Element> Elements { get; set; }

        public Board(int widthSize, int heigthSize, List<Element> elements)
        {
            Width = widthSize;
            Heigth = heigthSize;
            Elements = elements;
        }

        public Element CheckElement(Position position)
        {
            return Elements.FirstOrDefault(x => x.Position.PositionX == position.PositionX && x.Position.PositionY == position.PositionY);
        }
    }

    public class Element
    {
        public ElementsBoard ElementBoard { get; set; }
        public Position Position { get; set; }
    }
}
