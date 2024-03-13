int start12 = int.Parse(Console.ReadLine());
int start34 = int.Parse(Console.ReadLine());
int addon12 = int.Parse(Console.ReadLine());
int addon34 = int.Parse(Console.ReadLine());

for (int i = start12; i <= (start12 + addon12); i++)
{
    if (i % 2 == 0 || i % 3 == 0 || i % 5 == 0 || i % 7 == 0)
    {
        continue;
    }

    for (int j = start34; j <= (start34 + addon34); j++)
    {
        if (j % 2 == 0 || j % 3 == 0 || j % 5 == 0 || j % 7 == 0)
        {
            continue;
        }
        Console.WriteLine($"{i}{j}");
    }
}