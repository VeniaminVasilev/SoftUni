decimal savings = decimal.Parse(Console.ReadLine());
List<int> initialDrumSet = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

List<int> currentDrumSet = new List<int>();
currentDrumSet.AddRange(initialDrumSet);

while (true)
{
    string command = Console.ReadLine();
    
    if (command == "Hit it again, Gabsy!")
    {
        break;
    }

    int hitPower = int.Parse(command);

    for (int i = 0; i < currentDrumSet.Count; i++)
    {
        currentDrumSet[i] -= hitPower;
    }

    for (int i = 0; i < currentDrumSet.Count; i++)
    {
        if (currentDrumSet[i] <= 0)
        {
            if (initialDrumSet[i] * 3 <= savings)
            {
                currentDrumSet[i] = initialDrumSet[i];
                savings -= initialDrumSet[i] * 3;
            }
            else
            {
                currentDrumSet.RemoveAt(i);
                initialDrumSet.RemoveAt(i);
                i--;
            }
        }
    }
}

Console.WriteLine(string.Join(" ", currentDrumSet));
Console.WriteLine($"Gabsy has {savings:F2}lv.");