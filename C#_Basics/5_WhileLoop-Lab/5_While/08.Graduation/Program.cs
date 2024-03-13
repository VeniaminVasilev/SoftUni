string name = Console.ReadLine();
int gradeNumber = 1;
double totalScore = 0;
int badScores = 0;

while (true)
{
    double score = double.Parse(Console.ReadLine());

    if (score >= 4)
    {
        gradeNumber++;
        totalScore += score;
    } else
    {
        badScores++;
        if (badScores < 2)
        {
            continue;
        } else
        {
            Console.WriteLine($"{name} has been excluded at {gradeNumber} grade");
            break;
        }
    }

    if (gradeNumber > 12)
    {
        break;
    }
}

double averageScore = totalScore / 12;

if (gradeNumber > 12)
{
    Console.WriteLine($"{name} graduated. Average grade: {averageScore:F2}");
}