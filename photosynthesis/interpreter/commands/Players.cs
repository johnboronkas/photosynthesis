using System;

namespace photosynthesis.interpreter.commands
{
    public class Players : Command
    {
        public GameMode GetUseability()
        {
            return GameMode.Init | GameMode.Playing;
        }

        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            gameState.Players.ForEach((player) =>
            {
                Console.WriteLine(player);
            });

            return new CommandResponse(CommandState.Successful);
        }
    }
}
