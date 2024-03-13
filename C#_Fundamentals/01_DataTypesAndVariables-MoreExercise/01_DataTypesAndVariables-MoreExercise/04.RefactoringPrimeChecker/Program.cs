int maxNumber = int.Parse(Console.ReadLine());
for (int currentNumber = 2; currentNumber <= maxNumber; currentNumber++)
{
    bool primeNumber = true;
    for (int divisionNumber = 2; divisionNumber < currentNumber; divisionNumber++)
    {
        if (currentNumber % divisionNumber == 0)
        {
            primeNumber = false;
            break;
        }
    }

    if (primeNumber)
    {
        Console.WriteLine($"{currentNumber} -> true");
    }
    else
    {
        Console.WriteLine($"{currentNumber} -> false");
    }
}