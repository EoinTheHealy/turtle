using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TurtleChallengeApp;

namespace TurtleChallengeAppTest
{
    [TestClass]
    public class ParseGameSettingsTests
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

            GameParser.ParseGameSettings(lines);
        }

        [TestMethod]
        public void NoData()
        {
            string[] lines =
            {
            };

            Exception exception = null;
            try
            {
                GameParser.ParseGameSettings(lines);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "No data found");
        }

        [TestMethod]
        public void EmptyData()
        {
            string[] lines =
            {
                ""
            };

            Exception exception = null;
            try
            {
                GameParser.ParseGameSettings(lines);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "No data found");
        }

        [TestMethod]
        public void NoTurtle()
        {
            string[] lines =
            {
                "----",
                "----",
                "-**-",
                "---e"
            };

            Exception exception = null;
            try
            {
                GameParser.ParseGameSettings(lines);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "No start position specified");
        }

        [TestMethod]
        public void NoExit()
        {
            string[] lines =
            {
                ">---",
                "-**-",
                "----",
                "----"
            };

            Exception exception = null;
            try
            {
                GameParser.ParseGameSettings(lines);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "No exit found");
        }

        [TestMethod]
        public void MultipleExits()
        {
            string[] lines =
            {
                ">---",
                "--*-",
                "----",
                "-e-e"
            };

            Exception exception = null;
            try
            {
                GameParser.ParseGameSettings(lines);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Multiple exits found");
        }

        [TestMethod]
        public void MultipleTurtles()
        {
            string[] lines =
            {
                ">---",
                "----",
                "--^-",
                "---e"
            };

            Exception exception = null;
            try
            {
                GameParser.ParseGameSettings(lines);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Multiple starts found");
        }

        [TestMethod]
        public void InvalidCharacter()
        {
            string[] lines =
            {
                ">---",
                "----",
                "--?-",
                "---e"
            };

            Exception exception = null;
            try
            {
                GameParser.ParseGameSettings(lines);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Unexpected character found");
        }

        [TestMethod]
        public void InconsistentBoardSize()
        {
            string[] lines =
            {
                ">---",
                "----",
                "---", // 3 characters
                "---e"
            };

            Exception exception = null;
            try
            {
                GameParser.ParseGameSettings(lines);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Inconsistent game width");
        }
    }
}