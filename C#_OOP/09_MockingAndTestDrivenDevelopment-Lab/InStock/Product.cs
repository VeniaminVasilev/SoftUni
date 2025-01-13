namespace InStock
{
    public class Product
    {
        public string Label { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Product(string label, decimal price, int quantity)
        {
            this.Label = label;
            this.Price = price;
            this.Quantity = quantity;
        }

        public override bool Equals(object obj)
        {
            if (obj is Product other)
            {
                return Label.Equals(other.Label, StringComparison.Ordinal);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Label.GetHashCode();
        }
    }
}