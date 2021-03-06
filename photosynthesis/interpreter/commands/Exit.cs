﻿using System;

namespace photosynthesis.interpreter.commands
{
    public class Exit : Command
    {
        public GameMode GetUseability()
        {
            return GameMode.Config | GameMode.Init | GameMode.Playing;
        }

        public CommandResponse CanPerform(GameState gameState, params string[] parameters)
        {
            return new CommandResponse(CommandState.Successful);
        }

        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            Environment.Exit(0);
            return new CommandResponse(CommandState.Successful);
        }

        public override string ToString()
        {
            return HelpString.Create(GetType().Name, "", "Exits the program.");
        }
    }
}
