int n = int.Parse(Console.ReadLine());

//Roof: rows = (n + 1) / 2
for (int row = 1; row <= (n + 1) / 2; row++)
{
    if (n % 2 == 0)
    {
        for (int horizontalLine = row; horizontalLine <= (n / 2) - 1; horizontalLine++)
        {
            Console.Write("-");
        }

        Console.Write("**");

        for (int star = 1; star < row; star++)
        {
            Console.Write("**");
        }

        for (int horizontalLine = row; horizontalLine <= (n / 2) - 1; horizontalLine++)
        {
            Console.Write("-");
        }
        Console.WriteLine();
    }
    else
    {
        for (int horizontalLine = row; horizontalLine <= n / 2; horizontalLine++)
        {
            Console.Write("-");
        }

        Console.Write("*");

        for (int star = 1; star < row; star++)
        {
            Console.Write("**");
        }

        for (int horizontalLine = row; horizontalLine <= n / 2; horizontalLine++)
        {
            Console.Write("-");
        }
        Console.WriteLine();
    }
}

// Other side of the house:
for (int row = 1; row <= n / 2; row++)
{
    Console.Write("|");

    for (int star = 1; star <= n - 2; star++)
    {
        Console.Write("*");
    }

    Console.Write("|");
    Console.WriteLine();
}