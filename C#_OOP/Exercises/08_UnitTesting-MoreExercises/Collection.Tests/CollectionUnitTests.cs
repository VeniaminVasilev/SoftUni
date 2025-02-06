using Collections;

namespace Collection.Tests
{
    public class Tests
    {
        [Test]
        public void Test_Collections_EmptyConstructor()
        {
            // Act
            Collection<int> collection = new Collection<int>();

            // Assert
            Assert.AreEqual(0, collection.Count);
            Assert.That(collection.Capacity >= 16);
        }

        [Test]
        public void Test_Collections_ConstructorSingleItem()
        {
            // Act
            Collection<int> collection = new Collection<int>(5);

            // Assert
            Assert.AreEqual(1, collection.Count);
            Assert.AreEqual(5, collection[0]);
        }

        [Test]
        public void Test_Collections_ConstructorMultipleItems()
        {
            // Act
            Collection<int> collection = new Collection<int>(1, 2, 3);

            // Assert
            Assert.AreEqual(3, collection.Count);
            Assert.AreEqual(1, collection[0]);
            Assert.AreEqual(2, collection[1]);
            Assert.AreEqual(3, collection[2]);
        }

        [Test]
        public void Test_Collections_Add()
        {
            // Arrange
            Collection<int> collection = new Collection<int>();

            // Act
            collection.Add(10);

            // Assert
            Assert.AreEqual(1, collection.Count);
            Assert.AreEqual(10, collection[0]);
        }

        [Test]
        public void Test_Collections_AddRange()
        {
            // Arrange
            Collection<int> collection = new Collection<int>();

            // Act
            collection.AddRange(1, 2, 3);

            // Assert
            Assert.That(collection.Count, Is.EqualTo(3));
            Assert.That(collection[0], Is.EqualTo(1));
            Assert.That(collection[1], Is.EqualTo(2));
            Assert.That(collection[2], Is.EqualTo(3));
        }

        [Test]
        public void Test_Collections_AddRangeWithGrow()
        {
            // Arrange
            Collection<int> collection = new Collection<int>(1, 2);

            // Act
            collection.AddRange(3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20);

            // Assert
            Assert.That(collection.Count == 20);
            Assert.That(collection.Capacity >= 20);
        }

        [Test]
        public void Test_Collections_AddWithGrow()
        {
            // Arrange
            Collection<int> collection = new Collection<int>();
            int initialCapacity = collection.Capacity;

            // Act
            for (int i = 0; i < initialCapacity + 1; i++)
            {
                collection.Add(i);
            }

            // Assert
            Assert.That(collection.Count == initialCapacity + 1);
            Assert.That(collection.Capacity == 2 * initialCapacity);

        }

        [Test]
        public void Test_Collections_Clear()
        {
            // Arrange
            Collection<int> collection = new Collection<int>(1, 2, 3);

            // Act
            collection.Clear();

            // Assert
            Assert.That(collection.Count == 0);
        }

        [Test]
        public void Test_Collections_CountAndCapacity()
        {
            // Arrange & Act
            Collection<int> collection = new Collection<int>(1, 2, 3);

            // Assert
            Assert.That(collection.Count == 3);
            Assert.That(collection.Capacity >= 3);
        }

        [Test]
        public void Test_Collections_GetByIndex()
        {
            // Arrange & Act
            Collection<int> collection = new Collection<int>(1, 2, 3);

            // Assert
            Assert.That(collection[0] == 1);
            Assert.That(collection[1] == 2);
            Assert.That(collection[2] == 3);
        }

        [Test]
        public void Test_Collections_GetByInvalidIndex()
        {
            // Arrange
            Collection<int> collection = new Collection<int>(1, 2, 3);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { int item = collection[3]; });
        }

        [Test]
        public void Test_Collections_SetByIndex()
        {
            // Arrange
            Collection<int> collection = new Collection<int>(1, 2, 3);

            // Act
            collection[1] = 100;

            // Assert
            Assert.That(collection[1] == 100);
        }

