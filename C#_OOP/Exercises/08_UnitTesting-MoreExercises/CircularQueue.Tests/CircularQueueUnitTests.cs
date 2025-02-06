using Collections;

namespace CircularQueue.Tests
{
    public class Tests
    {
        [Test]
        public void Test_CircularQueue_ConstructorDefault()
        {
            // Act
            CircularQueue<int> queue = new CircularQueue<int>();

            // Assert
            Assert.That(queue.ToString() == "[]");
            Assert.That(queue.Count == 0);
            Assert.That(queue.Capacity > 0);
            Assert.That(queue.StartIndex == 0);
            Assert.That(queue.EndIndex == 0);
        }

        [Test]
        public void Test_CircularQueue_ConstructorWithCapacity()
        {
            // Act
            CircularQueue<int> queue = new CircularQueue<int>(16);

            // Assert
            Assert.That(queue.ToString() == "[]");
            Assert.That(queue.Count == 0);
            Assert.That(queue.Capacity == 16);
            Assert.That(queue.StartIndex == 0);
            Assert.That(queue.EndIndex == 0);
        }

        [Test]
        public void Test_CircularQueue_Enqueue()
        {
            // Arrange
            CircularQueue<int> queue = new CircularQueue<int>();

            // Act
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);

            // Assert
            Assert.That(queue.ToString() == "[10, 20, 30]");
            Assert.That(queue.Count == 3);
            Assert.That(queue.Capacity == 8);
        }

        [Test]
        public void Test_CircularQueue_EnqueueWithGrow()
        {
            // Arrange
            CircularQueue<int> queue = new CircularQueue<int>();

            // Act
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            queue.Enqueue(40);
            queue.Enqueue(50);
            queue.Enqueue(60);
            queue.Enqueue(70);
            queue.Enqueue(80);
            queue.Enqueue(90);

            // Assert
            Assert.That(queue.ToString() == "[10, 20, 30, 40, 50, 60, 70, 80, 90]");
            Assert.That(queue.Count == 9);
            Assert.That(queue.Capacity == 16);
        }

        [Test]
        public void Test_CircularQueue_Dequeue()
        {
            // Arrange
            CircularQueue<int> queue = new CircularQueue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);

            // Act
            queue.Dequeue();

