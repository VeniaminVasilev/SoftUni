int chrysanthemums = int.Parse(Console.ReadLine());
int roses = int.Parse(Console.ReadLine());
int tulips  = int.Parse(Console.ReadLine());
string season = Console.ReadLine();
char holiday = char.Parse(Console.ReadLine());

double priceChrysanthemums = 0.00;
double priceRoses = 0.00;
double priceTulips = 0.00;

if (season == "Spring" || season == "Summer")
{
    priceChrysanthemums = chrysanthemums * 2.00;
    priceRoses = roses * 4.10;
    priceTulips = tulips * 2.50;
} else if (season == "Autumn" || season == "Winter")
{
    priceChrysanthemums = chrysanthemums * 3.75;
    priceRoses = roses * 4.50;
    priceTulips = tulips * 4.15;
}

if (holiday == 'Y')
{
    priceChrysanthemums *= 1.15;
    priceRoses *= 1.15;
    priceTulips *= 1.15;
}

double priceBouquet = priceChrysanthemums + priceRoses + priceTulips;

if (season == "Spring" && tulips > 7)
{
    priceBouquet *= 0.95;
}

if (season == "Winter" && roses >= 10)
{
    priceBouquet *= 0.90;
}

if ((chrysanthemums + roses + tulips) > 20)
{
    priceBouquet *= 0.80;
}

priceBouquet += 2.00;

Console.WriteLine($"{priceBouquet:F2}");