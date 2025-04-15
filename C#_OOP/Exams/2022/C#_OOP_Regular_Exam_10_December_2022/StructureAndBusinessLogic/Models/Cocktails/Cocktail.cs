using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Drawing;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {
        private string _name;
        private string _size;
        private double _price;

        public Cocktail(string cocktailName, string size, double price)
        {
            this.Name = cocktailName;
            this.Size = size;
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
                _name = value;
            }
        }

        public string Size
        {
            get { return _size; }
            private set { _size = value; }
        }

        public double Price
        {
            get { return _price; }
            private set 
            { 
                if (this.Size == "Large")
                {
                    _price = value;
                }
                else if (this.Size == "Middle")
                {
                    _price = (value / 3) * 2;
                }
                else if (this.Size == "Small")
                {
                    _price = value / 3;
                }
            }
        }

        public override string ToString()
        {
            return $"{this.Name} ({this.Size}) - {this.Price:F2} lv";
        }
    }
}