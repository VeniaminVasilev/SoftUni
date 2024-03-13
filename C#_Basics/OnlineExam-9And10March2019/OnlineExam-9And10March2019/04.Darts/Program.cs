string nameOfPlayer = Console.ReadLine();
int points = 301;
int successfulStrikes = 0;
int unsuccessfulStrikes = 0;

while (true)
{
    string command = Console.ReadLine();
    if (command == "Retire")
    {
        Console.WriteLine($"{nameOfPlayer} retired after {unsuccessfulStrikes} unsuccessful shots.");
        break;
    }

    int currentPoints = int.Parse(Console.ReadLine());

    if (command == "Single" && points - currentPoints >= 0)
    {
        successfulStrikes++;
        points -= currentPoints;
    }
    else if (command == "Single" && points - currentPoints < 0)
    {
        unsuccessfulStrikes++;
    }
    else if (command == "Double" && points - (2 * currentPoints) >= 0)
    {
        successfulStrikes++;
        points -= (2 * currentPoints);
    }
    else if (command == "Double" && points - (2 * currentPoints) < 0)
    {
        unsuccessfulStrikes++;
    }
    else if (command == "Triple" && points - (3 * currentPoints) >= 0)
    {
        successfulStrikes++;
        points -= (3 * currentPoints);
    }
    else if (command == "Triple" && points - (3 * currentPoints) < 0)
    {
        unsuccessfulStrikes++;
    }

    if (points == 0)
    {
        Console.WriteLine($"{nameOfPlayer} won the leg with {successfulStrikes} shots.");
        break;
    }
}