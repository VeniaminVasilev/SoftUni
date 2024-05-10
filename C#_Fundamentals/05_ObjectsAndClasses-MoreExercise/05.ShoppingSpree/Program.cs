namespace _05.ShoppingSpree
{
    public class Person
    {
        public string PersonName { get; set; }
        public decimal PersonMoney { get; set; }
        public List<Product> BagOfProducts { get; set; } = new List<Product>();
        
        public Person(string personName, decimal personMoney) 
        {
            this.PersonName = personName;
            this.PersonMoney = personMoney;
        }

        public void TryBuyingAProduct(Product product)
        {
            if (PersonMoney >= product.ProductCost)
            {
                PersonMoney -= product.ProductCost;
                BagOfProducts.Add(product);
                Console.WriteLine($"{PersonName} bought {product.ProductName}");
            }
            else
            {
                Console.WriteLine($"{PersonName} can't afford {product.ProductName}");
            }
        }
    }

    public class Product
    {
        public string ProductName { get; set; }
        public decimal ProductCost { get; set; }

        public Product(string productName, decimal productCost)
        {
            this.ProductName = productName;
            this.ProductCost = productCost;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            string[] peopleInput = Console.ReadLine().Split(";");

            for (int i = 0; i < peopleInput.Length; i++)
            {
                string personName = peopleInput[i].Split("=")[0];
                decimal personMoney = decimal.Parse(peopleInput[i].Split("=")[1]);
                Person person = new Person(personName, personMoney);
                people.Add(person);
            }

            string[] productInput = Console.ReadLine().Split(";");

            for (int i = 0; i < productInput.Length; i++)
            {
                string productName = productInput[i].Split("=")[0];
                decimal productCost = decimal.Parse(productInput[i].Split("=")[1]);
                Product product = new Product(productName, productCost);
                products.Add(product);
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END") { break; }

                string[] tokens = command.Split(" ");
                string personName = tokens[0];
                string productName = tokens[1];

                people.Find(p => p.PersonName == personName).TryBuyingAProduct(products.Find(p => p.ProductName == productName));
            }

            for (int i = 0; i < people.Count; i++)
            {
                Console.Write($"{people[i].PersonName} - ");

                if (people[i].BagOfProducts.Count > 0)
                {
                    for (int j = 0; j < people[i].BagOfProducts.Count; j++)
                    {
                        if (j == 0)
                        { Console.Write($"{people[i].BagOfProducts[j].ProductName}"); }
                        else { Console.Write($", {people[i].BagOfProducts[j].ProductName}"); }
                    }
                } 
                else { Console.Write($"Nothing bought"); }
                Console.WriteLine();
            }
        }
    }
}