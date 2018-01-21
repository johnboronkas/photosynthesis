using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace photosynthesis.state
{
    public class ScoreTokens
    {
        public List<int> Value1Tokens = new List<int>() { 14, 14, 13, 13, 13, 12, 12, 12, 12 };

        // TODO PICKUP Add rest of score tokens and test.
        public List<int> Value2Tokens = new List<int>() { 14, 14, 13, 13, 13, 12, 12, 12, 12 };
        public List<int> Value3Tokens = new List<int>() { 14, 14, 13, 13, 13, 12, 12, 12, 12 };
        public List<int> Value4Tokens = new List<int>() { 14, 14, 13, 13, 13, 12, 12, 12, 12 };

        public Dictionary<int, List<int>> ValueToTokens;

        public ScoreTokens()
        {
            ValueToTokens = new Dictionary<int, List<int>>()
            {
                { 1, Value1Tokens },
                { 2, Value2Tokens },
                { 3, Value3Tokens },
                { 4, Value4Tokens },
            };
        }

        public int CollectNext(int spaceScoreValue)
        {
            for (int i = spaceScoreValue; i >= 1; i--)
            {
                List<int> currentTokens = ValueToTokens[i];
                if (currentTokens.Count > 0)
                {
                    int scoreValue = currentTokens[0];
                    currentTokens.RemoveAt(0);
                    return scoreValue;
                }
            }

            return 0;
        }
    }
}
