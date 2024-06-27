namespace _02.TaxCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> cars = Console.ReadLine()
                .Split(">>")
                .ToList();

            decimal allTaxes = 0;

            for (int i = 0; i < cars.Count; i++)
            {
                string[] tokens = cars[i].Split(" ");
                string carType = tokens[0];
                int yearsTax = int.Parse(tokens[1]);
                int kilometersTraveled = int.Parse(tokens[2]);

                if (carType == "family")
                {
                    decimal currentTax = 50 - (yearsTax * 5) + (12 * (kilometersTraveled / 3000));
                    allTaxes += currentTax;
                    Console.WriteLine($"A {carType} car will pay {currentTax:F2} euros in taxes.");
                }
                else if (carType == "heavyDuty")
                {
                    decimal currentTax = 80 - (yearsTax * 8) + (14 * (kilometersTraveled / 9000));
                    allTaxes += currentTax;
                    Console.WriteLine($"A {carType} car will pay {currentTax:F2} euros in taxes.");
                }
                else if (carType == "sports")
                {
                    decimal currentTax = 100 - (yearsTax * 9) + (18 * (kilometersTraveled / 2000));
                    allTaxes += currentTax;
                    Console.WriteLine($"A {carType} car will pay {currentTax:F2} euros in taxes.");
                }
                else
                {
                    Console.WriteLine("Invalid car type.");
                }
            }

            Console.WriteLine($"The National Revenue Agency will collect {allTaxes:F2} euros in taxes.");
        }
    }
}