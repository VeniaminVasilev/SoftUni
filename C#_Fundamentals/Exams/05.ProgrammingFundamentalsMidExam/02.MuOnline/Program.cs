namespace _02.MuOnline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int health = 100;
            int bitcoins = 0;

            List<string> rooms = Console.ReadLine()
                .Split("|")
                .ToList();

            for (int i = 0; i < rooms.Count; i++)
            {
                string[] tokens = rooms[i].Split(" ");
                string command = tokens[0];

                if (command == "potion")
                {
                    int amount = int.Parse(tokens[1]);

                    if (health < 100)
                    {
                        health += amount;

                        if (health > 100)
                        {
                            Console.WriteLine($"You healed for {amount - (health - 100)} hp.");
                            health = 100;
                            Console.WriteLine($"Current health: {health} hp.");
                        }
                        else
                        {
                            Console.WriteLine($"You healed for {amount} hp.");
                            Console.WriteLine($"Current health: {health} hp.");
                        }
                    }
                }
                else if (command == "chest")
                {
                    int bitcoinsFound = int.Parse(tokens[1]);
                    Console.WriteLine($"You found {bitcoinsFound} bitcoins.");
                    bitcoins += bitcoinsFound;
                }
                else
                {
                    int attack = int.Parse(tokens[1]);

                    health -= attack;

                    if (health > 0)
                    {
                        Console.WriteLine($"You slayed {command}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {command}.");
                        Console.WriteLine($"Best room: {i + 1}");
                        break;
                    }
                }
            }

            if (health > 0)
            {
                Console.WriteLine($"You've made it!\nBitcoins: {bitcoins}\nHealth: {health}");
            }
        }
    }
}