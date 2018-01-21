using System;

namespace photosynthesis.interpreter.commands
{
    public class Exit : Command
    {
        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            Environment.Exit(0);
            return new CommandResponse(true);
        }
    }
}
