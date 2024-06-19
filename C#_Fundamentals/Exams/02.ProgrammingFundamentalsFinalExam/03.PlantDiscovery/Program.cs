namespace _03.PlantDiscovery
{
    class Plant
    {
        public string Name { get; set; }
        public int Rarity { get; set; }
        public List<int> Ratings { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Plant> plants = new List<Plant>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string information = Console.ReadLine();
                string[] tokens = information.Split("<->");
                string plantName = tokens[0];
                int plantRarity = int.Parse(tokens[1]);

                if (plants.Any(p => p.Name.Equals(plantName)))
                {
                    Plant plantToUpdate = plants.FirstOrDefault(p => p.Name.Equals(plantName));
                    plantToUpdate.Rarity = plantRarity;
                }
                else
                {
                    Plant newPlant = new Plant()
                    {
                        Name = plantName,
                        Rarity = plantRarity,
                        Ratings = new List<int>()
                    };
                    plants.Add(newPlant);
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Exhibition") { break; }

                string[] tokens = command.Split(" ");
                string action = tokens[0];
                string plant = tokens[1];

                if (action == "Rate:")
                {
                    int rating = int.Parse(tokens[3]);
                    if (plants.Any(p => p.Name.Equals(plant)))
                    {
                        Plant plantToUpdate = plants.FirstOrDefault(p => p.Name.Equals(plant));
                        plantToUpdate.Ratings.Add(rating);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (action == "Update:")
                {
                    int rarity = int.Parse(tokens[3]);
                    if (plants.Any(p => p.Name.Equals(plant)))
                    {
                        Plant plantToUpdate = plants.FirstOrDefault(p => p.Name.Equals(plant));
                        plantToUpdate.Rarity = rarity;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (action == "Reset:")
                {
                    if (plants.Any(p => p.Name.Equals(plant)))
                    {
                        Plant plantToUpdate = plants.FirstOrDefault(p => p.Name.Equals(plant));
                        plantToUpdate.Ratings.Clear();
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
            }
            Console.WriteLine("Plants for the exhibition:");
            foreach (var plant in plants)
            {
                if (plant.Ratings.Count == 0)
                {
                    Console.WriteLine($"- {plant.Name}; Rarity: {plant.Rarity}; Rating: 0.00");
                }
                else
                {
                    Console.WriteLine($"- {plant.Name}; Rarity: {plant.Rarity}; Rating: {plant.Ratings.Average():F2}");
                }
            }
        }
    }
}