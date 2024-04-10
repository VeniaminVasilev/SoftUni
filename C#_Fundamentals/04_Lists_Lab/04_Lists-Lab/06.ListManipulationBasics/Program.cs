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

    switch (tokens[0])
    {
        case "Add":
            int numberToAdd = int.Parse(tokens[1]);
            list.Add(numberToAdd);
            break;
        case "Remove":
            int numberToRemove = int.Parse(tokens[1]);
            list.Remove(numberToRemove);
            break;
        case "RemoveAt":
            int indexToRemove = int.Parse(tokens[1]);
            list.RemoveAt(indexToRemove);
            break;
        case "Insert":
            int numberToInsert = int.Parse(tokens[1]);
            int indexToInsert = int.Parse(tokens[2]);
            list.Insert(indexToInsert, numberToInsert);
            break;
    }
}