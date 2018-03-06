using photosynthesis.state;
using System.Linq;

namespace photosynthesis.interpreter.commands
{
    public class Seed : Command
    {
        public GameMode GetUseability()
        {
            return GameMode.Playing;
        }

        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            Player player = gameState.CurrentPlayer;

            Space spaceFrom;
            if (!gameState.Board.State.TryGetValue(CommandInterpreter.ParamsToHex(parameters.Skip(1).Take(3).ToList()), out spaceFrom))
            {
                return new CommandResponse(CommandState.Failure, "Invalid source hex. Use 'ShowHex' to view cube coordinates.");
            }

            if (player.UsedSpaces.Contains(spaceFrom)) return new CommandResponse(CommandState.Failure, "Cannot use the same hex more than once a turn.");

            if (spaceFrom.Team != player.Team) return new CommandResponse(CommandState.Failure, "Cannot seed from unowned hex.");
            if (Token.SmallTree <= spaceFrom.Token && spaceFrom.Token <= Token.LargeTree) return new CommandResponse(CommandState.Failure, "Cannot seed from non-tree token.");

            if (gameState.GameMode.IsSet(GameMode.Advanced))
            {
                if (!spaceFrom.IsLit) { return new CommandResponse(CommandState.Failure, "Cannot use an unlit hex."); }
            }

            if (!player.Hand.Contains(Token.Seed)) return new CommandResponse(CommandState.Failure, "Seed missing from hand. Must buy one from the shop first.");

            Space spaceTo;
            if (!gameState.Board.State.TryGetValue(CommandInterpreter.ParamsToHex(parameters.Skip(4).Take(3).ToList()), out spaceTo))
            {
                return new CommandResponse(CommandState.Failure, "Invalid from hex. Use 'ShowHex' to view cube coordinates.");
            }

            if (spaceTo.Token != Token.None) return new CommandResponse(CommandState.Failure, "Destination hex not empty.");
            if (!player.TrySubtractLightPoints(Player.ShootSeedCost)) return new CommandResponse(CommandState.Failure, "Insufficient light points.");

            player.Hand.Remove(Token.Seed);
            spaceTo.Set(player.Team, Token.Seed);
            player.UsedSpaces.Add(spaceFrom);
            return new CommandResponse(CommandState.GameStateUpdated);
        }

        public override string ToString()
        {
            return HelpString.Create(GetType().Name, "srcQ srcR srcS dstQ dstR dstS", "Shoots a seed from the source cube coordinate to the destination cube coordinate.");
        }
    }
}
