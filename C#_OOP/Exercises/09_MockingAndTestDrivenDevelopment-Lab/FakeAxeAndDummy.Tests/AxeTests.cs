using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private Axe axe;
    private Dummy dummy;
    private const int InitialAxeAttackPoints = 10;
    private const int InitialAxeDurabilityPoints = 10;
    private const int DummyHealth = 10;
    private const int DummyExperience = 10;

    [SetUp]
    public void SetUp()
    {
        axe = new Axe(InitialAxeAttackPoints, InitialAxeDurabilityPoints);
        dummy = new Dummy(DummyHealth, DummyExperience);
    }

    [Test]
    public void Attack_WhenAxeAttacks_LosesDurability()
    {
        // Arrange
        int expectedDurabilityAfterAttack = InitialAxeDurabilityPoints - 1;

        // Act
        axe.Attack(dummy);

        // Assert
        Assert.That(axe.DurabilityPoints, Is.EqualTo(expectedDurabilityAfterAttack), "Axe Durability doesn't change after attack.");
    }

    [Test]
    public void Attack_WhenAxeIsBroken_ThrowsException()
    {
        // Arrange
        axe = new Axe(InitialAxeAttackPoints, 0);

        // Act & Assert
        Exception exception = Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        Assert.AreEqual("Axe is broken.", exception.Message);
    }
}