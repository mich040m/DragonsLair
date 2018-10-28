using System.Collections.Generic;

namespace TournamentLib
{
    public class Round
    {
        private List<Match> matches = new List<Match>();

        private Team freeRider = null;

        public Team FreeRider { get {   return freeRider; }set { freeRider = value; } }

        public void AddMatch(Match m)
        {
            matches.Add(m);
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
