using System.Collections.Generic;

namespace TournamentLib
{
    public class TournamentRepo
    {
        private Tournament winterTournament = new Tournament("Vinter Turnering");

        public Tournament GetTournament(string name)
        {
            if (name == "Vinter Turnering")
            {
                return winterTournament;
            }
            return null;
        }
    }
}