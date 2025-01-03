namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Constructor_ShouldInitializeDataCorrectly(int[] input)
        {
            // Arrange & Act
            Database database = new Database(input);
            int[] fetchedDatabase = database.Fetch();

            // Assert
            Assert.AreEqual(input.Length, database.Count, "Count does not match the expected value.");
            for (int i = 0; i < input.Length; i++)
            {
                Assert.AreEqual(input[i], fetchedDatabase[i], $"Value at index {i} does not match the expected value.");
            }
        }

        [Test]
        public void Constructor_ShouldCreateEmptyData_WhenNoArguments()
        {
            // Arrange & Act
            Database database = new Database();

            // Assert
            Assert.AreEqual(0, database.Count, "Count should be 0 for an empty database.");
        }

        [TestCase(1, 2, 3, 4, 5)]
        [TestCase(42)]
        [TestCase(-111, -222)]
        [TestCase(0, 0, 0)]
        public void Constructor_ShouldHandleParamsInput(params int[] input)
        {
            // Arrange & Act
            Database database = new Database(input);
            int[] fetchedDatabase = database.Fetch();

            // Assert
            Assert.AreEqual(input.Length, database.Count, "Count does not match the expected value.");
            for (int i = 0; i < input.Length; i++)
            {
                Assert.AreEqual(input[i], fetchedDatabase[i], $"Value at index {i} does not match the expected value.");
            }
        }

        [Test]
        public void Constructor_ShouldThrowNullReferenceException_WhenNullIsPassed()
        {
            // Act & Assert
            Assert.Throws<NullReferenceException>(() =>
            {
                Database database = new Database(null);
            }, "The constructor should throw NullReferenceException when null is passed.");
        }

        [Test]
        public void Constructor_ShouldThrowInvalidOperationException_WhenExceedingCapacity()
        {
            // Arrange
            int[] largeInput = new int[17];

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database database = new Database(largeInput);
            }, "The constructor should throw InvalidOperationException when input exceeds maximum capacity.");
        }

        [TestCase(-10)]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(10)]
        public void Add_ShouldAddElementCorrectly_WhenCapacityIsNotExceeded(int number)
        {
            // Arrange
            Database database = new Database();

            // Act
            database.Add(number);
            int[] fetchedDatabase = database.Fetch();

            // Assert
            Assert.AreEqual(1, database.Count, "Count should be 1 after adding one element.");
            Assert.AreEqual(number, fetchedDatabase[0], "The first element should be the one added.");
        }

        [Test]
        public void Add_ShouldThrowInvalidOperationException_WhenCapacityIsExceeded()
        {
            // Arrange
            Database database = new Database();

            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(17);
            }, "Adding more then 16 elements should throw InvalidOperationException.");
        }

        [Test]
        public void Add_ShouldAllowAddingDuplicateElements()
        {
            // Arrange
            Database database = new Database();

            // Act
            database.Add(1);
            database.Add(1);
            int[] fetchedDatabase = database.Fetch();

            // Assert
            Assert.AreEqual(2, database.Count, "Count should be 2 after adding two elements, even if duplicates.");
            Assert.AreEqual(1, fetchedDatabase[0], "The first element should be 1.");
            Assert.AreEqual(1, fetchedDatabase[1], "The second element should be 1.");
        }

        [Test]
        public void Remove_ShouldDecrementCount_WhenCollectionIsNotEmpty()
        {
            // Arrange
            Database database = new Database(1, 2, 3);

            // Act
            database.Remove();

            // Assert
            Assert.AreEqual(2, database.Count, "Count should be decremented by 1 after removing an element.");
        }

        [Test]
        public void Remove_ShouldThrowInvalidOperationException_WhenCollectionIsEmpty()
        {
            // Arrange
            Database database = new Database();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            }, "Removing an element fron an empty collection should throw InvalidOperationException.");
        }

        [Test]
        public void Remove_ShouldAllowRemovingAllElementsUntilEmpty()
        {
            // Arrange
            Database database = new Database(1, 2, 3);

            // Act
            database.Remove();
            database.Remove();
            database.Remove();

            // Assert
            Assert.AreEqual(0, database.Count, "Count should be 0 after removing all elements.");
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            }, "Removing an element fron an empty collection should throw InvalidOperationException.");
        }

        [Test]
        public void Fetch_ShouldReturnAllElements_WhenDatabaseIsPopulated()
        {
            // Arrange
            Database database = new Database(1, 2, 3);

            // Act
            int[] result = database.Fetch();

            // Assert
            Assert.AreEqual(3, result.Length, "The fetched array should contain all the elements in the database.");
            Assert.AreEqual(new[] { 1, 2, 3 }, result, "The fetched array should match the elements in the database.");
        }

        [Test]
        public void Fetch_ShouldReturnEmptyArray_WhenDatabaseIsEmpty()
        {
            // Arrange
            Database database = new Database();

            // Act
            int[] result = database.Fetch();

            // Assert
            Assert.AreEqual(0, result.Length, "The fetched array should be empty when the database is empty.");
        }

        [Test]
        public void Fetch_ShouldReturnACopyOfTheData_NotAReference()
        {
            // Arrange
            Database database = new Database(1, 2, 3);

            // Act
            int[] result = database.Fetch();

            result[0] = 99; // Modifying the returned array

            // Assert
            Assert.AreEqual(new[] { 1, 2, 3 }, database.Fetch(), "Modifying the fetched array should not affect the database.");
        }

        [Test]
        public void Fetch_ShouldReturnArrayWithSingleElement_WhenDatabaseHasOneElement()
        {
            // Arrange
            Database database = new Database(42);

            // Act
            int[] result = database.Fetch();

            // Assert
            Assert.AreEqual(1, result.Length, "The fetched array should have one element.");
            Assert.AreEqual(42, result[0], "The single element should match the one in the database.");
        }
    }
}