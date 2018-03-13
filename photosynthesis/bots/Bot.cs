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
        /// This will be called during the starting rounds when players place their starting trees.
        /// </summary>
        /// <returns>A list of commands for the interpreter.</returns>
        public abstract List<string> SubmitInitialMove(GameState gameState);

        /// <summary>
        /// This will be called during the main part of the game to request what to do next.
        /// </summary>
        /// <returns>A list of commands for the interpreter.</returns>
        public abstract List<string> SubmitMove(GameState gameState);

        private CommandInterpreter commandInterpreter;

        public Bot()
        {
            commandInterpreter = new CommandInterpreter();
        }

        protected bool CanPlaceStartingTree(Hex hex, GameState gameState)
        {
            // TODO
            return false;
        }

        protected bool PlaceStartingTree(Hex hex, GameState gameState)
        {
            List<string> cmd = ("placestartingtree " + hex.AsCommandInput()).Split(' ').ToList();
            CommandState response = commandInterpreter.DoAction(gameState, cmd);
            return response != CommandState.Failure;
        }

        protected bool CanBuy(Token token, GameState gameState)
        {
            // TODO
            return false;
        }

        /// <summary>
        /// Attempts to buy the given Token from your shop.
        /// </summary>
        /// <param name="token">The Token to buy.</param>
        /// <returns>True if the command succeeded, otherwise false.</returns>
        protected bool Buy(Token token, GameState gameState)
        {
            List<string> cmd = ("buy " + token.ToString()).Split(' ').ToList();
            CommandState response = commandInterpreter.DoAction(gameState, cmd);
            return response != CommandState.Failure;
        }

        protected bool CanGrow(Hex hex, GameState gameState)
        {
            // TODO
            return false;
        }

        protected bool Grow(Hex hex, GameState gameState)
        {
            List<string> cmd = ("grow " + hex.AsCommandInput()).Split(' ').ToList();
            CommandState response = commandInterpreter.DoAction(gameState, cmd);
            return response != CommandState.Failure;
        }

        protected bool CanSeed(Hex from, Hex to, GameState gameState)
        {
            // TODO
            return false;
        }

        protected bool Seed(Hex from, Hex to, GameState gameState)
        {
            List<string> cmd = string.Format("{0} {1} {2}", "seed", from.AsCommandInput(), to.AsCommandInput()).Split(' ').ToList();
            CommandState response = commandInterpreter.DoAction(gameState, cmd);
            return response != CommandState.Failure;
        }

        /// <summary>
        /// A Pass indicates the end of your turn, play will continue with the next player.
        /// </summary>
        protected void Pass(GameState gameState)
        {
            commandInterpreter.DoAction(gameState, new List<string>() { "pass" });
        }
    }
}