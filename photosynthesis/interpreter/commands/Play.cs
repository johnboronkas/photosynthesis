using System;

namespace photosynthesis.interpreter.commands
{
    public class Play : Command
    {
        public GameMode GetUseability()
        {
            return GameMode.Config;
        }

        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            if (gameState.Players.Count <= 0)
            {
                return new CommandResponse(CommandState.Failure, "Must have at least 1 player before starting the game.");
            }

            gameState.SetGameMode(GameMode.Config, false);
            gameState.SetGameMode(GameMode.Init, true);
            return new CommandResponse(CommandState.Successful);
        }

        public override string ToString()
        {
            return HelpString.Create(GetType().Name, "", "Start the game already! Use this command to accept the current configuration and begin playing.");
        }
    }
}
