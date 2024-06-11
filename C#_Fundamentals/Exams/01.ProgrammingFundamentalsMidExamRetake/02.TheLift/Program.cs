namespace _02.TheLift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int peopleWaiting = int.Parse(Console.ReadLine());

            List<int> liftWagons = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                if (peopleWaiting <= 0) { break; }
                if (liftWagons.Sum() == (liftWagons.Count * 4)) { break; }

                for (int i = 0; i < liftWagons.Count; i++)
                {
                    if (liftWagons[i] < 4)
                    {
                        liftWagons[i]++;
                        break;
                    }
                }
                peopleWaiting--;
            }

            if (liftWagons.Sum() < (liftWagons.Count * 4) && peopleWaiting == 0)
            {
                Console.WriteLine($"The lift has empty spots!\n{string.Join(" ", liftWagons)}");
            }
            else if (peopleWaiting > 0 && liftWagons.Sum() == (liftWagons.Count * 4))
            {
                Console.WriteLine($"There isn't enough space! {peopleWaiting} people in a queue!\n{string.Join(" ", liftWagons)}");
            }
            else if (peopleWaiting == 0 && liftWagons.Sum() == (liftWagons.Count * 4))
            {
                Console.WriteLine(string.Join(" ", liftWagons));
            }
        }
    }
}