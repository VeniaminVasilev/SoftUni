int number1 = int.Parse(Console.ReadLine());
int number2 = int.Parse(Console.ReadLine());
char operation = char.Parse(Console.ReadLine());

double result = 0.00;

if (operation == '+')
{
    if ((number1 + number2) % 2 == 0)
    {
        result = number1 + number2;
        Console.WriteLine($"{number1} + {number2} = {result} - even");
    } else
    {
        result = number1 + number2;
        Console.WriteLine($"{number1} + {number2} = {result} - odd");
    }
}

if (operation == '-')
{
    if ((number1 - number2) % 2 == 0)
    {
        result = number1 - number2;
        Console.WriteLine($"{number1} - {number2} = {result} - even");
    }
    else
    {
        result = number1 - number2;
        Console.WriteLine($"{number1} - {number2} = {result} - odd");
    }
}

if (operation == '*')
{
    if ((number1 * number2) % 2 == 0)
    {
        result = number1 * number2;
        Console.WriteLine($"{number1} * {number2} = {result} - even");
    }
    else
    {
        result = number1 * number2;
        Console.WriteLine($"{number1} * {number2} = {result} - odd");
    }
}

if (operation == '/')
{
    if (number2 == 0 || number1 == 0)
    {
        Console.WriteLine($"Cannot divide {number1} by zero");
    } else if (number2 > 0)
    {
        result = (number1 * 1.0) / number2;
        Console.WriteLine($"{number1} / {number2} = {result:F2}");
    }
}

if (operation == '%')
{
    if (number2 == 0)
    {
        Console.WriteLine($"Cannot divide {number1} by zero");
    }
    else
    {
        result = number1 % number2;
        Console.WriteLine($"{number1} % {number2} = {result}");
    }
}