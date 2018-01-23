using System;

namespace photosynthesis.interpreter.commands
{
    public class ShowShadow : Command
    {
        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            Console.WriteLine(gameState.Board.ShadowsHumanReadable());
            return new CommandResponse(true);
        }
    }
}
