string namePlayer1 = Console.ReadLine();
string namePlayer2 = Console.ReadLine();

bool numberWars = false;
string winner = string.Empty;

int pointsPlayer1 = 0;
int pointsPlayer2 = 0;

while (true)
{
    string commandPlayer1 = Console.ReadLine();
    if (commandPlayer1 == "End of game")
    {
        Console.WriteLine($"{namePlayer1} has {pointsPlayer1} points");
        Console.WriteLine($"{namePlayer2} has {pointsPlayer2} points");
        break;
    }

    string commandPlayer2 = Console.ReadLine();
    if (commandPlayer2 == "End of game")
    {
        Console.WriteLine($"{namePlayer1} has {pointsPlayer1} points");
        Console.WriteLine($"{namePlayer2} has {pointsPlayer2} points");
        break;
    }

    int cardPlayer1 = int.Parse(commandPlayer1);
    int cardPlayer2 = int.Parse(commandPlayer2);

    if (cardPlayer1 > cardPlayer2)
    {
        pointsPlayer1 += cardPlayer1 - cardPlayer2;
    }
    else if (cardPlayer2 > cardPlayer1)
    {
        pointsPlayer2 += cardPlayer2 - cardPlayer1;
    }
    else if (cardPlayer1 == cardPlayer2)
    {
        numberWars = true;
        int finalCardPlayer1 = int.Parse(Console.ReadLine());
        int finalCardPlayer2 = int.Parse(Console.ReadLine());

        if (finalCardPlayer1 > finalCardPlayer2)
        {
            winner = namePlayer1;
        }
        else if (finalCardPlayer2 > finalCardPlayer1)
        {
            winner = namePlayer2;
        }
        break;
    }
}

if (numberWars == true && winner == namePlayer1)
{
    Console.WriteLine($"Number wars!");
    Console.WriteLine($"{namePlayer1} is winner with {pointsPlayer1} points");
}
else if (numberWars == true && winner == namePlayer2)
{
    Console.WriteLine($"Number wars!");
    Console.WriteLine($"{namePlayer2} is winner with {pointsPlayer2} points");
}