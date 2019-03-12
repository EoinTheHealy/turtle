using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CommandLine;
using TurtleChallenge;

namespace TurtleChallengeApp
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                   .WithParsed<Options>(o =>
                   {
                       if (!File.Exists(o.Settings))
                       {
                           Console.WriteLine("Settings file not found.");
                           return;
                       }

                       if (!File.Exists(o.Moves))
                       {
                           Console.WriteLine("Moves file not found.");
                           return;
                       }

                       string[] settingsData = File.ReadAllLines(o.Settings);
                       string[] movesData = File.ReadAllLines(o.Moves);

                       GameConsole newGame = GameParser.ParseGameConsoleSettings(settingsData);

                       List<Move> moves = GameParser.ParseGameMoves(movesData);

                       SimulateMoves(newGame, moves, o.DrawBoard);
                   });
        }

        private static void SimulateMoves(GameConsole newGame, List<Move> moves, bool draw)
        {
            if (draw)
            {
                Console.WriteLine("Start position");
                Console.WriteLine(newGame.Display());
            }

            try
            {
                for (int i = 0; i < moves.Count; ++i)
                {
                    newGame.Move(moves[i]);
                    if (draw)
                    {
                        Console.WriteLine($"After move {i + 1}: {moves[i]}");
                        Console.WriteLine(newGame.Display());
                    }
                }
            }
            catch (InvalidMoveException)
            {
                Console.WriteLine("Invalid move received");
                Console.WriteLine("Press enter to exit");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Game finished in state: " + newGame.State);
            Console.WriteLine("Press enter to exit");
            Console.ReadKey();
        }
    }
}