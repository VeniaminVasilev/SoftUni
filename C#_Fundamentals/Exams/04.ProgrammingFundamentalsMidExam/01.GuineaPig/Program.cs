namespace _01.GuineaPig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal foodInGr = decimal.Parse(Console.ReadLine()) * 1000;
            decimal hayInGr = decimal.Parse(Console.ReadLine()) * 1000;
            decimal coverInGr = decimal.Parse(Console.ReadLine()) * 1000;
            decimal QuineaInGr = decimal.Parse(Console.ReadLine()) * 1000;
            bool enoughResources = true;

            for (int i = 1; i <= 30; i++)
            { 
                if (foodInGr <= 0 || hayInGr <= 0 || coverInGr <= 0)
                {
                    Console.WriteLine("Merry must go to the pet store!");
                    enoughResources = false;
                    break;
                }

                foodInGr -= 300m;
                if (foodInGr <= 0)
                {
                    Console.WriteLine("Merry must go to the pet store!");
                    enoughResources = false;
                    break;
                }

                if (i % 2 == 0)
                {
                    decimal amountOfHay = foodInGr * 0.05m;
                    hayInGr -= amountOfHay;

                    if (hayInGr <= 0)
                    {
                        Console.WriteLine("Merry must go to the pet store!");
                        enoughResources = false;
                        break;
                    }
                }
                
                if (i % 3 == 0)
                {
                    decimal amountOfCover = QuineaInGr / 3;
                    coverInGr -= amountOfCover;

                    if (coverInGr <= 0)
                    {
                        Console.WriteLine("Merry must go to the pet store!");
                        enoughResources = false;
                        break;
                    }
                }
            }

            if (enoughResources)
            {
                Console.WriteLine($"Everything is fine! Puppy is happy! Food: {foodInGr / 1000:F2}, Hay: {hayInGr / 1000:F2}, Cover: {coverInGr / 1000:F2}.");
            }
        }
    }
}