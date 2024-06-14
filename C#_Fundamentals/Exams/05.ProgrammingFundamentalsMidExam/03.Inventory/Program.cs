namespace _03.Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine()
                .Split(", ")
                .ToList();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Craft!")
                {
                    Console.WriteLine(string.Join(", ", items));
                    break;
                }

                string[] tokens = command.Split(" - ");
                string action = tokens[0];

                if (action == "Collect")
                {
                    string item = tokens[1];
                    if (!items.Contains(item))
                    {
                        items.Add(item);
                    }
                }
                else if (action == "Drop")
                {
                    string item = tokens[1];
                    if (items.Contains(item))
                    {
                        items.Remove(item);
                    }
                }
                else if (action == "Combine Items")
                {
                    string[] array = tokens[1].Split(":");
                    string oldItem = array[0];
                    string newItem = array[1];

                    if (items.Contains(oldItem))
                    {
                        int indexOfOldItem = items.IndexOf(oldItem);
                        items.Insert(indexOfOldItem + 1, newItem);
                    }
                }
                else if (action == "Renew")
                {
                    string item = tokens[1];
                    if (items.Contains(item))
                    {
                        items.Remove(item);
                        items.Add(item);
                    }
                }
            }
        }
    }
}