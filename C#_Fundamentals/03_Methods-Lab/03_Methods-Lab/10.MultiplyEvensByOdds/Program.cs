static void GetMultipleOfEvenAndOdds(int number)
{
    int sumEven = GetSumOfEvenDigits(number);
    int sumOdd = GetSumOfOddDigits(number);
    Console.WriteLine(sumEven * sumOdd);
}

static int GetSumOfEvenDigits(int number)
{
    int sumOfEvenDigits = 0;

    while (number > 0)
    {
        int nextNumber = number % 10;
        number /= 10;
        if (nextNumber % 2 == 0)
        {
            sumOfEvenDigits += nextNumber;
        }
    }

    return sumOfEvenDigits;
}

static int GetSumOfOddDigits(int number)
{
    int sumOfOddDigits = 0;

    while (number > 0)
    {
        int nextNumber = number % 10;
        number /= 10;
        if (nextNumber % 2 != 0)
        {
            sumOfOddDigits += nextNumber;
        }
    }

    return sumOfOddDigits;
}

int number = Math.Abs(int.Parse(Console.ReadLine()));
GetMultipleOfEvenAndOdds(number);