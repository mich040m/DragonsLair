using System.Collections.Generic;

namespace TournamentLib
{
    public class TournamentRepo
    {
        private Tournament winterTournament = new Tournament("Vinter Turnering"); //Stub code
        private List<Tournament> tournaments = new List<Tournament>();


        public List<Tournament> Tournaments{ get{ return Tournaments; }set { tournaments = value; } }
        public Tournament GetTournament(string name)
        {
            tournaments.Add(winterTournament); //for stub tests
            for (int i = 0; i < tournaments.Count; i++)
            {
                if (tournaments[i].Name.ToString() == name)
            {
                    return tournaments[i];
            }

            }
            return null;
        }

        public void SaveTournament(string s)
        {
            Tournament tournament = new Tournament(s);
            tournaments.Add(tournament);
            SQL.InsertToTable(s, "TOURNAMENT");
        }
        public void ShowAllTournaments()
        {
            for (int i = 0; i < tournaments.Count; i++)
            {
                System.Console.WriteLine(tournaments[i].Name.ToString());
            }
        }
    }
}