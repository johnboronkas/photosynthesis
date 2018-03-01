using photosynthesis.state;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace photosynthesis
{
    public class GameState
    {
        public GameMode GameMode { get; set; }
        public int MaxRounds { get; private set; }
        private const int NumAdvancedRounds = 4;
        private const int NumNormalRounds = 3;
        public int CurrentRound { get; private set; }
        public List<Player> Players { get; private set; }
        public Dictionary<Team, Player> TeamToPlayer;
        public int PlayerNumberFirstToMove { get; private set; }
        public int CurrentPlayerNumber { get; private set; }
        public Player CurrentPlayer { get; private set; }
        public Board Board { get; private set; }
        public ScoreTokens ScoreTokens { get; private set; }
        public GameFile GameFile { get; private set; }

        public GameState(GameMode gameMode, List<Player> players, Board board, ScoreTokens scoreTokens, GameFile gameFile)
        {
            GameMode = gameMode;
            UseAdvancedRules(GameMode.IsSet(GameMode.Advanced));

            CurrentRound = 0;

            Players = players;
            TeamToPlayer = new Dictionary<Team, Player>();
            players.ForEach((player) =>
            {
                TeamToPlayer.Add(player.Team, player);
            });

            PlayerNumberFirstToMove = 0;
            CurrentPlayerNumber = 0;
            CurrentPlayer = Players[CurrentPlayerNumber];
            Board = board;
            ScoreTokens = scoreTokens;
            GameFile = gameFile;
        }

        public void UseAdvancedRules(bool advancedMode)
        {
            MaxRounds = advancedMode ? NumAdvancedRounds : NumNormalRounds;
        }

        public void SetCurrentPlayer(int playerNumber)
        {
            CurrentPlayerNumber = playerNumber;
            CurrentPlayer = Players[CurrentPlayerNumber];
        }

        public void EndTurn()
        {
            CurrentPlayer.UsedSpaces.Clear();

            CurrentPlayerNumber = ++CurrentPlayerNumber % Players.Count;
            if (CurrentPlayerNumber == PlayerNumberFirstToMove)
            {
                PlayerNumberFirstToMove = CurrentPlayerNumber = ++CurrentPlayerNumber % Players.Count;
                Board.AdvanceSunPosition();
                if (GameMode.IsSet(GameMode.HumanFriendly)) Console.WriteLine(string.Format("Sun is now to the {0}.", Board.SunDirection));

                if (Board.SunDirection == Direction.North)
                {
                    CurrentRound++;
                    if (GameMode.IsSet(GameMode.HumanFriendly)) Console.WriteLine(string.Format("Begin Round {0}", CurrentRound + 1));

                    if (CurrentRound >= MaxRounds)
                    {
                        if (GameMode.IsSet(GameMode.HumanFriendly)) Console.WriteLine("\n---- The game has ended ----");
                        EndOfGame();
                    }
                }

                CollectLightPoints();
            }

            CurrentPlayer = Players[CurrentPlayerNumber];
        }

        public void CollectLightPoints()
        {
            foreach (Space space in Board.State.Values)
            {
                Player player;
                if (TeamToPlayer.TryGetValue(space.Team, out player))
                {
                    if (space.IsLit)
                    {
                        player.AddLightPoints((int)space.Token);
                    }
                }
            }
        }

        public void EndOfGame()
        {
            List<Player> finalPlacings = Players.OrderByDescending((player) => player.GetCurrentFinalScore()).ToList();
            var sb = new StringBuilder();
            finalPlacings.ForEach((player) => sb.AppendFormat("{0}: {1}\n", player.Team, player.GetCurrentFinalScore()));

            string scores = sb.ToString();
            Console.WriteLine(scores);
            GameFile.AddMove(scores);
        }
    }
}
