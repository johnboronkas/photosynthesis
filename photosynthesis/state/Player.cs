using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public static int[] ShopSeedCost = new int[] { 1, 1, 2, 2 };

        public const int ShopMaxSmallTrees = 4;
        public static int[] ShopSmallTreeCost = new int[] { 2, 2, 3, 3 };

        public const int ShopMaxMediumTrees = 3;
        public static int[] ShopMediumTreeCost = new int[] { 3, 3, 4 };

        public const int ShopMaxLargeTrees = 2;
        public static int[] ShopLargeTreeCost = new int[] { 4, 5 };

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
        public int LightPoints { get; private set; }
        public List<Token> Hand { get; private set; }
        public List<Token> Shop { get; private set; }
        public int Score { get; private set; }

        public Player(Team team)
        {
            Team = team;
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
        }

        public void AddLightPoints(int lightPoints)
        {
            LightPoints = Math.Min(LightPoints + lightPoints, MaxLightPoints);
        }

        public bool TrySubtractLightPoints(int lightPointCost)
        {
            if (LightPoints < lightPointCost)
            {
                return false;
            }
            else
            {
                LightPoints -= lightPointCost;
                return true;
            }
        }

        public void AddScore(int spaceScoreValue, ScoreTokens scoreTokens)
        {
            Score += scoreTokens.CollectNext(spaceScoreValue);
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
