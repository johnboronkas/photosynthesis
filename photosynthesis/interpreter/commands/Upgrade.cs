using photosynthesis.state;
using System.Linq;

namespace photosynthesis.interpreter.commands
{
    public class Upgrade : Command
    {
        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            Player player = gameState.CurrentPlayer;
            Space space;
            if (!gameState.Board.State.TryGetValue(CommandInterpreter.ParamsToHex(parameters.Skip(1).Take(3).ToList()), out space))
            {
                return new CommandResponse(false, "Invalid hex. Use 'ShowHex' to view cube coordinates.");
            }

            if (space.Team != player.Team) { return new CommandResponse(false, "Cannot upgrade unowned hex."); }

            if (GameState.AdvancedMode)
            {
                if (!space.IsLit) { return new CommandResponse(false, "Cannot use an unlit hex."); }
            }

            Token currentToken = space.Token;
            Token nextToken = currentToken + 1;

            if (nextToken == Token.Score)
            {
                if (!player.TrySubtractLightPoints((int)nextToken)) { return new CommandResponse(false, "Insufficient light points."); }

                player.AddScore(space.ScoreValue, gameState.ScoreTokens);

                player.ShopAddToken(currentToken);
                space.Clear();
                gameState.Board.UpdateShadows();
                return new CommandResponse(true);
            }

            if (!player.Hand.Contains(nextToken)) { return new CommandResponse(false, "Upgraded token missing from hand. Must buy one from the shop first."); }
            if (!player.TrySubtractLightPoints((int)nextToken)) { return new CommandResponse(false, "Insufficient light points."); }

            player.Hand.Remove(nextToken);
            space.Set(player.Team, nextToken);
            player.ShopAddToken(currentToken);

            gameState.Board.UpdateShadows();
            return new CommandResponse(true);
        }
    }
}
