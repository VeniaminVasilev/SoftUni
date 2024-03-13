int number = int.Parse(Console.ReadLine());

while (true)
{
    if (number % 10 == 0)
    {
        Console.WriteLine($"The number is divisible by 10");
        break;
    }

    if (number % 7 == 0)
    {
        Console.WriteLine($"The number is divisible by 7");
        break;
    }

    if (number % 6 == 0)
    {
        Console.WriteLine($"The number is divisible by 6");
        break;
    }

    if (number % 3 == 0)
    {
        Console.WriteLine($"The number is divisible by 3");
        break;
    }

    if (number % 2 == 0)
    {
        Console.WriteLine($"The number is divisible by 2");
        break;
    }

        Console.WriteLine("Not divisible");
    break;
}