int lines = int.Parse(Console.ReadLine());

int[] arrayFirst = new int[lines];
int[] arraySecond = new int[lines];

for (int i = 0; i < lines; i++)
{
    int[] currentLineArray = Console.ReadLine()
        .Split(" ")
        .Select(int.Parse)
        .ToArray();

    if (i % 2 == 0)
    {
        arraySecond[i] = currentLineArray[0];
        arrayFirst[i] = currentLineArray[1];
    }
    else
    {
        arrayFirst[i] = currentLineArray[0];
        arraySecond[i] = currentLineArray[1];
    }
}

Console.WriteLine(string.Join(" ", arraySecond));
Console.WriteLine(string.Join(" ", arrayFirst));