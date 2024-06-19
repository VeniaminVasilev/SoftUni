using System.Text.RegularExpressions;

namespace _02.FancyBarcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfBarcodes = int.Parse(Console.ReadLine());
            string pattern = @"@#+[A-Z][a-zA-Z0-9]{4,}[A-Z]@#+";

            for (int i = 0; i < countOfBarcodes; i++)
            {
                string input = Console.ReadLine();

                if (Regex.IsMatch(input, pattern))
                {
                    string productGroup = string.Empty;
                    for (int j = 0; j < input.Length; j++)
                    {
                        if (char.IsDigit(input[j]))
                        {
                            productGroup += input[j];
                        }
                    }

                    if (productGroup.Length > 0)
                    {
                        Console.WriteLine($"Product group: {productGroup}");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: 00");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid barcode");
                }
            }
        }
    }
}