﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using photosynthesis.state;

namespace photosynthesis.interpreter.commands
{
    public class Help : Command
    {
        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            StringBuilder help = new StringBuilder();

            help.AppendLine("Help - Prints this help menu.");
            help.AppendLine("\n---- MOVES ----");
            help.AppendLine("PlaceStartingTree p q r - Places a small tree on the given cube coordinate. Can only be used on the outer rim of the board.");
            help.AppendLine("Buy tokenID - Buys a token from your shop.");
            help.AppendLine("Seed srcP srcQ srcR dstP dstQ dstR - Shoots a seed from the source cube coordinate to the destination cube coordinate.");
            help.AppendLine("Upgrade p q r - Upgrades the given cube coordinate.");
            help.AppendLine("Pass - End your turn and advance the game.");
            help.AppendLine("\n---- VISUAL ----");
            help.AppendLine("ShowBoard - Prints TeamNum and Token, where 9 is none.");
            help.AppendLine("ShowHex - Prints cube coordinates (p, q, r) of every hex.");
            help.AppendLine("Players - Prints Team : CurrentLightPoints for every player.");
            // TODO Show all player's shops and hands.
            // TODO Add score tokens.
            help.AppendLine("WriteGameFile - Writes the current gamefile to disk (overwrites).");
            help.AppendLine("\n---- DEBUG ---- (below commands may only be used if debug mode is set in GameState)");
            help.AppendLine("DebugAddLightPoints - Maxes out every player's light points.");
            help.AppendLine("DebugShopToHand - Moves all player's shop tokens into their hands.");

            Console.WriteLine(help.ToString());
            return new CommandResponse(true);
        }
    }
}
