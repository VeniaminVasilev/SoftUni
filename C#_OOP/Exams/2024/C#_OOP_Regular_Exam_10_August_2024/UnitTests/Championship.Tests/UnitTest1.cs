using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;

namespace Championship.Tests
{
    public class Tests
    {
        [Test]
        public void Constructor_InitializesCorrectly()
        {
            // Act
            League league = new League();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(league.Capacity, Is.EqualTo(10));
                Assert.That(league.Teams, Is.Empty);
                Assert.That(league.Teams.Count, Is.EqualTo(0));
            });
        }

        [Test]
        public void AddTeam_AddsSuccessfully()
        {
            // Arrange
            Team team = new Team("Name");
            League league = new League();

            // Act
            league.AddTeam(team);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(league.Teams.Count, Is.EqualTo(1));
                Assert.That(league.Teams.Contains(team));
            });
        }

        [Test]
        public void AddTeam_DoesNotAdd_WhenCapacityReached()
        {
            // Arrange
            League league = new League();

            for (int i = 0; i < league.Capacity; i++)
            {
                Team team = new Team($"{i}");
                league.AddTeam(team);
            }
            Team additionalTeam = new Team("Additional");

            // Act & Assert
            Exception exception = Assert.Throws<InvalidOperationException>(() =>
            {
                league.AddTeam(additionalTeam);
            });
            Assert.That(exception.Message, Is.EqualTo("League is full."));
        }

        [Test]
        public void AddTeam_DoesNotAdd_WhenTeamExists()
        {
            // Arrange
            string teamName = "Name";
            League league = new League();
            Team team = new Team(teamName);
            league.AddTeam(team);

            Team sameTeam = new Team(teamName);

            // Act & Assert
            Exception exception = Assert.Throws<InvalidOperationException>(() =>
            {
                league.AddTeam(sameTeam);
            });
            Assert.That(exception.Message, Is.EqualTo("Team already exists."));
        }

        [Test]
        public void RemoveTeam_RemovesSuccessfully()
        {
            // Arrange
            string teamName = "Name";
            League league = new League();
            Team team = new Team(teamName);
            league.AddTeam(team);

            // Act
            bool removed = league.RemoveTeam(teamName);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(removed, Is.True);
                Assert.That(league.Teams.Count, Is.EqualTo(0));
                Assert.That(!league.Teams.Contains(team));
            });
        }

        [Test]
        public void RemoveTeam_DoesNotRemove_WhenTeamDoesNotExist()
        {
            // Arrange
            League league = new League();
            Team liverpool = new Team("Liverpool");
            league.AddTeam(liverpool);

            // Act
            bool removed = league.RemoveTeam("Name");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(removed, Is.False);
                Assert.That(league.Teams.Contains(liverpool));
                Assert.That(league.Teams.Count, Is.EqualTo(1));
            });
        }

        [Test]
        public void PlayMatch_ThrowsException_WhenOneTeamDoesNotExist()
        {
            // Arrange
            string liverpoolName = "Liverpool";
            League league = new League();
            Team liverpool = new Team(liverpoolName);
            league.AddTeam(liverpool);

            // Act & Assert
            Exception exception = Assert.Throws<InvalidOperationException>(() =>
            {
                league.PlayMatch(liverpoolName, "Name", 5, 0);
            });
            Assert.That(exception.Message, Is.EqualTo("One or both teams do not exist."));
        }

        [Test]
        public void PlayMatch_ThrowsException_WhenBothTeamsDoNotExist()
        {
            // Arrange
            League league = new League();

            // Act & Assert
            Exception exception = Assert.Throws<InvalidOperationException>(() =>
            {
                league.PlayMatch("firstName", "secondName", 5, 0);
            });
            Assert.That(exception.Message, Is.EqualTo("One or both teams do not exist."));
        }

        [Test]
        public void PlayMatch_IsDraw_WhenGoalsAreEqual()
        {
            // Arrange
            League league = new League();

            string liverpoolName = "Liverpool";
            Team liverpool = new Team(liverpoolName);
            league.AddTeam(liverpool);

            string manchesterName = "Manchester";
            Team manchester = new Team(manchesterName);
            league.AddTeam(manchester);

            // Act
            league.PlayMatch(liverpoolName, manchesterName, 3, 3);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(league.Teams.Where(t => t.Name == liverpoolName).FirstOrDefault().Draws, Is.EqualTo(1));
                Assert.That(league.Teams.Where(t => t.Name == manchesterName).FirstOrDefault().Draws, Is.EqualTo(1));
            });
        }

        [Test]
        public void PlayMatch_HomeTeamWins_WhenItsGoalsAreMore()
        {
            // Arrange
            League league = new League();

            string homeTeamName = "Liverpool";
            Team homeTeam = new Team(homeTeamName);
            league.AddTeam(homeTeam);

            string awayTeamName = "Manchester";
            Team awayTeam = new Team(awayTeamName);
            league.AddTeam(awayTeam);

            // Act
            league.PlayMatch(homeTeamName, awayTeamName, 3, 0);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(league.Teams.Where(t => t.Name == homeTeamName).FirstOrDefault().Wins, Is.EqualTo(1));
                Assert.That(league.Teams.Where(t => t.Name == awayTeamName).FirstOrDefault().Loses, Is.EqualTo(1));
            });
        }

        [Test]
        public void PlayMatch_HomeTeamLoses_WhenItsGoalsAreLess()
        {
            // Arrange
            League league = new League();

            string homeTeamName = "Liverpool";
            Team homeTeam = new Team(homeTeamName);
            league.AddTeam(homeTeam);

            string awayTeamName = "Manchester";
            Team awayTeam = new Team(awayTeamName);
            league.AddTeam(awayTeam);

            // Act
            league.PlayMatch(homeTeamName, awayTeamName, 0, 1);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(league.Teams.Where(t => t.Name == homeTeamName).FirstOrDefault().Loses, Is.EqualTo(1));
                Assert.That(league.Teams.Where(t => t.Name == awayTeamName).FirstOrDefault().Wins, Is.EqualTo(1));
            });
        }

        [Test]
        public void GetTeamInfo_ReturnsCorrectTeamInfo()
        {
            // Arrange
            League league = new League();

            string teamName = "Liverpool";
            Team team = new Team(teamName);
            league.AddTeam(team);

            string expectedTeamInfo = $"{teamName} - 0 points (0W 0D 0L)";

            // Act
            string actualTeamInfo = league.GetTeamInfo(teamName);

            // Assert
            Assert.That(actualTeamInfo, Is.EqualTo(expectedTeamInfo));
        }

        [Test]
        public void GetTeamInfo_ThrowsException_WhenTeamDoesNotExist()
        {
            // Arrange
            League league = new League();

            // Act & Assert
            Exception exception = Assert.Throws<InvalidOperationException>(() =>
            {
                league.GetTeamInfo("TeamName");
            });
            Assert.That(exception.Message, Is.EqualTo("Team does not exist."));
        }
    }
}