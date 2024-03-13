string drink = Console.ReadLine();
string sugar = Console.ReadLine();
int numberDrinks = int.Parse(Console.ReadLine());

double sum = 0;

if (drink == "Espresso" && sugar == "Without")
{
    sum = numberDrinks * (0.90 * 0.65);
}
else if (drink == "Espresso" && sugar == "Normal")
{
    sum = numberDrinks * 1.0;
}
else if (drink == "Espresso" && sugar == "Extra")
{
    sum = numberDrinks * 1.20;
}
else if (drink == "Cappuccino" && sugar == "Without")
{
    sum = numberDrinks * (1.00 * 0.65);
}
else if (drink == "Cappuccino" && sugar == "Normal")
{
    sum = numberDrinks * 1.20;
}
else if (drink == "Cappuccino" && sugar == "Extra")
{
    sum = numberDrinks * 1.60;
}
else if (drink == "Tea" && sugar == "Without")
{
    sum = numberDrinks * (0.50 * 0.65);
}
else if (drink == "Tea" && sugar == "Normal")
{
    sum = numberDrinks * 0.60;
}
else if (drink == "Tea" && sugar == "Extra")
{
    sum = numberDrinks * 0.70;
}

if (drink == "Espresso" && numberDrinks >= 5)
{
    sum *= 0.75;
}

if (sum > 15.00)
{
    sum *= 0.80;
}

Console.WriteLine($"You bought {numberDrinks} cups of {drink} for {sum:F2} lv.");