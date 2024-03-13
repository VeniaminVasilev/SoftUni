double sum = 0;

while (true)
{
    string command = Console.ReadLine();

    if (command == "Start") { break; }

    double coin = double.Parse(command);

    if (coin == 0.1 || coin == 0.2 || coin == 0.5 || coin == 1 || coin == 2)
    {
        sum += coin;
    }
    else
    {
        Console.WriteLine($"Cannot accept {coin}");
    }
}

while (true)
{
    string command = Console.ReadLine();

    if (command == "End") { break; }

    if (command == "Nuts" && sum >= 2.0)
    {
        sum -= 2.0;
        Console.WriteLine($"Purchased nuts");
    }
    else if (command == "Nuts" && sum < 2.0)
    {
        Console.WriteLine($"Sorry, not enough money");
    }
    else if (command == "Water" && sum >= 0.7)
    {
        sum -= 0.7;
        Console.WriteLine($"Purchased water");
    }
    else if (command == "Water" && sum < 0.7)
    {
        Console.WriteLine($"Sorry, not enough money");
    }
    else if (command == "Crisps" && sum >= 1.5)
    {
        sum -= 1.5;
        Console.WriteLine($"Purchased crisps");
    }
    else if (command == "Crisps" && sum < 1.5)
    {
        Console.WriteLine($"Sorry, not enough money");
    }
    else if (command == "Soda" && sum >= 0.8)
    {
        sum -= 0.8;
        Console.WriteLine($"Purchased soda");
    }
    else if (command == "Soda" && sum < 0.8)
    {
        Console.WriteLine($"Sorry, not enough money");
    }
    else if (command == "Coke" && sum >= 1.0)
    {
        sum -= 1.0;
        Console.WriteLine($"Purchased coke");
    }
    else if (command == "Coke" && sum < 1.0)
    {
        Console.WriteLine($"Sorry, not enough money");
    }
    else { Console.WriteLine("Invalid product"); }
}

Console.WriteLine($"Change: {sum:F2}");