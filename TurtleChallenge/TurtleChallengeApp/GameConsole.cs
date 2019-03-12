using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallenge;

namespace TurtleChallengeApp
{
    /// <summary>
    /// Class that can play game and display output on console
    /// </summary>
    public class GameConsole : Game
    {
        public GameConsole(uint width, uint height, Tile startPosition, Direction startDirection, Tile exitPosition, List<Tile> mines)
            : base(width, height, startPosition, startDirection, exitPosition, mines)
        {
        }

        public string Display()
        {
            StringBuilder boardString = new StringBuilder();

            for (int y = 0; y < this.BoardHeight; ++y)
            {
                string lineStr = "";

                for (int x = 0; x < this.BoardWidth; ++x)
                {
                    if (this.Position.X == x && this.Position.Y == y)
                    {
                        if (this.CurrentDirection == Direction.North)
                        {
                            lineStr += GameParser.NorthSymbol;
                        }
                        else if (this.CurrentDirection == Direction.East)
                        {
                            lineStr += GameParser.EastSymbol;
                        }
                        else if (this.CurrentDirection == Direction.South)
                        {
                            lineStr += GameParser.SouthSymbol;
                        }
                        else if (this.CurrentDirection == Direction.West)
                        {
                            lineStr += GameParser.WestSymbol;
                        }
                    }
                    else if (this.Mines.Exists(i => i.X == x && i.Y == y))
                    {
                        lineStr += GameParser.MineSymbol;
                    }
                    else if (this.Exit.X == x && this.Exit.Y == y)
                    {
                        lineStr += GameParser.ExitSymbol;
                    }
                    else
                    {
                        lineStr += GameParser.BlankSymbol;
                    }
                }

                boardString.AppendLine(lineStr);
            }

            return boardString.ToString();
        }
    }
}
