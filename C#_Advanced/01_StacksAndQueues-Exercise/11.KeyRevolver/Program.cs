namespace _11.KeyRevolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int priceBullet = int.Parse(Console.ReadLine());
            int sizeBarrel = int.Parse(Console.ReadLine());
            List<int> bullets = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            List<int> locks = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            int valueIntelligence = int.Parse(Console.ReadLine());

            int countShots = 0;
            int totalCountShots = 0;

            Stack<int> stackBullets = new Stack<int>();
            for (int i = 0; i < bullets.Count; i++)
            {
                stackBullets.Push(bullets[i]);
            }

            Queue<int> queueLocks = new Queue<int>();
            for (int i = 0; i < locks.Count; i++)
            {
                queueLocks.Enqueue(locks[i]);
            }

            while (true)
            {
                if (countShots == sizeBarrel && stackBullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    countShots = 0;
                }

                if (stackBullets.Count == 0 && queueLocks.Count != 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {queueLocks.Count}");
                    break;
                }
                else if (queueLocks.Count == 0)
                {
                    Console.WriteLine($"{stackBullets.Count} bullets left. Earned ${valueIntelligence - (priceBullet * totalCountShots)}");
                    break;
                }

                int currentBullet = stackBullets.Peek();
                int currentLock = queueLocks.Peek();

                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    stackBullets.Pop();
                    queueLocks.Dequeue();

                    countShots++;
                    totalCountShots++;
                }
                else
                {
                    Console.WriteLine("Ping!");
                    stackBullets.Pop();

                    countShots++;
                    totalCountShots++;
                }
            }
        }
    }
}