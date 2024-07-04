namespace _05.FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> clothes = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            int rackCapacity = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            int racksUsed = 1;
            int currentSum = 0;

            for (int i = 0; i < clothes.Count; i++)
            {
                stack.Push(clothes[i]);
            }

            for (int i = 0; i < clothes.Count; i++)
            {
                if (currentSum + stack.Peek() > rackCapacity)
                {
                    racksUsed++;
                    currentSum = 0;
                    i--;
                }
                else if (currentSum + stack.Peek() == rackCapacity)
                {
                    if (stack.Count > 1)
                    {
                        racksUsed++;
                        currentSum = 0;
                        stack.Pop();
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                else if (currentSum + stack.Peek() < rackCapacity)
                {
                    currentSum += stack.Pop();
                }
            }

            Console.WriteLine(racksUsed);
        }
    }
}