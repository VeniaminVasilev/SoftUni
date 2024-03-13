int budget = int.Parse(Console.ReadLine());
string season = Console.ReadLine();
int fishermen = int.Parse(Console.ReadLine());

double costs = 0.0;

if (season == "Spring")
{
    costs = 3000.0;
} else if (season == "Summer" || season == "Autumn")
{
    costs = 4200.0;
} else if (season == "Winter")
{
    costs = 2600.0;
}

if (fishermen <= 6)
{
    costs *= 0.9;
} else if (fishermen >= 7 && fishermen <= 11)
{
    costs *= 0.85;
} else if (fishermen >= 12)
{
    costs *= 0.75;
}

if (fishermen % 2 == 0 && season != "Autumn")
{
    costs = costs * 0.95;
}

double difference = Math.Abs(budget - costs);

if (budget >= costs)
{
    Console.WriteLine($"Yes! You have {difference:F2} leva left.");
}
else
{
    Console.WriteLine($"Not enough money! You need {difference:F2} leva.");
}