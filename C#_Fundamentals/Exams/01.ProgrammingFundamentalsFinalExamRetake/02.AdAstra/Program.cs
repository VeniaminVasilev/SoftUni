using System.Text.RegularExpressions;

namespace _02.AdAstra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string regex = @"(?<delimiter>#|\|)(?<itemName>[A-Za-z\s]+)\k<delimiter>(?<expirationDate>\d{2}\/\d{2}\/\d{2})\k<delimiter>(?<calories>\d{1,5})\k<delimiter>";
            
            MatchCollection matches = Regex.Matches(input, regex);

            int totalCalories = matches.Cast<Match>()
                .Where(m => m.Success)
                .Sum(m => int.Parse(m.Groups["calories"].Value));

            int dailyCalorieIntake = 2000;
            int daysSufficient = totalCalories / dailyCalorieIntake;

            Console.WriteLine($"You have food to last you for: {daysSufficient} days!");

            if (daysSufficient > 0)
            {
                foreach (Match match in matches)
                {
                    string itemName = match.Groups["itemName"].Value;
                    string expirationDate = match.Groups["expirationDate"].Value;
                    int calories = int.Parse(match.Groups["calories"].Value);

                    Console.WriteLine($"Item: {itemName}, Best before: {expirationDate}, Nutrition: {calories}");
                }
            }
        }
    }
}