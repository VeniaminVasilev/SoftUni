int maxNumber1 = int.Parse(Console.ReadLine());
int maxNumber2 = int.Parse(Console.ReadLine());
int maxNumber3 = int.Parse(Console.ReadLine());

for (int i = 2; i <= maxNumber1; i++)
{
    if (i % 2 != 0) continue;

    for (int j = 2; j <= maxNumber2; j++)
    {
        if (j == 4 || j == 6 || j == 8 || j == 9) continue;

        for (int k = 2; k <= maxNumber3; k++)
        {
            if (k % 2 != 0) continue;

            Console.WriteLine($"{i} {j} {k}");
        }
    }
}