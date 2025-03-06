namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Tests
    {
        [Test]
        public void Constructor_InitializesCorrectly()
        {
            // Arrange
            string name = "Name";

            // Act
            RailwayStation station = new RailwayStation(name);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(station.Name == name);
                Assert.That(station.ArrivalTrains != null);
                Assert.That(station.ArrivalTrains.Count == 0);
                Assert.That(station.DepartureTrains != null);
                Assert.That(station.DepartureTrains.Count == 0);
            });
        }

        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("")]
        public void ArgumentExceptionThrown_WhenNameIsInvalid(string name)
        {
            // Act & Assert
            Exception exception = Assert.Throws<ArgumentException>(() =>
            {
                RailwayStation station = new RailwayStation(name);
            });
            Assert.That(exception.Message, Is.EqualTo("Name cannot be null or empty!"));
        }

        [Test]
        public void NewArrivalOnBoard_Success()
        {
            // Arrange
            string name = "Name";
            RailwayStation station = new RailwayStation(name);
            string trainInfo = "TrainInfo";

            // Act
            station.NewArrivalOnBoard(trainInfo);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(station.ArrivalTrains.Count == 1);
                Assert.That(station.ArrivalTrains.Contains(trainInfo));
                Assert.That(station.DepartureTrains.Count == 0);
            });
        }

        [Test]
        public void NewArrivalOnBoard_Many_Success()
        {
            // Arrange
            string name = "Name";
            RailwayStation station = new RailwayStation(name);
            string trainInfo = "TrainInfo";
            string trainInfo2 = "TrainInfo2";
            string trainInfo3 = "TrainInfo3";

            // Act
            station.NewArrivalOnBoard(trainInfo);
            station.NewArrivalOnBoard(trainInfo2);
            station.NewArrivalOnBoard(trainInfo3);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(station.ArrivalTrains.Count == 3);
                Assert.That(station.ArrivalTrains.Contains(trainInfo));
                Assert.That(station.ArrivalTrains.Contains(trainInfo2));
                Assert.That(station.ArrivalTrains.Contains(trainInfo3));
                Assert.That(station.DepartureTrains.Count == 0);
            });
        }

        [Test]
        public void TrainHasArrived_WhenTrainInfoIsCorrect()
        {
            // Arrange
            string name = "Name";
            RailwayStation station = new RailwayStation(name);
            string trainInfo = "TrainInfo";
            string trainInfo2 = "TrainInfo2";
            station.NewArrivalOnBoard(trainInfo);
            station.NewArrivalOnBoard(trainInfo2);

            // Act
            string result = station.TrainHasArrived(trainInfo);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(station.ArrivalTrains.Count == 1);
                Assert.That(station.DepartureTrains.Count == 1);
                Assert.That(station.DepartureTrains.Contains(trainInfo));
                Assert.That(result, Is.EqualTo($"{trainInfo} is on the platform and will leave in 5 minutes."));
            });
        }

        [Test]
        public void TrainHasArrived_WhenTrainInfoIsNotCorrect()
        {
            // Arrange
            string name = "Name";
            RailwayStation station = new RailwayStation(name);
            string trainInfo = "TrainInfo";
            string trainInfo2 = "TrainInfo2";
            station.NewArrivalOnBoard(trainInfo);
            station.NewArrivalOnBoard(trainInfo2);

            // Act
            string result = station.TrainHasArrived(trainInfo2);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(station.ArrivalTrains.Count == 2);
                Assert.That(station.DepartureTrains.Count == 0);
                Assert.That(station.ArrivalTrains.Contains(trainInfo));
                Assert.That(station.ArrivalTrains.Contains(trainInfo2));
                Assert.That(result, Is.EqualTo($"There are other trains to arrive before {trainInfo2}."));
            });
        }

        [Test]
        public void TrainHasLeft_ReturnsTrue_WhenTrainLeaves()
        {
            // Arrange
            string name = "Name";
            RailwayStation station = new RailwayStation(name);
            string trainInfo = "TrainInfo";
            station.NewArrivalOnBoard(trainInfo);
            station.TrainHasArrived(trainInfo);

            // Act
            bool trainHasLeft = station.TrainHasLeft(trainInfo);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(trainHasLeft, Is.True);
                Assert.That(station.DepartureTrains.Count, Is.EqualTo(0));
                Assert.That(station.ArrivalTrains.Count, Is.EqualTo(0));
            });
        }

        [Test]
        public void TrainHasLeft_ReturnsFalse_WhenWrongTrainInfoSent()
        {
            // Arrange
            string name = "Name";
            RailwayStation station = new RailwayStation(name);
            string trainInfo = "TrainInfo";
            string trainInfo2 = "TrainInfo2";
            station.NewArrivalOnBoard(trainInfo);
            station.NewArrivalOnBoard(trainInfo2);
            station.TrainHasArrived(trainInfo);
            station.TrainHasArrived(trainInfo2);

            // Act
            bool trainHasLeft = station.TrainHasLeft(trainInfo2);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(trainHasLeft, Is.False);
                Assert.That(station.DepartureTrains.Count, Is.EqualTo(2));
                Assert.That(station.DepartureTrains.Contains(trainInfo));
                Assert.That(station.DepartureTrains.Contains(trainInfo2));
                Assert.That(station.ArrivalTrains.Count, Is.EqualTo(0));
            });
        }
    }
}