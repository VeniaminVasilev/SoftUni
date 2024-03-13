while (true)
{
    double number = double.Parse(Console.ReadLine());

    if (number < 0)
    {
        Console.WriteLine($"Negative number!");
        break;
    }

    double result = number * 2.0;
    Console.WriteLine($"Result: {result:F2}");
}