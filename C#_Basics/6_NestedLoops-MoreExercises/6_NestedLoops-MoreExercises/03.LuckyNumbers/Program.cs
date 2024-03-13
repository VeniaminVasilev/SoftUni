int n = int.Parse(Console.ReadLine());

for (int first = 1; first <= 9; first++)
{
    for (int second = 1; second <= 9; second++)
    {
        if (n % (first + second) != 0)
        {
            continue;
        }

        for (int third = 1; third <= 9; third++)
        {
            for (int fourth = 1; fourth <= 9; fourth++)
            {
                if ((first + second) == (third + fourth))
                {
                    Console.Write($"{first}{second}{third}{fourth} ");
                }
            }
        }
    }
}