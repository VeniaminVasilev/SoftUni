static void PrintNxNMatrix(int number)
{
    for (int column = 0; column < number; column++)
    {
        for (int row = 0; row < number; row++)
        {
            Console.Write($"{number} ");
        }
        Console.WriteLine();
    }
}

int number = int.Parse(Console.ReadLine());
PrintNxNMatrix(number);