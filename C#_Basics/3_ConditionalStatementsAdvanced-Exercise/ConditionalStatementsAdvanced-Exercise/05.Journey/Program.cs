double budget = double.Parse(Console.ReadLine());
string season = Console.ReadLine();

string destination = string.Empty;
string vacationType = string.Empty;
double spentSum = 0.00;

if (budget <= 100.0 && season == "summer")
{
    vacationType = "Camp";
    spentSum = budget * 0.30;
    destination = "Bulgaria";
} else if (budget <= 100.0 && season == "winter")
{
    vacationType = "Hotel";
    spentSum = budget * 0.70;
    destination = "Bulgaria";
} else if (budget <= 1000.0 && season == "summer")
{
    vacationType = "Camp";
    spentSum = budget * 0.40;
    destination = "Balkans";
} else if (budget <= 1000.0 && season == "winter")
{
    vacationType = "Hotel";
    spentSum = budget * 0.80;
    destination = "Balkans";
} else if (budget > 1000.0)
{
    vacationType = "Hotel";
    spentSum = budget * 0.90;
    destination = "Europe";
}

Console.WriteLine($"Somewhere in {destination}");
Console.WriteLine($"{vacationType} - {spentSum:F2}");