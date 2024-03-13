double priceTennisRocket = double.Parse(Console.ReadLine());
int numberOfTennisRockets = int.Parse(Console.ReadLine());
int numberOfPairsShoes = int.Parse(Console.ReadLine());
double priceAllShoes = numberOfPairsShoes * (priceTennisRocket / 6.0);
double priceRocketsAndShoes = (priceTennisRocket * numberOfTennisRockets) + priceAllShoes;
double priceOtherEquipment = priceRocketsAndShoes * 0.20;
double priceAll = priceRocketsAndShoes + priceOtherEquipment;

Console.WriteLine($"Price to be paid by Djokovic {Math.Floor(priceAll / 8)}");
Console.WriteLine($"Price to be paid by sponsors {Math.Ceiling((priceAll * 7) / 8)}");