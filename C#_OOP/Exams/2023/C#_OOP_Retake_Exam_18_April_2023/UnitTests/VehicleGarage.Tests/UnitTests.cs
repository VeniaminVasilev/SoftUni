using NUnit.Framework;
using System;

namespace VehicleGarage.Tests
{
    public class Tests
    {
        [Test]
        public void Constructor_InitializesCorrectly()
        {
            // Arrange
            int capacity = 100;

            // Act
            Garage garage = new Garage(capacity);

            // Assert
            Assert.That(garage.Capacity, Is.EqualTo(capacity));
            Assert.That(garage.Vehicles, Is.Empty);
        }

        [Test]
        public void AddVehicle_Success()
        {
            // Arrange
            int capacity = 100;
            Garage garage = new Garage(capacity);
            string brand = "Brand";
            string model = "Model";
            string licensePlateNumber = "LicensePlateNumber";
            Vehicle vehicle = new Vehicle(brand, model, licensePlateNumber);

            // Act
            bool result = garage.AddVehicle(vehicle);

            // Assert
            Assert.That(garage.Vehicles.Count, Is.EqualTo(1));
            Assert.That(garage.Vehicles.Contains(vehicle));
            Assert.That(result, Is.True);
        }

        [Test]
        public void AddVehicle_ReturnsFalse_WhenNoCapacity()
        {
            // Arrange
            int capacity = 1;
            Garage garage = new Garage(capacity);
            string brand = "Brand";
            string model = "Model";
            string licensePlateNumber = "LicensePlateNumber";
            string licensePlateNumber2 = "LicensePlateNumber2";
            Vehicle vehicle = new Vehicle(brand, model, licensePlateNumber);
            Vehicle vehicle2 = new Vehicle(brand, model, licensePlateNumber2);
            garage.AddVehicle(vehicle);

            // Act
            bool result = garage.AddVehicle(vehicle2);

            // Assert
            Assert.That(garage.Vehicles.Count, Is.EqualTo(1));
            Assert.That(!garage.Vehicles.Contains(vehicle2));
            Assert.That(result, Is.False);
        }

        [Test]
        public void AddVehicle_ReturnsFalse_WhenLicensePlateNumberExists()
        {
            // Arrange
            int capacity = 100;
            Garage garage = new Garage(capacity);
            string brand = "Brand";
            string model = "Model";
            string licensePlateNumber = "LicensePlateNumber";
            Vehicle vehicle = new Vehicle(brand, model, licensePlateNumber);
            Vehicle vehicle2 = new Vehicle(brand, model, licensePlateNumber);
            garage.AddVehicle(vehicle);

            // Act
            bool result = garage.AddVehicle(vehicle2);

            // Assert
            Assert.That(garage.Vehicles.Count, Is.EqualTo(1));
            Assert.That(!garage.Vehicles.Contains(vehicle2));
            Assert.That(result, Is.False);
        }

