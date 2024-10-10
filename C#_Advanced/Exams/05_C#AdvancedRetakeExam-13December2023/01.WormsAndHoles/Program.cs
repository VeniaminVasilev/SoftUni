namespace _01.WormsAndHoles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> worms = new Stack<int>(Console.ReadLine()
                .Split(" ")
                .Select(int.Parse));

            Queue<int> holes = new Queue<int>(Console.ReadLine()
                .Split(" ")
                .Select(int.Parse));

            int matches = 0;
            int initialWormsCount = worms.Count;

            while (true)
            {
                if (worms.Count == 0 || holes.Count == 0) break;

                int currentWorm = worms.Peek();
                int currentHole = holes.Peek();

                if (currentWorm <= 0)
                {
                    worms.Pop();
                    continue;
                }

                if (currentWorm == currentHole)
                {
                    worms.Pop();
                    holes.Dequeue();
                    matches++;
                }
                else
                {
                    currentWorm -= 3;

                    if (currentWorm > 0)
                    {
                        worms.Pop();
                        worms.Push(currentWorm);
                    }
                    else
                    {
                        worms.Pop();
                    }

                    holes.Dequeue();
                }
            }

            if (matches > 0)
            {
                Console.WriteLine($"Matches: {matches}");
            }
            else
            {
                Console.WriteLine("There are no matches.");
            }

            if (initialWormsCount == matches && worms.Count == 0)
            {
                Console.WriteLine($"Every worm found a suitable hole!");
            }
            else if (worms.Count == 0)
            {
                Console.WriteLine($"Worms left: none");
            }
            else if (worms.Count > 0)
            {
                Console.WriteLine($"Worms left: {string.Join(", ", worms)}");
            }

            if (holes.Count == 0)
            {
                Console.WriteLine("Holes left: none");
            }
            else
            {
                Console.WriteLine($"Holes left: {string.Join(", ", holes)}");
            }
        }
    }
}