        [Test]
        public void Test_Collections_SetByInvalidIndex()
        {
            // Arrange
            Collection<int> collection = new Collection<int>(1, 2, 3);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => collection[3] = 100);
        }

        [Test]
        public void Test_Collections_InsertAtStart()
        {
            // Arrange
            Collection<int> collection = new Collection<int>(2, 3);

            // Act
            collection.InsertAt(0, 1);

            // Assert
            Assert.That(collection[0] == 1);
            Assert.That(collection.Count == 3);
        }

        [Test]
        public void Test_Collections_InsertAtMiddle()
        {
            // Arrange
            Collection<int> collection = new Collection<int>(1, 3);

            // Act
            collection.InsertAt(1, 2);

            // Assert
            Assert.That(collection[1] == 2);
            Assert.That(collection.Count == 3);
        }

        [Test]
        public void Test_Collections_InsertAtEnd()
        {
            // Arrange
            Collection<int> collection = new Collection<int>(1, 2);

            // Act
            collection.InsertAt(2, 3);

            // Assert
            Assert.That(collection[2] == 3);
            Assert.That(collection.Count == 3);
        }

        [Test]
        public void Test_Collections_InsertAtInvalidIndex()
        {
            // Arrange
            Collection<int> collection = new Collection<int>(1, 2, 3);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => collection.InsertAt(4, 100));
        }

        [Test]
        public void Test_Collections_InsertAtWithGrow()
        {
            // Arrange
            Collection<int> collection = new Collection<int>();
            int initialCapacity = collection.Capacity;

            // Act
            for (int i = 0; i < 20; i++)
            {
                collection.InsertAt(i, i);
            }

            // Assert
            Assert.That(collection.Count == 20);
            Assert.That(collection.Capacity == 2 * initialCapacity);
        }

        [Test]
        public void Test_Collections_RemoveAtStart()
        {
            // Arrange
            Collection<int> collection = new Collection<int>(1, 2, 3);

            // Act
            int removedItem = collection.RemoveAt(0);

            // Assert
            Assert.That(removedItem == 1);
            Assert.That(collection.Count == 2);
            Assert.That(collection[0] == 2);
            Assert.That(collection[1] == 3);
        }

        [Test]
        public void Test_Collections_RemoveAtMiddle()
        {
            // Arrange
            Collection<int> collection = new Collection<int>(1, 2, 3);

            // Act
            int removedItem = collection.RemoveAt(1);

            // Assert
            Assert.That(removedItem == 2);
            Assert.That(collection.Count == 2);
            Assert.That(collection[0] == 1);
            Assert.That(collection[1] == 3);
        }

        [Test]
        public void Test_Collections_RemoveAtEnd()
        {
            // Arrange
            Collection<int> collection = new Collection<int>(1, 2, 3);

            // Act
            int removedItem = collection.RemoveAt(2);

            // Assert
            Assert.That(removedItem == 3);
            Assert.That(collection.Count == 2);
            Assert.That(collection[0] == 1);
            Assert.That(collection[1] == 2);
        }

        [Test]
        public void Test_Collections_RemoveAtInvalidIndex()
        {
            // Arrange
            Collection<int> collection = new Collection<int>(1, 2, 3);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => collection.RemoveAt(3));
        }

        [Test]
        public void Test_Collections_RemoveAll()
        {
            // Arrange
            Collection<int> collection = new Collection<int>(1, 2, 3);

            // Act
            while (collection.Count > 0)
            {
                collection.RemoveAt(0);
            }

            // Assert
            Assert.That(collection.Count == 0);
        }

        [Test]
        public void Test_Collections_ExchangeMiddle()
        {
            // Arrange
            Collection<int> collection = new Collection<int>(1, 2, 3, 4, 5);

            // Act
            collection.Exchange(2, 3);

            // Assert
            Assert.That(collection[0] == 1);
            Assert.That(collection[1] == 2);
            Assert.That(collection[2] == 4);
            Assert.That(collection[3] == 3);
            Assert.That(collection[4] == 5);
        }

        [Test]
        public void Test_Collections_ExchangeFirstLast()
        {
            // Arrange
            Collection<int> collection = new Collection<int>(1, 2, 3, 4, 5);

            // Act
            collection.Exchange(0, 4);

            // Assert
            Assert.That(collection[0] == 5);
            Assert.That(collection[1] == 2);
            Assert.That(collection[2] == 3);
            Assert.That(collection[3] == 4);
            Assert.That(collection[4] == 1);
        }

        [Test]
        public void Test_Collections_ExchangeInvalidIndexes()
        {
            // Arrange
            Collection<int> collection = new Collection<int>(1, 2, 3);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => collection.Exchange(0, 3));
        }

        [Test]
        public void Test_Collections_ToStringEmpty()
        {
            // Arrange
            Collection<int> collection = new Collection<int>();

            // Act & Assert
            Assert.That(collection.ToString() == "[]");
        }

        [Test]
        public void Test_Collections_ToStringSingle()
        {
            // Arrange
            Collection<int> collection = new Collection<int>(100);

            // Act & Assert
            Assert.That(collection.ToString() == "[100]");
        }

        [Test]
        public void Test_Collections_ToStringMultiple()
        {
            // Arrange
            Collection<int> collection = new Collection<int>(1, 2, 3);

            // Act & Assert
            Assert.That(collection.ToString() == "[1, 2, 3]");
        }

        [Test]
        public void Test_Collections_ToStringCollectionOfCollections()
        {
            // Arrange
            Collection<int> innerCollection = new Collection<int>(1, 2);
            Collection<Collection<int>> outerCollection = new Collection<Collection<int>>(innerCollection);

            // Act & Assert
            Assert.That(outerCollection.ToString() == "[[1, 2]]");
        }

        [Test]
        public void Test_Collections_1MillionItems()
        {
            // Arrange
            Collection<int> collection = new Collection<int>();
            const int itemsCount = 1_000_000;

            // Act
            for (int i = 0; i < itemsCount; i++)
            {
                collection.Add(i);
            }

            // Assert
            Assert.That(collection.Count == itemsCount);
            Assert.That(collection[itemsCount - 1] == itemsCount - 1);
        }
    }
}