using NUnit.Framework;
using System.Linq;

namespace RobotFactory.Tests
{
    public class Tests
    {
        [Test]
        public void Constructor_InitializesCorrectly()
        {
            // Arrange
            string name = "Name";
            int capacity = 100;

            // Act
            Factory factory = new Factory(name, capacity);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(factory.Name, Is.EqualTo(name));
                Assert.That(factory.Capacity, Is.EqualTo(capacity));
                Assert.That(factory.Robots, Is.Empty);
                Assert.That(factory.Supplements, Is.Empty);
            });
        }

        [Test]
        public void ProduceRobot_Success()
        {
            // Arrange
            string name = "Name";
            int capacity = 100;
            Factory factory = new Factory(name, capacity);

            string model = "Model";
            double price = 50.1234;
            int interfaceStandard = 1111;

            // Act
            string result = factory.ProduceRobot(model, price, interfaceStandard);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo($"Produced --> Robot model: {model} IS: {interfaceStandard}, Price: {price:f2}"));
                Assert.That(factory.Robots.Count, Is.EqualTo(1));
            });
        }

        [Test]
        public void ProduceRobot_Fail_WhenNoCapacity()
        {
            // Arrange
            string name = "Name";
            int capacity = 0;
            Factory factory = new Factory(name, capacity);

            string model = "Model";
            double price = 50.1234;
            int interfaceStandard = 1111;

            // Act
            string result = factory.ProduceRobot(model, price, interfaceStandard);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo($"The factory is unable to produce more robots for this production day!"));
                Assert.That(factory.Robots.Count, Is.EqualTo(0));
            });
        }

        [Test]
        public void ProduceSupplement_Success()
        {
            // Arrange
            string name = "Name";
            int capacity = 10;
            Factory factory = new Factory(name, capacity);

            string supplementName = "Supplement Name";
            int interfaceStandard = 1000;

            // Act
            string result = factory.ProduceSupplement(supplementName, interfaceStandard);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo($"Supplement: {supplementName} IS: {interfaceStandard}"));
                Assert.That(factory.Supplements.Count, Is.EqualTo(1));
                Assert.That(factory.Robots.Count, Is.EqualTo(0));
            });
        }

        [Test]
        public void UpgradeRobot_Success()
        {
            // Arrange
            string name = "Name";
            int capacity = 100;
            Factory factory = new Factory(name, capacity);

            string model = "Model";
            double price = 50.1234;
            int interfaceStandard = 1111;
            factory.ProduceRobot(model, price, interfaceStandard);

            string supplementName = "Supplement Name";
            factory.ProduceSupplement(supplementName, interfaceStandard);

            Robot robot = factory.Robots.FirstOrDefault(r => r.Model == model);
            Supplement supplement = factory.Supplements.FirstOrDefault(s => s.Name == supplementName);

            // Act
            bool result = factory.UpgradeRobot(robot, supplement);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(robot.Supplements.Contains(supplement));
                Assert.That(factory.Robots.Contains(robot));
                Assert.That(factory.Supplements.Contains(supplement));
            });
        }

        [Test]
        public void UpgradeRobot_ReturnsFalse_WhenRobotAlreadyContainsSupplement()
        {
            // Arrange
            string name = "Name";
            int capacity = 100;
            Factory factory = new Factory(name, capacity);

            string model = "Model";
            double price = 50.1234;
            int interfaceStandard = 1111;
            factory.ProduceRobot(model, price, interfaceStandard);

            string supplementName = "Supplement Name";
            factory.ProduceSupplement(supplementName, interfaceStandard);

            Robot robot = factory.Robots.FirstOrDefault(r => r.Model == model);
            Supplement supplement = factory.Supplements.FirstOrDefault(s => s.Name == supplementName);

            factory.UpgradeRobot(robot, supplement);

            // Act
            bool result = factory.UpgradeRobot(robot, supplement);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.False);
                Assert.That(robot.Supplements.Contains(supplement));
            });
        }

        [Test]
        public void SellRobot_Success_WhenOnlyOneProducedRobot()
        {
            // Arrange
            string name = "Name";
            int capacity = 100;
            Factory factory = new Factory(name, capacity);

            string model = "Model";
            double price = 50.1234;
            int interfaceStandard = 1111;
            factory.ProduceRobot(model, price, interfaceStandard);
            Robot producedRobot = factory.Robots.First();

            // Act
            Robot soldRobot = factory.SellRobot(60);

            // Assert
            Assert.That(soldRobot, Is.EqualTo(producedRobot));
        }

        [Test]
        public void SellRobot_Success_WhenTwoProducedRobots()
        {
            // Arrange
            string name = "Name";
            int capacity = 100;
            Factory factory = new Factory(name, capacity);

            factory.ProduceRobot("Model1", 50, 100);
            factory.ProduceRobot("Model2", 60, 100);
            Robot expectedRobot = factory.Robots.FirstOrDefault(r => r.Model == "Model1");

            // Act
            Robot soldRobot = factory.SellRobot(50);

            // Assert
            Assert.That(soldRobot, Is.EqualTo(expectedRobot));
        }

        [Test]
        public void SellRobot_Success_WhenManyProducedRobots()
        {
            // Arrange
            string name = "Name";
            int capacity = 100;
            Factory factory = new Factory(name, capacity);

            for (int i = 1; i <= 100; i++)
            {
                factory.ProduceRobot($"Model {i}", 50 + i, 100);
            }

            Robot expectedRobot = factory.Robots.FirstOrDefault(r => r.Model == "Model 50");

            // Act
            Robot soldRobot = factory.SellRobot(100);

            // Assert
            Assert.That(soldRobot, Is.EqualTo(expectedRobot));
        }
    }
}