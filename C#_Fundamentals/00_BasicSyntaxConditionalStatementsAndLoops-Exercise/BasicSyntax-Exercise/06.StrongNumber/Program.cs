int number = int.Parse(Console.ReadLine());

string numberToString = number.ToString();
int numberLength = numberToString.Length;
int sumOfAllFactorials = 0;

for (int i = 0; i < numberLength; i++)
{
    char currentNumberChar = numberToString[i];
    int currentNumber = int.Parse(currentNumberChar.ToString());
    int currentFactorialSum = currentNumber;

    for (int j = currentNumber - 1; j > 0; j--)
    {
        if (j != 0) { currentFactorialSum *= j; }
    }

    if (currentFactorialSum == 0)
    {
        sumOfAllFactorials += 1;
    }
    else
    {
        sumOfAllFactorials += currentFactorialSum;
    }
}

if (number == sumOfAllFactorials)
{
    Console.WriteLine("yes");
}
else
{
    Console.WriteLine("no");
}