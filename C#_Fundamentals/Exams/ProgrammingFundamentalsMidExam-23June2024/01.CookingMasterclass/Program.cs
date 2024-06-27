namespace _01.CookingMasterclass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            decimal priceFlour = decimal.Parse(Console.ReadLine());
            decimal priceEgg = decimal.Parse(Console.ReadLine());
            decimal priceApron = decimal.Parse(Console.ReadLine());

            decimal priceAllPackagesFlour = (students - (students / 5)) * priceFlour;
            decimal priceAllEggs = students * (10 * priceEgg);
            decimal priceAllAprons = (Math.Ceiling(students * 1.2m)) * priceApron;

            decimal priceAll = priceAllPackagesFlour + priceAllEggs + priceAllAprons;
            if (priceAll <= budget)
            {
                Console.WriteLine($"Items purchased for {priceAll:F2}$.");
            }
            else
            {
                Console.WriteLine($"{priceAll - budget:F2}$ more needed.");
            }
        }
    }
}