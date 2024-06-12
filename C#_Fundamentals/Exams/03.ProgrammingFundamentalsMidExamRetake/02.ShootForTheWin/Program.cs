namespace _02.ShootForTheWin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int shotTargets = 0;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    Console.WriteLine($"Shot targets: {shotTargets} -> {string.Join(" ", targets)}");
                    break;
                }

                int shotIndex = int.Parse(command);
                int shotNumber = 0;

                if (shotIndex < 0 || shotIndex >= targets.Count) { continue; }

                if (targets[shotIndex] != -1)
                {
                    shotNumber = targets[shotIndex];
                    targets[shotIndex] = -1;
                    shotTargets++;

                    for (int i = 0; i < targets.Count; i++)
                    {
                        if (targets[i] != -1)
                        {
                            if (targets[i] > shotNumber)
                            {
                                targets[i] -= shotNumber;
                            }
                            else
                            {
                                targets[i] += shotNumber;
                            }
                        }
                    }
                }
            }
        }
    }
}