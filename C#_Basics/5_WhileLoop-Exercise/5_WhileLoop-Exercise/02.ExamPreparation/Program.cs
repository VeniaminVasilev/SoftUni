int failedThreshold = int.Parse(Console.ReadLine());

bool success = false;
double exerciseSum = 0;
int exerciseCounter = 0;
string lastExercise = string.Empty;
int badGradesCounter = 0;

while (true)
{
    string exerciseName = Console.ReadLine();

    if (exerciseName == "Enough")
    {
        success = true;
        break;
    }

    int evaluation = int.Parse(Console.ReadLine());

    if (evaluation <= 4)
    {
        badGradesCounter++;

        if (badGradesCounter == failedThreshold)
        {
            exerciseCounter++;
            lastExercise = exerciseName;
            exerciseSum += evaluation;
            break;
        }
    }

    exerciseSum += evaluation;
    exerciseCounter++;
    lastExercise = exerciseName;
}

double averageScore = exerciseSum / exerciseCounter;

if (success)
{
    Console.WriteLine($"Average score: {averageScore:F2}");
    Console.WriteLine($"Number of problems: {exerciseCounter}");
    Console.WriteLine($"Last problem: {lastExercise}");
} else
{
    Console.WriteLine($"You need a break, {badGradesCounter} poor grades.");
}