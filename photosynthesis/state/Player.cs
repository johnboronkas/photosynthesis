using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public Team Team { get; private set; }
        public int LightPoints { get; private set; }
        public List<Token> Hand { get; private set; }
        public List<Token> Shop { get; private set; }

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
        }

        public void CollectLightPoints(int lightPoints)
        {
            LightPoints = Math.Min(LightPoints + lightPoints, MaxLightPoints);
        }
    }
}
