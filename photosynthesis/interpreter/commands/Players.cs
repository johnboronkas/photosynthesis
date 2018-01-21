﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace photosynthesis.interpreter.commands
{
    public class Players : Command
    {
        public CommandResponse Perform(GameState gameState, params string[] parameters)
        {
            gameState.Players.ForEach((player) =>
            {
                Console.WriteLine(player);
            });

            return new CommandResponse(true);
        }
    }
}
