double priceParty = double.Parse(Console.ReadLine());
int numberLoveLetters = int.Parse(Console.ReadLine());
int numberRoses = int.Parse(Console.ReadLine());
int numberKeyHolders = int.Parse(Console.ReadLine());
int numberCaricatures = int.Parse(Console.ReadLine());
int numberLuckSurprizes = int.Parse(Console.ReadLine());

double priceLoveLetters = numberLoveLetters * 0.60;
double priceRoses = numberRoses * 7.20;
double priceKeyHolders = numberKeyHolders * 3.60;
double priceCaricatures = numberCaricatures * 18.20;
double priceLuckSurprizes = numberLuckSurprizes * 22.00;

double sumPrices = priceLoveLetters + priceRoses + priceKeyHolders + priceCaricatures + priceLuckSurprizes;
double finalSum = sumPrices;

if ((numberLoveLetters + numberRoses + numberKeyHolders + numberCaricatures + numberLuckSurprizes) >= 25)
{
    finalSum = finalSum - (finalSum * 0.35);
    finalSum *= 0.90;
}
else
{
    finalSum *= 0.90;
}

if (finalSum >= priceParty)
{
    Console.WriteLine($"Yes! {finalSum - priceParty:F2} lv left.");
}
else
{
    Console.WriteLine($"Not enough money! {priceParty - finalSum:F2} lv needed.");
}