string fuel = Console.ReadLine();
double amountFuel = double.Parse(Console.ReadLine());
string clubCard = Console.ReadLine(); 

double price = 0.00;

if (fuel == "Gasoline" && clubCard == "Yes")
{
    price = (2.22 - 0.18) * amountFuel;
} else if (fuel == "Gasoline" && clubCard == "No")
{
    price = 2.22 * amountFuel;
} else if (fuel == "Diesel" && clubCard == "Yes")
{
    price = (2.33 - 0.12) * amountFuel;
} else if (fuel == "Diesel" && clubCard == "No")
{
    price = 2.33 * amountFuel;
} else if (fuel == "Gas" && clubCard == "Yes")
{
    price = (0.93 - 0.08) * amountFuel;
} else if (fuel == "Gas" && clubCard == "No")
{
    price = 0.93 * amountFuel;
}

if (amountFuel >= 20 && amountFuel <= 25)
{
    price *= 0.92;
} else if (amountFuel > 25)
{
    price *= 0.90;
}

Console.WriteLine($"{price:F2} lv.");