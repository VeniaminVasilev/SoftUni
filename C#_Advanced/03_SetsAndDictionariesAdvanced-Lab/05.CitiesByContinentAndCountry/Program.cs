namespace _05.CitiesByContinentAndCountry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> continents = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string continent = tokens[0];
                string country = tokens[1];
                string city = tokens[2];

                if (continents.ContainsKey(continent))
                {
                    if (continents[continent].ContainsKey(country))
                    {
                        continents[continent][country].Add(city);
                    }
                    else
                    {
                        continents[continent][country] = new List<string>();
                        continents[continent][country].Add(city);
                    }
                }
                else
                {
                    continents[continent] = new Dictionary<string, List<string>>();
                    continents[continent][country] = new List<string> { city };
                }
            }

            foreach (var continent in continents)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}