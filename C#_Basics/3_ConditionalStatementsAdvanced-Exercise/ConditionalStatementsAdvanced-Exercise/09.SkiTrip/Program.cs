int days = int.Parse(Console.ReadLine());
string typeRoom = Console.ReadLine();
string evaluation = Console.ReadLine();

double costs = 0.00;

if (typeRoom == "room for one person" && evaluation == "positive")
{
    costs = ((days - 1) * 18.00) * 1.25;
} else if (typeRoom == "room for one person" && evaluation == "negative")
{
    costs = ((days - 1) * 18.00) * 0.90;
} else if (typeRoom == "apartment" && evaluation == "positive")
{
    if (days < 10)
    {
        costs = (((days - 1) * 25.00) * 0.70) * 1.25;
    } else if (days <= 15)
    {
        costs = (((days - 1) * 25.00) * 0.65) * 1.25;
    } else if (days > 15)
    {
        costs = (((days - 1) * 25.00) * 0.50) * 1.25;
    }
}
else if (typeRoom == "apartment" && evaluation == "negative")
{
    if (days < 10)
    {
        costs = (((days - 1) * 25.00) * 0.70) * 0.90;
    }
    else if (days <= 15)
    {
        costs = (((days - 1) * 25.00) * 0.65) * 0.90;
    }
    else if (days > 15)
    {
        costs = (((days - 1) * 25.00) * 0.50) * 0.90;
    }
} else if (typeRoom == "president apartment" && evaluation == "positive")
{
    if (days < 10)
    {
        costs = (((days - 1) * 35.00) * 0.90) * 1.25;
    }
    else if (days <= 15)
    {
        costs = (((days - 1) * 35.00) * 0.85) * 1.25;
    }
    else if (days > 15)
    {
        costs = (((days - 1) * 35.00) * 0.80) * 1.25;
    }
} else if (typeRoom == "president apartment" && evaluation == "negative")
{
    if (days < 10)
    {
        costs = (((days - 1) * 35.00) * 0.90) * 0.90;
    }
    else if (days <= 15)
    {
        costs = (((days - 1) * 35.00) * 0.85) * 0.90;
    }
    else if (days > 15)
    {
        costs = (((days - 1) * 35.00) * 0.80) * 0.90;
    }
}

Console.WriteLine($"{costs:F2}");