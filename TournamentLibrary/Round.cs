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
            // TODO: Implement this method
            
            return null;
        }

        public bool IsMatchesFinished()
        {
            // TODO: Implement this method
            return false;
        }

        public List<Team> GetWinningTeams()
        {
            // TODO: Implement this method
            List<Team> winner = new List<Team>();
            foreach (Match sieger in matches)
            {
                winner.Add(sieger.Winner);
            }
            return winner;
        }

        public List<Team> GetLosingTeams()
        {
            // TODO: Implement this method
            List<Team> looser = new List<Team>();
            foreach (Match taber in matches)
            {
                if(taber.Winner == taber.FirstOpponent)
                looser.Add(taber.SecondOpponent);

                else
                {
                    looser.Add(taber.FirstOpponent);
                }
            
            }
           
            return looser;
        }
    }
}
