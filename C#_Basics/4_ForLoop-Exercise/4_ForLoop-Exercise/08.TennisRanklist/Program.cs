int tournaments = int.Parse(Console.ReadLine());
int startingPoints = int.Parse(Console.ReadLine());

int finalPoints = 0;

int win = 0;

finalPoints += startingPoints;

for (int i = 0; i < tournaments; i++)
{
    string phase = Console.ReadLine();
    if (phase == "W")
    {
        win++;
        finalPoints += 2000;
    } else if (phase == "F")
    {
        finalPoints += 1200;
    } else if (phase == "SF")
    {
        finalPoints += 720;
    }
}

double averagePoints = Math.Floor((finalPoints - startingPoints) / (double)tournaments);
double percentageWin = (win / (double)tournaments) * 100.00;

Console.WriteLine($"Final points: {finalPoints}");
Console.WriteLine($"Average points: {averagePoints}");
Console.WriteLine($"{percentageWin:F2}%");