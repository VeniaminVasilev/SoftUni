using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;

namespace ChristmasPastryShop.Models.Delicacies
{
    public abstract class Delicacy : IDelicacy
    {
        private string _name;
        private double _price;

        public Delicacy(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name
        {
            get { return _name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                this._name = value;
            }
        }

        public double Price
        {
            get { return _price; }
            private set { _price = value; }
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Price:F2} lv";
        }
    }
}