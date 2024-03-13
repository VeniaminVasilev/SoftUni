int[] array = Console.ReadLine()
    .Split(" ")
    .Select(int.Parse)
    .ToArray();

bool sumsAreEqual = false;

for (int i = 0; i < array.Length; i++)
{
    int leftSum = 0;
    int rightSum = 0;

    if (array.Length == 1)
    {
        Console.WriteLine("0");
        sumsAreEqual = true;
        break;
    }

    for (int j = 0; j < i; j++)
    {
        leftSum += array[j];
    }

    for (int k = i + 1; k < array.Length; k++)
    {
        rightSum += array[k];
    }


    if (leftSum == rightSum)
    {
        Console.WriteLine(i);
        sumsAreEqual = true;
    }
}

if (sumsAreEqual == false)
{
    Console.WriteLine("no");
}