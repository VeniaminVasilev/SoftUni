int students = int.Parse(Console.ReadLine());

double sumOfStudentsGrades = 0;
int counterAbove5 = 0;
int counterAbove4 = 0;
int counterAbove3 = 0;
int counterBelow3 = 0;

for (int i = 0; i < students; i++)
{
    double grade = double.Parse(Console.ReadLine());
    if (grade >= 5)
    {
        counterAbove5++;
        sumOfStudentsGrades += grade;
    }
    else if (grade >= 4 && grade <= 4.99)
    {
        counterAbove4++;
        sumOfStudentsGrades += grade;
    }
    else if (grade >= 3 && grade <= 3.99)
    {
        counterAbove3++;
        sumOfStudentsGrades += grade;
    }
    else if (grade < 3)
    {
        counterBelow3++;
        sumOfStudentsGrades += grade;
    }
}

Console.WriteLine($"Top students: {((double)counterAbove5 / students) * 100:F2}%");
Console.WriteLine($"Between 4.00 and 4.99: {((double)counterAbove4 / students) * 100:F2}%");
Console.WriteLine($"Between 3.00 and 3.99: {((double)counterAbove3 / students) * 100:F2}%");
Console.WriteLine($"Fail: {((double)counterBelow3 / students) * 100:F2}%");
Console.WriteLine($"Average: {sumOfStudentsGrades / students:F2}");