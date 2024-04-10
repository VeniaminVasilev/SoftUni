List<int> list = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToList();

bool hasChanges = false;

while (true)
{
    string command = Console.ReadLine();

    if (command == "end")
    {
        if (hasChanges)
        {
            Console.WriteLine(string.Join(" ", list));
        }
        break;
    }

    string[] tokens = command.Split();

    switch (tokens[0])
    {
        case "Contains":
            if (list.Contains(int.Parse(tokens[1])))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No such number");
            }
            break;
        case "PrintEven":
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] % 2 == 0)
                {
                    Console.Write($"{list[i]} ");
                }
            }
            Console.WriteLine();
            break;
        case "PrintOdd":
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] % 2 != 0)
                {
                    Console.Write($"{list[i]} ");
                }
            }
            Console.WriteLine();
            break;
        case "GetSum":
            int sum = 0;
            for (int i = 0; i < list.Count; i++)
            {
                int currentNumber = list[i];
                sum += currentNumber;
            }
            Console.WriteLine(sum);
            break;
        case "Filter":
            if (tokens[1] == "<")
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] < int.Parse(tokens[2]))
                    {
                        Console.Write($"{list[i]} ");
                    }
                }
            }
            else if (tokens[1] == ">")
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] > int.Parse(tokens[2]))
                    {
                        Console.Write($"{list[i]} ");
                    }
                }
            }
            else if (tokens[1] == ">=")
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] >= int.Parse(tokens[2]))
                    {
                        Console.Write($"{list[i]} ");
                    }
                }
            }
            else if (tokens[1] == "<=")
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] <= int.Parse(tokens[2]))
                    {
                        Console.Write($"{list[i]} ");
                    }
                }
            }
            Console.WriteLine();
            break;
        case "Add":
            int numberToAdd = int.Parse(tokens[1]);
            list.Add(numberToAdd);
            hasChanges = true;
            break;
        case "Remove":
            int numberToRemove = int.Parse(tokens[1]);
            list.Remove(numberToRemove);
            hasChanges = true;
            break;
        case "RemoveAt":
            int indexToRemove = int.Parse(tokens[1]);
            list.RemoveAt(indexToRemove);
            hasChanges = true;
            break;
        case "Insert":
            int numberToInsert = int.Parse(tokens[1]);
            int indexToInsert = int.Parse(tokens[2]);
            list.Insert(indexToInsert, numberToInsert);
            hasChanges = true;
            break;
    }
}