string bestPlayer = string.Empty;
int maxPoints = 0;

while (true)
{
    string name = Console.ReadLine();

    if (name == "Stop")
    {
        break;
    }

    int n = name.Length;
    int currentPoints = 0;

    for (int i = 0; i < n; i++)
    {
        char currentDigit = name[i];
        int currentNumber = (int)currentDigit;

        int readNumber = int.Parse(Console.ReadLine());

        if (currentNumber == readNumber)
        {
            currentPoints += 10;
        }
        else
        { currentPoints += 2; }
    }

    if (currentPoints >= maxPoints)
    {
        maxPoints = currentPoints;
        bestPlayer = name;
    }
}

Console.WriteLine($"The winner is {bestPlayer} with {maxPoints} points!");