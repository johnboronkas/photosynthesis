namespace photosynthesis.interpreter.commands
{
    public class DebugShopToHand : Command
    {
        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            if (GameState.DebugMode)
            {
                gameState.Players.ForEach((player) =>
                {
                    player.Hand.AddRange(player.Shop);
                    player.Shop.Clear();
                });

                return new CommandResponse(CommandState.GameStateUpdated);
            }
            else
            {
                return new CommandResponse(CommandState.Failure, "Cannot use debug commands if debug mode is not set in GameState.");
            }
        }
    }
}
