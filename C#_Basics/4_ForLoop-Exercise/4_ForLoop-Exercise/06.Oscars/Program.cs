string actor = Console.ReadLine();
double pointsFromAcademy = double.Parse(Console.ReadLine());
int numberOfRaters = int.Parse(Console.ReadLine());

double sumPoints = 0;
sumPoints += pointsFromAcademy;

for (int i = 0; i < numberOfRaters; i++)
{
    string nameOfRater = Console.ReadLine();
    double pointsFromRater = double.Parse(Console.ReadLine());

    int pointsFromNameOfRater = nameOfRater.Length;
    double finalPointsFromRater = (pointsFromNameOfRater * pointsFromRater) / 2;
    sumPoints += finalPointsFromRater;

    if (sumPoints > 1250.5)
    {
        break;
    }
}

if (sumPoints > 1250.5)
{
    Console.WriteLine($"Congratulations, {actor} got a nominee for leading role with {sumPoints:F1}!");
} else
{
    double difference = Math.Abs(sumPoints - 1250.5);
    Console.WriteLine($"Sorry, {actor} you need {difference:F1} more!");
}