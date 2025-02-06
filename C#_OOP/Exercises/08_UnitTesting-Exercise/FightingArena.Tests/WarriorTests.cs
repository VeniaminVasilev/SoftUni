namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;
        private Warrior defenderWarrior;
        private const string name = "Name";
        private const int damage = 100;
        private const int hp = 100;
        private const string defenderName = "Defender";
        private const int defenderDamage = 90;
        private const int defenderHp = 100;
        private const int MIN_ATTACK_HP = 30;

        [SetUp]
        public void SetUp()
        {
            warrior = new Warrior(name, damage, hp);
            defenderWarrior = new Warrior(defenderName, defenderDamage, defenderHp);
        }

        [Test]
        public void Constructor_ShouldInitializeCorrectly_WhenValidParametersAreProvided()
        {
            // Assert
            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(damage, warrior.Damage);
            Assert.AreEqual(hp, warrior.HP);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("                     ")]
        public void Constructor_ShouldThrowArgumentException_WhenNameIsNullOrWhitespace(string nullOrWhitespaceName)
        {
            // Act & Assert
            Exception exception = Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior(nullOrWhitespaceName, damage, hp);
            });
            Assert.AreEqual("Name should not be empty or whitespace!", exception.Message);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-100)]
        public void Constructor_ShouldThrowArgumentException_WhenDamageIsZeroOrNegative(int zeroOrNegativeDamage)
        {
            // Act & Assert
            Exception exception = Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior(name, zeroOrNegativeDamage, hp);
            });
            Assert.AreEqual("Damage value should be positive!", exception.Message);
        }

        [TestCase(-1)]
        [TestCase(-100)]
        public void Constructor_ShouldThrowArgumentException_WhenHPIsNegative(int negativeHP)
        {
            // Act & Assert
            Exception exception = Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior(name, damage, negativeHP);
            });
            Assert.AreEqual("HP should not be negative!", exception.Message);
        }

        [TestCase(MIN_ATTACK_HP)]
        [TestCase(MIN_ATTACK_HP - 1)]
        [TestCase(MIN_ATTACK_HP - 30)]
        public void Attack_ShouldThrowInvalidOperationException_WhenAttackerHPIsLessThanOrEqualToMinAttackHP(int minAttackHp)
        {
            // Arrange
            warrior = new Warrior(name, damage, minAttackHp);

            // Act & Assert
            Exception exception = Assert.Throws<InvalidOperationException>(() => warrior.Attack(defenderWarrior));
            Assert.AreEqual("Your HP is too low in order to attack other warriors!", exception.Message);
        }

        [TestCase(MIN_ATTACK_HP)]
        [TestCase(MIN_ATTACK_HP - 1)]
        [TestCase(MIN_ATTACK_HP - 30)]
        public void Attack_ShouldThrowInvalidOperationException_WhenDefenderHPIsLessThanOrEqualToMinAttackHP(int minAttackHp)
        {
            // Arrange
            defenderWarrior = new Warrior(defenderName, defenderDamage, minAttackHp);

            // Act & Assert
            Exception exception = Assert.Throws<InvalidOperationException>(() => warrior.Attack(defenderWarrior));
            Assert.AreEqual($"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!", exception.Message);
        }

        [TestCase(hp + 1)]
        [TestCase(hp + 1000)]
        public void Attack_ShouldThrowInvalidOperationException_WhenAttackerHPIsLessThanDefenderDamage(int greaterDefenderDamage)
        {
            // Arrange
            defenderWarrior = new Warrior(defenderName, greaterDefenderDamage, defenderHp);

            // Act & Assert
            Exception exception = Assert.Throws<InvalidOperationException>(() => warrior.Attack(defenderWarrior));
            Assert.AreEqual($"You are trying to attack too strong enemy", exception.Message);
        }

        [Test]
        public void Attack_ShouldDecreaseAttackerHPByDefenderDamage_WhenAttackIsSuccessful()
        {
            // Arrange
            int expectedWarriorHp = warrior.HP - defenderWarrior.Damage;

            // Act
            warrior.Attack(defenderWarrior);

            // Assert
            Assert.AreEqual(expectedWarriorHp, warrior.HP);
        }

        [TestCase(damage)]
        [TestCase(damage + 1)]
        [TestCase(damage + 100)]
        public void Attack_ShouldSetDefenderHPToZero_WhenAttackerDamageExceedsOrEqualsDefenderHP(int attackerDamage)
        {
            // Arrange
            int expectedDefenderWarriorHp = 0;
            warrior = new Warrior(name, attackerDamage, hp);

            // Act
            warrior.Attack(defenderWarrior);

            // Assert
            Assert.AreEqual(expectedDefenderWarriorHp, defenderWarrior.HP);
        }

        [TestCase(damage)]
        [TestCase(damage - 1)]
        [TestCase(damage - 10)]
        [TestCase(damage - 99)]
        public void Attack_ShouldDecreaseDefenderHPByAttackerDamage_WhenAttackerDamageIsLessThanOrEqualToDefenderHP(int attackerDamage)
        {
            // Arrange
            int expectedDefenderWarriorHp = defenderWarrior.HP - attackerDamage;
            warrior = new Warrior(name, attackerDamage, hp);

            // Act
            warrior.Attack(defenderWarrior);

            // Assert
            Assert.AreEqual(expectedDefenderWarriorHp, defenderWarrior.HP);
        }
    }
}