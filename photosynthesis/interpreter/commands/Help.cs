using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using photosynthesis.state;

namespace photosynthesis.interpreter.commands
{
    public class Help : Command
    {
        public void Perform(GameState gameState, params string[] parameters)
        {
            StringBuilder help = new StringBuilder();

            help.AppendLine("Help");
            help.AppendLine();
            help.AppendLine("PlaceStartingTree p q r");
            help.AppendLine("Buy tokenID");
            help.AppendLine("Seed srcP srcQ srcR dstP dstQ dstR");
            help.AppendLine("Upgrade p q r");
            help.AppendLine("Pass");
            help.AppendLine();
            help.AppendLine("ShowBoard");
            help.AppendLine("ShowHex");
            // TODO Add show all player states command.
            help.AppendLine("WriteGameFile");

            Console.WriteLine(help.ToString());
        }
    }
}
