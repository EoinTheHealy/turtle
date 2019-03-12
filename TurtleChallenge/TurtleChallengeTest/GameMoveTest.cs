using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TurtleChallenge;
using TurtleChallengeApp;

namespace TurtleChallengeTest
{
    [TestClass]
    public class GameMoveTest
    {
        [TestMethod]
        public void Success()
        {
            string[] lines =
            {
                ">---",
                "--*-",
                "-*--",
                "-*-e"
            };

            Game game = GameParser.ParseGameSettings(lines);

            game.Move(Move.Move);

            Assert.AreEqual(GameState.InProgress, game.State);
        }

        [TestMethod]
        public void MoveOffTheBoard()
        {
            string[] lines =
            {
                "--->",
                "--*-",
                "-*--",
                "-*-e"
            };

            Game game = GameParser.ParseGameSettings(lines);

            Exception exception = null;

            try
            {
                game.Move(Move.Move);
            }
            catch (InvalidMoveException ex)
            {
                exception = ex;
            }

            Assert.IsNotNull(exception);
        }

        [TestMethod]
        public void GameOver()
        {
            string[] lines =
            {
                "->-*",
                "--*-",
                "-*--",
                "-*-e"
            };

            Game game = GameParser.ParseGameSettings(lines);

            game.Move(Move.Move);
            Assert.AreEqual(GameState.InProgress, game.State);

            game.Move(Move.Move);
            Assert.AreEqual(GameState.Dead, game.State);
            
            Exception exception = null;
            try
            {
                game.Move(Move.Move);
            }
            catch (GameOverException ex)
            {
                exception = ex;
            }

            Assert.IsNotNull(exception);
        }
    }
}