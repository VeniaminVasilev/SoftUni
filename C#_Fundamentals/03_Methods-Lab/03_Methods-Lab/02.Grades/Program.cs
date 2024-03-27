double grade = double.Parse(Console.ReadLine());
PrintInWords(grade);

static void PrintInWords (double grade)
{
    if (grade < 3.0)
    {
        Console.WriteLine("Fail");
    }
    else if (grade < 3.50)
    {
        Console.WriteLine("Poor");
    }
    else if (grade < 4.50)
    {
        Console.WriteLine("Good");
    }
    else if (grade < 5.50)
    {
        Console.WriteLine("Very good");
    }
    else
    {
        Console.WriteLine("Excellent");
    }
}