string season = Console.ReadLine();
double kilometersPerMonth = double.Parse(Console.ReadLine());

double salary = 0.00;

if (kilometersPerMonth <= 5000)
{
    if (season == "Spring" || season == "Autumn")
    {
        salary = (4 * kilometersPerMonth) * 0.75;
    } else if (season == "Summer")
    {
        salary = (4 * kilometersPerMonth) * 0.90;
    } else if (season == "Winter")
    {
        salary = (4 * kilometersPerMonth) * 1.05;
    }
} else if (kilometersPerMonth > 5000 && kilometersPerMonth <= 10000)
{
    if (season == "Spring" || season == "Autumn")
    {
        salary = (4 * kilometersPerMonth) * 0.95;
    }
    else if (season == "Summer")
    {
        salary = (4 * kilometersPerMonth) * 1.10;
    }
    else if (season == "Winter")
    {
        salary = (4 * kilometersPerMonth) * 1.25;
    }
} else if (kilometersPerMonth > 10000 && kilometersPerMonth <= 20000)
{
    salary = (4 * kilometersPerMonth) * 1.45;
}

salary *= 0.90;

Console.WriteLine($"{salary:F2}");