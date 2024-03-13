int lines = int.Parse(Console.ReadLine());

for (int i = 0; i < lines; i++)
{
    string currentNumber = Console.ReadLine();
    string number1 = string.Empty;
    string number2 = string.Empty;
    bool number1Ready = false;

    for (int j = 0; j < currentNumber.Length; j++)
    {
        if (currentNumber[j] == ' ')
        {
            number1Ready = true;
        }

        if (number1Ready == false && currentNumber[j] != ' ')
        {
            number1 += currentNumber[j];
        }

        if (number1Ready && currentNumber[j] != ' ')
        {
            number2 += currentNumber[j];
        }
    }

    long intNumber1 = long.Parse(number1);
    long intNumber2 = long.Parse(number2);
    long sum = 0;

    if (intNumber1 >= intNumber2)
    {
        intNumber1 = Math.Abs(intNumber1);
        
        while (intNumber1 > 0)
        {
            sum += intNumber1 % 10;
            intNumber1 /= 10;
        }
    }
    else if (intNumber2 > intNumber1)
    {
        intNumber2 = Math.Abs(intNumber2);

        while (intNumber2 > 0)
        {
            sum += intNumber2 % 10;
            intNumber2 /= 10;
        }
    }
    Console.WriteLine(sum);
}