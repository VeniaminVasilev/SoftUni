using CarDealership.Models.Contracts;
using CarDealership.Utilities.Messages;

namespace CarDealership.Models
{
    public abstract class Customer : ICustomer
    {
        private string _name;
        private List<string> _purchases;

        public Customer(string name)
        {
            Name = name;
            Purchases = new List<string>();
        }

        public string Name
        {
            get { return _name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameIsRequired);
                }
                _name = value;
            }
        }

        public IReadOnlyCollection<string> Purchases
        {
            get { return _purchases.AsReadOnly(); }
            private set { _purchases = (List<string>)value; }
        }

        public void BuyVehicle(string vehicleModel)
        {
            this._purchases.Add(vehicleModel);
        }

        public override string ToString()
        {
            return $"{Name} - Purchases: {this._purchases.Count}";
        }
    }
}