using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using photosynthesis.bots;

namespace photosynthesis.state
{
    public class Player
    {
        public const int MaxLightPoints = 20;
        public const int ShootSeedCost = 1;

        public const int UpgradeSeedCost = 1;
        public const int UpgradeSmallTreeCost = 2;
        public const int UpgradeMediumTreeCost = 3;
        public const int UpgradeLargeTreeCost = 4;

        public const int ShopMaxSeeds = 4;
        public static int[] ShopSeedCost = new int[] { 2, 2, 1, 1 };

        public const int ShopMaxSmallTrees = 4;
        public static int[] ShopSmallTreeCost = new int[] { 3, 3, 2, 2 };

        public const int ShopMaxMediumTrees = 3;
        public static int[] ShopMediumTreeCost = new int[] { 4, 3, 3 };

        public const int ShopMaxLargeTrees = 2;
        public static int[] ShopLargeTreeCost = new int[] { 5, 4 };

        public static Dictionary<Token, int> ShopMaxes = new Dictionary<Token, int>()
        {
            { Token.Seed, ShopMaxSeeds },
            { Token.SmallTree, ShopMaxSmallTrees },
            { Token.MediumTree, ShopMaxMediumTrees },
            { Token.LargeTree, ShopMaxLargeTrees },
        };

        public static Dictionary<Token, int[]> ShopCosts = new Dictionary<Token, int[]>()
        {
            { Token.Seed, ShopSeedCost },
            { Token.SmallTree, ShopSmallTreeCost },
            { Token.MediumTree, ShopMediumTreeCost },
            { Token.LargeTree, ShopLargeTreeCost },
        };

        public Team Team { get; private set; }
        public string Name { get; private set; }
        public Bot Bot { get; private set; }
        public int LightPoints { get; private set; }
        public List<Token> Hand { get; private set; }
        public List<Token> Shop { get; private set; }
        public int Score { get; private set; }
        public List<Space> UsedSpaces { get; private set; }

        public Player(Team team, string name = "", Bot bot = null)
        {
            Team = team;
            Name = name;
            Bot = bot;
            LightPoints = 0;
            Hand = new List<Token>()
            {
                Token.Seed,
                Token.Seed,
                Token.SmallTree,
                Token.SmallTree,
                Token.MediumTree,
            };
            Shop = new List<Token>()
            {
                Token.Seed,
                Token.Seed,
                Token.Seed,
                Token.Seed,
                Token.SmallTree,
                Token.SmallTree,
                Token.SmallTree,
                Token.SmallTree,
                Token.MediumTree,
                Token.MediumTree,
                Token.MediumTree,
                Token.LargeTree,
                Token.LargeTree,
            };
            Score = 0;
            UsedSpaces = new List<Space>();
        }

        public void AddLightPoints(int lightPoints)
        {
            LightPoints = Math.Min(LightPoints + lightPoints, MaxLightPoints);
        }

        public void SubtractLightPoints(int lightPoints)
        {
            LightPoints = Math.Max(LightPoints - lightPoints, 0);
        }

        public bool CanAfford(int lightPointCost)
        {
            return LightPoints < lightPointCost;
        }

        public void AddScore(int spaceScoreValue, ScoreTokens scoreTokens)
        {
            Score += scoreTokens.CollectNext(spaceScoreValue);
        }

        public int GetCurrentFinalScore()
        {
            return Score + (LightPoints / 3);
        }

        public void ShopAddToken(Token token)
        {
            int shopTokenCount = GetTokenCount(Shop, token);
            if (shopTokenCount < ShopMaxes[token])
            {
                Shop.Add(token);
            }
        }

        public int GetTokenCount(List<Token> tokens, Token tokenToCount)
        {
            return tokens.Where(t => t == tokenToCount).Count();
        }

        /// <summary>
        /// Returns null if there are no more tokens of the provided type in the shop.
        /// </summary>
        public int? GetTokenCost(Token token)
        {
            int shopTokenCount = GetTokenCount(Shop, token);
            if (shopTokenCount <= 0) return null;

            return ShopCosts[token][shopTokenCount - 1];
        }

        public override string ToString()
        {
            StringBuilder player = new StringBuilder();

            player.AppendFormat("{0}: Score: {1}, Light Points: {2}\n", Team, Score, LightPoints);
            player.AppendFormat("\tHand:\n");
            player.AppendFormat("\t\tSeed: {0}, Sml: {1}, Med: {2}, Lrg: {3}\n",
                GetTokenCount(Hand, Token.Seed), GetTokenCount(Hand, Token.SmallTree), GetTokenCount(Hand, Token.MediumTree), GetTokenCount(Hand, Token.LargeTree));
            player.AppendFormat("\tShop:\n");
            player.AppendFormat("\t\tSeed: {0}, Sml: {1}, Med: {2}, Lrg: {3}\n",
                GetTokenCount(Shop, Token.Seed), GetTokenCount(Shop, Token.SmallTree), GetTokenCount(Shop, Token.MediumTree), GetTokenCount(Shop, Token.LargeTree));
            player.AppendLine();

            return player.ToString();
        }
    }
}
