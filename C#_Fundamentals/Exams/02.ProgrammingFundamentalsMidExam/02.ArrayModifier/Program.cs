namespace _02.ArrayModifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end") { break; }

                string[] tokens = command.Split(" ").ToArray();

                if (tokens[0] == "swap")
                {
                    int index1 = int.Parse(tokens[1]);
                    int index2 = int.Parse(tokens[2]);

                    int numberAtIndex1 = list[index1];
                    int numberAtIndex2 = list[index2];

                    list[index1] = numberAtIndex2;
                    list[index2] = numberAtIndex1;
                }
                else if (tokens[0] == "multiply")
                {
                    int index1 = int.Parse(tokens[1]);
                    int index2 = int.Parse(tokens[2]);

                    int numberAtIndex1 = list[index1];
                    int numberAtIndex2 = list[index2];

                    int result = numberAtIndex1 * numberAtIndex2;

                    list[index1] = result;
                }
                else if (tokens[0] == "decrease")
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        list[i] -= 1;
                    }
                }
            }

            Console.WriteLine(string.Join(", ", list));
        }
    }
}