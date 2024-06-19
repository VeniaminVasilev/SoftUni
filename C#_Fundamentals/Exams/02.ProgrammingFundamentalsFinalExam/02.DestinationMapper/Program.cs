using System.Text.RegularExpressions;

namespace _02.DestinationMapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string places = Console.ReadLine();
            string regex = @"([=\/])[A-Z][a-zA-Z]{2,}\1";
            int travelPoints = 0;
            List<string> validPlaces = new List<string>();

            MatchCollection matches = Regex.Matches(places, regex);

            foreach (Match match in matches)
            {
                string currentMatch = match.ToString();
                currentMatch = currentMatch.Remove(0, 1);
                currentMatch = currentMatch.Remove(currentMatch.Length - 1, 1);
                int currentTravelPoints = currentMatch.Length;

                travelPoints += currentTravelPoints;
                validPlaces.Add(currentMatch);
            }

            Console.WriteLine($"Destinations: {string.Join(", ", validPlaces)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}