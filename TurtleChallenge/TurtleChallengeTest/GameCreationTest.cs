using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TurtleChallenge;

namespace TurtleChallengeTest
{
    [TestClass]
    public class GameCreationTest
    {
        [TestMethod]
        public void Success()
        {
            uint width = 10;
            uint height = 20;
            Tile startPosition = new Tile(2, 2);
            Direction startDirection = Direction.North;
            Tile exitPosition = new Tile(8, 8);
            List<Tile> mines = new List<Tile> {
                new Tile(3,3),
                new Tile(4,4)
            };

            Game game = new Game(width, height, startPosition, startDirection, exitPosition, mines);
        }

        [TestMethod]
        public void InvalidStartPosition()
        {
            uint width = 10;
            uint height = 20;
            Tile startPosition = new Tile(10, 2); // off board!
            Direction startDirection = Direction.North;
            Tile exitPosition = new Tile(8, 8);
            List<Tile> mines = new List<Tile> {
                new Tile(3,3),
                new Tile(4,4)
            };

            Exception exception = null;

            try
            {
                Game game = new Game(width, height, startPosition, startDirection, exitPosition, mines);
            }
            catch (InvalidGameException ex)
            {
                exception = ex;
            }

            Assert.IsNotNull(exception);
            Assert.AreEqual("Invalid start position.", exception.Message);
        }

        [TestMethod]
        public void InvalidSize()
        {
            uint width = 0;
            uint height = 20;
            Tile startPosition = new Tile(0, 2);
            Direction startDirection = Direction.North;
            Tile exitPosition = new Tile(8, 8);
            List<Tile> mines = new List<Tile> {
                new Tile(3,3),
                new Tile(4,4)
            };

            Exception exception = null;

            try
            {
                Game game = new Game(width, height, startPosition, startDirection, exitPosition, mines);
            }
            catch (InvalidGameException ex)
            {
                exception = ex;
            }

            Assert.IsNotNull(exception);
            Assert.AreEqual("Invalid board size.", exception.Message);
        }

        [TestMethod]
        public void InvalidExit()
        {
            uint width = 10;
            uint height = 20;
            Tile startPosition = new Tile(2, 2);
            Direction startDirection = Direction.North;
            Tile exitPosition = new Tile(12, 8);
            List<Tile> mines = new List<Tile> {
                new Tile(3,3),
                new Tile(4,4)
            };

            Exception exception = null;

            try
            {
                Game game = new Game(width, height, startPosition, startDirection, exitPosition, mines);
            }
            catch (InvalidGameException ex)
            {
                exception = ex;
            }

            Assert.IsNotNull(exception);
            Assert.AreEqual("Invalid exit position.", exception.Message);
        }

        [TestMethod]
        public void OverlappingStartExit()
        {
            uint width = 10;
            uint height = 20;
            Direction startDirection = Direction.North;
            Tile startPosition = new Tile(2, 2);
            Tile exitPosition = new Tile(2, 2);
            List<Tile> mines = new List<Tile> {
                new Tile(3,3),
                new Tile(4,4)
            };

            Exception exception = null;

            try
            {
                Game game = new Game(width, height, startPosition, startDirection, exitPosition, mines);
            }
            catch (InvalidGameException ex)
            {
                exception = ex;
            }

            Assert.IsNotNull(exception);
            Assert.AreEqual("Overlapping tiles found.", exception.Message);
        }
    }
}