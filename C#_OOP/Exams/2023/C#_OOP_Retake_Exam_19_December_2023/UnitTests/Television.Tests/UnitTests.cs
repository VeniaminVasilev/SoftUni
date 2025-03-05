namespace Television.Tests
{
    using System;
    using System.Diagnostics;
    using NUnit.Framework;
    public class Tests
    {
        [Test]
        public void Constructor_InitializesCorrectly()
        {
            // Arrange
            string brand = "Brand";
            double price = 100.0;
            int screenWidth = 50;
            int screenHeight = 25;

            // Act
            TelevisionDevice tv = new TelevisionDevice(brand, price, screenWidth, screenHeight);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(tv.Brand, Is.EqualTo(brand));
                Assert.That(tv.Price, Is.EqualTo(price));
                Assert.That(tv.ScreenWidth, Is.EqualTo(screenWidth));
                Assert.That(tv.ScreenHeigth, Is.EqualTo(screenHeight));
                Assert.That(tv.CurrentChannel, Is.EqualTo(0));
                Assert.That(tv.Volume, Is.EqualTo(13));
                Assert.That(tv.IsMuted, Is.False);
            });
        }

        [Test]
        public void SwitchOn_WorksCorrectly_WhenTvIsNotMuted()
        {
            // Arrange
            string brand = "Brand";
            double price = 100.0;
            int screenWidth = 50;
            int screenHeight = 25;
            TelevisionDevice tv = new TelevisionDevice(brand, price, screenWidth, screenHeight);

            // Act
            string result = tv.SwitchOn();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo($"Cahnnel {tv.CurrentChannel} - Volume {tv.Volume} - Sound On"));
                Assert.That(tv.Brand, Is.EqualTo(brand));
                Assert.That(tv.Price, Is.EqualTo(price));
                Assert.That(tv.ScreenWidth, Is.EqualTo(screenWidth));
                Assert.That(tv.ScreenHeigth, Is.EqualTo(screenHeight));
                Assert.That(tv.CurrentChannel, Is.EqualTo(0));
                Assert.That(tv.Volume, Is.EqualTo(13));
                Assert.That(tv.IsMuted, Is.False);
            });
        }

        [Test]
        public void SwitchOn_WorksCorrectly_WhenTvIsMuted()
        {
            // Arrange
            string brand = "Brand";
            double price = 100.0;
            int screenWidth = 50;
            int screenHeight = 25;
            TelevisionDevice tv = new TelevisionDevice(brand, price, screenWidth, screenHeight);
            tv.MuteDevice();

            // Act
            string result = tv.SwitchOn();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo($"Cahnnel {tv.CurrentChannel} - Volume {tv.Volume} - Sound Off"));
                Assert.That(tv.Brand, Is.EqualTo(brand));
                Assert.That(tv.Price, Is.EqualTo(price));
                Assert.That(tv.ScreenWidth, Is.EqualTo(screenWidth));
                Assert.That(tv.ScreenHeigth, Is.EqualTo(screenHeight));
                Assert.That(tv.CurrentChannel, Is.EqualTo(0));
                Assert.That(tv.Volume, Is.EqualTo(13));
                Assert.That(tv.IsMuted, Is.True);
            });
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(100)]
        public void ChangeChannel_WorksCorrectly(int channel)
        {
            // Arrange
            string brand = "Brand";
            double price = 100.0;
            int screenWidth = 50;
            int screenHeight = 25;
            TelevisionDevice tv = new TelevisionDevice(brand, price, screenWidth, screenHeight);

            // Act
            int currentChannel = tv.ChangeChannel(channel);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(currentChannel, Is.EqualTo(channel));
                Assert.That(tv.CurrentChannel, Is.EqualTo(channel));
            });
        }

        [TestCase(-1)]
        [TestCase(-10)]
        public void ChangeChannel_ThrowsException_WhenChannelIsLessThanZero(int channel)
        {
            // Arrange
            string brand = "Brand";
            double price = 100.0;
            int screenWidth = 50;
            int screenHeight = 25;
            TelevisionDevice tv = new TelevisionDevice(brand, price, screenWidth, screenHeight);

            // Act & Assert
            Exception exception = Assert.Throws<ArgumentException>(() =>
            {
                tv.ChangeChannel(channel);
            });
            Assert.That(exception.Message, Is.EqualTo("Invalid key!"));
        }

        [Test]
        public void VolumeChange_DirectionUp()
        {
            // Arrange
            string brand = "Brand";
            double price = 100.0;
            int screenWidth = 50;
            int screenHeight = 25;
            TelevisionDevice tv = new TelevisionDevice(brand, price, screenWidth, screenHeight);

            // Act & Assert
            string result1 = tv.VolumeChange("UP", 1);
            Assert.That(result1, Is.EqualTo($"Volume: 14"));
            Assert.That(tv.Volume, Is.EqualTo(14));

            string result2 = tv.VolumeChange("UP", 86);
            Assert.That(result2, Is.EqualTo($"Volume: 100"));
            Assert.That(tv.Volume, Is.EqualTo(100));

            string result3 = tv.VolumeChange("UP", 1);
            Assert.That(result3, Is.EqualTo($"Volume: 100"));
            Assert.That(tv.Volume, Is.EqualTo(100));
        }

        [Test]
        public void VolumeChange_DirectionDown()
        {
            // Arrange
            string brand = "Brand";
            double price = 100.0;
            int screenWidth = 50;
            int screenHeight = 25;
            TelevisionDevice tv = new TelevisionDevice(brand, price, screenWidth, screenHeight);

            // Act & Assert
            string result1 = tv.VolumeChange("DOWN", 1);
            Assert.That(result1, Is.EqualTo($"Volume: 12"));
            Assert.That(tv.Volume, Is.EqualTo(12));

            string result2 = tv.VolumeChange("DOWN", 12);
            Assert.That(result2, Is.EqualTo($"Volume: 0"));
            Assert.That(tv.Volume, Is.EqualTo(0));

            string result3 = tv.VolumeChange("DOWN", 1);
            Assert.That(result3, Is.EqualTo($"Volume: 0"));
            Assert.That(tv.Volume, Is.EqualTo(0));
        }

        [Test]
        public void MuteDevice_WorksSuccessfully()
        {
            // Arrange
            string brand = "Brand";
            double price = 100.0;
            int screenWidth = 50;
            int screenHeight = 25;
            TelevisionDevice tv = new TelevisionDevice(brand, price, screenWidth, screenHeight);

            // Act & Assert
            Assert.That(tv.IsMuted, Is.False);

            bool muted = tv.MuteDevice();
            Assert.That(muted, Is.True);
            Assert.That(tv.IsMuted, Is.True);

            muted = tv.MuteDevice();
            Assert.That(muted, Is.False);
            Assert.That(tv.IsMuted, Is.False);
        }

        [Test]
        public void ToStringMethodReturnsCorrectString()
        {
            // Arrange
            string brand = "Brand";
            double price = 100.0;
            int screenWidth = 50;
            int screenHeight = 25;
            TelevisionDevice tv = new TelevisionDevice(brand, price, screenWidth, screenHeight);

            // Act
            string result = tv.ToString();

            // Assert
            Assert.That(result, Is.EqualTo($"TV Device: {brand}, Screen Resolution: {screenWidth}x{screenHeight}, Price {price}$"));
        }
    }
}