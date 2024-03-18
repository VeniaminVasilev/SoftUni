int[] inputArray = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int lengthK = inputArray.Length / 4;
int[] firstRow = new int[inputArray.Length / 2];
int[] secondRow = new int[inputArray.Length / 2];

for (int i = 0; i < lengthK; i++)
{
    firstRow[i] = inputArray[lengthK - 1 - i];
}

int counter = 1;
for (int i = lengthK; i < inputArray.Length / 2; i++)
{
    firstRow[i] = inputArray[inputArray.Length - counter];
    counter++;
}

for (int i = lengthK; i < inputArray.Length - lengthK; i++)
{
    secondRow[i - lengthK] = inputArray[i];
}

int[] sumOfFolded = new int[inputArray.Length / 2];

for (int i = 0; i < inputArray.Length / 2; i++)
{
    sumOfFolded[i] = firstRow[i] + secondRow[i];
}

Console.WriteLine(string.Join(" ", sumOfFolded));