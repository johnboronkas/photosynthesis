using System;

namespace photosynthesis.interpreter.commands
{
    public class ShowConfig : Command
    {
        public GameMode GetUseability()
        {
            return GameMode.Config | GameMode.Init | GameMode.Playing;
        }

        public CommandResponse CanPerform(GameState gameState, params string[] parameters)
        {
            return new CommandResponse(CommandState.Successful);
        }

        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            Console.WriteLine(gameState.GameMode);
            return new CommandResponse(CommandState.Successful);
        }

        public override string ToString()
        {
            return HelpString.Create(GetType().Name, "", "Shows which configuration options are enabled for this game.");
        }
    }
}
