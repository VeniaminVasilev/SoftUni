string month = Console.ReadLine();
int days = int.Parse(Console.ReadLine());

double studio = 0.00;
double apartment = 0.00;
if (month == "May" || month == "October")
{
    if (days > 7 && days <= 14)
    {
        studio = (days * 50.0) * 0.95;
        apartment = days * 65.0;
    } else if (days > 14)
    {
        studio = (days * 50.0) * 0.70;
        apartment = (days * 65.0) * 0.90;
    } else
    {
        studio = days * 50.0;
        apartment = days * 65.0;
    }
} else if (month == "June" || month == "September")
{
    if (days > 14)
    {
        studio = (days * 75.20) * 0.80;
        apartment = (days * 68.70) * 0.90;
    } else
    {
        studio = days * 75.20;
        apartment = days * 68.70;
    }
} else if (month == "July" || month == "August")
{
    if (days > 14)
    {
        studio = days * 76.00;
        apartment = (days * 77.00) * 0.90;
    } else
    {
        studio = days * 76.00;
        apartment = days * 77.00;
    }
}

Console.WriteLine($"Apartment: {apartment:F2} lv.");
Console.WriteLine($"Studio: {studio:F2} lv.");