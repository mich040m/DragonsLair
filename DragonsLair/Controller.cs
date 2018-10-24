using System;
using System.Collections.Generic;
using System.Linq;
using TournamentLib;

namespace DragonsLair
{
    public class Controller
    {
        private TournamentRepo tournamentRepository = new TournamentRepo();

        public void ShowScore(string tournamentName)
        {

            Tournament tournament = new Tournament(tournamentName);
            int numberOfRounds = tournament.GetNumberOfRounds();
            List<Team> score = new List<Team>();
            List<Team> test = tournament.GetTeams();
            for (int i = 0; i < numberOfRounds; i++)
            {
                Round currentRound = tournament.GetRound(i);
                score.AddRange(currentRound.GetWinningTeams());
            }
            List<string> s = new List<string>();
            foreach (Team i in score)
                s.Add(i.ToString());
            List<string> s2 = new List<string>();
            foreach (Team i in test)
                s2.Add(i.ToString());

            List<string> distinct = s.Distinct().ToList();


            int[] testVar = new int[distinct.Count];
            
            
            for (int i = 0; i < distinct.Count; i++)
            {
                foreach (string item in s)
                {
                    if (distinct[i] ==item)
                    {
                        testVar[i] = testVar[i] + 1;
                    }
                }

            }

                SortedDictionary<string, int> keyValuePairs = new SortedDictionary<string, int>();
            for (int i = 0; i < testVar.Length; i++)
            {
                keyValuePairs.Add(distinct[i], testVar[i]);
            }
            var myList = keyValuePairs.ToList();
            myList.Sort((pair2, pair1) => pair1.Value.CompareTo(pair2.Value));

            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine(myList[i]);
            }
        }

        public void ScheduleNewRound(string tournamentName, bool printNewMatches = true)
        {
            // Do not implement this method
        }

        public void SaveMatch(string tournamentName, int roundNumber, string team1, string team2, string winningTeam)
        {
            // Do not implement this method
        }
    }
}
