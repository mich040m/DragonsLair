using System.Collections.Generic;

namespace TournamentLib
{
    public class Tournament
    {
        public string Name { get; private set; }

        public Tournament(string tournamentName)
        {
            Name = tournamentName;
        }

        public List<Team> GetTeams()
        {
            return new List<Team>(new Team[] {
                new Team("The Valyrians"),
                new Team("The Spartans"),
                new Team("The Cretans"),
                new Team("The Thereans"),
                new Team("The Coans"),
                new Team("The Cnideans"),
                new Team("The Megareans"),
                new Team("The Corinthians")
            });
        }

        public int GetNumberOfRounds()
        {
            return 3;
        }
        
        public Round GetRound(int idx)
        {
            Round r = new Round();
            if (idx == 0)
            {
                Match match1 = new Match();
                match1.FirstOpponent = new Team("The Valyrians");
                match1.SecondOpponent = new Team("The Spartans");
                match1.Winner = match1.FirstOpponent;
                r.AddMatch(match1);

                Match match2 = new Match();
                match2.FirstOpponent = new Team("The Cretans");
                match2.SecondOpponent = new Team("The Thereans");
                match2.Winner = match2.SecondOpponent;
                r.AddMatch(match2);

                Match match3 = new Match();
                match3.FirstOpponent = new Team("The Coans");
                match3.SecondOpponent = new Team("The Cnideans");
                match3.Winner = match3.FirstOpponent;
                r.AddMatch(match3);

                Match match4 = new Match();
                match4.FirstOpponent = new Team("The Megareans");
                match4.SecondOpponent = new Team("The Corinthians");
                match4.Winner = match4.SecondOpponent;
                r.AddMatch(match4);

            }
            else if (idx == 1)
            {
                Match match1 = new Match();
                match1.FirstOpponent = new Team("The Valyrians");
                match1.SecondOpponent = new Team("The Thereans");
                match1.Winner = match1.FirstOpponent;
                r.AddMatch(match1);

                Match match2 = new Match();
                match2.FirstOpponent = new Team("The Coans");
                match2.SecondOpponent = new Team("The Corinthians");
                match2.Winner = match2.FirstOpponent;
                r.AddMatch(match2);
            }
            else if (idx == 2)
            {
                Match match1 = new Match();
                match1.FirstOpponent = new Team("The Valyrians");
                match1.SecondOpponent = new Team("The Coans");
                match1.Winner = match1.SecondOpponent;
                r.AddMatch(match1);
            }
            return r;
        }
    }
}
