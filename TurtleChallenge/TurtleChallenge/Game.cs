using System.Collections.Generic;
using System.Linq;

namespace TurtleChallenge
{
    public class Game
    {
        public Game(uint width, uint height, Tile startPosition, Direction startDirection, Tile exitPosition, List<Tile> mines)
        {
            if (width < 1 || height < 1)
            {
                throw new InvalidGameException("Invalid board size.");
            }

            this.BoardWidth = width;
            this.BoardHeight = height;

            if (startPosition == null || !IsTileOnBoard(startPosition))
            {
                throw new InvalidGameException("Invalid start position.");
            }

            if (exitPosition == null || !IsTileOnBoard(exitPosition))
            {
                throw new InvalidGameException("Invalid exit position.");
            }

            if (mines == null)
            {
                mines = new List<Tile>();
            }

            if (mines.Exists(i => !IsTileOnBoard(i)))
            {
                throw new InvalidGameException("Mine cannot be off the board.");
            }

            //Check if any given tiles are overlapping;
            var allTiles = mines.Union(new List<Tile> { startPosition, exitPosition });
            var overlappingTiles = allTiles.GroupBy(i => new { i.X, i.Y }).Where(i => i.Count() > 1);
            if (overlappingTiles.Count() > 0)
            {
                throw new InvalidGameException("Overlapping tiles found.");
            }

            this.Position = startPosition;
            this.Exit = exitPosition;
            this.Mines = mines;
            this.CurrentDirection = startDirection;
            this.State = GameState.InProgress;
        }

        public GameState State { get; set; }

        protected readonly uint BoardWidth;

        protected readonly uint BoardHeight;

        protected readonly List<Tile> Mines;

        protected readonly Tile Position;

        protected readonly Tile Exit;

        protected Direction CurrentDirection;
        
        public void Move(Move move)
        {
            if (State != GameState.InProgress)
            {
                throw new GameOverException("Cannot move while game not in progress.");
            }

            switch (move)
            {
                case TurtleChallenge.Move.Move:
                    this.GoForward();
                    break;

                case TurtleChallenge.Move.Rotate:
                    this.TurnRight();
                    break;
            }
        }

        protected void TurnRight()
        {
            switch (this.CurrentDirection)
            {
                case Direction.North:
                    this.CurrentDirection = Direction.East;
                    break;

                case Direction.East:
                    this.CurrentDirection = Direction.South;
                    break;

                case Direction.South:
                    this.CurrentDirection = Direction.West;
                    break;

                case Direction.West:
                    this.CurrentDirection = Direction.North;
                    break;
            }
        }

        protected void GoForward()
        {
            try
            {
                checked
                {
                    switch (this.CurrentDirection)
                    {
                        case Direction.North:
                            Position.Y -= 1;
                            break;

                        case Direction.East:
                            Position.X += 1;
                            break;

                        case Direction.South:
                            Position.Y += 1;
                            break;

                        case Direction.West:
                            Position.X -= 1;
                            break;
                    }
                }
            }
            catch(System.OverflowException)
            {
                // This covers x<0 || y<0
                throw new InvalidMoveException();
            }

            if (!this.IsPositionOnBoard())
            {
                throw new InvalidMoveException();
            }

            if (this.IsOnMine())
            {
                State = GameState.Dead;
            }

            if (this.ReachedExit())
            {
                State = GameState.Success;
            }
        }

        protected bool IsOnMine()
        {
            return this.Mines.Exists(i => i.X == Position.X && i.Y == Position.Y);
        }

        protected bool ReachedExit()
        {
            return this.Exit.X == Position.X && this.Exit.Y == Position.Y;
        }

        protected bool IsPositionOnBoard()
        {
            if (this.Position.X < 0 || this.Position.Y < 0)
            {
                return false;
            }

            if (Position.X >= this.BoardWidth || Position.Y >= this.BoardWidth)
            {
                return false;
            }

            return true;
        }

        private bool IsTileOnBoard(Tile tile)
        {
            return tile.X >= 0 && tile.X < this.BoardWidth && tile.Y >= 0 && tile.Y < this.BoardHeight;
        }
    }

    public enum Direction
    {
        North,
        East,
        South,
        West
    }

    public enum GameState
    {
        InProgress,
        Dead,
        Success
    }
}