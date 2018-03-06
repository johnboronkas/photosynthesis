using System.Linq;
using photosynthesis.state;

namespace photosynthesis.interpreter.commands
{
    public class PlaceStartingTree : Command
    {
        public GameMode GetUseability()
        {
            return GameMode.Init;
        }

        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            Space space;
            if (!gameState.Board.State.TryGetValue(CommandInterpreter.ParamsToHex(parameters.Skip(1).Take(3).ToList()), out space))
            {
                return new CommandResponse(CommandState.Failure, "Invalid hex. Use 'ShowHex' to view cube coordinates.");
            }

            if (space.Token != Token.None) return new CommandResponse(CommandState.Failure, "Cannot place starting tree on top of another token.");
            if (space.ScoreValue > 1) return new CommandResponse(CommandState.Failure, "Starting trees may only be placed on spaces that have a score value of 1 or less.");

            space.Set(gameState.CurrentPlayer.Team, Token.SmallTree);
            gameState.Board.UpdateShadows();

            return new CommandResponse(CommandState.GameStateUpdated);
        }

        public override string ToString()
        {
            return HelpString.Create(GetType().Name, "q r s", "Places a small tree on the given cube coordinate. Can only be used on the outer rim of the board.");
        }
    }
}
