int nights = int.Parse(Console.ReadLine()) - 1;
string kindOfRoom = Console.ReadLine();
string evaluation = Console.ReadLine();

double priceToBePaid = 0;

if (kindOfRoom == "room for one person")
{
    priceToBePaid = nights * 18.00;
}
else if (kindOfRoom == "apartment" && nights < 10)
{
    priceToBePaid = (nights * 25.00) * 0.70;
}
else if (kindOfRoom == "apartment" && nights >= 10 && nights <= 15)
{
    priceToBePaid = (nights * 25.00) * 0.65;
}
else if (kindOfRoom == "apartment" && nights > 15)
{
    priceToBePaid = (nights * 25.00) * 0.50;
}
else if (kindOfRoom == "president apartment" && nights < 10)
{
    priceToBePaid = (nights * 35.00) * 0.90;
}
else if (kindOfRoom == "president apartment" && nights >= 10 && nights <= 15)
{
    priceToBePaid = (nights * 35.00) * 0.85;
}
else if (kindOfRoom == "president apartment" && nights > 15)
{
    priceToBePaid = (nights * 35.00) * 0.80;
}

if (evaluation == "positive")
{
    priceToBePaid *= 1.25;
}
else if (evaluation == "negative")
{
    priceToBePaid *= 0.90;
}

Console.WriteLine($"{priceToBePaid:F2}");