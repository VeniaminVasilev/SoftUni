using System;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace SocialMediaManager.Tests
{
    public class Tests
    {
        [Test]
        public void Constructor_InitializesCorrectly()
        {
            // Act
            InfluencerRepository influencerRepository = new InfluencerRepository();

            // Assert
            Assert.That(influencerRepository.Influencers, Is.Not.Null);
            Assert.That(influencerRepository.Influencers.Count, Is.EqualTo(0));
            Assert.That(influencerRepository.Influencers, Is.Empty);
        }

        [Test]
        public void RegisterInfluencer_RegistersSuccessfully()
        {
            // Arrange
            string username = "Username";
            int followers = 10;
            Influencer influencer = new Influencer(username, followers);
            InfluencerRepository influencerRepository = new InfluencerRepository();

            // Act
            string result = influencerRepository.RegisterInfluencer(influencer);

            // Assert
            Assert.That(influencerRepository.Influencers.Count, Is.EqualTo(1));
            Assert.That(influencerRepository.Influencers.Contains(influencer));
            Assert.That(result, Is.EqualTo($"Successfully added influencer {username} with {followers}"));
        }

        [Test]
        public void RegisterInfluencer_ThrowsException_WhenInfluencerIsNull()
        {
            // Arrange
            InfluencerRepository influencerRepository = new InfluencerRepository();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                influencerRepository.RegisterInfluencer(null);
            });
        }

        [Test]
        public void RegisterInfluencer_ThrowsException_WhenInfluencerExists()
        {
            // Arrange
            string username = "Username";
            int followers = 10;
            Influencer influencer = new Influencer(username, followers);
            InfluencerRepository influencerRepository = new InfluencerRepository();
            influencerRepository.RegisterInfluencer(influencer);

            // Act and Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
            {
                influencerRepository.RegisterInfluencer(influencer);
            });
            Assert.That(exception.Message, Is.EqualTo($"Influencer with username {username} already exists"));
            Assert.That(influencerRepository.Influencers.Count, Is.EqualTo(1));
        }

        [Test]
        public void RemoveInfluencer_RemovesSuccessfully()
        {
            // Arrange
            string username = "Username";
            int followers = 10;
            Influencer influencer = new Influencer(username, followers);
            InfluencerRepository influencerRepository = new InfluencerRepository();
            influencerRepository.RegisterInfluencer(influencer);

            // Act
            bool isRemoved = influencerRepository.RemoveInfluencer(username);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(isRemoved, Is.True);
                Assert.That(influencerRepository.Influencers.Count, Is.EqualTo(0));
                Assert.That(!influencerRepository.Influencers.Contains(influencer));
            });
        }

        [Test]
        public void RemoveInfluencer_ThrowsException_WhenUsernameIsWhiteSpace()
        {
            // Arrange
            string username = "Username";
            int followers = 10;
            Influencer influencer = new Influencer(username, followers);
            InfluencerRepository influencerRepository = new InfluencerRepository();
            influencerRepository.RegisterInfluencer(influencer);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                influencerRepository.RemoveInfluencer(" ");
            });
            Assert.That(influencerRepository.Influencers.Count, Is.EqualTo(1));
        }

        [Test]
        public void RemoveInfluencer_ThrowsException_WhenUsernameIsNull()
        {
            // Arrange
            string username = "Username";
            int followers = 10;
            Influencer influencer = new Influencer(username, followers);
            InfluencerRepository influencerRepository = new InfluencerRepository();
            influencerRepository.RegisterInfluencer(influencer);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                influencerRepository.RemoveInfluencer(null);
            });
            Assert.That(influencerRepository.Influencers.Count, Is.EqualTo(1));
        }

        [Test]
        public void RemoveInfluencer_ReturnsFalse_WhenUserDoesNotExist()
        {
            // Arrange
            string username = "Username";
            int followers = 10;
            Influencer influencer = new Influencer(username, followers);
            InfluencerRepository influencerRepository = new InfluencerRepository();
            influencerRepository.RegisterInfluencer(influencer);

            // Act
            bool isRemoved = influencerRepository.RemoveInfluencer("Unknown");

            // Assert
            Assert.That(isRemoved, Is.False);
            Assert.That(influencerRepository.Influencers.Contains(influencer));
        }

        [Test]
        public void GetInfluencerWithMostFollowers_ReturnsCorrectInfluencer()
        {
            // Arrange
            string username = "Username";
            int followers = 10;
            Influencer influencer = new Influencer(username, followers);
            InfluencerRepository influencerRepository = new InfluencerRepository();
            influencerRepository.RegisterInfluencer(influencer);

            string username2 = "Username2";
            int followers2 = 20;
            Influencer influencer2 = new Influencer(username2, followers2);
            influencerRepository.RegisterInfluencer(influencer2);

            // Act
            Influencer returnedInfluencer = influencerRepository.GetInfluencerWithMostFollowers();

            // Assert
            Assert.That(returnedInfluencer, Is.EqualTo(influencer2));
        }

        [Test]
        public void GetInfluencer_ReturnsCorrectInfluencer()
        {
            // Arrange
            string username = "Username";
            int followers = 10;
            Influencer influencer = new Influencer(username, followers);
            InfluencerRepository influencerRepository = new InfluencerRepository();
            influencerRepository.RegisterInfluencer(influencer);

            string username2 = "Username2";
            int followers2 = 20;
            Influencer influencer2 = new Influencer(username2, followers2);
            influencerRepository.RegisterInfluencer(influencer2);

            // Act
            Influencer returnedInfluencer = influencerRepository.GetInfluencer(username);

            // Assert
            Assert.That(returnedInfluencer, Is.EqualTo(influencer));
        }
    }
}