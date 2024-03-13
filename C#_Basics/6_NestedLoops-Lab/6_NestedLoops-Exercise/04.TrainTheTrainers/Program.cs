int people = int.Parse(Console.ReadLine());

double sumOfAverageEvaluations = 0;
int counter = 0;
while (true)
{
    string presentationName = Console.ReadLine();

    if (presentationName == "Finish")
    {
        Console.WriteLine($"Student's final assessment is {sumOfAverageEvaluations / counter:F2}.");
        break;
    }

    double sumOfEvaluations = 0;

    for (int i = 0; i < people; i++)
    {
        double evaluation = double.Parse(Console.ReadLine());
        sumOfEvaluations += evaluation;
    }

    double averageEvaluation = sumOfEvaluations / people;
    sumOfAverageEvaluations += averageEvaluation;
    counter++;
    Console.WriteLine($"{presentationName} - {averageEvaluation:F2}.");
}