        [Test]
        public void DriveVehicle_NoAccident()
        {
            // Arrange
            int capacity = 100;
            Garage garage = new Garage(capacity);
            string brand = "Brand";
            string model = "Model";
            string licensePlateNumber = "LicensePlateNumber";
            Vehicle vehicle = new Vehicle(brand, model, licensePlateNumber);
            garage.AddVehicle(vehicle);
            int batteryDrainage = 90;

            // Act
            garage.DriveVehicle(licensePlateNumber, batteryDrainage, false);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(vehicle.BatteryLevel == 100 - batteryDrainage);
                Assert.That(vehicle.IsDamaged, Is.False);
            });
        }

        [Test]
        public void DriveVehicle_Accident()
        {
            // Arrange
            int capacity = 100;
            Garage garage = new Garage(capacity);
            string brand = "Brand";
            string model = "Model";
            string licensePlateNumber = "LicensePlateNumber";
            Vehicle vehicle = new Vehicle(brand, model, licensePlateNumber);
            garage.AddVehicle(vehicle);
            int batteryDrainage = 90;

            // Act
            garage.DriveVehicle(licensePlateNumber, batteryDrainage, true);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(vehicle.BatteryLevel == 100 - batteryDrainage);
                Assert.That(vehicle.IsDamaged, Is.True);
            });
        }

        [Test]
        public void DriveVehicle_Fail_WhenWrongLicensePlate()
        {
            // Arrange
            int capacity = 100;
            Garage garage = new Garage(capacity);
            string brand = "Brand";
            string model = "Model";
            string licensePlateNumber = "LicensePlateNumber";
            Vehicle vehicle = new Vehicle(brand, model, licensePlateNumber);
            garage.AddVehicle(vehicle);
            int batteryDrainage = 90;

            // Act
            Assert.Throws<NullReferenceException>(() =>
            {
                garage.DriveVehicle("Wrong", batteryDrainage, true);
            });
        }

        [Test]
        public void DriveVehicle_Fail_WhenVehicleIsDamaged()
        {
            // Arrange
            int capacity = 100;
            Garage garage = new Garage(capacity);
            string brand = "Brand";
            string model = "Model";
            string licensePlateNumber = "LicensePlateNumber";
            Vehicle vehicle = new Vehicle(brand, model, licensePlateNumber);
            garage.AddVehicle(vehicle);
            int batteryDrainage = 90;
            garage.DriveVehicle(licensePlateNumber, batteryDrainage, true);

            // Act
            garage.DriveVehicle(licensePlateNumber, 1, false);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(vehicle.BatteryLevel == 100 - batteryDrainage);
                Assert.That(vehicle.IsDamaged, Is.True);
            });
        }

        [Test]
        public void DriveVehicle_Fail_WhenBatteryDrainageGreaterThan100()
        {
            // Arrange
            int capacity = 100;
            Garage garage = new Garage(capacity);
            string brand = "Brand";
            string model = "Model";
            string licensePlateNumber = "LicensePlateNumber";
            Vehicle vehicle = new Vehicle(brand, model, licensePlateNumber);
            garage.AddVehicle(vehicle);
            int batteryDrainage = 101;

            // Act
            garage.DriveVehicle(licensePlateNumber, batteryDrainage, false);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(vehicle.BatteryLevel == 100);
                Assert.That(vehicle.IsDamaged, Is.False);
            });
        }

        [Test]
        public void DriveVehicle_Fail_WhenBatteryDrainageGreaterThanBatteryLevel()
        {
            // Arrange
            int capacity = 100;
            Garage garage = new Garage(capacity);
            string brand = "Brand";
            string model = "Model";
            string licensePlateNumber = "LicensePlateNumber";
            Vehicle vehicle = new Vehicle(brand, model, licensePlateNumber);
            garage.AddVehicle(vehicle);
            int batteryDrainage = 90;
            garage.DriveVehicle(licensePlateNumber, batteryDrainage, true);

            // Act
            garage.DriveVehicle(licensePlateNumber, batteryDrainage, false);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(vehicle.BatteryLevel == 100 - batteryDrainage);
                Assert.That(vehicle.IsDamaged, Is.True);
            });
        }

        [Test]
        public void ChargeVehicles_Success()
        {
            // Arrange
            int capacity = 100;
            Garage garage = new Garage(capacity);
            string brand = "Brand";
            string model = "Model";
            string licensePlateNumber = "LicensePlateNumber";
            Vehicle vehicle = new Vehicle(brand, model, licensePlateNumber);
            garage.AddVehicle(vehicle);
            int batteryDrainage = 90;
            garage.DriveVehicle(licensePlateNumber, batteryDrainage, false);

            // Act
            int vehiclesCharged = garage.ChargeVehicles(100);

            // Assert
            Assert.That(vehicle.BatteryLevel, Is.EqualTo(100));
            Assert.That(vehiclesCharged, Is.EqualTo(1));
        }

        [Test]
        public void ChargeVehicles_ReturnsZero_WhenNoVehiclesCharged()
        {
            // Arrange
            int capacity = 100;
            Garage garage = new Garage(capacity);

            // Act
            int vehiclesCharged = garage.ChargeVehicles(100);

            // Assert
            Assert.That(vehiclesCharged, Is.EqualTo(0));
        }

        [Test]
        public void ChargeVehicles_ForVehicles_LessThanOrEqual10()
        {
            // Arrange
            int capacity = 100;
            Garage garage = new Garage(capacity);
            string brand = "Brand";
            string model = "Model";
            string licensePlateNumber = "LicensePlateNumber";
            string licensePlateNumber2 = "LicensePlateNumber2";
            Vehicle vehicle = new Vehicle(brand, model, licensePlateNumber);
            Vehicle vehicle2 = new Vehicle(brand, model, licensePlateNumber2);
            garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicle2);
            int batteryDrainage = 90;
            garage.DriveVehicle(licensePlateNumber, batteryDrainage, false);

            // Act
            int vehiclesCharged = garage.ChargeVehicles(10);

            // Assert
            Assert.That(vehicle.BatteryLevel, Is.EqualTo(100));
            Assert.That(vehiclesCharged, Is.EqualTo(1));
        }

        [Test]
        public void RepairVehicles_Success()
        {
            // Arrange
            int capacity = 100;
            Garage garage = new Garage(capacity);
            string brand = "Brand";
            string model = "Model";
            string licensePlateNumber = "LicensePlateNumber";
            Vehicle vehicle = new Vehicle(brand, model, licensePlateNumber);
            garage.AddVehicle(vehicle);
            int batteryDrainage = 90;
            garage.DriveVehicle(licensePlateNumber, batteryDrainage, true);

            // Act
            Assert.That(vehicle.IsDamaged, Is.True);
            string result = garage.RepairVehicles();

            // Assert
            Assert.That(vehicle.IsDamaged, Is.False);
            Assert.That(result, Is.EqualTo("Vehicles repaired: 1"));
        }

        [Test]
        public void RepairVehicles_WhenNoRepairedVehicles()
        {
            // Arrange
            int capacity = 100;
            Garage garage = new Garage(capacity);

            // Act
            string result = garage.RepairVehicles();

            // Assert
            Assert.That(result, Is.EqualTo("Vehicles repaired: 0"));
        }
    }
}