            // Assert
            Assert.That(queue.ToString() == "[20]");
            Assert.That(queue.Count == 1);
            Assert.That(queue.Capacity == 8);
        }

        [Test]
        public void Test_CircularQueue_DequeueEmpty()
        {
            // Arrange
            CircularQueue<int> queue = new CircularQueue<int>();

            // Act & Assert
            Exception exception = Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
            Assert.That("The queue is empty!" == exception.Message);
        }

        [Test]
        public void Test_CircularQueue_EnqueueDequeue_WithRangeCross()
        {
            // Arrange
            CircularQueue<int> queue = new CircularQueue<int>(4);

            // Act
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            queue.Enqueue(40);

            // Dequeue two elements to make space and cause range crossing
            Assert.That(queue.Dequeue(), Is.EqualTo(10));
            Assert.That(queue.Dequeue(), Is.EqualTo(20));

            // Enqueue more elements to wrap around the internal array
            queue.Enqueue(50);
            queue.Enqueue(60);

            // Assert
            int[] expectedArray = new int[] { 30, 40, 50, 60 };
            Assert.That(queue.ToArray(), Is.EqualTo(expectedArray));
            Assert.That(queue.Count == 4);
            Assert.That(queue.Capacity == 4);
            Assert.That(queue.StartIndex == queue.EndIndex);

            Assert.That(queue.Dequeue(), Is.EqualTo(30));
            Assert.That(queue.Dequeue(), Is.EqualTo(40));
            Assert.That(queue.Dequeue(), Is.EqualTo(50));
            Assert.That(queue.Dequeue(), Is.EqualTo(60));

            Assert.That(queue.Count, Is.EqualTo(0));
        }

        [Test]
        public void Test_CircularQueue_Peek()
        {
            // Arrange
            CircularQueue<int> queue = new CircularQueue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);

            // Act & Assert
            Assert.That(queue.Peek(), Is.EqualTo(10));

            queue.Dequeue();
            Assert.That(queue.Peek(), Is.EqualTo(20));
        }

        [Test]
        public void Test_CircularQueue_PeekEmpty()
        {
            // Arrange
            CircularQueue<int> queue = new CircularQueue<int>();

            // Act & Assert
            Exception exception = Assert.Throws<InvalidOperationException>(() => queue.Peek());
            Assert.That(exception.Message, Is.EqualTo("The queue is empty!"));
        }

        [Test]
        public void Test_CircularQueue_ToArray()
        {
            // Arrange
            CircularQueue<int> queue = new CircularQueue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);

            // Act 
            int[] array = queue.ToArray();

            // Assert
            CollectionAssert.AreEqual(new int[] { 10, 20, 30 }, array);
        }

        [Test]
        public void Test_CircularQueue_ToArray_WithRangeCross()
        {
            // Arrange
            CircularQueue<int> queue = new CircularQueue<int>(4);
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            queue.Enqueue(40);

            // Dequeue two elements to make space and cause range crossing
            Assert.That(queue.Dequeue(), Is.EqualTo(10));
            Assert.That(queue.Dequeue(), Is.EqualTo(20));

            // Enqueue more elements to wrap around the internal array
            queue.Enqueue(50);
            queue.Enqueue(60);

            // Act
            int[] array = queue.ToArray();

            // Assert
            CollectionAssert.AreEqual(new int[] { 30, 40, 50, 60 }, array);
        }

        [Test]
        public void Test_CircularQueue_ToString()
        {
            // Arrange
            CircularQueue<int> queue = new CircularQueue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);

            // Act 
            string queueToString = queue.ToString();

            // Assert
            Assert.That(queueToString, Is.EqualTo("[10, 20, 30]"));
        }

        [Test]
        public void Test_CircularQueue_MultipleOperations()
        {
            const int initialCapacity = 2;
            const int iterationsCount = 300;

            CircularQueue<int> queue = new CircularQueue<int>(initialCapacity);

            int addedCount = 0;
            int removedCount = 0;
            int counter = 0;

            for (int i = 0; i < iterationsCount; i++)
            {
                Assert.That(queue.Count == addedCount - removedCount);

                queue.Enqueue(++counter);
                addedCount++;
                Assert.That(queue.Count == addedCount - removedCount);

                queue.Enqueue(++counter);
                addedCount++;
                Assert.That(queue.Count == addedCount - removedCount);

                int firstElement = queue.Peek();
                Assert.That(firstElement == removedCount + 1);

                int removedElement = queue.Dequeue();
                removedCount++;
                Assert.That(removedElement == removedCount);
                Assert.That(queue.Count == addedCount - removedCount);

                int[] expectedElements = Enumerable.Range(removedCount + 1, addedCount - removedCount).ToArray();
                string expectedString = "[" + string.Join(", ", expectedElements) + "]";

                int[] queueAsArray = queue.ToArray();
                string queueAsString = queue.ToString();

                CollectionAssert.AreEqual(expectedElements, queueAsArray);
                Assert.AreEqual(expectedString, queueAsString);

                Assert.That(queue.Capacity >= queue.Count);
            }

            Assert.That(queue.Capacity > initialCapacity);
        }

        [Test]
        [Timeout(500)]
        public void Test_CircularQueue_1MillionItems()
        {
            // Arrange
            const int iterationsCount = 1000000;
            CircularQueue<int> queue = new CircularQueue<int>();
            int addedCount = 0;
            int removedCount = 0;
            int counter = 0;

            // Act
            for (int i = 0; i < iterationsCount / 2; i++)
            {
                queue.Enqueue(++counter);
                addedCount++;

                queue.Enqueue(++counter);
                addedCount++;

                queue.Dequeue();
                removedCount++;
            }

            // Assert
            Assert.That(queue.Count == addedCount - removedCount);
        }
    }
}