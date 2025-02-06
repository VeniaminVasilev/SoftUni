namespace _03.ShoppingSpree
{
    public class Person
    {
        private string _name;
        private int _money;
        private List<Product> _bagOfProducts;

        public Person(string name, int money)
        {
            this.Name = name;
            this.Money = money;
            _bagOfProducts = new List<Product>();
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                _name = value;
            }
        }

        public int Money
        {
            get => _money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                _money = value;
            }
        }

        public List<Product> BagOfProducts
        { 
            get => _bagOfProducts;
        }

        public bool BuyProduct(Product product)
        {
            if (product.Cost <= _money)
            {
                _bagOfProducts.Add(product);
                _money -= product.Cost;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}