int soldGames = int.Parse(Console.ReadLine());

int hearthstone = 0;
int fornite = 0;
int overwatch = 0;
int others = 0;

for (int i = 1; i <= soldGames; i++)
{
    string game = Console.ReadLine();

    if (game == "Hearthstone")
    {
        hearthstone++;
    } 
    else if (game == "Fornite")
    {  
        fornite++;
    }
    else if (game == "Overwatch")
    {
        overwatch++;
    }
    else
    {
        others++;
    }
}

Console.WriteLine($"Hearthstone - {((double)hearthstone / soldGames) * 100:F2}%");
Console.WriteLine($"Fornite - {((double)fornite / soldGames) * 100:F2}%");
Console.WriteLine($"Overwatch - {((double)overwatch / soldGames) * 100:F2}%");
Console.WriteLine($"Others - {((double)others / soldGames) * 100:F2}%");