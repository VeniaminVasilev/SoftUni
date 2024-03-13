int[] array = Console.ReadLine()
    .Split(" ")
    .Select(int.Parse)
    .ToArray();

int rotations = int.Parse(Console.ReadLine());

for (int i = 0; i < rotations; i++)
{
    int first = array[0];
    for (int j = 0; j < array.Length - 1; j++)
    {
        array[j] = array[j + 1];
    }
    array[array.Length - 1] = first;
}

Console.WriteLine(string.Join(" ", array));