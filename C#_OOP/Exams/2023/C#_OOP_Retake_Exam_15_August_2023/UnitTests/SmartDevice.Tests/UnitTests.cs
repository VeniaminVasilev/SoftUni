namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Tests
    {
        [TestCase(-10)]
        [TestCase(0)]
        [TestCase(10)]
        public void Constructor_InitializesCorrectly(int memoryCapacity)
        {
            // Act
            Device device = new Device(memoryCapacity);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(device.MemoryCapacity == memoryCapacity);
                Assert.That(device.AvailableMemory == memoryCapacity);
                Assert.That(device.Photos == 0);
                Assert.That(device.Applications, Is.Not.Null);
                Assert.That(device.Applications.Count == 0);
            });
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(100)]
        public void TakePhoto_Success(int photoSize)
        {
            // Arrange
            int memoryCapacity = 100;
            Device device = new Device(memoryCapacity);

            // Act
            bool result = device.TakePhoto(photoSize);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(device.Photos == 1);
                Assert.That(result == true);
                Assert.That(device.AvailableMemory == (memoryCapacity - photoSize));
            });
        }

        [Test]
        public void TakePhoto_Failure()
        {
            // Arrange
            int memoryCapacity = 100;
            Device device = new Device(memoryCapacity);
            int photoSize = 101;

            // Act
            bool result = device.TakePhoto(photoSize);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(device.Photos == 0);
                Assert.That(result == false);
                Assert.That(device.AvailableMemory == device.MemoryCapacity);
            });
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(100)]
        public void InstallApp_Success(int appSize)
        {
            // Arrange
            int memoryCapacity = 100;
            Device device = new Device(memoryCapacity);
            string appName = "AppName";

            // Act
            string result = device.InstallApp(appName, appSize);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo($"{appName} is installed successfully. Run application?"));
                Assert.That(device.AvailableMemory == (memoryCapacity - appSize));
                Assert.That(device.Applications.Count == 1);
                Assert.That(device.Applications.Contains(appName));
            });
        }

        [Test]
        public void InstallApp_Failure()
        {
            // Arrange
            int memoryCapacity = 100;
            Device device = new Device(memoryCapacity);
            string appName = "AppName";
            int appSize = 101;

            // Act & Assert
            Exception exception = Assert.Throws<InvalidOperationException>(() =>
            {
                string result = device.InstallApp(appName, appSize);
            });
            Assert.That(exception.Message, Is.EqualTo("Not enough available memory to install the app."));
        }

        [Test]
        public void FormatDevice_Success()
        {
            // Arrange
            int memoryCapacity = 100;
            Device device = new Device(memoryCapacity);
            string appName = "AppName";
            int appSize = 10;
            int photoSize = 10;

            device.InstallApp(appName, appSize);
            device.TakePhoto(photoSize);

            // Act
            device.FormatDevice();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(device.Photos == 0);
                Assert.That(device.Applications, Is.Not.Null);
                Assert.That(device.Applications.Count == 0);
                Assert.That(device.AvailableMemory == memoryCapacity);
            });
        }

        [Test]
        public void GetDeviceStatus_ReturnsCorrectString()
        {
            // Arrange
            int memoryCapacity = 100;
            Device device = new Device(memoryCapacity);
            string appName = "AppName";
            string appName2 = "AppName2";
            int appSize = 10;
            int photoSize = 10;

            device.InstallApp(appName, appSize);
            device.InstallApp(appName2, appSize);
            device.TakePhoto(photoSize);

            List<string> installedApps = new List<string> { appName, appName2 };

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Memory Capacity: {memoryCapacity} MB, Available Memory: {memoryCapacity - (appSize + appSize + photoSize)} MB");
            stringBuilder.AppendLine($"Photos Count: {device.Photos}");
            stringBuilder.AppendLine($"Applications Installed: {string.Join(", ", installedApps)}");

            string expectedResult = stringBuilder.ToString().TrimEnd();

            // Act
            string result = device.GetDeviceStatus();

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}