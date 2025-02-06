namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;
        private const string make = "Toyota";
        private const string model = "Avensis";
        private const double fuelConsumption = 5;
        private const double fuelCapacity = 50;

        [SetUp]
        public void SetUp()
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);
        }

        [Test]
        public void Constructor_ShouldSetPropertiesCorrectly_WhenAllParametersAreValid()
        {
            // Assert
            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Constructor_ShouldThrowArgumentException_WhenMakeIsNullOrEmpty(string make)
        {
            // Act & Assert
            Exception exception = Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            });
            Assert.AreEqual("Make cannot be null or empty!", exception.Message);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Constructor_ShouldThrowArgumentException_WhenModelIsNullOrEmpty(string model)
        {
            // Act & Assert
            Exception exception = Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            });
            Assert.AreEqual("Model cannot be null or empty!", exception.Message);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void Constructor_ShouldThrowArgumentException_WhenFuelConsumptionIsZeroOrNegative(double fuelConsumption)
        {
            // Act & Assert
            Exception exception = Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            });
            Assert.AreEqual("Fuel consumption cannot be zero or negative!", exception.Message);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void Constructor_ShouldThrowArgumentException_WhenFuelCapacityIsZeroOrNegative(double fuelCapacity)
        {
            // Act & Assert
            Exception exception = Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            });
            Assert.AreEqual("Fuel capacity cannot be zero or negative!", exception.Message);
        }

        [TestCase(0.001)]
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(50)]
        public void Refuel_ShouldIncreaseFuelAmount_WhenFuelToRefuelIsValid(double fuelToRefuel)
        {
            // Act
            car.Refuel(fuelToRefuel);

            // Assert
            Assert.AreEqual(fuelToRefuel, car.FuelAmount);
        }

        [TestCase(50.001)]
        [TestCase(51)]
        [TestCase(5000)]
        public void Refuel_ShouldSetFuelAmountToFuelCapacity_WhenRefuelingExceedsCapacity(double fuelToRefuel)
        {
            // Act
            car.Refuel(fuelToRefuel);

            // Assert
            Assert.AreEqual(50, car.FuelAmount);
        }

        [TestCase(0)]
        [TestCase(-0.001)]
        [TestCase(-1)]
        public void Refuel_ShouldThrowArgumentException_WhenFuelToRefuelIsZeroOrNegative(double fuelToRefuel)
        {
            // Act & Assert
            Exception exception = Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(fuelToRefuel);
            });
            Assert.AreEqual("Fuel amount cannot be zero or negative!", exception.Message);
        }

        [Test]
        public void Refuel_ShouldAccumulateFuelCorrectly_WhenCalledMultipleTimes()
        {
            // Act & Assert
            double refueledFuel = 0;

            for (int i = 0; i < 5; i++)
            {
                double fuelToRefuel = 10;

                car.Refuel(fuelToRefuel);
                refueledFuel += fuelToRefuel;

                Assert.AreEqual(refueledFuel, car.FuelAmount);
            }
        }

        [Test]
        public void Refuel_ShouldFillTheFuelCapacity_WhenFuelToRefuelIsExactlyEnoughForTheFuelCapacity()
        {
            // Act & Assert
            double fuelToRefuel = 50;
            car.Refuel(fuelToRefuel);

            Assert.AreEqual(50, car.FuelAmount);
        }

        [TestCase(000.1, 49.994999999999997)]
        [TestCase(1, 49.95)]
        [TestCase(10, 49.5)]
        [TestCase(100, 45)]
        [TestCase(1000, 0)]
        public void Drive_ShouldReduceFuelAmountCorrectly_WhenFuelIsSufficient(double distanceToDrive, double expectedFuelAmount)
        {
            // Arrange
            double fuelToRefuel = 50;
            car.Refuel(fuelToRefuel);

            // Act
            car.Drive(distanceToDrive);

            // Assert
            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        [TestCase(1000.001)]
        [TestCase(1001)]
        [TestCase(10000)]
        public void Drive_ShouldThrowInvalidOperationException_WhenFuelIsInsufficient(double distanceToDrive)
        {
            // Arrange
            double fuelToRefuel = 50;
            car.Refuel(fuelToRefuel);

            // Act & Assert
            Exception exception = Assert.Throws<InvalidOperationException>(() => car.Drive(distanceToDrive));
            Assert.AreEqual("You don't have enough fuel to drive!", exception.Message);
        }

        [TestCase(000.1)]
        [TestCase(1)]
        [TestCase(100)]
        public void Drive_ShouldThrowInvalidOperationException_WhenFuelAmountIsZero(double distanceToDrive)
        {
            // Act & Assert
            Exception exception = Assert.Throws<InvalidOperationException>(() => car.Drive(distanceToDrive));
            Assert.AreEqual("You don't have enough fuel to drive!", exception.Message);
        }

        [Test]
        public void Drive_ShouldNotChangeFuelAmount_WhenDistanceIsZero()
        {
            // Arrange
            double fuelToRefuel = 50;
            car.Refuel(fuelToRefuel);

            // Act
            car.Drive(0);

            // Assert
            Assert.AreEqual(50, car.FuelAmount);
        }
    }
}