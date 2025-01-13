using InStock;

namespace INStock.Tests
{
    using NUnit.Framework;
    using System.Xml.Serialization;

    [TestFixture]
    public class ProductStockTests
    {
        [Test]
        public void Add_ShouldAddProductInStock()
        {
            // Arrange
            Product product = new Product("Table", 100, 10);
            Stock stock = new Stock();

            // Act
            stock.Add(product);

            // Assert
            Assert.That(stock.Count == 1);
        }

        [Test]
        public void Add_ShouldThrowArgumentNullException_WhenProductIsNull()
        {
            // Arrange
            Stock stock = new Stock();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => stock.Add(null));
        }

        [Test]
        public void Contains_ShouldReturnTrue_WhenProductIsPresent()
        {
            // Arrange
            Product product = new Product("Table", 100, 10);
            Stock stock = new Stock();
            stock.Add(product);

            // Act
            bool contains = stock.Contains(product);

            // Assert
            Assert.That(contains, Is.True);
        }

        [Test]
        public void Contains_ShouldReturnFalse_WhenProductIsMissing()
        {
            // Arrange
            Product product = new Product("Table", 100, 10);
            Stock stock = new Stock();

            // Act
            bool contains = stock.Contains(product);

            // Assert
            Assert.That(contains, Is.False);
        }

        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
        public void Count_ShouldReturnTheNumberOfProductsInStock(int countOfProductsToBeAdded)
        {
            // Arrange
            Stock stock = new Stock();
            for (int i = 0; i < countOfProductsToBeAdded; i++)
            {
                Product product = new Product($"{i}", 10, 10);
                stock.Add(product);
            }

            // Act
            int actualCount = stock.Count();

            // Assert
            Assert.That(actualCount, Is.EqualTo(countOfProductsToBeAdded));
        }

        [Test]
        public void Find_ShouldReturnTheProduct_WhenIndexIsValid()
        {
            // Arrange
            Product product = new Product("Table", 100, 10);
            Stock stock = new Stock();
            stock.Add(product);

            // Act
            Product foundProduct = stock.Find(0);

            // Assert
            Assert.That(foundProduct.Label == product.Label);
        }

        [TestCase(-1)]
        [TestCase(1)]
        [TestCase(100)]
        public void Find_ShouldThrowIndexOutOfRangeException_WhenIndexIsNotValid(int index)
        {
            // Arrange
            Product product = new Product("Table", 100, 10);
            Stock stock = new Stock();
            stock.Add(product);

            // Act & Assert
            Assert.Throws<IndexOutOfRangeException>(() => stock.Find(index));
        }

        [Test]
        public void FindByLabel_ShouldReturnTheProduct_WhenLabelIsExisting()
        {
            // Arrange
            Product product = new Product("Table", 100, 10);
            Stock stock = new Stock();
            stock.Add(product);

            // Act
            Product productFound = stock.FindByLabel(product.Label);

            // Assert
            Assert.That(productFound.Label == product.Label);
        }

