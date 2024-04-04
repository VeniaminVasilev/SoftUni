static int GetSumOfTwoIntegers(int integer1, int integer2)
{
    int sum = integer1 + integer2;
    return sum;
}

static int GetResultOfSubtraction(int integer1, int integer2)
{
    int resultOfSubtraction = integer1 - integer2;
    return resultOfSubtraction;
}

int number1 = int.Parse(Console.ReadLine());
int number2 = int.Parse(Console.ReadLine());
int number3 = int.Parse(Console.ReadLine());

int sumFirstTwoNumbers = GetSumOfTwoIntegers(number1, number2);
int resultOfSubtraction = GetResultOfSubtraction(sumFirstTwoNumbers, number3);
Console.WriteLine(resultOfSubtraction);