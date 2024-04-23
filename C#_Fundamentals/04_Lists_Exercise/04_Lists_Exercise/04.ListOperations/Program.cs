List<int> list = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToList();

while (true)
{
    string command = Console.ReadLine();

    if (command == "End")
    {
        Console.WriteLine(string.Join(" ", list));
        break;
    }

    string[] tokens = command.Split();

    if (tokens[0] == "Add")
    {
        list.Add(int.Parse(tokens[1]));
    }
    else if (tokens[0] == "Insert")
    {
        if (int.Parse(tokens[2]) < 0 || int.Parse(tokens[2]) >= list.Count)
        {
            Console.WriteLine($"Invalid index");
        }
        else
        {
            list.Insert(int.Parse(tokens[2]), int.Parse(tokens[1]));
        }
    }
    else if (tokens[0] == "Remove")
    {
        if (int.Parse(tokens[1]) < 0 || int.Parse(tokens[1]) >= list.Count)
        {
            Console.WriteLine($"Invalid index");
        }
        else
        {
            list.RemoveAt(int.Parse(tokens[1]));
        }
    }
    else if (tokens[0] == "Shift" && tokens[1] == "left")
    {
        for (int i = 0; i < int.Parse(tokens[2]); i++)
        {
            list.Add(list[0]);
            list.RemoveAt(0);
        }
    }
    else if (tokens[0] == "Shift" && tokens[1] == "right")
    {
        for (int i = 0; i < int.Parse(tokens[2]); i++)
        {
            list.Insert(0, list[list.Count - 1]);
            list.RemoveAt(list.Count - 1);
        }
    }
}