        [Test]
        public void FindByLabel_ShouldThrowArgumentException_WhenLabelIsNotExisting()
        {
            // Arrange
            Product product = new Product("Table", 100, 10);
            Stock stock = new Stock();
            stock.Add(product);

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Product productFound = stock.FindByLabel("New label");
            });
        }

        [Test]
        public void FindAllInPriceRange_ShouldReturnCorrectCollectionInDescendingOrder_WhenThereAreSuchProducts()
        {
            // Arrange
            Product door = new Product("Door", 200, 10);
            Product table = new Product("Table", 100, 10);
            Product chair = new Product("Chair", 50, 10);
            Product lamp = new Product("Lamp", 10, 10);

            Stock stock = new Stock();
            stock.Add(door);
            stock.Add(table);
            stock.Add(chair);
            stock.Add(lamp);

            // Act
            List<Product> foundProducts = (List<Product>)stock.FindAllInPriceRange(50, 200);

            // Assert
            Assert.That(foundProducts.Count == 3);
            Assert.That(foundProducts[0] == door);
            Assert.That(foundProducts[1] == table);
            Assert.That(foundProducts[2] == chair);
        }

        [Test]
        public void FindAllInPriceRange_ShouldReturnEmptyCollection_WhenThereAreNoSuchProducts()
        {
            // Arrange
            Product door = new Product("Door", 200, 10);
            Product table = new Product("Table", 100, 10);
            Product chair = new Product("Chair", 50, 10);
            Product lamp = new Product("Lamp", 10, 10);

            Stock stock = new Stock();
            stock.Add(door);
            stock.Add(table);
            stock.Add(chair);
            stock.Add(lamp);

            // Act
            List<Product> foundProducts = (List<Product>)stock.FindAllInPriceRange(201, 300);

            // Assert
            Assert.That(foundProducts.Count == 0);
        }

        [Test]
        public void FindAllByPrice_ShouldReturnCorrectCollection_WhenThereAreSuchProducts()
        {
            // Arrange
            Product door = new Product("Door", 200, 10);
            Product table = new Product("Table", 100, 10);
            Product chair = new Product("Chair", 100, 10);
            Product lamp = new Product("Lamp", 10, 10);

            Stock stock = new Stock();
            stock.Add(door);
            stock.Add(table);
            stock.Add(chair);
            stock.Add(lamp);

            // Act
            List<Product> foundProducts = (List<Product>)stock.FindAllByPrice(100);

            // Assert
            Assert.That(foundProducts.Count == 2);
            Assert.Contains(table, foundProducts);
            Assert.Contains(chair, foundProducts);
        }

        [Test]
        public void FindAllByPrice_ShouldReturnEmptyCollection_WhenThereAreNoSuchProducts()
        {
            // Arrange
            Product door = new Product("Door", 200, 10);
            Product table = new Product("Table", 100, 10);
            Product chair = new Product("Chair", 100, 10);
            Product lamp = new Product("Lamp", 10, 10);

            Stock stock = new Stock();
            stock.Add(door);
            stock.Add(table);
            stock.Add(chair);
            stock.Add(lamp);

            // Act
            List<Product> foundProducts = (List<Product>)stock.FindAllByPrice(22);

            // Assert
            Assert.That(foundProducts.Count == 0);
        }

        [TestCase(1)]
        [TestCase(3)]
        [TestCase(10)]
        public void FindMostExpensiveProducts_ShouldReturnMostExpensiveProducts(int count)
        {
            // Arrange
            Stock stock = new Stock();

            Product door = new Product("Door", 200, 10);
            Product table = new Product("Table", 100, 10);
            Product chair = new Product("Chair", 50, 10);
            stock.Add(door);
            stock.Add(table);
            stock.Add(chair);

            for (int i = 0; i < count; i++)
            {
                Product product = new Product($"product {i}", 10, 10);
                stock.Add(product);
            }

            // Act
            List<Product> foundProducts = (List<Product>)stock.FindMostExpensiveProducts(count);

            // Assert
            Assert.That(foundProducts.Count == count);
            Assert.That(foundProducts[0].Label == "Door");
        }

        [Test]
        public void FindMostExpensiveProducts_ShouldReturnEmptyCollection_WhenCountIsZero()
        {
            // Arrange
            Stock stock = new Stock();

            Product door = new Product("Door", 200, 10);
            Product table = new Product("Table", 100, 10);
            Product chair = new Product("Chair", 50, 10);
            stock.Add(door);
            stock.Add(table);
            stock.Add(chair);

            // Act
            List<Product> foundProducts = (List<Product>)stock.FindMostExpensiveProducts(0);

            // Assert
            Assert.That(foundProducts.Count == 0);
        }

        [Test]
        public void FindAllByQuantity_ShouldReturnCorrectCollection_WhenThereAreSuchProducts()
        {
            // Arrange
            Stock stock = new Stock();

            Product door = new Product("Door", 200, 20);
            Product table = new Product("Table", 100, 10);
            Product chair = new Product("Chair", 50, 10);
            stock.Add(door);
            stock.Add(table);
            stock.Add(chair);

            // Act
            List<Product> foundProducts = (List<Product>)stock.FindAllByQuantity(10);

            // Assert
            Assert.That(foundProducts.Count == 2);
            Assert.Contains(table, foundProducts);
            Assert.Contains(chair, foundProducts);
        }

        [Test]
        public void FindAllByQuantity_ShouldReturnEmptyCollection_WhenThereAreNoSuchProducts()
        {
            // Arrange
            Stock stock = new Stock();

            Product door = new Product("Door", 200, 20);
            Product table = new Product("Table", 100, 10);
            Product chair = new Product("Chair", 50, 10);
            stock.Add(door);
            stock.Add(table);
            stock.Add(chair);

            // Act
            List<Product> foundProducts = (List<Product>)stock.FindAllByQuantity(30);

            // Assert
            Assert.That(foundProducts.Count == 0);
        }

        [Test]
        public void FindAllByQuantity_ShouldReturnCorrectCollection_WhenQuantityIsZero()
        {
            // Arrange
            Stock stock = new Stock();

            Product door = new Product("Door", 200, 20);
            Product table = new Product("Table", 100, 0);
            Product chair = new Product("Chair", 50, 0);
            stock.Add(door);
            stock.Add(table);
            stock.Add(chair);

            // Act
            List<Product> foundProducts = (List<Product>)stock.FindAllByQuantity(0);

            // Assert
            Assert.That(foundProducts.Count == 2);
            Assert.Contains(table, foundProducts);
            Assert.Contains(chair, foundProducts);
        }

        [Test]
        public void GetEnumerator_ShouldIterateOverAllProducts()
        {
            // Arrange
            Stock stock = new Stock();

            Product door = new Product("Door", 200, 20);
            Product table = new Product("Table", 100, 10);
            Product chair = new Product("Chair", 50, 10);
            stock.Add(door);
            stock.Add(table);
            stock.Add(chair);

            // Act
            List<Product> enumeratedProducts = stock.ToList();

            // Assert
            Assert.That(enumeratedProducts.Count == 3);
            Assert.Contains(door, enumeratedProducts);
            Assert.Contains(table, enumeratedProducts);
            Assert.Contains(chair, enumeratedProducts);

            Assert.That(enumeratedProducts[0] == door);
            Assert.That(enumeratedProducts[1] == table);
            Assert.That(enumeratedProducts[2] == chair);
        }

        [Test]
        public void GetEnumerator_EmptyStock_ShouldReturnEmptyEnumeration()
        {
            // Arrange
            Stock stock = new Stock();

            // Act
            List<Product> enumeratedProducts = stock.ToList();

            // Assert
            Assert.IsEmpty(enumeratedProducts);
        }

        [Test]
        public void Indexer_Get_ValidIndex_ReturnsCorrectProduct()
        {
            // Arrange
            Stock stock = new Stock();
            Product door = new Product("Door", 200, 20);
            Product table = new Product("Table", 100, 10);
            Product chair = new Product("Chair", 50, 10);
            stock.Add(door);
            stock.Add(table);
            stock.Add(chair);

            // Act
            Product result = stock[0];

            // Assert
            Assert.That(door == result);
        }

        [Test]
        public void Indexer_Get_InvalidIndex_ThrowsIndexOutOfRangeException()
        {
            // Arrange
            Stock stock = new Stock();
            Product door = new Product("Door", 200, 20);
            Product table = new Product("Table", 100, 10);
            Product chair = new Product("Chair", 50, 10);
            stock.Add(door);
            stock.Add(table);
            stock.Add(chair);

            // Act & Assert
            Assert.Throws<IndexOutOfRangeException>(() => { Product result = stock[-1]; });
            Assert.Throws<IndexOutOfRangeException>(() => { Product result = stock[3]; });
        }

        [Test]
        public void Indexer_Set_ValidIndex_UpdatesProduct()
        {
            // Arrange
            Stock stock = new Stock();
            Product door = new Product("Door", 200, 20);
            stock.Add(door);

            Product laptop = new Product("Laptop", 500, 5);

            // Act
            stock[0] = laptop;

            // Assert
            Assert.That(stock[0] == laptop);
        }

        [Test]
        public void Indexer_Set_InvalidIndex_ThrowsIndexOutOfRangeException()
        {
            // Arrange
            Stock stock = new Stock();
            Product door = new Product("Door", 200, 20);
            stock.Add(door);

            Product laptop = new Product("Laptop", 500, 5);

            // Act & Assert
            Assert.Throws<IndexOutOfRangeException>(() => { stock[-1] = laptop; });
            Assert.Throws<IndexOutOfRangeException>(() => { stock[1] = laptop; });
        }

        [Test]
        public void Indexer_Set_NullProduct_UpdatesCorrectly()
        {
            // Arrange
            Stock stock = new Stock();
            Product door = new Product("Door", 200, 20);
            stock.Add(door);

            // Act
            stock[0] = null;

            // Assert
            Assert.IsNull(stock[0]);
        }
    }
}