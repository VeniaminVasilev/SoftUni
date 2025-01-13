using FakeAxeAndDummy.Interfaces;
using Moq;

namespace FakeAxeAndDummy.Tests
{
    [TestFixture]
    public class HeroTests
    {
        [Test]
        public void HeroGainsExperienceWhenTargetIsDead()
        {
            // Arrange
            Mock<IWeapon> mockWeapon = new Mock<IWeapon>();
            Mock<ITarget> mockTarget = new Mock<ITarget>();

            mockTarget.Setup(t => t.IsDead()).Returns(true); // Target is dead
            mockTarget.Setup(t => t.GiveExperience()).Returns(20); // Target gives 20 XP

            mockWeapon.Setup(w => w.Attack(It.IsAny<ITarget>()))
               .Callback<ITarget>(target => target.TakeAttack(100));

            Hero hero = new Hero("Name", mockWeapon.Object);

            // Act
            hero.Attack(mockTarget.Object);

            // Assert
            Assert.That(hero.Experience == 20);

            // Verify interactions
            mockWeapon.Verify(w => w.Attack(It.IsAny<ITarget>()), Times.Once());
            mockTarget.Verify(t => t.IsDead(), Times.Once());
            mockTarget.Verify(t => t.GiveExperience(), Times.Once());
        }
    }
}