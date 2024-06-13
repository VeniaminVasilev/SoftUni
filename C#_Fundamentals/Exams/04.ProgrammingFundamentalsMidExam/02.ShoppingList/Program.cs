namespace _02.ShoppingList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> shoppingList = Console.ReadLine()
                .Split("!")
                .ToList();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Go Shopping!")
                {
                    Console.WriteLine(string.Join(", ", shoppingList));
                    break;
                }

                string[] tokens = command.Split(" ");
                string action = tokens[0];
                string item = tokens[1];

                if (action == "Urgent")
                {
                    if (!shoppingList.Contains(item))
                    {
                        shoppingList.Insert(0, item);
                    }
                }
                else if (action == "Unnecessary")
                {
                    if (shoppingList.Contains(item))
                    {
                        shoppingList.Remove(item);
                    }
                }
                else if (action == "Correct")
                {
                    string newItem = tokens[2];

                    if (shoppingList.Contains(item))
                    {
                        int indexOfOldItem = shoppingList.IndexOf(item);
                        shoppingList[indexOfOldItem] = newItem;
                    }
                }
                else if (action == "Rearrange")
                {
                    if (shoppingList.Contains(item))
                    {
                        shoppingList.Remove(item);
                        shoppingList.Add(item);
                    }
                }
            }
        }
    }
}