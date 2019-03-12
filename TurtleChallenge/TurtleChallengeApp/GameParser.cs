using System;
using System.Collections.Generic;
using System.Linq;
using TurtleChallenge;

namespace TurtleChallengeApp
{
    /// <summary>
    /// Class to parse a Game and Moves from a partiticular file format
    /// </summary>
    public static class GameParser
    {
        public const char NorthSymbol = '^';
        public const char SouthSymbol = 'v';
        public const char EastSymbol = '>';
        public const char WestSymbol = '<';
        public const char MineSymbol = '*';
        public const char ExitSymbol = 'e';
        public const char BlankSymbol = '-';

        public static List<Move> ParseGameMoves(string[] lines)
        {
            List<Move> moves = new List<Move>();

            foreach (string line in lines)
            {
                Move move = (Move)Enum.Parse(typeof(Move), line);
                moves.Add(move);
            }

            return moves;
        }

        public static Game ParseGameSettings(string[] fileLines)
        {
            uint gameWidth;
            uint gameHeight;
            Tile startPosition;
            Direction direction;
            Tile exitTile;
            List<Tile> mines;

            GameParser.ParseGameSettings(fileLines, out gameWidth, out gameHeight, out startPosition, out direction, out exitTile, out mines);

            return new GameConsole(gameWidth, gameHeight, startPosition, direction, exitTile, mines);
        }

        public static GameConsole ParseGameConsoleSettings(string[] fileLines)
        {
            uint gameWidth;
            uint gameHeight;
            Tile startPosition;
            Direction direction;
            Tile exitTile;
            List<Tile> mines;

            GameParser.ParseGameSettings(fileLines, out gameWidth, out gameHeight, out startPosition, out direction, out exitTile, out mines);

            return new GameConsole(gameWidth, gameHeight, startPosition, direction, exitTile, mines);
        }

        private static void ParseGameSettings(string[] fileLines, out uint gameWidth, out uint gameHeight, out Tile startPosition, out Direction direction, out Tile exitTile, out List<Tile> mines)
        {
            mines = new List<Tile>();
            exitTile = null;
            startPosition = null;
            direction = Direction.North;

            // Ignore empty lines and comments (#)
            var lines = fileLines.Where(i => !i.StartsWith("#") && i.Length != 0).ToArray();

            if (lines.Length < 1)
            {
                throw new Exception("No data found");
            }

            gameWidth = (uint) lines[0].Length;
            gameHeight = (uint) lines.Length;

            for (int y = 0; y < lines.Length; y++)
            {
                if (lines[y].Length != gameWidth)
                {
                    throw new Exception("Inconsistent game width");
                }

                for (int x = 0; x < lines[y].Length; x++)
                {
                    char currentChar = lines[y][x];
                    Tile currentTile = new Tile((uint)x, (uint)y);

                    switch (currentChar)
                    {
                        case BlankSymbol:
                            break;

                        case MineSymbol:
                            mines.Add(currentTile);
                            break;

                        case ExitSymbol:
                            if (exitTile != null)
                            {
                                throw new Exception("Multiple exits found");
                            }

                            exitTile = currentTile;
                            break;

                        case NorthSymbol:
                        case SouthSymbol:
                        case EastSymbol:
                        case WestSymbol:
                            if (startPosition != null)
                            {
                                throw new Exception("Multiple starts found");
                            }

                            startPosition = currentTile;

                            if (currentChar == NorthSymbol) direction = Direction.North;
                            if (currentChar == SouthSymbol) direction = Direction.South;
                            if (currentChar == EastSymbol) direction = Direction.East;
                            if (currentChar == WestSymbol) direction = Direction.West;

                            break;

                        default:
                            throw new Exception("Unexpected character found");
                    }
                }
            }

            if (startPosition == null)
            {
                throw new Exception("No start position specified");
            }

            if (exitTile == null)
            {
                throw new Exception("No exit found");
            }
        }
    }
}