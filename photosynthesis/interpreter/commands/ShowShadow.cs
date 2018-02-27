using System;

namespace photosynthesis.interpreter.commands
{
    public class ShowShadow : Command
    {
        public GameMode GetUseability()
        {
            return GameMode.Init | GameMode.Playing;
        }

        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            Console.WriteLine(gameState.Board.ShadowsHumanReadable());
            return new CommandResponse(CommandState.Successful);
        }
    }
}
