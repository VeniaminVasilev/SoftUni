List<int> list = Console.ReadLine()
    .Split(" ")
    .Select(int.Parse)
    .ToList();

decimal resultLeft = 0;
decimal resultRight = 0;

for (int i = 0; i < (list.Count - 1) / 2; i++)
{
    if (list[i] == 0 && resultLeft != 0)
    {
        resultLeft *= 0.8m;
    } else
    {
        resultLeft += list[i];
    }
}

for (int i = list.Count - 1; i > (list.Count - 1) / 2; i--)
{
    if (list[i] == 0 && resultRight != 0)
    {
        resultRight *= 0.8m;
    }
    else
    {
        resultRight += list[i];
    }
}

if (resultLeft > resultRight)
{
    Console.WriteLine($"The winner is right with total time: {resultRight:#.#}");
}
else if (resultLeft < resultRight)
{
    Console.WriteLine($"The winner is left with total time: {resultLeft:#.#}");
}