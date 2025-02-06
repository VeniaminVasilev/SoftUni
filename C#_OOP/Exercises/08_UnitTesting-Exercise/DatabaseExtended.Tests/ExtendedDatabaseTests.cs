namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [Test]
        public void Constructor_ShouldInitializeDataCorrectlyWithOnePerson()
        {
            // Arrange & Act
            Person person = new Person(123, "John");
            Database database = new Database(person);

            // Assert
            Assert.AreEqual(1, database.Count, "Count does not match the expected value.");
        }

        [Test]
        public void Constructor_ShouldInitializeDataCorrectlyWithEmptyArray()
        {
            // Arrange & Act
            Database database = new Database(new Person[] { });

            // Assert
            Assert.AreEqual(0, database.Count, "Count does not match the expected value.");
        }

        [Test]
        public void Constructor_ShouldInitializeDataCorrectlyWithArrayWith16People()
        {
            // Arrange
            Person[] people = new Person[16];

            for (int i = 0; i < 16; i++)
            {
                Person person = new Person(i, $"Name{i}");
                people[i] = person;
            }

            // Act
            Database database = new Database(people);

            // Assert
            Assert.AreEqual(16, database.Count, "Count does not match the expected value.");
        }

        [Test]
        public void Constructor_ShouldCreateEmptyData_WhenNoArguments()
        {
            // Arrange & Act
            Database database = new Database();

            // Assert
            Assert.AreEqual(0, database.Count, "Count should be 0 for an empty database.");
        }

        [Test]
        public void Constructor_ShouldHandleParamsInput()
        {
            // Arrange
            Person george = new Person(9223372036854775807, "George");
            Person john = new Person(9223372036854775806, "John");

            // Act
            Database database = new Database(george, john);

            // Assert
            Assert.AreEqual(2, database.Count, "Count does not match the expected value.");
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
        public void Constructor_ShouldThrowArgumentException_WhenExceedingCapacity()
        {
            // Arrange
            Person[] people = new Person[17];

            for (int i = 0; i < 17; i++)
            {
                Person person = new Person(i, $"Name{i}");
                people[i] = person;
            }

            // Act & Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
            {
                Database database = new Database(people);
            }, "The constructor should throw InvalidOperationException when input exceeds maximum capacity.");

            Assert.AreEqual(exception.Message, "Provided data length should be in range [0..16]!");
        }

        [Test]
        public void Constructor_ShouldThrowInvalidOperationException_When2PeopleWithSameUsernames()
        {
            // Arrange
            Person person1 = new Person(1, "Name");
            Person person2 = new Person(2, "Name");

            // Act & Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
            {
                Database database = new Database(person1, person2);
            });
            Assert.AreEqual(exception.Message, "There is already user with this username!");
        }

        [Test]
        public void Constructor_ShouldThrowInvalidOperationException_When2PeopleWithSameIds()
        {
            // Arrange
            Person person1 = new Person(1, "Name");
            Person person2 = new Person(1, "Different");

            // Act & Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
            {
                Database database = new Database(person1, person2);
            });
            Assert.AreEqual(exception.Message, "There is already user with this Id!");
        }

        [Test]
        public void Constructor_ShouldThrowInvalidOperationException_When2SamePeople()
        {
            // Arrange
            Person person1 = new Person(1, "Name");
            Person person2 = new Person(1, "Name");

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database database = new Database(person1, person2);
            });
        }

        [Test]
        public void Add_ShouldAddPersonCorrectly_WhenCapacityIsNotExceeded()
        {
            // Arrange
            Person firstPerson = new Person(1, "FirstPerson");
            Person personToBeAdded = new Person(2, "PersonToBeAdded");

            Database database = new Database(firstPerson);

            // Act
            database.Add(personToBeAdded);

            // Assert
            Assert.AreEqual(2, database.Count);

            Person retrievedPerson = database.FindByUsername(personToBeAdded.UserName);
            Assert.AreEqual(personToBeAdded, retrievedPerson);

            retrievedPerson = database.FindById(personToBeAdded.Id);
            Assert.AreEqual(personToBeAdded, retrievedPerson);
        }

        [Test]
        public void Add_ShouldAddPersonCorrectly_WhenEmptyDatabase()
        {
            // Arrange
            Person personToBeAdded = new Person(2, "PersonToBeAdded");
            Database database = new Database();

            // Act
            database.Add(personToBeAdded);

            // Assert
            Assert.AreEqual(1, database.Count);

            Person retrievedPerson = database.FindByUsername(personToBeAdded.UserName);
            Assert.AreEqual(personToBeAdded, retrievedPerson);

            retrievedPerson = database.FindById(personToBeAdded.Id);
            Assert.AreEqual(personToBeAdded, retrievedPerson);
        }

        [Test]
        public void Add_ShouldAddPersonCorrectly_UntilCapacityIsFull()
        {
            // Arrange
            Database database = new Database();

            // Act & Assert
            for (int i = 0; i < 16; i++)
            {
                Person person = new Person(i, $"Name {i}");
                database.Add(person);

                Person retrievedPerson = database.FindByUsername($"Name {i}");
                Assert.AreEqual(person, retrievedPerson);

                retrievedPerson = database.FindById(i);
                Assert.AreEqual(person, retrievedPerson);

                Assert.AreEqual(i + 1, database.Count);
            }
        }

        [Test]
        public void Add_ShouldThrowInvalidOperationException_WhenCapacityIsExceeded()
        {
            // Arrange
            Database database = new Database();

            for (int i = 0; i < 16; i++)
            {
                Person person = new Person(i, $"Name {i + 1}");
                database.Add(person);
            }
            Person personToBeAdded = new Person(17, "Name 17");

            // Act & Assert
            Exception exception = Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(personToBeAdded);
            });

            Assert.AreEqual(exception.Message, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void Add_ShouldThrowInvalidOperationException_WhenSameUsername()
        {
            // Arrange
            Database database = new Database();
            Person firstPerson = new Person(1, "Same name");
            database.Add(firstPerson);

            Person personToBeAdded = new Person(2, "Same name");

            // Act & Assert
            Exception exception = Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(personToBeAdded);
            });

            Assert.AreEqual(exception.Message, "There is already user with this username!");
        }

        [Test]
        public void Add_ShouldThrowInvalidOperationException_WhenSameId()
        {
            // Arrange
            Person firstPerson = new Person(1, "Name");
            Database database = new Database(firstPerson);

            Person personToBeAdded = new Person(1, "Different Name");

            // Act & Assert
            Exception exception = Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(personToBeAdded);
            });

            Assert.AreEqual(exception.Message, "There is already user with this Id!");
        }

        [Test]
        public void Add_ShouldThrowInvalidOperationException_WhenSameUsernameAndId()
        {
            // Arrange
            Person firstPerson = new Person(1, "Name");
            Database database = new Database(firstPerson);

            Person personToBeAdded = new Person(1, "Name");

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(personToBeAdded);
            });
        }

        [Test]
        public void Remove_ShouldRemovePersonCorrectly_WhenCountIsNotZero()
        {
            // Arrange
            Person firstPerson = new Person(1, "First Person");
            Person secondPerson = new Person(2, "Second Person");
            Database database = new Database(firstPerson, secondPerson);

            // Act
            database.Remove();

            // Assert
            Assert.AreEqual(1, database.Count);
        }

        [Test]
        public void Remove_ShouldRemovePersonCorrectly_UntilCountIsZero()
        {
            // Arrange
            Database database = new Database();
            for (int i = 0; i < 16; i++)
            {
                Person person = new Person(i, $"Name {i + 1}");
                database.Add(person);
            }

            // Act & Assert
            for (int i = 15; i >= 0; i--)
            {
                database.Remove();
                Assert.AreEqual(i, database.Count);
            }
        }

        [Test]
        public void Remove_ShouldThrowInvalidOperationException_WhenCountIsZero()
        {
            // Arrange
            Database database = new Database();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }

        [Test]
        public void FindByUsername_ShouldFindPersonByUsername_WhenPersonIsPresent()
        {
            // Arrange
            Person person = new Person(1000, "John");
            Database database = new Database(person);

            // Act
            Person retrievedPerson = database.FindByUsername(person.UserName);

            // Assert
            Assert.AreEqual(person, retrievedPerson);
        }

        [Test]
        public void FindByUsername_ShouldThrowArgumentNullException_WhenGivenUsernameIsNull()
        {
            // Arrange
            Person person = new Person(1000, "John");
            Database database = new Database(person);

            // Act & Assert
            Exception exception = Assert.Throws<ArgumentNullException>(() =>
            {
                Person retrievedPerson = database.FindByUsername(null);
            });
            Assert.AreEqual("Value cannot be null. (Parameter 'Username parameter is null!')", exception.Message);
        }

        [Test]
        public void FindByUsername_ShouldThrowArgumentNullException_WhenGivenUsernameIsEmptyString()
        {
            // Arrange
            Person person = new Person(1000, "John");
            Database database = new Database(person);

            // Act & Assert
            Exception exception = Assert.Throws<ArgumentNullException>(() =>
            {
                Person retrievedPerson = database.FindByUsername("");
            });
            Assert.AreEqual("Value cannot be null. (Parameter 'Username parameter is null!')", exception.Message);
        }

        [Test]
        public void FindByUsername_ShouldThrowInvalidOperationException_WhenNoPersonMatchesGivenUsername()
        {
            // Arrange
            Person person = new Person(1000, "John");
            Database database = new Database(person);

            // Act & Assert
            Exception exception = Assert.Throws<InvalidOperationException>(() =>
            {
                Person retrievedPerson = database.FindByUsername("Wrong username");
            });
            Assert.AreEqual("No user is present by this username!", exception.Message);
        }

        [Test]
        public void FindById_ShouldFindPersonById_WhenPersonIsPresent()
        {
            // Arrange
            Person person = new Person(1000, "John");
            Database database = new Database(person);

            // Act
            Person retrievedPerson = database.FindById(person.Id);

            // Assert
            Assert.AreEqual(person, retrievedPerson);
        }

        [Test]
        public void FindById_ShouldThrowArgumentOutOfRangeException_WhenGivenIdIsNegative()
        {
            // Arrange
            Person person = new Person(1000, "John");
            Database database = new Database(person);

            // Act & Assert
            Exception exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Person retrievedPerson = database.FindById(-1);
            });
            Assert.AreEqual("Specified argument was out of the range of valid values. (Parameter 'Id should be a positive number!')", 
                exception.Message);
        }

        [Test]
        public void FindById_ShouldThrowInvalidOperationException_WhenNoPersonMatchesGivenId()
        {
            // Arrange
            Person person = new Person(1000, "John");
            Database database = new Database(person);

            // Act & Assert
            Exception exception = Assert.Throws<InvalidOperationException>(() =>
            {
                Person retrievedPerson = database.FindById(1);
            });
            Assert.AreEqual("No user is present by this ID!", exception.Message);
        }
    }
}