int n = int.Parse(Console.ReadLine());
int l = int.Parse(Console.ReadLine());

for (int i = 1; i < n; i++)
{
    for (int i2 = 1; i2 < n; i2++)
    {
        for (int j = 97; j < (97 + l); j++)
        {
            for (int k = 97; k < (97 + l); k++)
            {
                for (int m = 1; m <= n; m++)
                {
                    char currentChar = (char)j;
                    char currentChar2 = (char)k;

                    if (m > i && m > i2)
                    {
                        Console.Write($"{i}{i2}{currentChar}{currentChar2}{m} ");
                    }
                }
            }
        }
    }
}