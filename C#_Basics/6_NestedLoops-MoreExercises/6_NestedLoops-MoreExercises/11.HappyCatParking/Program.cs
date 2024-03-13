int days = int.Parse(Console.ReadLine());
int hours = int.Parse(Console.ReadLine());

double sumForCurrentDay = 0;
double totalSumForAllDays = 0;

for (int day = 1; day <= days; day++)
{
    for (int hour = 1; hour <= hours; hour++)
    {
        if (day % 2 == 0 && hour % 2 != 0)
        {
            sumForCurrentDay += 2.50;
        }
        else if (day % 2 == 1 && hour % 2 == 0)
        {
            sumForCurrentDay += 1.25;
        }
        else
        {
            sumForCurrentDay += 1.0;
        }
    }

    Console.WriteLine($"Day: {day} - {sumForCurrentDay:F2} leva");
    totalSumForAllDays += sumForCurrentDay;
    sumForCurrentDay = 0;
}

Console.WriteLine($"Total: {totalSumForAllDays:F2} leva");