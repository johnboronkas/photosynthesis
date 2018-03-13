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

        public CommandResponse CanPerform(GameState gameState, params string[] parameters)
        {
            string tokenInput = parameters[1];
            Token tokenToBuy;
            if (!Enum.TryParse(tokenInput, true, out tokenToBuy)) return new CommandResponse(CommandState.Failure, "Token to buy must be one of: seed, smalltree, mediumtree, or largetree.");

            Player player = gameState.CurrentPlayer;
            int? tokenCost = player.GetTokenCost(tokenToBuy);
            if (!tokenCost.HasValue) return new CommandResponse(CommandState.Failure, "Token to buy missing from the shop. Nothing to buy.");

            if (!player.CanAfford(tokenCost.Value)) return new CommandResponse(CommandState.Failure, "Insufficient light points.");

            return new CommandResponse(CommandState.Successful);
        }

        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            CommandResponse response = CanPerform(gameState, parameters);
            if (response.State == CommandState.Failure)
            {
                return response;
            }

            Player player = gameState.CurrentPlayer;
            Token tokenToBuy = (Token)Enum.Parse(typeof(Token), parameters[1], true);
            player.SubtractLightPoints(player.GetTokenCost(tokenToBuy).Value);
            player.Shop.Remove(tokenToBuy);
            player.Hand.Add(tokenToBuy);
            return new CommandResponse(CommandState.GameStateUpdated);
        }

        public override string ToString()
        {
            return HelpString.Create(GetType().Name, "seed/smalltree/mediumtree/largetree", "Buys a token from your shop.");
        }
    }
}
