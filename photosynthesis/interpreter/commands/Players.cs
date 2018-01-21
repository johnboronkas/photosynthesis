using System;

namespace photosynthesis.interpreter.commands
{
    public class Players : Command
    {
        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            gameState.Players.ForEach((player) =>
            {
                Console.WriteLine(player);
            });

            return new CommandResponse(true);
        }
    }
}
