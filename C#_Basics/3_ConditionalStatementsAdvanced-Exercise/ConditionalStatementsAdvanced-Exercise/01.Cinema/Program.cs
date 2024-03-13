string typeProjection = Console.ReadLine();
int rows = int.Parse(Console.ReadLine());
int columns = int.Parse(Console.ReadLine());

double income = 0.0;

if (typeProjection == "Premiere")
{
    income = rows * columns * 12.00;
} else if (typeProjection == "Normal")
{
    income = rows * columns * 7.50;
} else if (typeProjection == "Discount")
{
    income = rows * columns * 5.00;
}
Console.WriteLine($"{income:F2} leva");