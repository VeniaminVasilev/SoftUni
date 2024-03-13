string input = string.Empty;
double total = 0;

while (true)
{
    input = Console.ReadLine();

    if (input == "NoMoreMoney")
    {
        break;
    }

    double increase = double.Parse(input);

    if (increase < 0)
    {
        Console.WriteLine($"Invalid operation!");
        break;
    }

    Console.WriteLine($"Increase: {increase:F2}");
    total += increase;
}

Console.WriteLine($"Total: {total:F2}");