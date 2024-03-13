string season = Console.ReadLine();
string groupType = Console.ReadLine();
int students = int.Parse(Console.ReadLine());
int nights = int.Parse(Console.ReadLine());

string sport = string.Empty;
double price = 0.00;

if (season == "Winter")
{
    if (groupType == "boys")
    {
        price = (students * 9.60) * nights;
        sport = "Judo";
    }
    else if (groupType == "girls")
    {
        price = (students * 9.60) * nights;
        sport = "Gymnastics";
    }
    else if (groupType == "mixed")
    {
        price = (students * 10.00) * nights;
        sport = "Ski";
    }
} else if (season == "Spring")
{
    if (groupType == "boys")
    {
        price = (students * 7.20) * nights;
        sport = "Tennis";
    }
    else if (groupType == "girls")
    {
        price = (students * 7.20) * nights;
        sport = "Athletics";
    }
    else if (groupType == "mixed")
    {
        price = (students * 9.50) * nights;
        sport = "Cycling";
    }
} else if (season == "Summer")
{
    if (groupType == "boys")
    {
        price = (students * 15.00) * nights;
        sport = "Football";
    }
    else if (groupType == "girls")
    {
        price = (students * 15.00) * nights;
        sport = "Volleyball";
    }
    else if (groupType == "mixed")
    {
        price = (students * 20.00) * nights;
        sport = "Swimming";
    }
}

if (students >= 50)
{
    price *= 0.50;
} else if (students >= 20 && students < 50)
{
    price *= 0.85;
} else if (students >= 10 && students < 20)
{
    price *= 0.95;
}

Console.WriteLine($"{sport} {price:F2} lv.");