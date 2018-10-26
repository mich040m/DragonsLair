using System.Collections.Generic;

namespace TournamentLib
{
    public class Tournament
    {
        private List<Team> teams = new List<Team>();
        private List<Round> rounds = new List<Round>();

        public string Name { get; private set; }

        public Tournament(string tournamentName)
        {
            Name = tournamentName;
        }

        public List<Team> GetTeams()
        {
            return teams;
        }

        public void AddTeam(Team team)
        {
            teams.Add(team);
        }

        public int GetNumberOfRounds()
        {
            return rounds.Count;
        }

        public Round GetRound(int idx)
        {
            return rounds[idx];
        }

        public void AddRound(Round round)
        {
            rounds.Add(round);
        }


        // ** Setup Test ***************
        public void SetupTestTeams()
        {
            teams = new List<Team>
            {
                new Team("The Valyrians"),
                new Team("The Spartans"),
                new Team("The Cretans"),
                new Team("The Thereans"),
                new Team("The Coans"),
                new Team("The Cnideans"),
                new Team("The Megareans"),
                new Team("The Corinthians")
            };
        }
        public void SetupTestRounds()
        {
            SetupTestTeams();

            // Setup first round with matches and teams
            Round round1 = new Round();

            Match match1 = new Match();
            Team team1 = teams[0]; // The Valyrians
            Team team2 = teams[1]; // The Spartans
            match1.FirstOpponent = team1;
            match1.SecondOpponent = team2;
            match1.Winner = team1;
            teams.Add(team1);
            teams.Add(team2);
            round1.AddMatch(match1);

            Match match2 = new Match();
            Team team3 = teams[2]; // The Cretans
            Team team4 = teams[3]; // The Thereans
            match2.FirstOpponent = team3;
            match2.SecondOpponent = team4;
            match2.Winner = team4;
            teams.Add(team3);
            teams.Add(team4);
            round1.AddMatch(match2);

            Match match3 = new Match();
            Team team5 = teams[4]; // The Coans
            Team team6 = teams[5]; // The Cnideans
            match3.FirstOpponent = team5;
            match3.SecondOpponent = team6;
            match3.Winner = team5;
            teams.Add(team5);
            teams.Add(team6);
            round1.AddMatch(match3);

            Match match4 = new Match();
            Team team7 = teams[6]; // The Megareans
            Team team8 = teams[7]; // The Corinthians
            match4.FirstOpponent = team7;
            match4.SecondOpponent = team8;
            match4.Winner = team8;
            teams.Add(team7);
            teams.Add(team8);
            round1.AddMatch(match4);

            rounds.Add(round1);

            // Setup second round with matches and teams
            Round round2 = new Round();

            Match match5 = new Match();
            match5.FirstOpponent = team1; // The Valyrians
            match5.SecondOpponent = team4; // The Thereans
            match5.Winner = team1;
            round2.AddMatch(match5);

            Match match6 = new Match();
            match6.FirstOpponent = team5; // The Coans
            match6.SecondOpponent = team8; // The Corinthians
            match6.Winner = team5;
            round2.AddMatch(match6);

            rounds.Add(round2);

            // Setup third round with matches and teams
            Round round3 = new Round();

            Match match7 = new Match();
            match7.FirstOpponent = team1; // The Valerians
            match7.SecondOpponent = team5; // The Coans
            match7.Winner = team5;
            round3.AddMatch(match7);

            rounds.Add(round3);
        }
    }
}
