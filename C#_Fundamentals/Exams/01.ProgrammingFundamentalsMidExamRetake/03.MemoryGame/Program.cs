namespace _03.MemoryGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            int countOfTurns = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    if (list.Count > 0)
                    {
                        Console.WriteLine($"Sorry you lose :(");
                        Console.WriteLine(string.Join(" ", list));
                    }
                    break;
                }

                string[] array = input.Split(" ").ToArray();
                int index1 = 0;
                int index2 = 0;

                if (array[0] == array[1] || int.Parse(array[0]) < 0 || int.Parse(array[0]) >= list.Count || int.Parse(array[1]) < 0 || int.Parse(array[1]) >= list.Count) 
                {
                    countOfTurns++;
                    string string1 = $"-{countOfTurns}a";
                    string string2 = $"-{countOfTurns}a";
                    list.Insert((list.Count / 2), string1);
                    list.Insert((list.Count / 2), string2);

                    Console.WriteLine($"Invalid input! Adding additional elements to the board");
                    continue;
                }

                if (int.Parse(array[0]) > int.Parse(array[1]))
                {
                    index1 = int.Parse(array[0]);
                    index2 = int.Parse(array[1]);
                }
                else if (int.Parse(array[0]) < int.Parse(array[1]))
                {
                    index1 = int.Parse(array[1]);
                    index2 = int.Parse(array[0]);
                }

                if (list[index1] == list[index2])
                {
                    string match = list[index1];
                    list.RemoveAt(index1);
                    list.RemoveAt(index2);
                    Console.WriteLine($"Congrats! You have found matching elements - {match}!");
                    countOfTurns++;
                }
                else if (list[index1] != list[index2])
                {
                    Console.WriteLine("Try again!");
                    countOfTurns++;
                }

                if (list.Count == 0)
                {
                    Console.WriteLine($"You have won in {countOfTurns} turns!");
                    break;
                }
            }
        }
    }
}