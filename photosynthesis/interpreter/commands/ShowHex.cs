using System;

namespace photosynthesis.interpreter.commands
{
    public class ShowHex : Command
    {
        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            Console.WriteLine(gameState.Board.HexesHumanReadable());
            return new CommandResponse(CommandState.Successful);
        }
    }
}
