int[] array = Console.ReadLine()
    .Split(" ")
    .Select(int.Parse)
    .ToArray();

for (int i = 0; i < array.Length - 1; i++)
{
    bool currentNumberIsTopInteger = true;
    for (int j = i + 1; j < array.Length; j++)
    {
        if (array[i] <= array[j]) { currentNumberIsTopInteger = false; }
    }

    if (currentNumberIsTopInteger)
    {
        Console.Write(array[i] + " ");
    }
}
Console.Write(array[array.Length - 1]);