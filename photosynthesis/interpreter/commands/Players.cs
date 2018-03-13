using System;

namespace photosynthesis.interpreter.commands
{
    public class Players : Command
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
            gameState.Players.ForEach((player) =>
            {
                Console.WriteLine(player);
            });

            if (gameState.Players.Count <= 0)
            {
                Console.WriteLine("No players are currently in this game.");
            }

            return new CommandResponse(CommandState.Successful);
        }

        public override string ToString()
        {
            return HelpString.Create(GetType().Name, "", "Prints player stats for every player.");
        }
    }
}
