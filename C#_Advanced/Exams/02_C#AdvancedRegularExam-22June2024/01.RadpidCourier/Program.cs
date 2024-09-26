namespace _01.RadpidCourier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> packages = new Stack<int>(Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)); 

            Queue<int> couriers = new Queue<int>(Console.ReadLine()
                .Split(" ")
                .Select(int.Parse));

            int totalDeliveredWeight = 0;

            while (true)
            {
                if (packages.Count == 0 || couriers.Count == 0) break;

                int currentPackage = packages.Peek();
                int currentCourier = couriers.Peek();

                if (currentCourier >= currentPackage)
                {
                    if (currentCourier > currentPackage)
                    {
                        currentCourier -= 2 * currentPackage;

                        if (currentCourier > 0)
                        {
                            couriers.Enqueue(currentCourier);
                            couriers.Dequeue();
                        }
                        else
                        {
                            couriers.Dequeue();
                        }
                    }
                    else
                    {
                        couriers.Dequeue();
                    }

                    totalDeliveredWeight += currentPackage;
                    packages.Pop();
                }
                else
                {
                    int difference = currentPackage - currentCourier;

                    packages.Pop();
                    packages.Push(difference);
                    couriers.Dequeue();

                    totalDeliveredWeight += currentCourier;
                }
            }

            Console.WriteLine($"Total weight: {totalDeliveredWeight} kg");

            if (packages.Count == 0 && couriers.Count == 0)
            {
                Console.WriteLine("Congratulations, all packages were delivered successfully by the couriers today.");
            }
            else if (packages.Count > 0 && couriers.Count == 0)
            {
                Console.WriteLine($"Unfortunately, there are no more available couriers to deliver the following packages: {string.Join(", ", packages)}");
            }
            else if (packages.Count == 0 && couriers.Count > 0)
            {
                Console.WriteLine($"Couriers are still on duty: {string.Join(", ", couriers)} but there are no more packages to deliver.");
            }
        }
    }
}