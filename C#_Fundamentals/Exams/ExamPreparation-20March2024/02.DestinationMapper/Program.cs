using System.Text.RegularExpressions;

namespace _02.DestinationMapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string locations = Console.ReadLine();

            string pattern = @"([=\/])([A-Z][a-zA-Z]{2,})\1";

            MatchCollection matches = Regex.Matches(locations, pattern);

            List<string> locationMatches = new List<string>();
            int travelPoints = 0;

            foreach (Match match in matches)
            {
                string destination = match.Value;
                destination = destination.Remove(0, 1);
                destination = destination.Remove(destination.Length - 1, 1);
                locationMatches.Add(destination);
                travelPoints += destination.Length;
            }

            Console.WriteLine($"Destinations: {string.Join(", ", locationMatches)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}