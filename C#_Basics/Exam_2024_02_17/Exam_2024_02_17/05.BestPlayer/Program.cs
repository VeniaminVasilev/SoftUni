int maxGoals = 0;
string bestPlayer = string.Empty;
bool hatTrick = false;

while (true)
{
    string command = Console.ReadLine();

    if (command == "END")
    {
        break;
    }

    int goals = int.Parse(Console.ReadLine());

    if (goals > maxGoals && goals >= 3)
    {
        maxGoals = goals;
        bestPlayer = command;
        hatTrick = true;
    }
    else if (goals > maxGoals && goals < 3)
    {
        maxGoals = goals;
        bestPlayer = command;
        hatTrick = false;
    }

    if (goals >= 10)
    {
        break;
    }
}

if (hatTrick)
{
    Console.WriteLine($"{bestPlayer} is the best player!");
    Console.WriteLine($"He has scored {maxGoals} goals and made a hat-trick !!!");
}
else
{
    Console.WriteLine($"{bestPlayer} is the best player!");
    Console.WriteLine($"He has scored {maxGoals} goals.");
}