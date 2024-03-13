int magnolias = int.Parse(Console.ReadLine());
int ziumbiuls = int.Parse(Console.ReadLine());
int roses = int.Parse(Console.ReadLine());
int cactuses = int.Parse(Console.ReadLine());
double priceGift = double.Parse(Console.ReadLine());

double priceMagnolias = magnolias * 3.25;
double priceZiumbiuls = ziumbiuls * 4.0;
double priceRoses = roses * 3.50;
double priceCactuses = cactuses * 8.0;

double sum = priceMagnolias + priceZiumbiuls + priceRoses + priceCactuses;
double sumWithTax = sum * 0.95;
double difference = Math.Abs(sumWithTax - priceGift);

if (sumWithTax >= priceGift)
{
    Console.WriteLine($"She is left with {Math.Floor(difference)} leva.");
} else
{
    Console.WriteLine($"She will have to borrow {Math.Ceiling(difference)} leva.");
}