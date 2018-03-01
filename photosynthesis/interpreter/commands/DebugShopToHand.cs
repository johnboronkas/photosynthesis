namespace photosynthesis.interpreter.commands
{
    public class DebugShopToHand : Command
    {
        public GameMode GetUseability()
        {
            return GameMode.Debug | GameMode.Playing;
        }

        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            gameState.Players.ForEach((player) =>
            {
                player.Hand.AddRange(player.Shop);
                player.Shop.Clear();
            });

            return new CommandResponse(CommandState.GameStateUpdated);
        }
    }
}
