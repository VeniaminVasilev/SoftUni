namespace _05.DragonArmy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, SortedDictionary<string, int[]>> dragonArmy = new Dictionary<string, SortedDictionary<string, int[]>>();

            int numberOfDragons = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfDragons; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ").ToArray();

                string type = tokens[0];
                string name = tokens[1];
                int damage = 0;
                int health = 0;
                int armor = 0;

                if (tokens[2] == "null")
                { damage = 45; } else
                { damage = int.Parse(tokens[2]); }

                if (tokens[3] == "null")
                { health = 250; }
                else
                { health = int.Parse(tokens[3]); }

                if (tokens[4] == "null")
                { armor = 10; }
                else
                { armor = int.Parse(tokens[4]); }

                if (dragonArmy.ContainsKey(type) && dragonArmy[type].ContainsKey(name)) 
                {
                    dragonArmy[type][name][0] = damage;
                    dragonArmy[type][name][1] = health;
                    dragonArmy[type][name][2] = armor;
                }
                else if (!dragonArmy.ContainsKey(type))
                {
                    dragonArmy[type] = new SortedDictionary<string, int[]>();
                    dragonArmy[type][name] = new int[] { damage, health, armor };
                }
                else if (dragonArmy.ContainsKey(type) && !dragonArmy[type].ContainsKey(name))
                {
                    dragonArmy[type][name] = new int[] { damage, health, armor };
                }
            }

            foreach (var dragonType in dragonArmy)
            {
                double averageDamage = 0;
                double averageHealth = 0;
                double averageArmor = 0;
                int counter = 0;

                foreach (var dragon in dragonType.Value)
                {
                    averageDamage += dragon.Value[0];
                    averageHealth += dragon.Value[1];
                    averageArmor += dragon.Value[2];
                    counter++;
                }
                averageDamage /= counter;
                averageHealth /= counter;
                averageArmor /= counter;

                Console.WriteLine($"{dragonType.Key}::({averageDamage:F2}/{averageHealth:F2}/{averageArmor:F2})");

                foreach (var dragon in dragonType.Value)
                {
                    Console.WriteLine($"-{dragon.Key} -> damage: {dragon.Value[0]}, health: {dragon.Value[1]}, armor: {dragon.Value[2]}");
                }
            }
        }
    }
}