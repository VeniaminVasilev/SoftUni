double budget = double.Parse(Console.ReadLine());
int nights = int.Parse(Console.ReadLine());
double priceForNight = double.Parse(Console.ReadLine());
int percentAdditionalExpenses = int.Parse(Console.ReadLine());

double sum = 0;

if (nights > 7)
{
    sum = nights * (priceForNight * 0.95);
    sum += budget * (percentAdditionalExpenses / 100.0);
}
else
{
    sum = nights * priceForNight;
    sum += budget * (percentAdditionalExpenses / 100.0);
}

if (sum <= budget)
{
    Console.WriteLine($"Ivanovi will be left with {Math.Abs(sum - budget):F2} leva after vacation.");
}
else
{
    Console.WriteLine($"{Math.Abs(budget - sum):F2} leva needed.");
}