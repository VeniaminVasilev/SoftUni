int n = int.Parse(Console.ReadLine());
// Line 1:
for (int star = 0; star < n * 2; star++)
{
    Console.Write("*");
}

for (int space = 0; space < n; space++)
{
    Console.Write(" ");
}

for (int star = 0; star < n * 2; star++)
{
    Console.Write("*");
}

// Other rows:
for (int i = 0; i < n - 2; i++)
{
    Console.WriteLine();

    int middleLine = 0;
    if (n % 2 == 0)
    { middleLine = n / 2; }
    else
    { middleLine = (n / 2) + 1; }

    if (i == middleLine - 2)
    {
        Console.Write("*");

        for (int slash = 0; slash < (n * 2) - 2; slash++)
        {
            Console.Write("/");
        }

        Console.Write("*");

        for (int verticalLine = 0; verticalLine < n; verticalLine++)
        {
            Console.Write("|");
        }

        Console.Write("*");

        for (int slash = 0; slash < (n * 2) - 2; slash++)
        {
            Console.Write("/");
        }

        Console.Write("*");
    }
    else
    {
        Console.Write("*");

        for (int slash = 0; slash < (n * 2) - 2; slash++)
        {
            Console.Write("/");
        }

        Console.Write("*");

        for (int space = 0; space < n; space++)
        {
            Console.Write(" ");
        }

        Console.Write("*");

        for (int slash = 0; slash < (n * 2) - 2; slash++)
        {
            Console.Write("/");
        }

        Console.Write("*");
    }
}

// Last Line:
Console.WriteLine();

for (int star = 0; star < n * 2; star++)
{
    Console.Write("*");
}

for (int space = 0; space < n; space++)
{
    Console.Write(" ");
}

for (int star = 0; star < n * 2; star++)
{
    Console.Write("*");
}