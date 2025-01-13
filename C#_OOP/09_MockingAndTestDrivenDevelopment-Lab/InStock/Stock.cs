using System.Collections;

namespace InStock
{
    public class Stock : IEnumerable<Product>
    {
        private readonly List<Product> _products = new();

        public int Count => _products.Count;

        public void Add(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            _products.Add(product);
        }

        public bool Contains(Product product)
        {
            return _products.Any(p => p.Label == product.Label);
        }

        public Product Find(int index)
        {
            if (index < 0 || index >= _products.Count)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }
            return _products[index];
        }

        public Product FindByLabel(string label)
        {
            Product product = _products.FirstOrDefault(p => p.Label == label);
            if (product == null)
            {
                throw new ArgumentException($"No product with label '{label}' found.");
            }
            return product;
        }

        public IEnumerable<Product> FindAllInPriceRange(decimal lower, decimal upper)
        {
            return _products
                .Where(p => p.Price >= lower && p.Price <= upper)
                .OrderByDescending(p => p.Price)
                .ToList();
        }

        public IEnumerable<Product> FindAllByPrice(decimal price)
        {
            return _products
                .Where(p => p.Price == price)
                .ToList();
        }

        public IEnumerable<Product> FindMostExpensiveProducts(int count)
        {
            return _products
                .OrderByDescending(p => p.Price)
                .Take(count)
                .ToList();
        }

        public IEnumerable<Product> FindAllByQuantity(int quantity)
        {
            return _products
                .Where(p => p.Quantity == quantity)
                .ToList();
        }

        public IEnumerator<Product> GetEnumerator()
        {
            return _products.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Product this[int index]
        {
            get => Find(index);
            set
            {
                if (index < 0 || index >= _products.Count)
                {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }
                _products[index] = value;
            }
        }
    }
}