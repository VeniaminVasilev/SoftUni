int length = int.Parse(Console.ReadLine());

string command = Console.ReadLine();
int bestSumDNA = int.MinValue;
int currentSumDNA = 0;
int currentCounter = 0;
int maxCounter = int.MinValue;
int bestFirstAppearance = int.MaxValue;
int currentAppearance = int.MaxValue;
int bestSequenceIndex = 0;
int currentIndex = 0;
string strongestSequence = string.Empty;

while (command != "Clone them!")
{
    currentIndex++;
    currentCounter = 0;
    currentAppearance = int.MaxValue;
    currentSumDNA = 0;

    int[] currentDNA = command
        .Split("!", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    for (int i = 0; i < length - 1; i++)
    {
        int currentNumber = currentDNA[i];
        int nextNumber = currentDNA[i + 1];

        if (currentNumber == 1 && nextNumber == 1)
        {
            if (currentCounter == 0)
            {
                currentAppearance = i;
            }
            currentCounter++;
        }
    }

    foreach (int one in currentDNA)
    {
        if (one == 1)
        {
            currentSumDNA++;
        }
    }

    if (currentCounter > maxCounter || (currentCounter > maxCounter && currentAppearance < bestFirstAppearance) || (currentCounter == maxCounter && currentAppearance < bestFirstAppearance) || (currentCounter == maxCounter && currentAppearance == bestFirstAppearance && currentSumDNA > bestSumDNA))
    {
        maxCounter = currentCounter;
        bestFirstAppearance = currentAppearance;
        bestSumDNA = currentSumDNA;
        bestSequenceIndex = currentIndex;
        strongestSequence = string.Join(" ", currentDNA);
    }

    command = Console.ReadLine();
}

Console.WriteLine($"Best DNA sample {bestSequenceIndex} with sum: {bestSumDNA}.");
Console.WriteLine($"{strongestSequence}");