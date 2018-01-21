using System;

namespace photosynthesis.interpreter.commands
{
    public class WriteGameFile : Command
    {
        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            var path = Environment.CurrentDirectory + "\\gamefile.txt";
            gameState.GameFile.WriteToDisk(path);
            Console.WriteLine(string.Format("Game file written to: `{0}`.", path));
            return new CommandResponse(true);
        }
    }
}
