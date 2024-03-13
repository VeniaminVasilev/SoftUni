int n = int.Parse(Console.ReadLine());

if (n % 2 == 1)
{
    for (int row = 1; row <= (n / 2) + 1; row++)
    {
        if (n == 1)
        {
            Console.WriteLine("*");
            break;
        }

        for (int dash = row; dash <= n / 2; dash++)
        {
            Console.Write("-");
        }

        if (row == 1)
        {
            Console.Write("*");
        }
        else if (row == 2)
        {
            Console.Write("*");

            for (int dash = 1; dash < row; dash++)
            {
                Console.Write("-");
            }

            Console.Write("*");
        }
        else if (row > 2)
        {
            Console.Write("*");

            for (int dash = row; dash >= 3; dash--)
            {
                Console.Write("-");
            }

            Console.Write("-");

            for (int dash = row; dash >= 3; dash--)
            {
                Console.Write("-");
            }

            Console.Write("*");
        }

        for (int dash = row; dash <= n / 2; dash++)
        {
            Console.Write("-");
        }

        Console.WriteLine();
    }

    for (int row = (n / 2); row >= 1; row--)
    {
        if (n == 1)
        {
            Console.WriteLine("*");
            break;
        }

        for (int dash = row; dash <= n / 2; dash++)
        {
            Console.Write("-");
        }

        if (row == 1)
        {
            Console.Write("*");
        }
        else if (row == 2)
        {
            Console.Write("*");

            for (int dash = 1; dash < row; dash++)
            {
                Console.Write("-");
            }

            Console.Write("*");
        }
        else if (row > 2)
        {
            Console.Write("*");

            for (int dash = 1; dash < row - 1; dash++)
            {
                Console.Write("-");
            }

            for (int dash = 1; dash < row; dash++)
            {
                Console.Write("-");
            }

            Console.Write("*");
        }

        for (int dash = row; dash <= n / 2; dash++)
        {
            Console.Write("-");
        }

        Console.WriteLine();
    }
}

if (n % 2 == 0)
{
    for (int row = 1; row <= n / 2; row++)
    {
        if (n == 2)
        {
            Console.WriteLine("**");
            break;
        }

        for (int dash = row; dash <= (n / 2) - 1; dash++)
        {
            Console.Write("-");
        }

        Console.Write("*");

        for (int dash = 1; dash < row; dash++)
        {
            Console.Write("-");
        }

        for (int dash = 1; dash < row; dash++)
        {
            Console.Write("-");
        }

        Console.Write("*");

        for (int dash = row; dash <= (n / 2) - 1; dash++)
        {
            Console.Write("-");
        }

        Console.WriteLine();
    }

    for (int row = (n / 2) - 1; row >= 1; row--)
    {
        if (n == 2)
        {
            Console.WriteLine("**");
            break;
        }

        for (int dash = row; dash <= (n / 2) - 1; dash++)
        {
            Console.Write("-");
        }

        Console.Write("*");

        for (int dash = 1; dash < row; dash++)
        {
            Console.Write("-");
        }

        for (int dash = 1; dash < row; dash++)
        {
            Console.Write("-");
        }

        Console.Write("*");

        for (int dash = row; dash <= (n / 2) - 1; dash++)
        {
            Console.Write("-");
        }

        Console.WriteLine();
    }
}