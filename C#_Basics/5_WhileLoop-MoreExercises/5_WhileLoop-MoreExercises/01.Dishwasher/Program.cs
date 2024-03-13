int bottlesDetergent = int.Parse(Console.ReadLine());
int mlDetergentPresent = bottlesDetergent * 750;
int roundOfDishwasher = 0;
int washedPots = 0;
int washedDishes = 0;

while (mlDetergentPresent >= 0)
{
    string command = Console.ReadLine();
    roundOfDishwasher++;

    if (command == "End")
    {
        break;
    }

    if (roundOfDishwasher % 3 == 0)
    {
        int pots = int.Parse(command);
        int mlForPots = pots * 15;
        mlDetergentPresent -= mlForPots;
        washedPots += pots;
    } else if (roundOfDishwasher % 3 != 0)
    {
        int dishes = int.Parse(command);
        int mlForDishes = dishes * 5;
        mlDetergentPresent -= mlForDishes;
        washedDishes += dishes;
    }
}

if (mlDetergentPresent >= 0)
{
    Console.WriteLine("Detergent was enough!");
    Console.WriteLine($"{washedDishes} dishes and {washedPots} pots were washed.");
    Console.WriteLine($"Leftover detergent {mlDetergentPresent} ml.");
} else
{
    Console.WriteLine($"Not enough detergent, {Math.Abs(mlDetergentPresent)} ml. more necessary!");
}