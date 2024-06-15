namespace _01.BlackFlag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int dailyPlunder = int.Parse(Console.ReadLine());
            decimal expectedPlunder = decimal.Parse(Console.ReadLine());

            decimal totalPlunder = 0;

            for (int i = 1; i <= days; i++)
            {
                totalPlunder += dailyPlunder;

                if (i % 3 == 0)
                {
                    decimal additionalPlunder = (decimal)dailyPlunder / 2;
                    totalPlunder += additionalPlunder;
                }

                if (i % 5 == 0)
                {
                    decimal lostPlunder = totalPlunder * 0.30m;
                    totalPlunder -= lostPlunder;
                }
            }

            if (totalPlunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {totalPlunder:F2} plunder gained.");
            }
            else
            {
                decimal percentage = (totalPlunder / expectedPlunder) * 100;
                Console.WriteLine($"Collected only {percentage:F2}% of the plunder.");
            }
        }
    }
}