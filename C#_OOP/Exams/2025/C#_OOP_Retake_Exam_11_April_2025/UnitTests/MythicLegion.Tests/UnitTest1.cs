using System;
using NUnit.Framework;
using System.Text;

namespace MythicLegion.Tests
{
    public class Tests
    {
        [Test]
        public void Constructor_InitializesCorrectly()
        {
            // Act
            Legion legion = new Legion();
            string result = legion.GetLegionInfo();

            // Assert
            Assert.That(legion, Is.Not.Null);
            Assert.That(result, Is.EqualTo("No heroes in the legion."));
        }

        [Test]
        public void AddHero_Success()
        {
            // Arrange
            string name = "Name";
            string type = "Type";
            Hero hero = new Hero(name, type);
            Legion legion = new Legion();

            // Act
            legion.AddHero(hero);
            string result = legion.GetLegionInfo();

            // Assert
            Assert.That(result, Is.EqualTo($"{name} ({type}) - Power: {hero.Power}, Health: {hero.Health}, Trained: {hero.IsTrained}"));
        }

        [Test]
        public void AddHero_WhenHeroIsNull()
        {
            // Arrange
            Hero hero = null;
            Legion legion = new Legion();

            // Act & Assert
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
            {
                legion.AddHero(hero);
            });
            Assert.AreEqual("hero", exception.ParamName);
            Assert.That(exception.Message.StartsWith("Hero cannot be null"));
        }

        [Test]
        public void AddHero_WhenHeroIsAdded()
        {
            // Arrange
            string name = "Name";
            string type = "Type";
            Hero hero = new Hero(name, type);
            Legion legion = new Legion();
            legion.AddHero(hero);

            // Act & Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
            {
                legion.AddHero(hero);
            });
            Assert.That(exception.Message, Is.EqualTo($"Hero with name {hero.Name} already exists in the legion."));
        }

        [Test]
        public void RemoveHero_Success()
        {
            // Arrange
            string name = "Name";
            string type = "Type";
            Hero hero = new Hero(name, type);
            Legion legion = new Legion();
            legion.AddHero(hero);

            // Act
            bool isRemoved = legion.RemoveHero(name);
            string result = legion.GetLegionInfo();

            // Assert
            Assert.That(isRemoved, Is.True);
            Assert.That(result, Is.EqualTo("No heroes in the legion."));
        }

        [Test]
        public void RemoveHero_WrongName()
        {
            // Arrange
            string name = "Name";
            string type = "Type";
            Hero hero = new Hero(name, type);
            Legion legion = new Legion();
            legion.AddHero(hero);

            // Act
            bool isRemoved = legion.RemoveHero("WrongName");
            string result = legion.GetLegionInfo();

            // Assert
            Assert.That(isRemoved, Is.False);
            Assert.That(result, Is.EqualTo($"{name} ({type}) - Power: {hero.Power}, Health: {hero.Health}, Trained: {hero.IsTrained}"));
        }

        [Test]
        public void TrainHero_Success()
        {
            // Arrange
            string name = "Name";
            string type = "Type";
            Hero hero = new Hero(name, type);
            Legion legion = new Legion();
            legion.AddHero(hero);

            // Act
            string result = legion.TrainHero(name);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo($"{name} has been trained."));
                Assert.That(hero.Health, Is.EqualTo(101));
                Assert.That(hero.Power, Is.EqualTo(30));
                Assert.That(hero.IsTrained, Is.True);
            });
        }

        [Test]
        public void TrainHero_HeroNotFound()
        {
            // Arrange
            string name = "Name";
            string type = "Type";
            Hero hero = new Hero(name, type);
            Legion legion = new Legion();
            legion.AddHero(hero);

            // Act
            string wrongName = "Wrong Name";
            string result = legion.TrainHero(wrongName);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo($"Hero with name {wrongName} not found."));
                Assert.That(hero.Health, Is.EqualTo(100));
                Assert.That(hero.Power, Is.EqualTo(20));
                Assert.That(hero.IsTrained, Is.False);
            });
        }

        [Test]
        public void GetLegionInfo_WhenMoreHeroes()
        {
            // Arrange
            Legion legion = new Legion();
            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < 10; i++)
            {
                string name = $"Name{i}";
                string type = $"Type{i}";
                Hero hero = new Hero(name, type);
                legion.AddHero(hero);

                sb.AppendLine(hero.ToString());
            }

            string expectedResult = sb.ToString().TrimEnd();

            // Act
            string result = legion.GetLegionInfo();

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}