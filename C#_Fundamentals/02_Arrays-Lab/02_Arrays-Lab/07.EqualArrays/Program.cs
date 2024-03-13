int[] array1 = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int[] array2 = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int sum = 0;
bool identical = true;

for (int i = 0; i < array1.Length; i++)
{
    if (array1[i] != array2[i])
    {
        Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
        identical = false;
        break;
    }
    sum += array1[i];
}

if (identical)
{
    Console.WriteLine($"Arrays are identical. Sum: {sum}");
}