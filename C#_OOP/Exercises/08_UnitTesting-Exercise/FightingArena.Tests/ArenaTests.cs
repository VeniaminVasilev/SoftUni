namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior;
        private const string warriorName = "Warrior Name";
        private const int warriorDamage = 80;
        private const int warriorHp = 100;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
            warrior = new Warrior(warriorName, warriorDamage, warriorHp);
        }

        [Test]
        public void Constructor_ShouldInitializeWarriorsCollectionAsEmpty()
        {
            // Assert
            Assert.AreEqual(0, arena.Warriors.Count);
            Assert.IsEmpty(arena.Warriors);
        }

        [Test]
        public void Warriors_ShouldReturnAllEnrolledWarriorsAsReadOnlyCollection()
        {
            // Arrange
            arena.Enroll(warrior);

            // Act
            IReadOnlyCollection<Warrior> warriors = arena.Warriors;

            // Assert
            Assert.AreEqual(1, warriors.Count());
            Assert.Contains(warrior, (System.Collections.ICollection)warriors);
        }

        [Test]
        public void Warriors_ShouldBeEmpty_WhenNoWarriorsAreEnrolled()
        {
            // Act
            IReadOnlyCollection<Warrior> warriors = arena.Warriors;

            // Assert
            Assert.IsEmpty(warriors);
        }

        [Test]
        public void Count_ShouldReturnZero_WhenNoWarriorsAreEnrolled()
        {
            // Act
            int count = arena.Count;

            // Assert
            Assert.AreEqual(0, count);
        }

        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
        public void Count_ShouldReturnCorrectValue_WhenWarriorsAreEnrolled(int count)
        {
            // Arrange & Act
            for (int i = 0; i < count; i++)
            {
                Warrior newWarrior = new Warrior($"Name {i}", 100, 100);
                arena.Enroll(newWarrior);
            }

            // Assert
            Assert.AreEqual(count, arena.Count);
        }

        [Test]
        public void Enroll_ShouldAddWarriorToWarriorsCollection_WhenWarriorIsValid()
        {
            // Act
            arena.Enroll(warrior);

            // Assert
            Assert.Contains(warrior, arena.Warriors.ToList());
        }

        [Test]
        public void Enroll_ShouldIncreaseCount_WhenWarriorIsAdded()
        {
            // Act
            arena.Enroll(warrior);

            // Assert
            Assert.AreEqual(1, arena.Count);
        }

        [Test]
        public void Enroll_ShouldThrowInvalidOperationException_WhenWarriorWithSameNameIsAlreadyEnrolled()
        {
            // Act & Assert
            arena.Enroll(warrior);

            Warrior warriorWithSameName = warrior;
            Exception exception = Assert.Throws<InvalidOperationException>(() => arena.Enroll(warriorWithSameName));
            Assert.AreEqual("Warrior is already enrolled for the fights!", exception.Message);
        }

        [Test]
        public void Fight_ShouldThrowInvalidOperationException_WhenAttackerIsNotEnrolled()
        {
            // Arrange
            Warrior attacker = warrior;
            Warrior defender = new Warrior("Defender Name", 100, 100);
            arena.Enroll(defender);

            // Act & Assert
            Exception exception = Assert.Throws<InvalidOperationException>(() => arena.Fight(attacker.Name, defender.Name));
            Assert.AreEqual($"There is no fighter with name {attacker.Name} enrolled for the fights!", exception.Message);
        }

        [Test]
        public void Fight_ShouldThrowInvalidOperationException_WhenDefenderIsNotEnrolled()
        {
            // Arrange
            Warrior attacker = warrior;
            Warrior defender = new Warrior("Defender Name", 100, 100);
            arena.Enroll(attacker);

            // Act & Assert
            Exception exception = Assert.Throws<InvalidOperationException>(() => arena.Fight(attacker.Name, defender.Name));
            Assert.AreEqual($"There is no fighter with name {defender.Name} enrolled for the fights!", exception.Message);
        }

        [Test]
        public void Fight_ShouldThrowInvalidOperationException_WhenBothAttackerAndDefenderAreNotEnrolled()
        {
            // Arrange
            Warrior attacker = warrior;
            Warrior defender = new Warrior("Defender Name", 100, 100);

            // Act & Assert
            Exception exception = Assert.Throws<InvalidOperationException>(() => arena.Fight(attacker.Name, defender.Name));
            Assert.AreEqual($"There is no fighter with name {defender.Name} enrolled for the fights!", exception.Message);
        }

        [Test]
        public void Fight_ShouldHappen_WhenBothWarriorsAreEnrolled()
        {
            // Arrange
            Warrior attacker = warrior;
            Warrior defender = new Warrior("Defender Name", 50, 100);
            arena.Enroll(attacker);
            arena.Enroll(defender);

            // Act
            arena.Fight(attacker.Name, defender.Name);

            // Assert
            Assert.AreEqual(50, attacker.HP);
            Assert.AreEqual(20, defender.HP);
        }

        [Test]
        public void Fight_ShouldSetDefenderHPToZero_WhenAttackerDamageExceedsDefenderHP()
        {
            // Arrange
            Warrior attacker = warrior;
            Warrior defender = new Warrior("Defender Name", 50, 50);
            arena.Enroll(attacker);
            arena.Enroll(defender);

            // Act
            arena.Fight(attacker.Name, defender.Name);

            // Assert
            Assert.AreEqual(0, defender.HP);
        }
    }
}