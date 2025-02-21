using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NUnit.Framework;

namespace AutoTrade.Tests
{
    [TestFixture]
    public class DealerShopTests
    {

        [TestCase(1)]
        [TestCase(1000)]
        public void Constructor_ShouldInitializeCorrectly(int capacity)
        {
            // Act
            DealerShop dealerShop = new DealerShop(capacity);

            // Assert
            Assert.That(dealerShop, Is.Not.Null);
            Assert.That(dealerShop.Capacity, Is.EqualTo(capacity));
            Assert.That(dealerShop.Vehicles.Count, Is.EqualTo(0));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-1000)]
        public void Constructor_ShouldNotInitialize_WhenCapacityIsNotCorrect(int capacity)
        {
            // Assert
            Exception exception = Assert.Throws<ArgumentException>(() =>
            {
                DealerShop dealerShop = new DealerShop(capacity);
            });
            Assert.That(exception.Message, Is.EqualTo("Capacity must be a positive value."));
        }

        [Test]
        public void AddVehicle_ShouldAddVehicle_WhenCapacityIsNotReached()
        {
            // Arrange
            Vehicle vehicle = new Vehicle("Make", "Model", 2000);
            DealerShop dealerShop = new DealerShop(10);

            // Act
            string result = dealerShop.AddVehicle(vehicle);

            // Assert
            Assert.That(result, Is.EqualTo($"Added {vehicle.ToString()}"));
            Assert.That(dealerShop.Vehicles.Count(), Is.EqualTo(1));
            Assert.That(dealerShop.Vehicles.Contains(vehicle), Is.True);
            Assert.That(dealerShop.Capacity, Is.EqualTo(10));
        }

        [Test]
        public void AddVehicle_ShouldNotAddVehicle_WhenCapacityIsReached()
        {
            // Arrange
            Vehicle vehicle1 = new Vehicle("Make", "Model", 2000);
            Vehicle vehicle2 = new Vehicle("Make2", "Model2", 2000);
            DealerShop dealerShop = new DealerShop(1);
            dealerShop.AddVehicle(vehicle1);

            // Act & Assert
            Exception exception = Assert.Throws<InvalidOperationException>(() =>
            {
                dealerShop.AddVehicle(vehicle2);
            });
            Assert.That(exception.Message, Is.EqualTo("Inventory is full"));
        }

        [Test]
        public void SellVehicle_ShouldBeSuccessful_WhenVehicleIsPresent()
        {
            // Arrange
            Vehicle vehicle = new Vehicle("Make", "Model", 2000);
            DealerShop dealerShop = new DealerShop(1);
            dealerShop.AddVehicle(vehicle);

            // Act
            bool sold = dealerShop.SellVehicle(vehicle);

            // Assert
            Assert.That(sold, Is.True);
            Assert.That(dealerShop.Vehicles.Count, Is.EqualTo(0));
            Assert.That(dealerShop.Capacity, Is.EqualTo(1));
        }

        [Test]
        public void SellVehicle_ShouldNotBeSuccessful_WhenVehicleIsNotPresent()
        {
            // Arrange
            Vehicle vehicle = new Vehicle("Make", "Model", 2000);
            DealerShop dealerShop = new DealerShop(1);

            // Act
            bool sold = dealerShop.SellVehicle(vehicle);

            // Assert
            Assert.That(sold, Is.False);
            Assert.That(dealerShop.Vehicles.Count, Is.EqualTo(0));
            Assert.That(dealerShop.Capacity, Is.EqualTo(1));
        }

        [Test]
        public void InventoryReport_ReturnsCorrectString()
        {
            // Arrange
            int capacity = 1;
            Vehicle vehicle = new Vehicle("Make", "Model", 2000);
            DealerShop dealerShop = new DealerShop(capacity);
            dealerShop.AddVehicle(vehicle);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Inventory Report");
            sb.AppendLine($"Capacity: {capacity}");
            sb.AppendLine($"Vehicles: 1");
            sb.AppendLine(vehicle.ToString());

            string expectedReport = sb.ToString().TrimEnd();

            // Act
            string actualReport = dealerShop.InventoryReport();

            // Assert
            Assert.That(actualReport, Is.EqualTo(expectedReport));
        }
    }
}
