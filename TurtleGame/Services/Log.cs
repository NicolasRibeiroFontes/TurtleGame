using System;
using TurtleGame.Enums;
using TurtleGame.Models;

namespace TurtleGame.Services
{
    public class Log
    {
        public static string LogCurrent = "{0} | Position: {1}-{2} | Direction: {3}";
        public static string Move = "Turtle moved from position {0}.{1} to {2}.{3} and ";
        public static string Rotate = "Turtle was pointing to {0} and rotated to {1}";

        public const string HitWall = "The Turtle hit the wall!";
        public const string FoundMine = "triggered a mine";
        public const string FoundExit = "Success!! The Turtle found the exit!";

        public static void ShowLog(Directions oldDirection, Directions newDirection)
        {
            Console.WriteLine(string.Format(Rotate, oldDirection.ToString(), newDirection.ToString()));
        }

        public static void ShowLog(Position oldPosition, Position newPosition)
        {
            Console.Write(string.Format(Move, oldPosition.PositionX, oldPosition.PositionY, newPosition.PositionX, newPosition.PositionY));
        }

        public static void ShowLog(string consequenceMove)
        {
            Console.WriteLine(consequenceMove);
        }

        public static void ShowLog(string log, string[] parameters)
        {
            Console.WriteLine(string.Format(log, parameters));
        }
    }
}
