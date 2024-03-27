static void printingTriangle(int input)
{
    for (int i = 1; i <= input; i++)
    {
        for (int j = 1; j <= i; j++)
        {
            Console.Write($"{j} ");
        }
        Console.WriteLine();
    }

    for (int i = input - 1; i >= 1; i--)
    {
        for (int j = 1; j <= i; j++)
        {
            Console.Write($"{j} ");
        }
        Console.WriteLine();
    }
}

printingTriangle(int.Parse(Console.ReadLine()));