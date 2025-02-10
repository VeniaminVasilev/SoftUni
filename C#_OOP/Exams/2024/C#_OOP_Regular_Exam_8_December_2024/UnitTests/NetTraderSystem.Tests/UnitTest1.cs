using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace NetTraderSystem.Tests
{
    public class Tests
    {
        [Test]
        public void Constructor_ShouldInitializeCorrectly()
        {
            // Act
            TradingPlatform tradingPlatform = new TradingPlatform(100);

            // Assert
            Assert.NotNull(tradingPlatform.Products);
            Assert.IsEmpty(tradingPlatform.Products);
        }

        [Test]
        public void AddProduct_ShouldAddProductSuccessfully_WhenLimitIsNotReached()
        {
            // Arrange
            TradingPlatform tradingPlatform = new TradingPlatform(100);
            Product product = new Product("Name", "Category", 10);

            // Act
            string result = tradingPlatform.AddProduct(product);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(tradingPlatform.Products.Contains(product), Is.True);
                Assert.That(tradingPlatform.Products.Count, Is.EqualTo(1));
                Assert.That(result, Is.EqualTo($"Product {product.Name} added successfully"));
            });
        }

        [Test]
        public void AddProduct_ShouldNotAddProduct_WhenLimitIsReached()
        {
            // Arrange
            TradingPlatform tradingPlatform = new TradingPlatform(1);
            Product product = new Product("Name", "Category", 10);
            Product product2 = new Product("Name2", "Category2", 10);
            tradingPlatform.AddProduct(product);

            // Act
            string result = tradingPlatform.AddProduct(product2);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo("Inventory is full"));
                Assert.That(tradingPlatform.Products.Count, Is.EqualTo(1));
            });
        }

        [Test]
        public void RemoveProduct_ShouldReturnTrue_WhenRemoveIsSuccessful()
        {
            // Arrange
            TradingPlatform tradingPlatform = new TradingPlatform(1);
            Product product = new Product("Name", "Category", 10);
            tradingPlatform.AddProduct(product);

            // Act
            bool removed = tradingPlatform.RemoveProduct(product);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(removed, Is.True);
                Assert.That(tradingPlatform.Products.Count, Is.EqualTo(0));
                Assert.That(tradingPlatform.Products.Contains(product), Is.False);
            });
        }

        [Test]
        public void RemoveProduct_ShouldReturnFalse_WhenRemoveIsNotSuccessful()
        {
            // Arrange
            TradingPlatform tradingPlatform = new TradingPlatform(1);
            Product product = new Product("Name", "Category", 10);
            tradingPlatform.AddProduct(product);
            Product productForRemoving = new Product("Name2", "Category2", 10);

            // Act
            bool removed = tradingPlatform.RemoveProduct(productForRemoving);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(removed, Is.False);
                Assert.That(tradingPlatform.Products.Count, Is.EqualTo(1));
            });
        }

        [Test]
        public void SellProduct_ShouldBeSuccessful_WhenProductExists()
        {
            // Arrange
            TradingPlatform tradingPlatform = new TradingPlatform(1);
            Product product = new Product("Name", "Category", 10);
            tradingPlatform.AddProduct(product);

            // Act
            Product soldProduct = tradingPlatform.SellProduct(product);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(soldProduct, Is.Not.Null);
                Assert.That(soldProduct, Is.EqualTo(product));
                Assert.That(tradingPlatform.Products.Count(), Is.EqualTo(0));
            });
        }

        [Test]
        public void SellProduct_ShouldNotBeSuccessful_WhenProductDoesNotExist()
        {
            // Arrange
            TradingPlatform tradingPlatform = new TradingPlatform(1);
            Product product = new Product("Name", "Category", 10);

            // Act
            Product soldProduct = tradingPlatform.SellProduct(product);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(soldProduct, Is.Null);
                Assert.That(tradingPlatform.Products.Count(), Is.EqualTo(0));
            });
        }

        [Test]
        public void InventoryReport_ReturnsCorrectString()
        {
            // Arrange
            TradingPlatform tradingPlatform = new TradingPlatform(1);
            Product product = new Product("Name", "Category", 10);
            tradingPlatform.AddProduct(product);

            StringBuilder expectedResult = new StringBuilder();
            expectedResult.AppendLine("Inventory Report:");
            expectedResult.AppendLine($"Available Products: 1");
            expectedResult.AppendLine(product.ToString());

            // Act
            string result = tradingPlatform.InventoryReport();

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult.ToString().TrimEnd()));
        }
    }
}