string name = Console.ReadLine();
double budget = double.Parse(Console.ReadLine());
int numberBeer = int.Parse(Console.ReadLine());
int numberChips = int.Parse(Console.ReadLine());

double priceAllBeer = numberBeer * 1.20;
double oneChips = priceAllBeer * 0.45;
double priceAllChips = Math.Ceiling(numberChips * oneChips);
double moneyNeeded = priceAllBeer + priceAllChips;

if (budget >= moneyNeeded)
{
    Console.WriteLine($"{name} bought a snack and has {budget - moneyNeeded:F2} leva left.");
}
else
{
    Console.WriteLine($"{name} needs {Math.Abs(budget - moneyNeeded):F2} more leva!");
}