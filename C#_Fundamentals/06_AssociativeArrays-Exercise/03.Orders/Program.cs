namespace _03.Orders
{
    public class Product
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Product(decimal price, int quantity)
        {
            this.Price = price;
            this.Quantity = quantity;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "buy") { break; }

                string[] tokens = command.Split(" ");
                string name = tokens[0];
                decimal price = decimal.Parse(tokens[1]);
                int quantity = int.Parse(tokens[2]);

                if (!products.ContainsKey(name))
                {
                    products[name] = new Product(price, quantity);
                }
                else
                {
                    products[name].Price = price;
                    products[name].Quantity += quantity;
                }
            }

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Key} -> {product.Value.Price * product.Value.Quantity:F2}");
            }
        }
    }
}