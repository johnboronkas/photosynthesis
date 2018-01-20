using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace photosynthesis.state
{
    public class Space
    {
        public Hex Hex { get; private set; }
        public Team Team { get; private set; }
        public Token Token { get; private set; }
        public bool IsLit { get; set; }
        public int ScoreValue { get; private set; }

        public Space(Hex hex)
        {
            Hex = hex;
            Set(Team.None, Token.None);
            IsLit = true;
        }

        public void Set(Team team, Token token)
        {
            if (team == 0 && token != 0) throw new ArgumentException("Token placed without a team.");
            if (team != 0 && token == 0) throw new ArgumentException("No token on space, but a team owns it.");

            Team = team;
            Token = token;
        }

        public override string ToString()
        {
            return string.Format("{0}{1}", (int)Team, (int)Token);
        }
    }
}
