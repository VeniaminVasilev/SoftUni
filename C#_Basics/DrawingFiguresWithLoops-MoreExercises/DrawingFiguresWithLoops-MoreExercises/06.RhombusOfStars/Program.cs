int n = int.Parse(Console.ReadLine());

for (int row = 1; row <= n; row++)
{
    for (int interval = 0; interval < n - row; interval++)
    {
        Console.Write(" ");
    }

    Console.Write("*");

    for (int star = 0; star < row - 1; star++)
    {
        Console.Write(" *");
    }

    for (int interval = 0; interval < n - row; interval++)
    {
        Console.Write(" ");
    }
    Console.WriteLine();
}

for (int row = n - 1; row >= 1; row--)
{
    for (int interval = 0; interval < n - row; interval++)
    {
        Console.Write(" ");
    }

    Console.Write("*");

    for (int star = 0; star < row - 1; star++)
    {
        Console.Write(" *");
    }

    for (int interval = 0; interval < n - row; interval++)
    {
        Console.Write(" ");
    }
    Console.WriteLine();
}