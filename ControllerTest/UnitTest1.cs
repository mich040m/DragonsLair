using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControllerTest
{
    [TestClass]
    public class TestVersion1
    {
        Controller controller;
        TournamentRepo currentRepo;
        Tournament currentTournament;

        [TestInitialize]
        public void SetupForTest()
        {
            controller = new Controller();
            currentRepo = controller.GetTournamentRepository();
            currentTournament = currentRepo.GetTournament("Vinter Turnering");
            currentTournament.SetupTestTeams();  // Setup 8 teams
        }

        [TestMethod]
        public void TestScheduleNewRoundWithEvenNumberOfTeams()
        {
            Assert.AreEqual(8, currentTournament.GetTeams().Count);

            controller.ScheduleNewRound("Vinter Turnering", false);

            Assert.AreEqual(1, currentTournament.GetNumberOfRounds());
            Assert.AreEqual(8, currentTournament.GetTeams().Count);
        }

        [TestMethod]
        public void TestScheduleNewRoundWithOddNumbersOfTeams()
        {
            currentTournament.AddTeam(new Team("The Andals")); // Add the nine'th team
            Assert.AreEqual(9, currentTournament.GetTeams().Count);

            controller.ScheduleNewRound("Vinter Turnering", false);

            Assert.AreEqual(1, currentTournament.GetNumberOfRounds());
            Assert.AreEqual(9, currentTournament.GetTeams().Count);
        }
    }
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
