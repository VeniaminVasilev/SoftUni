int number1 = int.Parse(Console.ReadLine());
char operation = char.Parse(Console.ReadLine());
int number2 = int.Parse(Console.ReadLine());

static double Calculate(int number1, char operation, int number2)
{
    double result = 0;

    switch (operation)
    {
        case '/':
            result = number1 / number2;
            break;
        case '*':
            result = number1 * number2;
            break;
        case '+':
            result = number1 + number2;
            break;
        case '-':
            result = number1 - number2;
            break;
        default:
            break;
    }

    return result;
}

double result = Calculate(number1, operation, number2);
Console.WriteLine(result);