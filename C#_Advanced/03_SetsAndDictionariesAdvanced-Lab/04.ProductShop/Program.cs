namespace _04.ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shops = new SortedDictionary<string, Dictionary<string, double>>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Revision") { break; }

                string[] tokens = command.Split(", ").ToArray();
                string shopName = tokens[0];
                string product = tokens[1];
                double price = double.Parse(tokens[2]);

                if (shops.ContainsKey(shopName))
                {
                    shops[shopName][product] = price;
                }
                else
                {
                    shops[shopName] = new Dictionary<string, double>();
                    shops[shopName][product] = price;
                }
            }

            foreach (var shop in shops)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}