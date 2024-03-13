int locations = int.Parse(Console.ReadLine());

for (int i = 0; i < locations; i++)
{
    double expectedAverageGoldMinedPerDay = double.Parse(Console.ReadLine());
    int daysPerLocation = int.Parse(Console.ReadLine());

    double amountGoldMined = 0;

    for (int j = 0; j < daysPerLocation; j++)
    {
        double goldMinedForTheDay = double.Parse(Console.ReadLine());
        amountGoldMined += goldMinedForTheDay;
    }

    double averageGoldMinedPerDay = amountGoldMined / daysPerLocation;

    if (averageGoldMinedPerDay >= expectedAverageGoldMinedPerDay)
    {
        Console.WriteLine($"Good job! Average gold per day: {averageGoldMinedPerDay:F2}.");
    }
    else
    {
        Console.WriteLine($"You need {Math.Abs(averageGoldMinedPerDay - expectedAverageGoldMinedPerDay):F2} gold.");
    }
}