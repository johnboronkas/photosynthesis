using photosynthesis.state;
using System;

namespace photosynthesis.interpreter.commands
{
    public class Buy : Command
    {
        public GameMode GetUseability()
        {
            return GameMode.Playing;
        }

        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            string tokenInput = parameters[1];
            Token tokenToBuy;
            if (!Enum.TryParse(tokenInput, true, out tokenToBuy)) return new CommandResponse(CommandState.Failure, "Token to buy must be one of: seed, smalltree, mediumtree, or largetree.");

            Player player = gameState.CurrentPlayer;
            int? tokenCost = player.GetTokenCost(tokenToBuy);
            if (!tokenCost.HasValue) return new CommandResponse(CommandState.Failure, "Token to buy missing from the shop. Nothing to buy.");

            if (!player.TrySubtractLightPoints(tokenCost.Value)) return new CommandResponse(CommandState.Failure, "Insufficient light points.");
            player.Shop.Remove(tokenToBuy);
            player.Hand.Add(tokenToBuy);
            return new CommandResponse(CommandState.GameStateUpdated);
        }
    }
}
