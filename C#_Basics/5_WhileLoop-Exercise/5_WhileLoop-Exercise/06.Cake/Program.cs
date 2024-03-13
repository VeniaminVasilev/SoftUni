int numberOfPiecesCake = int.Parse(Console.ReadLine()) * int.Parse(Console.ReadLine());

while (numberOfPiecesCake > 0)
{
    string command = Console.ReadLine();

    if (command == "STOP")
    {
        break;
    }

    int cakesTaken = int.Parse(command);
    numberOfPiecesCake -= cakesTaken;
}

if (numberOfPiecesCake > 0)
{
    Console.WriteLine($"{numberOfPiecesCake} pieces are left.");
} else
{
    Console.WriteLine($"No more cake left! You need {Math.Abs(numberOfPiecesCake)} pieces more.");
}