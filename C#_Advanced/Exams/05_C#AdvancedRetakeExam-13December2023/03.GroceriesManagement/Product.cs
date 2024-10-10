namespace GroceriesManagement
{
    public class Product
    {
        private string _name;
        private double _price;

        public string Name { get { return _name; } }
        public double Price { get { return _price; } }

        public Product(string name, double price)
        {
            _name = name;
            _price = price;
        }

        public override string ToString()
        {
            return $"{_name}: {_price:F2}$";
        }
    }
}