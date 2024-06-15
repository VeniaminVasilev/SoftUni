namespace _03.ManOWar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateShip = Console.ReadLine()
                .Split(">")
                .Select(int.Parse)
                .ToList();

            List<int> warship = Console.ReadLine()
                .Split(">")
                .Select(int.Parse)
                .ToList();

            int maximumHealth = int.Parse(Console.ReadLine());

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Retire")
                {
                    Console.WriteLine($"Pirate ship status: {pirateShip.Sum()}");
                    Console.WriteLine($"Warship status: {warship.Sum()}");
                    break;
                }

                string[] tokens = input.Split(" ");
                string command = tokens[0];

                if (command == "Fire")
                {
                    int index = int.Parse(tokens[1]);
                    int damage = int.Parse(tokens[2]);

                    if (index >= 0 && index < warship.Count)
                    {
                        warship[index] -= damage;
                        if (warship[index] <= 0)
                        {
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            break;
                        }
                    }
                }
                else if (command == "Defend")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);
                    int damage = int.Parse(tokens[3]);

                    if (startIndex >= 0 && startIndex < pirateShip.Count && endIndex >= 0 && endIndex < pirateShip.Count)
                    {
                        bool piratesLoose = false;
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            pirateShip[i] -= damage;
                            if (pirateShip[i] <= 0)
                            {
                                Console.WriteLine("You lost! The pirate ship has sunken.");
                                piratesLoose = true;
                                break;
                            }
                        }
                        if (piratesLoose) { break; }
                    }
                }
                else if (command == "Repair")
                {
                    int index = int.Parse(tokens[1]);
                    int health = int.Parse(tokens[2]);

                    if (index >= 0 && index < pirateShip.Count)
                    {
                        pirateShip[index] += health;
                        if (pirateShip[index] > maximumHealth)
                        {
                            pirateShip[index] = maximumHealth;
                        }
                    }
                }
                else if (command == "Status")
                {
                    int count = 0;
                    for (int i = 0; i < pirateShip.Count; i++)
                    {
                        decimal percentage = (pirateShip[i] / (decimal)maximumHealth) * 100;
                        if (percentage < 20) { count++; }
                    }
                    Console.WriteLine($"{count} sections need repair.");
                }
            }
        }
    }
}