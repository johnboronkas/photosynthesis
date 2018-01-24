using photosynthesis.state;
using System.Linq;

namespace photosynthesis.interpreter.commands
{
    public class Seed : Command
    {
        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            Player player = gameState.CurrentPlayer;

            Space spaceFrom;
            if (!gameState.Board.State.TryGetValue(CommandInterpreter.ParamsToHex(parameters.Skip(1).Take(3).ToList()), out spaceFrom))
            {
                return new CommandResponse(false, "Invalid source hex. Use 'ShowHex' to view cube coordinates.");
            }

            if (player.UsedSpaces.Contains(spaceFrom)) return new CommandResponse(false, "Cannot use the same hex more than once a turn.");

            if (spaceFrom.Team != player.Team) return new CommandResponse(false, "Cannot seed from unowned hex.");
            if (Token.SmallTree <= spaceFrom.Token && spaceFrom.Token <= Token.LargeTree) return new CommandResponse(false, "Cannot seed from non-tree token.");

            if (GameState.AdvancedMode)
            {
                if (!spaceFrom.IsLit) { return new CommandResponse(false, "Cannot use an unlit hex."); }
            }

            if (!player.Hand.Contains(Token.Seed)) return new CommandResponse(false, "Seed missing from hand. Must buy one from the shop first.");

            Space spaceTo;
            if (!gameState.Board.State.TryGetValue(CommandInterpreter.ParamsToHex(parameters.Skip(4).Take(3).ToList()), out spaceTo))
            {
                return new CommandResponse(false, "Invalid from hex. Use 'ShowHex' to view cube coordinates.");
            }

            if (spaceTo.Token != Token.None) return new CommandResponse(false, "Destination hex not empty.");
            if (!player.TrySubtractLightPoints(Player.ShootSeedCost)) return new CommandResponse(false, "Insufficient light points.");

            player.Hand.Remove(Token.Seed);
            spaceTo.Set(player.Team, Token.Seed);
            player.UsedSpaces.Add(spaceFrom);
            return new CommandResponse(true);
        }
    }
}
