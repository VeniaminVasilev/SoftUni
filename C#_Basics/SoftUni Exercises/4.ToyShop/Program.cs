double priceTrip = double.Parse(Console.ReadLine());
int puzzles = int.Parse(Console.ReadLine());
int dolls = int.Parse(Console.ReadLine());
int bears = int.Parse(Console.ReadLine());
int minions = int.Parse(Console.ReadLine());
int trucks =  int.Parse(Console.ReadLine());

double profitPuzzles = puzzles * 2.60;
double profitDolls = dolls * 3.0;
double profitBears = bears * 4.10;
double profitMinions = minions * 8.20;
double profitTrucks = trucks * 2.0;

double profit = profitPuzzles + profitDolls + profitBears + profitMinions + profitTrucks;

if ((puzzles + dolls + bears + minions + trucks) >= 50)
{
    profit = profit * 0.75;
}

double profitLeft = profit * 0.9;

double difference = Math.Abs(profitLeft - priceTrip);

if (priceTrip <= profitLeft)
{
    Console.WriteLine($"Yes! {difference:F2} lv left.");
} else
{
    Console.WriteLine($"Not enough money! {difference:F2} lv needed.");
}