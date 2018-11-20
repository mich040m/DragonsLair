using System.Collections.Generic;

namespace TournamentLib
{
    public class TournamentRepo
    {
        private Tournament winterTournament = new Tournament("Vinter Turnering");
        List<Tournament> tournaments = new List<Tournament>();

        public Tournament GetTournament(string name)
        {
            if (name == "Vinter Turnering")
            {
                SQL.InsertToTable(name, "TOURNAMENT");
                return winterTournament;
            }
            return null;
        }

        public void SaveTournament(string s,TournamentRepo obj)
        {
            Tournament tournament = new Tournament(s);
            obj.tournaments.Add(tournament);
            SQL.InsertToTable(s, "TOURNAMENT");
        }
        public void ShowAllTournaments(TournamentRepo obj)
        {
            for (int i = 0; i < obj.tournaments.Count; i++)
            {
                System.Console.WriteLine(obj.tournaments[i].Name.ToString());
            }
        }
    }
}