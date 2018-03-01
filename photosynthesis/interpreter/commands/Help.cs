using System;
using System.Text;

namespace photosynthesis.interpreter.commands
{
    public class Help : Command
    {
        public GameMode GetUseability()
        {
            return GameMode.Config | GameMode.Init | GameMode.Playing;
        }

        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            // TODO Do something smart here. Should be a way to auto-grab all of the commands and only show the commands that are relevant.

            StringBuilder help = new StringBuilder();

            help.AppendLine("Help - Prints this help menu.");
            help.AppendLine("Exit - Exits the program.");
            // TODO Save/load gamefile and resume play.
            // TODO Add setup commands (ie, StartGame RandomBot Human MiddleBot Human -- where bots are loaded via reflection).
            help.AppendLine("\n---- MOVES ----");
            help.AppendLine("PlaceStartingTree q r s - Places a small tree on the given cube coordinate. Can only be used on the outer rim of the board.");
            help.AppendLine("Buy token - Buys a token from your shop (seed, smalltree, mediumtree, largetree).");
            help.AppendLine("Seed srcQ srcR srcS dstQ dstR dstS - Shoots a seed from the source cube coordinate to the destination cube coordinate.");
            help.AppendLine("Grow q r s - Grows the given cube coordinate.");
            help.AppendLine("Pass - End your turn and advance the game.");
            help.AppendLine("\n---- VISUAL ----");
            help.AppendLine("ShowBoard - Prints TeamNum and Token, where '--' is none.");
            help.AppendLine("ShowHex - Prints cube coordinates (q, r, s) of every hex.");
            help.AppendLine("ShowShadow - Prints X if shaded, O if lit, and the tokenID for each hex.");
            help.AppendLine("Players - Prints player stats for every player.");
            // TODO Load gamefile and step through it forwards (to 'watch' the game).
            help.AppendLine("WriteGameFile - Writes the current gamefile to disk (overwrites).");
            help.AppendLine("\n---- DEBUG ---- (below commands may only be used if debug mode is set in GameState)");
            help.AppendLine("DebugAddLightPoints - Maxes out every player's light points.");
            help.AppendLine("DebugShopToHand - Moves all player's shop tokens into their hands.");

            Console.WriteLine(help.ToString());
            return new CommandResponse(CommandState.Successful);
        }
    }
}
