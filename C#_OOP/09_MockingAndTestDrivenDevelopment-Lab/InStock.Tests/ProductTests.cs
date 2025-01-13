namespace INStock.Tests
{
    using InStock;
    using NUnit.Framework;

    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void Constructor_ValidParameters_ShouldInitializeCorrectly()
        {
            // Arrange
            string label = "Door";
            decimal price = 100;
            int quantity = 10;

            // Act
            Product product = new Product(label, price, quantity);

            // Assert
            Assert.That(product.Label, Is.EqualTo(label));
            Assert.That(product.Price, Is.EqualTo(price));
            Assert.That(product.Quantity, Is.EqualTo(quantity));
        }

        [Test]
        public void Equals_SameLabel_ShouldReturnTrue()
        {
            // Arrange
            Product product1 = new Product("Name", 10, 10);
            Product product2 = new Product("Name", 20, 20);

            // Act
            bool areEqual = product1.Equals(product2);

            // Assert
            Assert.IsTrue(areEqual);
        }

        [Test]
        public void Equals_DifferentLabel_ShouldReturnFalse()
        {
            // Arrange
            Product product1 = new Product("Name", 10, 10);
            Product product2 = new Product("Different", 20, 20);

            // Act
            bool areEqual = product1.Equals(product2);

            // Assert
            Assert.IsFalse(areEqual);
        }

        [Test]
        public void Equals_NullObject_ShouldReturnFalse()
        {
            // Arrange
            Product table = new Product("Table", 100, 10);

            // Act
            bool areEqual = table.Equals(null);

            // Assert
            Assert.IsFalse(areEqual);
        }

        [Test]
        public void Equals_DifferentType_ShouldReturnFalse()
        {
            // Arrange
            Product table = new Product("Table", 100, 10);
            string differentObject = "Not a product";

            // Act
            bool areEqual = table.Equals(differentObject);

            // Assert
            Assert.IsFalse(areEqual);
        }

        [Test]
        public void GetHashCode_SameLabel_ShouldReturnSameHashCode()
        {
            // Arrange
            Product product1 = new Product("Product", 10, 10);
            Product product2 = new Product("Product", 20, 20);

            // Act
            int hashCode1 = product1.GetHashCode();
            int hashCode2 = product2.GetHashCode();

            // Assert
            Assert.That(hashCode1 == hashCode2);
        }

        [Test]
        public void GetHashCode_DifferentLabel_ShouldReturnDifferentHashCode()
        {
            Product product1 = new Product("Product1", 10, 10);
            Product product2 = new Product("Product2", 10, 10);

            // Act
            int hashCode1 = product1.GetHashCode();
            int hashCode2 = product2.GetHashCode();

            // Assert
            Assert.That(hashCode1 != hashCode2);
        }
    }
}