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
            TournamentLib.SQL.InsertFirstOpponent(m.FirstOpponent.ToString(), "MATCHES");
            TournamentLib.SQL.InsertSecondOpponent(m.SecondOpponent.ToString(), "MATCHES");
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

        public Match GetMatch(string winner)
        {
            foreach(Match m in matches)
            {
                TournamentLib.SQL.InsertFirstOpponent(m.FirstOpponent.Name.ToString(), "MATCHES");
                TournamentLib.SQL.InsertSecondOpponent(m.SecondOpponent.Name.ToString(), "MATCHES");

                if (winner == m.FirstOpponent.Name || winner == m.SecondOpponent.Name)
                {
                    TournamentLib.SQL.InsertWinningTeam(m.Winner.Name.ToString(), "MATCHES");
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
                TournamentLib.SQL.InsertWinningTeam(item.Winner.Name.ToString(), "Matches");
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


        public void GetMatchesForDB()
        {
            foreach(Match item in matches)
            {
                TournamentLib.SQL.InsertToMatches(item.FirstOpponent.Name.ToString(), item.SecondOpponent.Name.ToString(), item.Winner.Name.ToString());
            }
        }
    }
}
