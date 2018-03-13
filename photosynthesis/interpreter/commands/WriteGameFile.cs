using System;

namespace photosynthesis.interpreter.commands
{
    public class WriteGameFile : Command
    {
        public GameMode GetUseability()
        {
            return GameMode.Init | GameMode.Playing;
        }

        public CommandResponse CanPerform(GameState gameState, params string[] parameters)
        {
            return new CommandResponse(CommandState.Successful);
        }

        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            var path = Environment.CurrentDirectory + "\\gamefile.txt";
            gameState.GameFile.WriteToDisk(path);
            Console.WriteLine(string.Format("Game file written to: `{0}`.", path));
            return new CommandResponse(CommandState.Successful);
        }

        public override string ToString()
        {
            return HelpString.Create(GetType().Name, "", "Writes the current gamefile to disk (overwrites).");
        }
    }
}
