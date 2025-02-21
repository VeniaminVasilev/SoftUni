using CarDealership.Models.Contracts;
using CarDealership.Utilities.Messages;

namespace CarDealership.Models
{
    public abstract class Vehicle : IVehicle
    {
        private string _model;
        private double _price;
        private List<string> _buyers;

        public Vehicle(string model, double price)
        {
            Model = model;
            Price = price;
            Buyers = new List<string>();
        }

        public string Model
        {
            get { return _model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelIsRequired);
                }
                _model = value;
            }
        }

        public double Price
        {
            get { return _price; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.PriceMustBePositive);
                }
                _price = value;
            }
        }

        public IReadOnlyCollection<string> Buyers
        {
            get { return _buyers.AsReadOnly(); }
            private set { _buyers = (List<string>)value; }
        }

        public int SalesCount 
        {
            get { return _buyers.Count; }
        }

        public void SellVehicle(string buyerName)
        {
            _buyers.Add(buyerName);
        }

        public override string ToString()
        {
            return $"{Model} - Price: {Price:F2}, Total Model Sales: {SalesCount}";
        }
    }
}