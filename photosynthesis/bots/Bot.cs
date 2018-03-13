using System.Collections.Generic;
using System.Linq;
using photosynthesis.interpreter;
using photosynthesis.interpreter.commands;
using photosynthesis.state;

namespace photosynthesis.bots
{
    /// <summary>
    /// All bots must extend this class.
    /// 
    /// Note that GameState is the actual GameState used by the game engine, so don't mess with it.
    /// You may access and look at anything within it, but may not modifiy it.
    /// There are no automated checks for this because deep copies are a pita and I don't feel like implementing momentos or hashes.
    /// 
    /// I will be doing code reviews before every match, so please play by the rules.
    /// 
    /// I'm always available for questions or reviews if you are unsure if something
    /// you are doing is legal or not.
    /// 
    /// 
    /// RULES
    /// TODO
    /// 
    /// </summary>
    public abstract class Bot
    {
        /// <summary>
        /// This will be called during your turn to request what to do next.
        /// Don't forget about the initial setup (gameState.GameMode.IsSet(GameMode.Init)).
        /// </summary>
        /// <returns>A list of commands for the interpreter.</returns>
        public abstract List<string> SubmitMove(GameState gameState);

        private CommandInterpreter commandInterpreter;

        public Bot()
        {
            commandInterpreter = new CommandInterpreter();
        }

        /// <summary>
        /// Returns true if this move is able to be used, otherwise false.
        /// Starting trees may only be placed on the perimeter of the map.
        /// </summary>
        /// <param name="hex">The hex to attempt to place your starting tree on.</param>
        /// <param name="gameState">The GameState to test against.</param>
        /// <returns></returns>
        protected bool CanPlaceStartingTree(Hex hex, GameState gameState)
        {
            var cmd = ("placestartingtree " + hex.AsCommandInput()).Split(' ').ToList();
            return commandInterpreter.DoAction(gameState, cmd, checkOnly: true) != CommandState.Failure;
        }

        /// <summary>
        /// Returns true if this move was successfully used, otherwise false.
        /// Starting trees may only be placed on the perimeter of the map.
        /// </summary>
        /// <param name="hex">The hex to attempt to place your starting tree on.</param>
        /// <param name="gameState">The GameState to test against.</param>
        protected bool PlaceStartingTree(Hex hex, GameState gameState)
        {
            var cmd = ("placestartingtree " + hex.AsCommandInput()).Split(' ').ToList();
            return commandInterpreter.DoAction(gameState, cmd) != CommandState.Failure;
        }

        protected bool CanBuy(Token token, GameState gameState)
        {
            var cmd = ("buy " + token.ToString()).Split(' ').ToList();
            return commandInterpreter.DoAction(gameState, cmd, checkOnly: true) != CommandState.Failure;
        }

        /// <summary>
        /// Attempts to buy the given Token from your shop.
        /// </summary>
        /// <param name="token">The Token to buy.</param>
        /// <returns>True if the command succeeded, otherwise false.</returns>
        protected bool Buy(Token token, GameState gameState)
        {
            var cmd = ("buy " + token.ToString()).Split(' ').ToList();
            return commandInterpreter.DoAction(gameState, cmd) != CommandState.Failure;
        }

        protected bool CanGrow(Hex hex, GameState gameState)
        {
            var cmd = ("grow " + hex.AsCommandInput()).Split(' ').ToList();
            return commandInterpreter.DoAction(gameState, cmd, checkOnly: true) != CommandState.Failure;
        }

        protected bool Grow(Hex hex, GameState gameState)
        {
            var cmd = ("grow " + hex.AsCommandInput()).Split(' ').ToList();
            return commandInterpreter.DoAction(gameState, cmd) != CommandState.Failure;
        }

        protected bool CanSeed(Hex from, Hex to, GameState gameState)
        {
            var cmd = string.Format("{0} {1} {2}", "seed", from.AsCommandInput(), to.AsCommandInput()).Split(' ').ToList();
            return commandInterpreter.DoAction(gameState, cmd, checkOnly: true) != CommandState.Failure;
        }

        protected bool Seed(Hex from, Hex to, GameState gameState)
        {
            var cmd = string.Format("{0} {1} {2}", "seed", from.AsCommandInput(), to.AsCommandInput()).Split(' ').ToList();
            return commandInterpreter.DoAction(gameState, cmd) != CommandState.Failure;
        }

        /// <summary>
        /// A Pass indicates the end of your turn, play will continue with the next player.
        /// Note that Passing is automagically done when placing your starting trees.
        /// </summary>
        protected void Pass(GameState gameState)
        {
            if (!gameState.GameMode.IsSet(GameMode.Playing)) return;
            commandInterpreter.DoAction(gameState, new List<string>() { "pass" });
        }
    }
}