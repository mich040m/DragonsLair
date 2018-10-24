using System.Collections.Generic;

namespace TournamentLib
{
    public class Round
    {
        private List<Match> matches = new List<Match>();
        
        public void AddMatch(Match m)
        {
            matches.Add(m);
        }

        public Match GetMatch(string teamName1, string teamName2)
        {
            
            foreach (Match match in matches)
            {
                if (match.FirstOpponent.ToString() == teamName1 && match.SecondOpponent.ToString() == teamName2)
                {
                    return match;
                }
            }
            return null;
            
        }

        public bool isMatchesFinished()
        {
            foreach (Match match in matches)
            { 
            if (match.Winner == null)
            {
                return false;
            }
                
            }
            return true;
        }

        public List<Team> GetWinningTeams()
        {
            List<Team> teams = new List<Team>();
            foreach (Match match in matches)
            {
                teams.Add(match.Winner);
            }

            return teams;
        }

        public List<Team> GetLosingTeams()
        {
            List<Team> losers = new List<Team>();
            foreach (Match mac in matches)
            {
                if (mac.FirstOpponent == mac.Winner)
                {
                    losers.Add(mac.SecondOpponent);
                }
                else
                {
                    losers.Add(mac.FirstOpponent);
                }
            }
            return losers;
        }
    }
}
