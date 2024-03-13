double budget = double.Parse(Console.ReadLine());
string season = Console.ReadLine();

string location = string.Empty;
string accomodation = string.Empty;
double price = 0.00;

if (budget <= 1000)
{
    accomodation = "Camp";
    if (season == "Summer")
    {
        location = "Alaska";
        price = budget * 0.65;
    } else if (season == "Winter")
    {
        location = "Morocco";
        price = budget * 0.45;
    }
} else if (budget > 1000 && budget <= 3000)
{
    accomodation = "Hut";
    if (season == "Summer")
    {
        location = "Alaska";
        price = budget * 0.80;
    } else if (season == "Winter")
    {
        location = "Morocco";
        price = budget * 0.60;
    }
} else if (budget > 3000)
{
    accomodation = "Hotel";
    if (season == "Summer")
    {
        location = "Alaska";
        price = budget * 0.90;
    }
    else if (season == "Winter")
    {
        location = "Morocco";
        price = budget * 0.90;
    }
}

Console.WriteLine($"{location} - {accomodation} - {price:F2}");