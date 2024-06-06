using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex nameRegex = new Regex(@"\%([A-Z][a-z]+)\%");
            Regex productRegex = new Regex(@"<(\w+)>");
            Regex quantityRegex = new Regex(@"\|(\d+)\|");
            Regex priceRegex = new Regex(@"(\d+(\.?\d+)?)\$");

            decimal totalIncome = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of shift") { break; }

                if (nameRegex.IsMatch(input) && productRegex.IsMatch(input) && quantityRegex.IsMatch(input) && priceRegex.IsMatch(input))
                {
                    string customerName = nameRegex.Match(input).Groups[1].ToString();
                    string product = productRegex.Match(input).Groups[1].ToString();
                    int quantity = int.Parse(quantityRegex.Match(input).Groups[1].ToString());
                    decimal price = decimal.Parse(priceRegex.Match(input).Groups[1].ToString());

                    Console.WriteLine($"{customerName}: {product} - {quantity * price:F2}");
                    totalIncome += quantity * price;
                }
            }
            Console.WriteLine($"Total income: {totalIncome:F2}");
        }
    }
}