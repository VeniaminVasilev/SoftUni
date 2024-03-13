int steps = int.Parse(Console.ReadLine());

int from0To9 = 0;
int from10To19 = 0;
int from20To29 = 0;
int from30To39 = 0;
int from40To50 = 0;
int invalidNumbers = 0;

double result = 0;

for (int i = 0; i < steps; i++)
{
    int number = int.Parse(Console.ReadLine());

    if (number >= 0 && number <= 9)
    {
        result += ((double)number / 100) * 20;
        from0To9++;
    }
    else if (number >= 10 && number <= 19)
    {
        result += ((double)number / 100) * 30;
        from10To19++;
    }
    else if (number >= 20 && number <= 29)
    {
        result += ((double)number / 100) * 40;
        from20To29++;
    }
    else if (number >= 30 && number <= 39)
    {
        result += 50;
        from30To39++;
    }
    else if (number >= 40 && number <= 50)
    {
        result += 100;
        from40To50++;
    }
    else if (number < 0 || number > 50)
    {
        result = result / 2;
        invalidNumbers++;
    }
}

Console.WriteLine($"{result:F2}");
Console.WriteLine($"From 0 to 9: {((double)from0To9 / steps) * 100:F2}%");
Console.WriteLine($"From 10 to 19: {((double)from10To19 / steps) * 100:F2}%");
Console.WriteLine($"From 20 to 29: {((double)from20To29 / steps) * 100:F2}%");
Console.WriteLine($"From 30 to 39: {((double)from30To39 / steps) * 100:F2}%");
Console.WriteLine($"From 40 to 50: {((double)from40To50 / steps) * 100:F2}%");
Console.WriteLine($"Invalid numbers: {((double)invalidNumbers / steps) * 100:F2}%");