namespace _03.P_rates
{
    class City
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<City> cities = new List<City>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Sail") { break; }

                string[] tokens = command.Split("||");
                string name = tokens[0];
                int population = int.Parse(tokens[1]);
                int gold = int.Parse(tokens[2]);

                if (cities.Any(c => c.Name.Equals(name)))
                {
                    City currentCity = cities.FirstOrDefault(c => c.Name.Equals(name));
                    currentCity.Population += population;
                    currentCity.Gold += gold;
                }
                else
                {
                    City newCity = new City()
                    {
                        Name = name,
                        Population = population,
                        Gold = gold,
                    };
                    cities.Add(newCity);
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End") { break; }

                string[] tokens = command.Split("=>");
                string action = tokens[0];
                string name = tokens[1];
                
                City currentCity = cities.FirstOrDefault(c => c.Name.Equals(name));

                if (action == "Plunder")
                {
                    int people = int.Parse(tokens[2]);
                    int gold = int.Parse(tokens[3]);

                    Console.WriteLine($"{name} plundered! {gold} gold stolen, {people} citizens killed.");

                    currentCity.Population -= people;
                    currentCity.Gold -= gold;

                    if (currentCity.Population <= 0 || currentCity.Gold <= 0)
                    {
                        Console.WriteLine($"{name} has been wiped off the map!");
                        cities.Remove(currentCity);
                    }
                }
                else if (action == "Prosper")
                {
                    int gold = int.Parse(tokens[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine($"Gold added cannot be a negative number!");
                    }
                    else
                    {
                        currentCity.Gold += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {name} now has {currentCity.Gold} gold.");
                    }
                }
            }

            if (cities.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                foreach (City city in cities)
                {
                    Console.WriteLine($"{city.Name} -> Population: {city.Population} citizens, Gold: {city.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}