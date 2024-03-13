double budget = double.Parse(Console.ReadLine());
string category = Console.ReadLine();
int peopleInGroup = int.Parse(Console.ReadLine());

double transport = 0.00;
double tickets = 0.00;

if (peopleInGroup <= 4)
{
    transport = budget * 0.75;
} else if (peopleInGroup <= 9)
{
    transport = budget * 0.60;
} else if (peopleInGroup <= 24)
{
    transport = budget * 0.50;
} else if (peopleInGroup <= 49)
{
    transport = budget * 0.40;
} else if (peopleInGroup >= 50)
{
    transport = budget * 0.25;
}

if (category == "VIP")
{
    tickets = peopleInGroup * 499.99;
} else if (category == "Normal")
{
    tickets = peopleInGroup * 249.99;
}

double totalCost = transport + tickets;
double difference = Math.Abs(totalCost - budget);

if (budget >= totalCost)
{
    Console.WriteLine($"Yes! You have {difference:F2} leva left.");
} else
{
    Console.WriteLine($"Not enough money! You need {difference:F2} leva.");
}