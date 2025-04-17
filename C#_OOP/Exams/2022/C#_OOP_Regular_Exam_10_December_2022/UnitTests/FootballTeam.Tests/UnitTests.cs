using NUnit.Framework;
using System;
using System.Xml.Linq;

namespace FootballTeam.Tests
{
    public class Tests
    {
        [Test]
        public void Constructor_InitializesCorrectly()
        {
            // Arrange
            string name = "Name";
            int capacity = 20;

            // Act
            FootballTeam footballTeam = new FootballTeam(name, capacity);

            // Assert
            Assert.That(footballTeam, Is.Not.Null);
            Assert.That(footballTeam.Name, Is.EqualTo(name));
            Assert.That(footballTeam.Capacity, Is.EqualTo(capacity));
            Assert.That(footballTeam.Players, Is.Not.Null);
        }

        [TestCase(null)]
        [TestCase("")]
        public void NotCorrectName_ThrowsArgumentException(string name)
        {
            // Arrange
            int capacity = 20;

            // Act & Assert
            Exception exception = Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam footballTeam = new FootballTeam(name, capacity);
            });
            Assert.That(exception.Message, Is.EqualTo("Name cannot be null or empty!"));
        }

        [TestCase(14)]
        [TestCase(0)]
        [TestCase(-100)]
        public void CapacityLessThan15_ThrowsArgumentException(int capacity)
        {
            // Arrange
            string name = "Name";

            // Act & Assert
            Exception exception = Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam footballTeam = new FootballTeam(name, capacity);
            });
            Assert.That(exception.Message, Is.EqualTo("Capacity min value = 15"));
        }

        [Test]
        public void AddNewPlayer_Success()
        {
            // Arrange
            string name = "Name";
            int capacity = 20;
            FootballTeam footballTeam = new FootballTeam(name, capacity);

            string playerName = "PlayerName";
            int playerNumber = 10;
            string position = "Goalkeeper";
            FootballPlayer player = new FootballPlayer(playerName, playerNumber, position);

            // Act
            string result = footballTeam.AddNewPlayer(player);

            // Assert
            Assert.That(result, Is.EqualTo($"Added player {playerName} in position {position} with number {playerNumber}"));
            Assert.That(footballTeam.Players.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddNewPlayer_Fail_WhenCapacityFull()
        {
            // Arrange
            string name = "Name";
            int capacity = 15;
            FootballTeam footballTeam = new FootballTeam(name, capacity);

            for (int i = 0; i < 15; i++)
            {
                string playerName = "PlayerName";
                int playerNumber = 10;
                string position = "Goalkeeper";
                FootballPlayer player = new FootballPlayer(playerName, playerNumber, position);
                footballTeam.AddNewPlayer(player);
            }

            string playerName2 = "PlayerName";
            int playerNumber2 = 10;
            string position2 = "Goalkeeper";
            FootballPlayer player2 = new FootballPlayer(playerName2, playerNumber2, position2);

            // Act
            string result = footballTeam.AddNewPlayer(player2);

            // Assert
            Assert.That(result, Is.EqualTo("No more positions available!"));
            Assert.That(footballTeam.Players.Count, Is.EqualTo(15));
        }

        [Test]
        public void PickPlayer_ReturnsCorrectPlayer()
        {
            // Arrange
            string name = "Name";
            int capacity = 20;
            FootballTeam footballTeam = new FootballTeam(name, capacity);

            string playerName = "PlayerName";
            int playerNumber = 10;
            string position = "Goalkeeper";
            FootballPlayer player = new FootballPlayer(playerName, playerNumber, position);
            footballTeam.AddNewPlayer(player);

            // Act
            FootballPlayer returnedPlayer = footballTeam.PickPlayer(playerName);

            // Assert
            Assert.That(returnedPlayer, Is.EqualTo(player));
            Assert.That(returnedPlayer.Name, Is.EqualTo(playerName));
            Assert.That(returnedPlayer.PlayerNumber, Is.EqualTo(playerNumber));
            Assert.That(returnedPlayer.Position, Is.EqualTo(position));
        }

        [Test]
        public void PlayerScore_ReturnsCorrectString()
        {
            // Arrange
            string name = "Name";
            int capacity = 20;
            FootballTeam footballTeam = new FootballTeam(name, capacity);

            string playerName = "PlayerName";
            int playerNumber = 10;
            string position = "Goalkeeper";
            FootballPlayer player = new FootballPlayer(playerName, playerNumber, position);
            footballTeam.AddNewPlayer(player);

            // Act
            string result = footballTeam.PlayerScore(playerNumber);

            // Assert
            Assert.That(result, Is.EqualTo($"{playerName} scored and now has {1} for this season!"));
            Assert.That(player.ScoredGoals, Is.EqualTo(1));
        }

        [Test]
        public void PlayerScore_ManyGoals()
        {
            // Arrange
            string name = "Name";
            int capacity = 20;
            FootballTeam footballTeam = new FootballTeam(name, capacity);

            string playerName = "PlayerName";
            int playerNumber = 10;
            string position = "Goalkeeper";
            FootballPlayer player = new FootballPlayer(playerName, playerNumber, position);
            footballTeam.AddNewPlayer(player);

            // Act
            int countOfGoals = 10;
            string result = string.Empty;

            for (int i = 0; i < countOfGoals; i++)
            {
                result = footballTeam.PlayerScore(playerNumber);
            }

            // Assert
            Assert.That(result, Is.EqualTo($"{playerName} scored and now has {countOfGoals} for this season!"));
            Assert.That(player.ScoredGoals, Is.EqualTo(countOfGoals));
        }
    }
}