string city = Console.ReadLine();
string typePack = Console.ReadLine();
string vip = Console.ReadLine();
int days = int.Parse(Console.ReadLine());

double price = 0;

if (city == "Bansko" && typePack == "withEquipment" && days > 0 || city == "Borovets" && typePack == "withEquipment" && days > 0)
{
    if (days > 7)
    {
        price = (days - 1) * 100.0;
    }
    else if (days < 7 && days > 0)
    {
        price = days * 100.0;
    }

    if (vip == "yes")
    {
        price *= 0.90;
    }

    Console.WriteLine($"The price is {price:F2}lv! Have a nice time!");
}
else if (city == "Bansko" && typePack == "noEquipment" && days > 0 || city == "Borovets" && typePack == "noEquipment" && days > 0)
{
    if (days > 7)
    {
        price = (days - 1) * 80.0;
    }
    else if (days < 7 && days > 0)
    {
        price = days * 80.0;
    }

    if (vip == "yes")
    {
        price *= 0.95;
    }

    Console.WriteLine($"The price is {price:F2}lv! Have a nice time!");
}
else if (city == "Varna" && typePack == "withBreakfast" && days > 0 || city == "Burgas" && typePack == "withBreakfast" && days > 0)
{
    if (days > 7)
    {
        price = (days - 1) * 130.0;
    }
    else if (days < 7 && days > 0)
    {
        price = days * 130.0;
    }

    if (vip == "yes")
    {
        price *= 0.88;
    }

    Console.WriteLine($"The price is {price:F2}lv! Have a nice time!");
}
else if (city == "Varna" && typePack == "noBreakfast" && days > 0 || city == "Burgas" && typePack == "noBreakfast" && days > 0)
{
    if (days > 7)
    {
        price = (days - 1) * 100.0;
    }
    else if (days < 7 && days > 0)
    {
        price = days * 100.0;
    }

    if (vip == "yes")
    {
        price *= 0.93;
    }

    Console.WriteLine($"The price is {price:F2}lv! Have a nice time!");
}
else if (days < 1)
{
    Console.WriteLine($"Days must be positive number!");
}
else
{
    Console.WriteLine($"Invalid input!");
}