using NUnit.Framework;
using System.Diagnostics.Metrics;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VendingRetail.Tests
{
    public class Tests
    {
        [Test]
        public void Constructor_InitializesCorrectly()
        {
            // Arrange
            int waterCapacity = 100;
            int buttonsCount = 10;

            // Act
            CoffeeMat coffeeMat = new CoffeeMat(waterCapacity, buttonsCount);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(coffeeMat.WaterCapacity, Is.EqualTo(waterCapacity));
                Assert.That(coffeeMat.ButtonsCount, Is.EqualTo(buttonsCount));
                Assert.That(coffeeMat.Income, Is.EqualTo(0));
            });
        }

        [Test]
        public void Constructor_InitializesCorrectly_WhenNegativeNumbers()
        {
            // Arrange
            int waterCapacity = -100;
            int buttonsCount = -10;

            // Act
            CoffeeMat coffeeMat = new CoffeeMat(waterCapacity, buttonsCount);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(coffeeMat.WaterCapacity, Is.EqualTo(waterCapacity));
                Assert.That(coffeeMat.ButtonsCount, Is.EqualTo(buttonsCount));
                Assert.That(coffeeMat.Income, Is.EqualTo(0));
            });
        }

        [Test]
        public void FillWaterTank_Success()
        {
            // Arrange
            int waterCapacity = 1000;
            int buttonsCount = 10;
            CoffeeMat coffeeMat = new CoffeeMat(waterCapacity, buttonsCount);

            // Act
            string result = coffeeMat.FillWaterTank();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo($"Water tank is filled with {waterCapacity}ml"));
                Assert.That(coffeeMat.WaterCapacity, Is.EqualTo(waterCapacity));
                Assert.That(coffeeMat.ButtonsCount, Is.EqualTo(buttonsCount));
                Assert.That(coffeeMat.Income, Is.EqualTo(0));
            });
        }

        [Test]
        public void FillWaterTank_WhenTankIsAlreadyFull()
        {
            // Arrange
            int waterCapacity = 1000;
            int buttonsCount = 10;
            CoffeeMat coffeeMat = new CoffeeMat(waterCapacity, buttonsCount);
            coffeeMat.FillWaterTank();

            // Act
            string result = coffeeMat.FillWaterTank();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo($"Water tank is already full!"));
                Assert.That(coffeeMat.WaterCapacity, Is.EqualTo(waterCapacity));
                Assert.That(coffeeMat.ButtonsCount, Is.EqualTo(buttonsCount));
                Assert.That(coffeeMat.Income, Is.EqualTo(0));
            });
        }

        [Test]
        public void AddDrink_Success()
        {
            // Arrange
            int waterCapacity = 1000;
            int buttonsCount = 10;
            CoffeeMat coffeeMat = new CoffeeMat(waterCapacity, buttonsCount);
            string drinkName = "Name";
            double drinkPrice = 10.5;

            // Act
            bool result = coffeeMat.AddDrink(drinkName, drinkPrice);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void AddDrink_ReturnsFalse_WhenNotEnoughButtons()
        {
            // Arrange
            int waterCapacity = 1000;
            int buttonsCount = 1;
            CoffeeMat coffeeMat = new CoffeeMat(waterCapacity, buttonsCount);
            string drinkName = "Name";
            string drinkName2 = "Name2";
            double drinkPrice = 10.5;
            coffeeMat.AddDrink(drinkName, drinkPrice);

            // Act
            bool result = coffeeMat.AddDrink(drinkName2, drinkPrice);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void AddDrink_ReturnsFalse_WhenSameName()
        {
            // Arrange
            int waterCapacity = 1000;
            int buttonsCount = 10;
            CoffeeMat coffeeMat = new CoffeeMat(waterCapacity, buttonsCount);
            string drinkName = "Name";
            double drinkPrice = 10.5;
            coffeeMat.AddDrink(drinkName, drinkPrice);

            // Act
            bool result = coffeeMat.AddDrink(drinkName, drinkPrice);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void AddDrink_ReturnsFalse_WhenSameNameAndNotEnoughButtons()
        {
            // Arrange
            int waterCapacity = 1000;
            int buttonsCount = 1;
            CoffeeMat coffeeMat = new CoffeeMat(waterCapacity, buttonsCount);
            string drinkName = "Name";
            double drinkPrice = 10.5;
            coffeeMat.AddDrink(drinkName, drinkPrice);

            // Act
            bool result = coffeeMat.AddDrink(drinkName, drinkPrice);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void BuyDrink_Success()
        {
            // Arrange
            int waterCapacity = 1000;
            int buttonsCount = 10;
            CoffeeMat coffeeMat = new CoffeeMat(waterCapacity, buttonsCount);
            string drinkName = "Name";
            double drinkPrice = 10.5;
            coffeeMat.AddDrink(drinkName, drinkPrice);
            coffeeMat.FillWaterTank();

            // Act
            string result = coffeeMat.BuyDrink(drinkName);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo($"Your bill is {drinkPrice:F2}$"));
                Assert.That(coffeeMat.Income, Is.EqualTo(drinkPrice));
            });
        }

        [Test]
        public void BuyDrink_Success_MoreDrinksBought()
        {
            // Arrange
            int waterCapacity = 1000;
            int buttonsCount = 10;
            CoffeeMat coffeeMat = new CoffeeMat(waterCapacity, buttonsCount);
            string drinkName = "Name";
            double drinkPrice = 10.5;
            coffeeMat.AddDrink(drinkName, drinkPrice);
            coffeeMat.FillWaterTank();

            // Act
            int times = 10;
            for (int i = 0; i < times; i++)
            {
                coffeeMat.BuyDrink(drinkName);
            }

            // Assert
            Assert.That(coffeeMat.Income, Is.EqualTo(times * drinkPrice));
        }

        [Test]
        public void BuyDrink_OutOfWater_AfterSale()
        {
            // Arrange
            int waterCapacity = 159;
            int buttonsCount = 10;
            CoffeeMat coffeeMat = new CoffeeMat(waterCapacity, buttonsCount);
            string drinkName = "Name";
            double drinkPrice = 10.5;
            coffeeMat.AddDrink(drinkName, drinkPrice);
            coffeeMat.FillWaterTank();

            // Act
            coffeeMat.BuyDrink(drinkName);
            string result = coffeeMat.BuyDrink(drinkName);

            // Assert
            Assert.That(result, Is.EqualTo("CoffeeMat is out of water!"));
            Assert.That(coffeeMat.Income, Is.EqualTo(drinkPrice));
        }

        [Test]
        public void BuyDrink_WaterForOnlyOneSale()
        {
            // Arrange
            int waterCapacity = 80;
            int buttonsCount = 10;
            CoffeeMat coffeeMat = new CoffeeMat(waterCapacity, buttonsCount);
            string drinkName = "Name";
            double drinkPrice = 10.5;
            coffeeMat.AddDrink(drinkName, drinkPrice);
            coffeeMat.FillWaterTank();

            // Act
            string result = coffeeMat.BuyDrink(drinkName);

            // Assert
            Assert.That(result, Is.EqualTo($"Your bill is {drinkPrice:f2}$"));
            Assert.That(coffeeMat.Income, Is.EqualTo(drinkPrice));
        }

        [Test]
        public void BuyDrink_OutOfWater()
        {
            // Arrange
            int waterCapacity = 1000;
            int buttonsCount = 10;
            CoffeeMat coffeeMat = new CoffeeMat(waterCapacity, buttonsCount);
            string drinkName = "Name";
            double drinkPrice = 10.5;
            coffeeMat.AddDrink(drinkName, drinkPrice);

            // Act
            string result = coffeeMat.BuyDrink(drinkName);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo("CoffeeMat is out of water!"));
                Assert.That(coffeeMat.Income, Is.EqualTo(0));
            });
        }

        [Test]
        public void BuyDrink_NotAvailableDrink()
        {
            // Arrange
            int waterCapacity = 1000;
            int buttonsCount = 10;
            CoffeeMat coffeeMat = new CoffeeMat(waterCapacity, buttonsCount);
            coffeeMat.FillWaterTank();
            string name = "Name";

            // Act
            string result = coffeeMat.BuyDrink(name);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo($"{name} is not available!"));
                Assert.That(coffeeMat.Income, Is.EqualTo(0));
            });
        }

        [Test]
        public void CollectIncome_Success()
        {
            // Arrange
            int waterCapacity = 1000;
            int buttonsCount = 10;
            CoffeeMat coffeeMat = new CoffeeMat(waterCapacity, buttonsCount);
            string drinkName = "Name";
            double drinkPrice = 10.5;
            coffeeMat.AddDrink(drinkName, drinkPrice);
            coffeeMat.FillWaterTank();
            coffeeMat.BuyDrink(drinkName);

            // Act
            double collectedIncome = coffeeMat.CollectIncome();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(collectedIncome, Is.EqualTo(drinkPrice));
                Assert.That(coffeeMat.Income, Is.EqualTo(0));
            });
        }
    }
}