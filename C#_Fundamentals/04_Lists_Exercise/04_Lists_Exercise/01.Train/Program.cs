List<int> wagons = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToList();

int maxCapacityOfWagon = int.Parse(Console.ReadLine());

while (true)
{
    string command = Console.ReadLine();

    if (command == "end")
    {
        Console.WriteLine(string.Join(" ", wagons));
        break;
    }

    string[] tokens = command.Split();

    if (tokens[0] == "Add")
    {
        wagons.Add(int.Parse(tokens[1]));
    }
    else
    {
        for (int i = 0; i < wagons.Count; i++)
        {
            if (wagons[i] + int.Parse(tokens[0]) <= maxCapacityOfWagon)
            {
                wagons[i] += int.Parse(tokens[0]);
                break;
            }
        }
    }
}