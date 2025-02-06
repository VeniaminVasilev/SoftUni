namespace _06.FoodShortage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<IBuyer> buyers = new List<IBuyer>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(" ").ToArray();

                if (data.Length == 4)
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string id = data[2];
                    string birthdate = data[3];

                    Citizen citizen = new Citizen(name, age, id, birthdate);
                    buyers.Add(citizen);
                }
                else if (data.Length == 3)
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string group = data[2];

                    Rebel rebel = new Rebel(name, age, group);
                    buyers.Add(rebel);
                }
            }

            while (true)
            {
                string currentName = Console.ReadLine();
                if (currentName == "End") { break; }

                if (buyers.Exists(b => b.Name == currentName))
                {
                    IBuyer buyer = buyers.FirstOrDefault(b => b.Name == currentName);
                    buyer.BuyFood();
                }
            }

            int totalAmountPurchasedFood = buyers.Sum(b => b.Food);
            Console.WriteLine(totalAmountPurchasedFood);
        }
    }
}