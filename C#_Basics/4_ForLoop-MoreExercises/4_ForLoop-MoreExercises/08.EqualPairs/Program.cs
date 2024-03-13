int numberOfPairs = int.Parse(Console.ReadLine());
int currentSum = 0;

int number1 = int.Parse(Console.ReadLine());
int number2 = int.Parse(Console.ReadLine());

currentSum += number1 + number2;
int difference = 0;
for (int i = 0; i < numberOfPairs - 1; i++)
{
    int newNumber1 = int.Parse(Console.ReadLine());
    int newNumber2 = int.Parse(Console.ReadLine());

    int sum = newNumber1 + newNumber2;

    if (sum != currentSum)
    {
        int newDifference = Math.Abs(sum - currentSum);

        if (newDifference > difference)
        {
            difference = newDifference;
        }
    }

    currentSum = sum;
}

if (difference != 0)
{
    Console.WriteLine($"No, maxdiff={difference}");
} else
{
    Console.WriteLine($"Yes, value={currentSum}");
}