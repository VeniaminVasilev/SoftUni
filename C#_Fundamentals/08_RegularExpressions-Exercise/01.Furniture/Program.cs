using System.Text.RegularExpressions;

namespace _01.Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string regex = @">>(?<name>[A-Za-z]+)<<(?<price>\d+(?:[,.]\d*)?)!(?<quantity>\d+)";
            //">>{furniture name}<<{price}!{quantity}"

            List<string> list = new List<string>();
            decimal totalSpentMoney = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Purchase") { break; }
                list.Add(input);
            }

            MatchCollection validFurniture = Regex.Matches(string.Join(" ", list), regex);

            Console.WriteLine($"Bought furniture:");

            foreach (Match furniture in validFurniture)
            { 
                string furnitureName = furniture.Groups["name"].Value;
                decimal furniturePrice = decimal.Parse(furniture.Groups["price"].Value) * int.Parse(furniture.Groups["quantity"].Value);

                if (furniturePrice == 0) { continue; }

                Console.WriteLine($"{furnitureName}");

                totalSpentMoney += furniturePrice;
            }

            Console.WriteLine($"Total money spend: {totalSpentMoney:F2}");
        }
    }
}