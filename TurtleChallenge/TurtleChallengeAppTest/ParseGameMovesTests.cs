using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TurtleChallenge;
using TurtleChallengeApp;

namespace TurtleChallengeAppTest
{
    [TestClass]
    public class ParseGameMovesTests
    {
        [TestMethod]
        public void Success()
        {
            string[] lines =
            {
                "Move",
                "Rotate",
                "Move",
                "Move",
                "Move",
                "Move",
                "Rotate",
                "Move",
                "Move"
            };

            List<Move> moves = GameParser.ParseGameMoves(lines);

            Assert.AreEqual(9, moves.Count);
        }

        [TestMethod]
        public void NoData()
        {
            string[] lines = { };

            List<Move> moves = GameParser.ParseGameMoves(lines);

            Assert.AreEqual(0, moves.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptyData()
        {
            string[] lines =
            {
                ""
            };

            GameParser.ParseGameMoves(lines);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidData()
        {
            string[] lines =
            {
                "TurnAround"
            };

            GameParser.ParseGameMoves(lines);
        }
    }
}