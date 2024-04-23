List<int> list = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToList();

while (true)
{
    string command = Console.ReadLine();

    if (command == "end")
    {
        Console.WriteLine(string.Join(" ", list));
        break;
    }

    string[] tokens = command.Split();

    if (tokens[0] == "Delete")
    {
        list.RemoveAll(x => x == int.Parse(tokens[1]));
    }
    else if (tokens[0] == "Insert")
    {
        list.Insert(int.Parse(tokens[2]), int.Parse(tokens[1]));
    }
}