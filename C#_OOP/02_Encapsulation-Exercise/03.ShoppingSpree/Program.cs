namespace _03.ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> peopleInfo = new List<string>(Console.ReadLine()
                .Split(";")).ToList();
            List<Person> people = new List<Person>();

            foreach (string info in peopleInfo)
            {
                string[] tokens = info.Split("=");
                string name = tokens[0];
                int money = int.Parse(tokens[1]);

                try
                {
                    Person person = new Person(name, money);
                    people.Add(person);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
            }

            List<string> productsInfo = new List<string>(Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries)).ToList();
            List<Product> products = new List<Product>();

            foreach (string info in productsInfo)
            {
                string[] tokens = info.Split("=");
                string name = tokens[0];
                int cost = int.Parse(tokens[1]);

                try
                {
                    Product product = new Product(name, cost);
                    products.Add(product);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                {
                    break;
                }

                string[] tokens = command.Split(" ");
                string personName = tokens[0];
                string productName = tokens[1];

                Product product = products.Find(p => p.Name == productName);
                Person person = people.Find(p => p.Name == personName);

                bool boughtProduct = person.BuyProduct(product);

                if (boughtProduct)
                {
                    Console.WriteLine($"{personName} bought {productName}");
                }
                else
                {
                    Console.WriteLine($"{personName} can't afford {productName}");
                }
            }

            foreach (Person person in people)
            {
                if (person.BagOfProducts.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
                else
                {
                    Console.Write($"{person.Name} -");

                    for (int i = 0; i < person.BagOfProducts.Count; i++)
                    {
                        if (i == 0)
                        {
                            Console.Write($" {person.BagOfProducts[i].Name}");
                        }
                        else
                        {
                            Console.Write($", {person.BagOfProducts[i].Name}");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}