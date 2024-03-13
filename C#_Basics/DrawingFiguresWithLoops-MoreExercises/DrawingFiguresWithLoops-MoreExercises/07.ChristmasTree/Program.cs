int n = int.Parse(Console.ReadLine());

for (int spaceLeft = 0; spaceLeft < n; spaceLeft++)
{
    Console.Write(" ");
}
Console.Write(" | ");
for (int spaceRight = 0; spaceRight < n; spaceRight++)
{
    Console.Write(" ");
}

for (int row = 0; row < n; row++)
{
    Console.WriteLine();

    for (int spaceLeft = 0; spaceLeft < n - row - 1; spaceLeft++)
    {
        Console.Write(" ");
    }

    for (int star = 0; star < row + 1; star++)
    {
        Console.Write("*");
    }

    Console.Write(" | ");

    for (int star = 0; star < row + 1; star++)
    {
        Console.Write("*");
    }

    for (int spaceRight = 0; spaceRight < n; spaceRight++)
    {
        Console.Write(" ");
    }
}