using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TournamentLib;

namespace TournamentTest
{
    [TestClass]
    public class DragonsLairTests
    {
        Tournament currentTournament;

        [TestInitialize]
        public void SetupForTest()
        {
            currentTournament = new Tournament("Vinter Turnering");
            currentTournament.SetupTestRounds();
        }

        [TestMethod]
        public void TournamentHasEvenNumberOfTeams()
        {
            int numberOfTeams = currentTournament.GetTeams().Count;
            Assert.AreEqual(0, numberOfTeams % 2);
        }

        [TestMethod]
        public void EqualNumberOfWinnersAndLosersPerRound()
        {
            int numberOfRounds = currentTournament.GetNumberOfRounds();
            for (int round = 0; round < numberOfRounds; round++)
            {
                Round currentRound = currentTournament.GetRound(round);
                int numberOfWinningTeams = currentRound.GetWinningTeams().Count;
                int numberOfLosingTeams = currentRound.GetLosingTeams().Count;
                Assert.AreEqual(numberOfWinningTeams, numberOfLosingTeams);
            }
        }

        [TestMethod]
        public void OneWinnerInLastRound()
        {
            // Verifies there is exactly one winner in last round
            int numberOfRounds = currentTournament.GetNumberOfRounds(); // output 3
            Round currentRound = currentTournament.GetRound(numberOfRounds - 1); // henter den sidste runde
            int numberOfWinningTeams = currentRound.GetWinningTeams().Count;
            Assert.AreEqual(1, numberOfWinningTeams);
        }

        [TestMethod]
        public void AllMatchesInPreviousRoundsFinished()
        {
            bool matchesFinished = true;
            int numberOfRounds = currentTournament.GetNumberOfRounds(); // output 3
            for (int round = 0; round < numberOfRounds; round++)
            {
                Round currentRound = currentTournament.GetRound(round); // 0, 1, 2 runde
                if (currentRound.IsMatchesFinished() == false)
                    matchesFinished = false;
            }
            Assert.AreEqual(true, matchesFinished);
        }
        [TestMethod]
        public void TestOddNumberOfTeamsGivesFreeRider()
        {
            currentTournament.AddTeam(new Team("The Andals")); // Add the nine'th team
            controller.ScheduleNewRound("Vinter Turnering", false);
            Assert.AreNotEqual(null, currentTournament.GetRound(0).FreeRider);
        }

        [TestMethod]
        public void TestWinningTeamInRound0IsRegistered()
        {
            String winnerName = "The Spartans";
            controller.ScheduleNewRound("Vinter Turnering", false);
            controller.SaveMatch("Vinter Turnering", 0, winnerName);
            Match m = currentTournament.GetRound(0).GetMatch(winnerName);
            Assert.AreEqual(winnerName, m.Winner.Name);
        }

        [TestMethod]
        public void TestWinningTeamInRound1IsRegistered()
        {
            String winnerName = "The Coans";

            controller.ScheduleNewRound("Vinter Turnering", false);
            controller.SaveMatch("Vinter Turnering", 0, "The Spartans");
            controller.SaveMatch("Vinter Turnering", 0, "The Cretans");
            controller.SaveMatch("Vinter Turnering", 0, "The Coans");
            controller.SaveMatch("Vinter Turnering", 0, "The Megareans");

            controller.ScheduleNewRound("Vinter Turnering", false);
            controller.SaveMatch("Vinter Turnering", 1, winnerName);

            Match m = currentTournament.GetRound(1).GetMatch(winnerName);
            Assert.AreEqual(winnerName, m.Winner.Name);
        }

    }
}
