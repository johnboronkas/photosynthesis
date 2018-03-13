using System;

namespace photosynthesis.interpreter.commands
{
    public class ShowShadow : Command
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
            Console.WriteLine(gameState.Board.ShadowsHumanReadable());
            return new CommandResponse(CommandState.Successful);
        }

        public override string ToString()
        {
            return HelpString.Create(GetType().Name, "", "Prints X if shaded, O if lit, and the tokenID for each hex.");
        }
    }
}
