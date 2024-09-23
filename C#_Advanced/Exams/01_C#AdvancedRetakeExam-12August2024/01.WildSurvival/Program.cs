namespace _01.WildSurvival
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> beesGroups = new Queue<int>(Console.ReadLine()
                .Split(" ")
                .Select(int.Parse));

            Stack<int> beeEatersGroups = new Stack<int>(Console.ReadLine()
                .Split(" ")
                .Select(int.Parse));

            while (true)
            {
                if (beesGroups.Count == 0 || beeEatersGroups.Count == 0 || beesGroups.Count == 0 && beeEatersGroups.Count == 0)
                {
                    break;
                }

                int attacker = beeEatersGroups.Peek() * 7;
                int defender = beesGroups.Peek();

                if (attacker == defender)
                {
                    beeEatersGroups.Pop();
                    beesGroups.Dequeue();
                }
                else if (attacker < defender)
                {
                    int difference = defender - attacker;

                    beeEatersGroups.Pop();
                    beesGroups.Dequeue();
                    beesGroups.Enqueue(difference);
                }
                else if (attacker > defender)
                {
                    double attackersToBeAdded = Math.Ceiling((double)(attacker - defender) / 7);

                    beesGroups.Dequeue();
                    beeEatersGroups.Pop();

                    if (beeEatersGroups.Any())
                    {
                        attackersToBeAdded += beeEatersGroups.Pop();
                        beeEatersGroups.Push((int)attackersToBeAdded);
                    }
                    else
                    {
                        beeEatersGroups.Push((int)attackersToBeAdded);
                    }
                }
            }

            Console.WriteLine("The final battle is over!");

            if (beesGroups.Count == 0 && beeEatersGroups.Count == 0)
            {
                Console.WriteLine("But no one made it out alive!");
            }
            else if (beesGroups.Count > 0 && beeEatersGroups.Count == 0)
            {
                Console.WriteLine($"Bee groups left: {string.Join(", ", beesGroups)}");
            }
            else if (beesGroups.Count == 0 && beeEatersGroups.Count > 0)
            {
                Console.WriteLine($"Bee-eater groups left: {string.Join(", ", beeEatersGroups)}");
            }
        }
    }
}