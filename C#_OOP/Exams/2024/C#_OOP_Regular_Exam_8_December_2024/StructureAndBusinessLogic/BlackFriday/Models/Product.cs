using BlackFriday.Models.Contracts;
using BlackFriday.Utilities.Messages;

namespace BlackFriday.Models
{
    public abstract class Product : IProduct
    {
        private string _productName;
        private double _basePrice;
        private bool _isSold;

        protected Product(string productName, double basePrice)
        {
            this.ProductName = productName;
            this.BasePrice = basePrice;
            this.IsSold = false;
        }

        public string ProductName
        { 
            get { return _productName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ProductNameRequired);
                }
                _productName = value;
            }
        }

        public double BasePrice
        {
            get { return _basePrice; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.ProductPriceConstraints);
                }
                _basePrice = value;
            }
        }

        public virtual double BlackFridayPrice { get; }

        public bool IsSold { get { return _isSold; } private set { _isSold = value; } }

        public void ToggleStatus()
        {
            if (IsSold == true)
            {
                IsSold = false;
            }
            else
            {
                IsSold = true;
            }
        }

        public void UpdatePrice(double newPriceValue)
        {
            this.BasePrice = newPriceValue;
        }

        public override string ToString()
        {
            return $"Product: {ProductName}, Price: {BasePrice:F2}, You Save: {(BasePrice-BlackFridayPrice):F2}";
        }
    }
}