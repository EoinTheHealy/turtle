using CommandLine;

namespace TurtleChallengeApp
{
    public class Options
    {
        [Option("settings", Required = true, HelpText = "The settings file.")]
        public string Settings { get; set; }

        [Option("moves", Required = true, HelpText = "The moves file.")]
        public string Moves { get; set; }

        [Option("draw", Required = false, HelpText = "Draws the board.")]
        public bool DrawBoard { get; set; }
    }
}