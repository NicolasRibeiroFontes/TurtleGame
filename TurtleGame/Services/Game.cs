using System;
using System.Collections.Generic;
using System.Linq;
using TurtleGame.Enums;
using TurtleGame.Models;

namespace TurtleGame.Services
{
    public class Game
    {
        static Config _config;
        static Board _board;

        static List<string> _actions;
        static bool _finishGame;

        public static void StartGame(string [] arguments)
        {
            GetFiles(arguments);

            Initialize();

            ExecuteActions();

            Console.WriteLine("\n######### FINISH GAME ###########");

            Console.ReadKey();
        }

        private static void GetFiles(string[] arguments)
        {
            string _configNameFile = arguments.Count() < 1 ? GenerateFile.defaultConfigNameFile : GenerateFile.ValidFileExists(arguments[0]) ? arguments[0] : GenerateFile.defaultConfigNameFile;
            string _actionNameFile = arguments.Count() < 2 ? GenerateFile.defaultActionNameFile: GenerateFile.ValidFileExists(arguments[1]) ? arguments[1] : GenerateFile.defaultActionNameFile;

            _config = GenerateFile.GenerateConfigFile(_configNameFile);
            _actions = GenerateFile.GenerateActionFile(_actionNameFile);
        }

        private static void Initialize()
        {
            Console.WriteLine("Welcome to TurtleGame!");
            Console.WriteLine("######## START GAME ############\n");

            CreateBoard();
        }

        private static void CreateBoard()
        {
            List<Element> elements = new List<Element>();

            foreach (var mine in _config.Mines)
                elements.Add(new Element { ElementBoard = ElementsBoard.Mine, Position = mine.Position });

            elements.Add(new Element { ElementBoard = ElementsBoard.Exit, Position = _config.Exit });

            _board = new Board(_config.Board.PositionX, _config.Board.PositionY, elements);
        }

        private static void ExecuteActions()
        {
            foreach (var action in _actions)
            {
                Log.ShowLog(Log.LogCurrent, new string[] { _config.Name, _config.Position.PositionX.ToString(), _config.Position.PositionY.ToString(), _config.Direction.ToString() });

                switch (action)
                {
                    case "Rotate":
                        _config.Rotate();
                        break;
                    case "Move":
                        _config.Move();
                        if (!ValidElement() && !ValidWallBoard())
                            Log.ShowLog("it's safe");
                        break;
                    default:
                        break;
                }

                if (_finishGame)
                    break;

                Console.WriteLine("####################\n");
            }
        }

        

        private static bool ValidWallBoard()
        {
            bool hitWall = _config.Position.PositionX < 0 || _config.Position.PositionX > _board.Heigth
                || _config.Position.PositionY < 0 || _config.Position.PositionY > _board.Width;

            if (hitWall)
                Log.ShowLog(Log.HitWall, new string[] { });

            _finishGame = hitWall;

            return hitWall;
        }

        private static bool ValidElement()
        {
            Element element = _board.CheckElement(_config.Position);

            if (element != null)
            {
                switch (element.ElementBoard)
                {
                    case ElementsBoard.Mine:
                        Log.ShowLog(Log.FoundMine, new string[] { });
                        break;
                    case ElementsBoard.Exit:
                        Log.ShowLog(Log.FoundExit, new string[] { });
                        break;
                    default:
                        break;
                }
            }

            _finishGame = element != null;

            return element != null;
        }
        
    }
}
