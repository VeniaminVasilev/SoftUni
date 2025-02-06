using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace SecureOpsSystem.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void Constructor_SetsCapacitySuccessfully()
        {
            // Act
            SecureHub secureHub = new SecureHub(100);

            // Assert
            Assert.That(secureHub.Capacity, Is.EqualTo(100));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void Constructor_ThrowsArgumentException_WhenCapacityIsInvalid(int capacity)
        {
            // Act & Assert
            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                SecureHub secureHub = new SecureHub(capacity);
            });
            Assert.That(ex.Message, Is.EqualTo("Capacity must be greater than 0."));
        }

        [Test]
        public void Capacity_Getter_ShouldReturnCorrectValue()
        {
            // Arrange
            SecureHub secureHub = new SecureHub(100);

            // Act
            int capacity = secureHub.Capacity;

            // Assert
            Assert.That(capacity, Is.EqualTo(100));
        }

        [Test]
        public void Tools_ShouldBeEmpty_WhenNoToolsAdded()
        {
            // Arrange
            SecureHub secureHub = new SecureHub(100);

            // Act
            List<SecurityTool> tools = secureHub.Tools.ToList();

            // Assert
            Assert.That(tools.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddTool_ShouldAddToolSuccessfully()
        {
            // Arrange
            string name = "Antivirus";
            string category = "Defense";
            double effectiveness = 10;
            SecureHub secureHub = new SecureHub(10);
            SecurityTool securityTool = new SecurityTool(name, category, effectiveness);

            // Act
            string message = secureHub.AddTool(securityTool);
            List<SecurityTool> tools = secureHub.Tools.ToList();

            // Assert
            Assert.That(secureHub.Tools.Count, Is.EqualTo(1));
            Assert.That(message, Is.EqualTo($"Security Tool {name} added successfully."));
            Assert.That(tools[0].Name, Is.EqualTo(name));
            Assert.That(tools[0].Category, Is.EqualTo(category));
            Assert.That(tools[0].Effectiveness, Is.EqualTo(effectiveness));
        }

        [Test]
        public void AddTool_ShouldNotAddTool_WhenToolExists()
        {
            // Arrange
            string name = "Antivirus";
            string category = "Defense";
            double effectiveness = 10;
            SecureHub secureHub = new SecureHub(10);
            SecurityTool securityTool = new SecurityTool(name, category, effectiveness);
            secureHub.AddTool(securityTool);

            // Act
            string message = secureHub.AddTool(securityTool);

            // Assert
            Assert.That(secureHub.Tools.Count, Is.EqualTo(1));
            Assert.That(message, Is.EqualTo($"Security Tool {name} already exists in the hub."));
        }

        [Test]
        public void AddTool_ShouldNotAddTool_WhenFullCapacity()
        {
            // Arrange
            string name = "Antivirus";
            string category = "Defense";
            double effectiveness = 10;
            SecureHub secureHub = new SecureHub(1);
            SecurityTool securityTool = new SecurityTool(name, category, effectiveness);
            secureHub.AddTool(securityTool);

            SecurityTool secondTool = new SecurityTool("Different", category, effectiveness);

            // Act
            string message = secureHub.AddTool(secondTool);

            // Assert
            Assert.That(secureHub.Tools.Count, Is.EqualTo(1));
            Assert.That(message, Is.EqualTo("Secure Hub is at full capacity."));
        }

        [Test]
        public void RemoveTool_ShouldRemoveToolSuccessfully_WhenToolExists()
        {
            // Arrange
            string name = "Antivirus";
            string category = "Defense";
            double effectiveness = 10;
            SecureHub secureHub = new SecureHub(10);
            SecurityTool securityTool = new SecurityTool(name, category, effectiveness);
            secureHub.AddTool(securityTool);

            // Act
            bool toolRemoved = secureHub.RemoveTool(securityTool);

            // Assert
            Assert.That(toolRemoved, Is.True);
            Assert.That(secureHub.Tools.Count, Is.EqualTo(0));
        }

        [Test]
        public void RemoveTool_ShouldReturnFalse_WhenToolDoesNotExist()
        {
            // Arrange
            string name = "Antivirus";
            string category = "Defense";
            double effectiveness = 10;
            SecureHub secureHub = new SecureHub(10);
            SecurityTool securityTool = new SecurityTool(name, category, effectiveness);

            // Act
            bool toolRemoved = secureHub.RemoveTool(securityTool);

            // Assert
            Assert.That(toolRemoved, Is.False);
        }

        [Test]
        public void DeployTool_RemovesAndReturnsToolSuccessfully_WhenToolExists()
        {
            // Arrange
            string name = "Antivirus";
            string category = "Defense";
            double effectiveness = 10;
            SecureHub secureHub = new SecureHub(10);
            SecurityTool securityTool = new SecurityTool(name, category, effectiveness);
            secureHub.AddTool(securityTool);

            // Act
            SecurityTool deployedTool = secureHub.DeployTool(name);

            // Assert
            Assert.That(deployedTool, Is.Not.Null);
            Assert.That(deployedTool, Is.EqualTo(securityTool));
            Assert.That(secureHub.Tools.Count, Is.EqualTo(0));
        }

        [Test]
        public void DeployTool_ReturnsNull_WhenToolDoesNotExist()
        {
            // Arrange
            string name = "Antivirus";
            string category = "Defense";
            double effectiveness = 10;
            SecureHub secureHub = new SecureHub(10);
            SecurityTool securityTool = new SecurityTool(name, category, effectiveness);
            secureHub.AddTool(securityTool);

            // Act
            SecurityTool deployedTool = secureHub.DeployTool("Name");

            // Assert
            Assert.That(deployedTool, Is.Null);
            Assert.That(secureHub.Tools.Count, Is.EqualTo(1));
        }

        [Test]
        public void SystemReport_ShouldReturnCorrectHeader_WhenCalled()
        {
            // Arrange
            SecureHub secureHub = new SecureHub(10);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Secure Hub Report:");
            sb.AppendLine($"Available Tools: 0");

            // Act
            string result = secureHub.SystemReport();

            // Assert
            Assert.That(result, Is.EqualTo(sb.ToString().TrimEnd()));
        }
    }
}