namespace _01.PiePursuit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> contestants = new Queue<int>(Console.ReadLine()
                .Split(" ")
                .Select(int.Parse));

            Stack<int> pies = new Stack<int>(Console.ReadLine()
                .Split(" ")
                .Select(int.Parse));

            while (contestants.Count > 0 && pies.Count > 0)
            {
                int currentContestant = contestants.Peek();
                int currentPie = pies.Peek();

                if (currentContestant >= currentPie)
                {
                    currentContestant -= currentPie;
                    pies.Pop();

                    if (currentContestant == 0)
                    {
                        contestants.Dequeue();
                    }
                    else if (currentContestant > 0)
                    {
                        contestants.Dequeue();
                        contestants.Enqueue(currentContestant);
                    }
                }
                else
                {
                    currentPie -= currentContestant;

                    if (currentPie == 1)
                    {
                        if (pies.Count == 1)
                        {
                            pies.Pop();
                            pies.Push(currentPie);
                        }
                        else if (pies.Count > 1)
                        {
                            pies.Pop();
                            int previousPie = pies.Pop() + 1;
                            pies.Push(previousPie);
                        }
                    }
                    else
                    {
                        pies.Pop();
                        pies.Push(currentPie);
                    }

                    contestants.Dequeue();
                }
            }

            if (pies.Count == 0 && contestants.Count > 0)
            {
                Console.WriteLine("We will have to wait for more pies to be baked!");
                Console.WriteLine($"Contestants left: {string.Join(", ", contestants)}");
            }
            else if (pies.Count == 0 && contestants.Count == 0)
            {
                Console.WriteLine("We have a champion!");
            }
            else if (pies.Count > 0 && contestants.Count == 0)
            {
                Console.WriteLine("Our contestants need to rest!");
                Console.WriteLine($"Pies left: {string.Join(", ", pies)}");
            }
        }
    }
}