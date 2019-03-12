using System;

namespace TurtleChallenge
{
    public abstract class TurtleChallengeException : Exception
    {
        public TurtleChallengeException() : base()
        {
        }

        public TurtleChallengeException(string message) : base(message)
        {
        }

        public TurtleChallengeException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class InvalidMoveException : TurtleChallengeException
    {
        public InvalidMoveException() : base()
        {
        }

        public InvalidMoveException(string message) : base(message)
        {
        }

        public InvalidMoveException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class GameOverException : TurtleChallengeException
    {
        public GameOverException() : base()
        {
        }

        public GameOverException(string message) : base(message)
        {
        }

        public GameOverException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class InvalidGameException : TurtleChallengeException
    {
        public InvalidGameException() : base()
        {
        }

        public InvalidGameException(string message) : base(message)
        {
        }

        public InvalidGameException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class InvalidTileException : TurtleChallengeException
    {
        public InvalidTileException() : base()
        {
        }

        public InvalidTileException(string message) : base(message)
        {
        }

        public InvalidTileException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}