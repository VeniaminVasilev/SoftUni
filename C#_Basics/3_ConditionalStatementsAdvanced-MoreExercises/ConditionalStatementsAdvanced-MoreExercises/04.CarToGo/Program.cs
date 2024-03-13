double budget = double.Parse(Console.ReadLine());
string season = Console.ReadLine();

string classCar = string.Empty;
string typeCar = string.Empty;
double priceCar = 0.00;

if (budget <= 100)
{
    classCar = "Economy class";
    if (season == "Summer")
    {
        typeCar = "Cabrio";
        priceCar = budget * 0.35;
    } else if (season == "Winter")
    {
        typeCar = "Jeep";
        priceCar = budget * 0.65;
    }
} else if (budget > 100 && budget <= 500)
{
    classCar = "Compact class";
    if (season == "Summer")
    {
        typeCar = "Cabrio";
        priceCar = budget * 0.45;
    }
    else if (season == "Winter")
    {
        typeCar = "Jeep";
        priceCar = budget * 0.80;
    }
} else if (budget > 500)
{
    classCar = "Luxury class";
    typeCar = "Jeep";
    priceCar = budget * 0.90;
}

Console.WriteLine(classCar);
Console.WriteLine($"{typeCar} - {priceCar:F2}");