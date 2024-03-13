int people = int.Parse(Console.ReadLine());
string groupType = Console.ReadLine();
string day = Console.ReadLine();

double priceSinglePerson = 0;

if (day == "Friday" && groupType == "Students")
{
    priceSinglePerson = 8.45;
} 
else if (day == "Friday" && groupType == "Business")
{
    priceSinglePerson = 10.90;
}
else if (day == "Friday" && groupType == "Regular")
{
    priceSinglePerson = 15;
}
else if (day == "Saturday" && groupType == "Students")
{
    priceSinglePerson = 9.80;
}
else if (day == "Saturday" && groupType == "Business")
{
    priceSinglePerson = 15.60;
}
else if (day == "Saturday" && groupType == "Regular")
{
    priceSinglePerson = 20;
}
else if (day == "Sunday" && groupType == "Students")
{
    priceSinglePerson = 10.46;
}
else if (day == "Sunday" && groupType == "Business")
{
    priceSinglePerson = 16;
}
else if (day == "Sunday" && groupType == "Regular")
{
    priceSinglePerson = 22.50;
}

double priceGroup = priceSinglePerson * people;

if (groupType == "Students" && people >= 30)
{
    priceGroup *= 0.85;
}
else if (groupType == "Business" && people >= 100)
{
    priceGroup -= priceSinglePerson * 10;
}
else if (groupType == "Regular" && people >= 10 && people <= 20) 
{
    priceGroup *= 0.95;
}

Console.WriteLine($"Total price: {priceGroup:F2}");