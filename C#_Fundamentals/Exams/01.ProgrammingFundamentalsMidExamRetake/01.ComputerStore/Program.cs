namespace _01.ComputerStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<decimal> partsPrices = new List<decimal>();
            bool isSpecial = false;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "special")
                {
                    isSpecial = true;
                    break;
                }
                else if (command == "regular")
                { break; }

                decimal currentPartPrice = decimal.Parse(command);
                if (currentPartPrice <= 0)
                {
                    Console.WriteLine("Invalid price!");
                }
                else
                {
                    partsPrices.Add(currentPartPrice);
                }
            }

            decimal totalPriceWithoutTaxes = partsPrices.Sum();
            decimal totalAmountOfTaxes = totalPriceWithoutTaxes * 0.2m;
            decimal totalPriceWithTaxes = totalPriceWithoutTaxes + totalAmountOfTaxes;

            if (isSpecial)
            {
                totalPriceWithTaxes *= 0.9m;
            }

            if (totalPriceWithTaxes == 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else
            {
                Console.WriteLine($"Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {totalPriceWithoutTaxes:F2}$");
                Console.WriteLine($"Taxes: {totalAmountOfTaxes:F2}$");
                Console.WriteLine($"-----------");
                Console.WriteLine($"Total price: {totalPriceWithTaxes:F2}$");
            }
        }
    }
}