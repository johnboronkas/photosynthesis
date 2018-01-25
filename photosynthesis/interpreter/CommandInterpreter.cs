using System;
using System.Collections.Generic;
using System.Linq;
using photosynthesis.interpreter.commands;
using photosynthesis.state;
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;

namespace photosynthesis.interpreter
{
    public class CommandInterpreter
    {
        public CommandState DoAction(GameState gameState, List<string> action)
        {
            try
            {
                var type = Type.GetType("photosynthesis.interpreter.commands." + action.First(), true, true);
                Command command = (Command)Activator.CreateInstance(type);

                if (gameState.InitMode)
                {
                    if (!(command is PlaceStartingTree || command is ShowBoard || command is ShowHex || command is ShowShadow ||
                        command is Help || command is Exit || command is Players || command is WriteGameFile))
                    {
                        Console.WriteLine("Game is in initialize mode. Must use command PlaceStartingTree.");
                        return CommandState.Failure;
                    }
                }
                else
                {
                    if (command is PlaceStartingTree)
                    {
                        Console.WriteLine("Not allowed to use initialize command while game is playing.");
                        return CommandState.Failure;
                    }
                }

                CommandResponse response = command.Perform(gameState, action.ToArray());
                switch (response.State)
                {
                    case CommandState.GameStateUpdated:
                        gameState.GameFile.AddMove(gameState.CurrentPlayer.Team + " " + action.Aggregate((s1, s2) => { return s1 + " " + s2; }));
                        break;
                    case CommandState.Failure:
                        Console.WriteLine(response);
                        break;
                }

                return response.State;
            }
            catch (Exception e)
            {
                if (e is ArgumentNullException || e is TargetInvocationException ||
                    e is TypeLoadException || e is ArgumentException || e is FileNotFoundException ||
                    e is FileLoadException || e is BadImageFormatException || e is NotSupportedException ||
                    e is TargetInvocationException || e is MethodAccessException || e is MemberAccessException ||
                    e is InvalidComObjectException || e is MissingMethodException || e is COMException || e is InvalidOperationException ||
                    e is NullReferenceException || e is IndexOutOfRangeException)
                {
                    Console.WriteLine(e);
                    return CommandState.Failure;
                }

                throw;
            }
        }

        internal static Hex ParamsToHex(List<string> parameters)
        {
            return new Hex(int.Parse(parameters[0]), int.Parse(parameters[1]), int.Parse(parameters[2]));
        }
    }
}
