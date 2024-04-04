static int GetSmallestNumber()
{
    int smallestNumber = int.MaxValue;

    for (int i = 0; i < 3; i++)
    {
        int currentNumber = int.Parse(Console.ReadLine());

        if (currentNumber < smallestNumber)
        {
            smallestNumber = currentNumber;
        }
    }

    return smallestNumber;
}

int smallestNumber = GetSmallestNumber();
Console.WriteLine(smallestNumber);