double filmBudget = double.Parse(Console.ReadLine());
int numberPeople = int.Parse(Console.ReadLine());
double priceClothing = double.Parse(Console.ReadLine());

double decor = filmBudget * 0.10;
double clothingCost = priceClothing * numberPeople;

if (numberPeople > 150)
{
    clothingCost = clothingCost * 0.90;
}

double moneyNeeded = decor + clothingCost;
double difference = Math.Abs(filmBudget - moneyNeeded);

if (moneyNeeded > filmBudget)
{
    Console.WriteLine("Not enough money!");
    Console.WriteLine($"Wingard needs {difference:F2} leva more.");
} else
{
    Console.WriteLine("Action!");
    Console.WriteLine($"Wingard starts filming with {difference:F2} leva left.");
}