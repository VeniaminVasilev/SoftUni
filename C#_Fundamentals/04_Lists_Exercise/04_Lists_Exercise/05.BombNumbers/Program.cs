List<int> list = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToList();

int[] special = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int specialBombNumber = special[0];
int bombPower = special[1];

for (int i = 0; i < list.Count; i++)
{
    if (list[i] == specialBombNumber)
    {
        for (int j = 1; j <= bombPower; j++)
        {
            if (i - j < 0)
            {
                break;
            }
            else
            {
                list[i - j] = 0;
            }
        }

        for (int j = 1; j <= bombPower; j++)
        {
            if (i + j > list.Count - 1)
            { 
                break;
            }
            else
            {
                list[i + j] = 0;
            }
        }

        list[i] = 0;
    }
}

Console.WriteLine(list.Sum());