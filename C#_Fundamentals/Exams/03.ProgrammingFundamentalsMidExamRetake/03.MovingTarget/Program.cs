namespace _03.MovingTarget
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    Console.WriteLine(string.Join("|", targets));
                    break;
                }

                string[] tokens = command.Split(" ");
                string action = tokens[0];
                int index = int.Parse(tokens[1]);

                if (action == "Shoot")
                {
                    if (index >= 0 && index < targets.Count)
                    {
                        int power = int.Parse(tokens[2]);
                        targets[index] -= power;

                        if (targets[index] <= 0)
                        {
                            targets.RemoveAt(index);
                        }
                    }
                }
                else if (action == "Add")
                {
                    if (index >= 0 && index < targets.Count)
                    {
                        int value = int.Parse(tokens[2]);
                        targets.Insert(index, value);
                    }
                    else
                    {
                        Console.WriteLine($"Invalid placement!");
                    }
                }
                else if (action == "Strike")
                {
                    int radius = int.Parse(tokens[2]);

                    if (index + radius < targets.Count && index - radius >= 0)
                    {
                        targets.RemoveRange(index - radius, (radius * 2 + 1));
                    }
                    else
                    {
                        Console.WriteLine($"Strike missed!");
                    }
                }
            }
        }
    }
}