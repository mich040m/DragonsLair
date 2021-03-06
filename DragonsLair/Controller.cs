﻿using System;
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
            
            Tournament tournament = tournamentRepository.GetTournament(tournamentName);
            int numberOfRounds = tournament.GetNumberOfRounds();
            List<Team> score = new List<Team>();
            List<Team> score2 = new List<Team>();
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


            int[] testVar = new int[s2.Count];
            
            
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

            for (int i = 0; i < numberOfRounds; i++)
            {
                Round currentRound = tournament.GetRound(i);
                score2.AddRange(currentRound.GetLosingTeams());
            }
            List<string> s3 = new List<string>();
            foreach (Team i in score2)
                s3.Add(i.ToString());
            s3 = s3.Distinct().ToList();
            int v1 = s3.Count;

            for (int i = 0; i < s3.Count; i++)
            {
                
                    
                    
                        s3.RemoveAll(item => item == distinct[i]);
                    
                
            }
            
            distinct.AddRange(s3);

                Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
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

    

        public TournamentRepo GetTournamentRepository()
        {
            
            return tournamentRepository;
        }

        public void ScheduleNewRound(string tournamentName, bool printNewMatches = true)
        {
            
            Round lastRound = new Round();
            List<Team> teams = new List<Team>();
            Team oldFreeRider;
            
            int numberOfRounds;
            bool isRoundFinished;

            Tournament t = tournamentRepository.GetTournament(tournamentName);
            numberOfRounds = t.GetNumberOfRounds();

            if (numberOfRounds == 0)
            {
                isRoundFinished = true;
                lastRound = null;

            }
            else
            {
                lastRound = t.GetRound(numberOfRounds - 1);
                isRoundFinished = lastRound.IsMatchesFinished();
            }

            if (isRoundFinished == true)
            {
                if (lastRound == null)
                {
                    teams = t.GetTeams().ToList();

                }
                else
                {
                    teams = lastRound.GetWinningTeams();
                    if (lastRound.FreeRider != null)
                    {
                        teams.Add(lastRound.FreeRider);
                    }
                }

                if (teams.Count > 1)
                {
                    Round newRound = new Round();
                    
                    if (teams.Count % 2 != 0)
                    {
                        if (numberOfRounds > 0)
                        {
                            oldFreeRider = lastRound.FreeRider;
                        }
                        else
                        {
                            oldFreeRider = null;
                        }
                        Team newFreeRider = null;


                        int i=0;
                        do
                        {
                            newFreeRider = teams[i];
                            i++;
                        } while (newFreeRider == oldFreeRider);

                        newRound.FreeRider = newFreeRider;
                        teams.Remove(newFreeRider);


                    }
                    for (int i = 0; i < teams.Count; i+=2)
                    {
                        Match m = new Match();
                        m.FirstOpponent = teams[i];
                        m.SecondOpponent = teams[i + 1];
                        newRound.AddMatch(m);
                    }
                   
                    t.AddRound(newRound);
                }
                else
                {
                    throw new Exception("Tourment is finished");
                }

            }
            else
            {
                throw new Exception("Round is not Finished");
            }

        }

        public void ScheduleNewTournament(string name)
        {
            tournamentRepository.SaveTournament(name);
        }
        public void SaveMatch(string tournamentName, int roundNumber, string winningTeam)
        {
            Tournament t = tournamentRepository.GetTournament(tournamentName);
            Round r = t.GetRound(roundNumber);
            Match m = r.GetMatch(winningTeam);

            if(m != null && m.Winner == null)
            {
                Team w = t.GetTeam(winningTeam);
                Console.WriteLine("Vinderen er registrerert!");
                m.Winner = w;

                SQL.InsertToMatches(m.FirstOpponent.Name.ToString(), m.SecondOpponent.Name.ToString(), m.Winner.Name.ToString());
            }
            else
            {
                Console.WriteLine("EEEEEEYYY are you braindead?!");
            }
        }
        public void ShowAllTournaments()
        {
            tournamentRepository.ShowAllTournaments();
        }
    }
}
