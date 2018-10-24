namespace TournamentLib
{
    public class Match
    {
        public Team FirstOpponent { get; set; }
        public Team SecondOpponent { get; set; }
        public Team Winner { get; set; } = null;
    }
}
