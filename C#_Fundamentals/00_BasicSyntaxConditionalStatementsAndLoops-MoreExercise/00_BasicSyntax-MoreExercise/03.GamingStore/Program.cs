double balance = double.Parse(Console.ReadLine());
double spentMoney = 0;

while (true)
{
    string command = Console.ReadLine();

    if (command == "Game Time") { break; }

    if (command == "OutFall 4" && balance >= 39.99)
    {
        balance -= 39.99;
        spentMoney += 39.99;
        Console.WriteLine("Bought OutFall 4");
    }
    else if (command == "CS: OG" && balance >= 15.99)
    {
        balance -= 15.99;
        spentMoney += 15.99;
        Console.WriteLine("Bought CS: OG");
    }
    else if (command == "Zplinter Zell" && balance >= 19.99)
    {
        balance -= 19.99;
        spentMoney += 19.99;
        Console.WriteLine("Bought Zplinter Zell");
    }
    else if (command == "Honored 2" && balance >= 59.99)
    {
        balance -= 59.99;
        spentMoney += 59.99;
        Console.WriteLine("Bought Honored 2");
    }
    else if (command == "RoverWatch" && balance >= 29.99)
    {
        balance -= 29.99;
        spentMoney += 29.99;
        Console.WriteLine("Bought RoverWatch");
    }
    else if (command == "RoverWatch Origins Edition" && balance >= 39.99)
    {
        balance -= 39.99;
        spentMoney += 39.99;
        Console.WriteLine("Bought RoverWatch Origins Edition");
    }
    else if (command == "OutFall 4" && balance < 39.99)
    {
        Console.WriteLine("Too Expensive");
    }
    else if (command == "CS: OG" && balance < 15.99)
    {
        Console.WriteLine("Too Expensive");
    }
    else if (command == "Zplinter Zell" && balance < 19.99)
    {
        Console.WriteLine("Too Expensive");
    }
    else if (command == "Honored 2" && balance < 59.99)
    {
        Console.WriteLine("Too Expensive");
    }
    else if (command == "RoverWatch" && balance < 29.99)
    {
        Console.WriteLine("Too Expensive");
    }
    else if (command == "RoverWatch Origins Edition" && balance < 39.99)
    {
        Console.WriteLine("Too Expensive");
    }
    else
    {
        Console.WriteLine("Not Found");
    }

    if (balance == 0)
    {
        Console.WriteLine("Out of money!");
        break;
    }
}

if (balance > 0)
{
    Console.WriteLine($"Total spent: ${spentMoney:F2}. Remaining: ${balance:F2}");
}