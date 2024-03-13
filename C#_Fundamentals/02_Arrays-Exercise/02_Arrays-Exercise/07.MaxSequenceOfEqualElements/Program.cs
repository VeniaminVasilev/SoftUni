int[] array = Console.ReadLine()
    .Split(" ")
    .Select(int.Parse)
    .ToArray();

int maxCount = 1;
int currentCount = 1;
int number = array[0];

for (int i = 1; i < array.Length; i++)
{
    int previousNumber = array[i - 1];
    int currentNumber = array[i];

    if (previousNumber == currentNumber)
    {
        currentCount++;

        if (currentCount > maxCount)
        {
            maxCount = currentCount;
            number = currentNumber;
        }
    }
    else
    {
        currentCount = 1;
    }
}

for (int i = 0; i < maxCount; i++)
{
    Console.Write($"{number} ");
}