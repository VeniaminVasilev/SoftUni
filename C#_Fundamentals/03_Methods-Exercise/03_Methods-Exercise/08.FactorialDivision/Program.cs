static long GetFactorialNumber(int number)
{
    long factorialNumber = 1;

    for (long i = number; i > 0; i--)
    {
        factorialNumber *= i;
    }

    return factorialNumber;
}

int number1 = int.Parse(Console.ReadLine());
int number2 = int.Parse(Console.ReadLine());
long factorialNumber1 = GetFactorialNumber(number1);
long factorialNumber2 = GetFactorialNumber(number2);

double resultAfterDivision = (double)factorialNumber1 / factorialNumber2;
Console.WriteLine($"{resultAfterDivision:F2}");