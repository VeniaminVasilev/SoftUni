namespace GroceriesManagement
{
    public class GroceriesStore
    {
        private int _capacity;
        private double _turnover;
        private List<Product> _stall;

        public int Capacity { get { return _capacity; } }
        public double Turnover { get { return _turnover; } }
        public List<Product> Stall { get { return _stall; } }

        public GroceriesStore(int capacity)
        { 
            _capacity = capacity;
            _turnover = 0;
            _stall = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            if (_capacity > _stall.Count && !_stall.Any(p => p.Name == product.Name))
            {
                _stall.Add(product);
            }
        }

        public bool RemoveProduct(string name)
        {
            if (_stall.Any(p => p.Name == name))
            {
                Product productToBeRemoved = _stall.Find(p => p.Name == name);
                _stall.Remove(productToBeRemoved);
                return true;
            }
            else
            {
                return false;
            }
        }

        public string SellProduct(string name, double quantity)
        {
            if (!_stall.Any(p => p.Name == name))
            {
                return "Product not found";
            }
            else
            {
                Product productForSale = _stall.Find(p => p.Name == name);
                double totalPrice = Math.Round((quantity * productForSale.Price), 2);
                _turnover += totalPrice;
                return $"{name} - {totalPrice:F2}$";
            }
        }

        public string GetMostExpensive()
        {
            Product mostExpensive = _stall.OrderByDescending(p => p.Price).FirstOrDefault();

            return mostExpensive.ToString();
        }

        public string CashReport()
        {
            return $"Total Turnover: {_turnover:f2}$";
        }

        public string PriceList()
        {
            string priceList = $"Groceries Price List:";

            for (int i = 0; i < _stall.Count; i++)
            {
                priceList += $"\n{_stall[i].ToString()}";
            }

            return priceList;
        }
    }
}