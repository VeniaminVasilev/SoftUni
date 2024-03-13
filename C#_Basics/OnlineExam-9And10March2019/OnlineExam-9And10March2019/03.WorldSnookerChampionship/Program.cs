string phase = Console.ReadLine();
string ticket = Console.ReadLine();
int numberOfTickets = int.Parse(Console.ReadLine());
char photo = char.Parse(Console.ReadLine());

double priceTicket = 0;

if (phase == "Quarter final" && ticket == "Standard")
{
    priceTicket = 55.50;
}
else if (phase == "Quarter final" && ticket == "Premium")
{
    priceTicket = 105.20;
}
else if (phase == "Quarter final" && ticket == "VIP")
{
    priceTicket = 118.90;
}
else if (phase == "Semi final" && ticket == "Standard")
{
    priceTicket = 75.88;
}
else if (phase == "Semi final" && ticket == "Premium")
{
    priceTicket = 125.22;
}
else if (phase == "Semi final" && ticket == "VIP")
{
    priceTicket = 300.40;
}
else if (phase == "Final" && ticket == "Standard")
{
    priceTicket = 110.10;
}
else if (phase == "Final" && ticket == "Premium")
{
    priceTicket = 160.66;
}
else if (phase == "Final" && ticket == "VIP")
{
    priceTicket = 400;
}

double priceAllTickets = priceTicket * numberOfTickets;
double finalPrice = 0;

if (priceAllTickets > 4000)
{
    finalPrice = priceAllTickets * 0.75;
}
else if (priceAllTickets > 2500 && photo == 'Y')
{
    finalPrice = (priceAllTickets * 0.90) + (numberOfTickets * 40);
}
else if (priceAllTickets > 2500 && photo == 'N')
{
    finalPrice = priceAllTickets * 0.90;
}
else if (priceAllTickets <= 2500 && photo == 'Y')
{
    finalPrice = priceAllTickets + (numberOfTickets * 40);
}
else if (priceAllTickets <= 2500 && photo == 'N')
{
    finalPrice = priceAllTickets;
}

Console.WriteLine($"{finalPrice:F2}");