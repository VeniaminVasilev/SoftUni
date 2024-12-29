using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy aliveDummy;
        private Dummy deadDummy;
        private const int DummyHealth = 10;
        private const int DummyExperience = 10;
        private const int DeadDummyHealth = 0;
        private const int AttackPoints = 10;

        [SetUp]
        public void SetUp()
        {
            aliveDummy = new Dummy(DummyHealth, DummyExperience);
            deadDummy = new Dummy(DeadDummyHealth, DummyExperience);
        }

        [Test]
        public void Attack_WhenDummyIsAttacked_LosesHealth()
        {
            // Arrange
            int expectedDummyHealth = DummyHealth - AttackPoints;

            // Act
            aliveDummy.TakeAttack(AttackPoints);

            // Assert
            Assert.That(aliveDummy.Health, Is.EqualTo(expectedDummyHealth), "Dummy health doesn't change after attack.");
        }

        [Test]
        public void Attack_WhenDummyIsDead_ThrowsException()
        {
            // Act & Assert
            Exception exception = Assert.Throws<InvalidOperationException>(() => deadDummy.TakeAttack(10));
            Assert.AreEqual("Dummy is dead.", exception.Message);
        }

        [Test]
        public void GiveXP_WhenDummyIsDead_CanGiveXP()
        {
            // Act
            int actualExperience = deadDummy.GiveExperience();

            // Assert
            Assert.That(actualExperience, Is.EqualTo(DummyExperience), "Cannot give experience of dead dummy.");
            Assert.That(deadDummy.IsDead, Is.True);
        }

        [Test]
        public void GiveXP_WhenDummyIsAlive_ThrowsException()
        {
            // Act & Assert
            Exception exception = Assert.Throws<InvalidOperationException>(() => aliveDummy.GiveExperience());
            Assert.AreEqual("Target is not dead.", exception.Message);
        }
    }
}