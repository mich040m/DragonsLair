using System.Collections.Generic;

namespace TournamentLib
{
    public class Round
    {
        private List<Match> matches = new List<Match>();

        public void metode()
        {
            foreach (Match item in matches)
            {
                SQL.InsertToMatches(item.FirstOpponent.Name.ToString(), item.SecondOpponent.Name.ToString(), item.Winner.Name.ToString());

            }
        }

        private Team freeRider = null;

        public Team FreeRider { get {   return freeRider; }set { freeRider = value; } }

        public void AddMatch(Match m)
        {
            matches.Add(m);

            if (m.Winner == null)
            {
                SQL.InsertToMatches(m.FirstOpponent.Name.ToString(), m.SecondOpponent.Name.ToString(), "INTET");
            }
            else
            {
                SQL.InsertToMatches(m.FirstOpponent.Name.ToString(), m.SecondOpponent.Name.ToString(), m.Winner.Name.ToString());
            }

        }

        public Match GetMatch(string teamName1, string teamName2)
        {
            foreach (Match mac in matches)
            {
                if (mac.FirstOpponent.ToString() == teamName1 && mac.SecondOpponent.ToString() == teamName2)
                {
                    return mac;
                }
            }
            return null;
        }

        public Match GetMatch(string winner)
        {
            foreach(Match m in matches)
            {
                if(winner == m.FirstOpponent.Name || winner == m.SecondOpponent.Name)
                {
                    return m;
                }
            }
            return null;
        }

        
        public bool IsMatchesFinished()
        {
            foreach (Match item in matches)
            {
                if (item.Winner == null)
                {
                    return false;
                }
                
            }

            return true;
        }

        public List<Team> GetWinningTeams()
        {
            List<Team> winners = new List<Team>();

            foreach (Match item in matches)
            {
                winners.Add(item.Winner);

                
            }
            return winners;
        }

        public List<Team> GetLosingTeams()
        {
            List<Team> loosers = new List<Team>();

            foreach (Match item in matches)
            {
                if (item.FirstOpponent == item.Winner )
                {
                    loosers.Add(item.SecondOpponent);
                }
                else if (item.SecondOpponent == item.Winner)
                {
                    loosers.Add(item.FirstOpponent);
                }
            }
            return loosers;
        }
    }
}
