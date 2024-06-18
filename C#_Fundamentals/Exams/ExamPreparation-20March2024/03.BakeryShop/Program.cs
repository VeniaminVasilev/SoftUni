namespace _03.BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> foodTypes = new Dictionary<string, int>();
            int quantitySold = 0;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Complete") { break; }

                string[] tokens = command.Split(" ");
                string action = tokens[0];
                int quantity = int.Parse(tokens[1]);
                string food = tokens[2];

                if (action == "Receive" && quantity > 0)
                {
                    if (foodTypes.ContainsKey(food))
                    {
                        foodTypes[food] += quantity;
                    }
                    else
                    {
                        foodTypes.Add(food, quantity);
                    }
                }
                else if (action == "Sell")
                {
                    if (!foodTypes.ContainsKey(food))
                    {
                        Console.WriteLine($"You do not have any {food}.");
                    }
                    else if (foodTypes.ContainsKey(food))
                    {
                        if (foodTypes[food] < quantity)
                        {
                            int currentQuantitySold = foodTypes[food];
                            foodTypes[food] = 0;
                            Console.WriteLine($"There aren't enough {food}. You sold the last {currentQuantitySold} of them.");
                            quantitySold += currentQuantitySold;
                            foodTypes.Remove(food);
                        }
                        else
                        {
                            foodTypes[food] -= quantity;
                            Console.WriteLine($"You sold {quantity} {food}.");
                            quantitySold += quantity;

                            if (foodTypes[food] == 0)
                            {
                                foodTypes.Remove(food);
                            }
                        }
                    }
                }
            }

            foreach (var foodType in foodTypes)
            {
                Console.WriteLine($"{foodType.Key}: {foodType.Value}");
            }
            Console.WriteLine($"All sold: {quantitySold} goods");
        }
    }
}