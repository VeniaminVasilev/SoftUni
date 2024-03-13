int numberTournaments = int.Parse(Console.ReadLine());
int startingPoints = int.Parse(Console.ReadLine());

double finalPoints = 0;
finalPoints += startingPoints;
int counterWins = 0;

for (int i = 0; i < numberTournaments; i++)
{
    string phase = Console.ReadLine();

    if (phase == "W")
    {
        finalPoints += 2000;
        counterWins++;
    }
    else if (phase == "F")
    {
        finalPoints += 1200;
    }
    else if (phase == "SF")
    {
        finalPoints += 720;
    }
}

Console.WriteLine($"Final points: {finalPoints}");
Console.WriteLine($"Average points: {Math.Floor((finalPoints - startingPoints) / numberTournaments)}");
Console.WriteLine($"{(((double)counterWins / numberTournaments) * 100):F2}%");