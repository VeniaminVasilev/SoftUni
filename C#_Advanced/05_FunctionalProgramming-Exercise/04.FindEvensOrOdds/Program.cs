namespace _04.FindEvensOrOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] boundaries = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            
            int lowerNumber = boundaries[0];
            int upperNumber = boundaries[1];

            Predicate<string> criteriaOdd = x => x == "odd" ? true : false;
            Predicate<int> oddNumber = x => x % 2 == 1 || x % 2 == -1 ? true : false;
            Action<int> printer = x => Console.Write($"{x} ");

            string command = Console.ReadLine();

            if (criteriaOdd(command))
            {
                for (int i = lowerNumber; i <= upperNumber; i++)
                {
                    if (oddNumber(i))
                    {
                        printer(i);
                    }
                }
            }
            else if (!criteriaOdd(command))
            {
                for (int i = lowerNumber; i <= upperNumber; i++)
                {
                    if (!oddNumber(i))
                    {
                        printer(i);
                    }
                }
            }
        }
    }
}