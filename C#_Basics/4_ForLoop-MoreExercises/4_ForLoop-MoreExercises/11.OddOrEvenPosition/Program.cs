double number = double.Parse(Console.ReadLine());

double oddSum = 0;
double oddMin = int.MaxValue;
double oddMax = int.MinValue;
double evenSum = 0;
double evenMin = int.MaxValue;
double evenMax = int.MinValue;

for (int i = 1; i <= number; i++)
{
    double currentNumber = double.Parse(Console.ReadLine());

    if (i % 2 == 1)
    {
        oddSum += currentNumber;

        if (currentNumber < oddMin)
        {
            oddMin = currentNumber;
        }

        if (currentNumber > oddMax)
        {
            oddMax = currentNumber;
        }
    }
    else if (i % 2 == 0)
    {
        evenSum += currentNumber;

        if (currentNumber < evenMin)
        {
            evenMin = currentNumber;
        }

        if (currentNumber > evenMax)
        {
            evenMax = currentNumber;
        }
    }
}

Console.WriteLine($"OddSum={oddSum:F2},");

if (oddMin == int.MaxValue)
{
    Console.WriteLine("OddMin=No,");
}
else
{
    Console.WriteLine($"OddMin={oddMin:F2},");
}

if (oddMax == int.MinValue)
{
    Console.WriteLine("OddMax=No,");
}
else
{
    Console.WriteLine($"OddMax={oddMax:F2},");
}

Console.WriteLine($"EvenSum={evenSum:F2},");

if (evenMin == int.MaxValue)
{
    Console.WriteLine("EvenMin=No,");
}
else
{
    Console.WriteLine($"EvenMin={evenMin:F2},");
}

if (evenMax == int.MinValue)
{
    Console.WriteLine("EvenMax=No");
}
else
{
    Console.WriteLine($"EvenMax={evenMax:F2}");
}