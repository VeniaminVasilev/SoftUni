string teamName = Console.ReadLine();
int games = int.Parse(Console.ReadLine());

int wins = 0;
int duals = 0;
int loses = 0;
int points = 0;

for (int i = 1; i <= games; i++)
{
    if (games == 0) { break; }

    char outcome = char.Parse(Console.ReadLine());

    if (outcome == 'W')
    {
        points += 3;
        wins++;
    }
    else if (outcome == 'D')
    {
        points += 1;
        duals++;
    }
    else if (outcome == 'L')
    {
        loses++;
    }
}

if (games == 0)
{
    Console.WriteLine($"{teamName} hasn't played any games during this season.");
}
else
{
    Console.WriteLine($"{teamName} has won {points} points during this season.");
    Console.WriteLine($"Total stats:");
    Console.WriteLine($"## W: {wins}");
    Console.WriteLine($"## D: {duals}");
    Console.WriteLine($"## L: {loses}");
    Console.WriteLine($"Win rate: {((double)wins / games) * 100:F2}%");
}