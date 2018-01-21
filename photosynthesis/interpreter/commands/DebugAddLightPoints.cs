﻿using photosynthesis.state;

namespace photosynthesis.interpreter.commands
{
    public class DebugAddLightPoints : Command
    {
        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            if (GameState.DebugMode)
            {
                gameState.Players.ForEach((player) =>
                {
                    player.AddLightPoints(Player.MaxLightPoints);
                });

                return new CommandResponse(true);
            }
            else
            {
                return new CommandResponse(false, "Cannot use debug commands if debug mode is not set in GameState.");
            }
        }
    }
}