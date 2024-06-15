namespace _02.TreasureHunt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> chest = Console.ReadLine()
                .Split("|")
                .ToList();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Yohoho!") { break; }

                string[] tokens = input.Split(" ");
                string command = tokens[0];

                if (command == "Loot")
                {
                    for (int i = 1; i < tokens.Length; i++)
                    {
                        if (!chest.Contains(tokens[i]))
                        {
                            chest.Insert(0, tokens[i]);
                        }
                    }
                }
                else if (command == "Drop")
                {
                    int index = int.Parse(tokens[1]);

                    if (index < 0 || index >= chest.Count)
                    {
                        continue;
                    }
                    else
                    {
                        string droppedLoot = chest[index];
                        chest.RemoveAt(index);
                        chest.Add(droppedLoot);
                    }
                }
                else if (command == "Steal")
                {
                    int count = int.Parse(tokens[1]);
                    List<string> stolenItems = new List<string>();

                    if (count >= chest.Count)
                    {
                        count = chest.Count;
                    }

                    for (int i = chest.Count - count; i < chest.Count; i++)
                    {
                        stolenItems.Add(chest[i]);
                    }

                    Console.WriteLine(string.Join(", ", stolenItems));
                    chest.RemoveRange(chest.Count - count, count);
                }
            }

            if (chest.Count == 0)
            {
                Console.WriteLine($"Failed treasure hunt.");
            }
            else
            {
                int lengthOfAllItems = 0;

                for (int i = 0; i < chest.Count; i++)
                {
                    int length = chest[i].Length;
                    lengthOfAllItems += length;
                }

                decimal averageGain = (decimal)lengthOfAllItems / chest.Count;

                Console.WriteLine($"Average treasure gain: {averageGain:F2} pirate credits.");
            }
        }
    }
}