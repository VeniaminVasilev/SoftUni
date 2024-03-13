int numberOfLoads = int.Parse(Console.ReadLine());

int microbus = 0;
int truck = 0;
int train = 0;

for (int i = 0; i < numberOfLoads; i++)
{
    int ton = int.Parse(Console.ReadLine());

    if (ton <= 3)
    {
        microbus += ton;
    } else if (ton <= 11)
    {
        truck += ton;
    } else if (ton >= 12)
    {
        train += ton;
    }
}

double priceMicrobus = microbus * 200.0;
double priceTruck = truck * 175.0;
double priceTrain = train * 120.0;
double priceAll = priceMicrobus + priceTruck + priceTrain;

int allTones = microbus + truck + train;

Console.WriteLine($"{(priceAll / allTones):F2}");
Console.WriteLine($"{((double)microbus / allTones) * 100:F2}%");
Console.WriteLine($"{((double)truck / allTones) * 100:F2}%");
Console.WriteLine($"{((double)train / allTones) * 100:F2}%");