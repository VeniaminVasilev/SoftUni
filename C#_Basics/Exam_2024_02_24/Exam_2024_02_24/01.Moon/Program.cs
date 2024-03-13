double averageSpeed = double.Parse(Console.ReadLine());
double litersFuelFor100Km =  double.Parse(Console.ReadLine());

int fullDistance = 2 * 384400;
double hoursForFullJourney = Math.Ceiling((double)fullDistance / averageSpeed) + 3;
double litersFuelNeeded = ((double)fullDistance / 100) * litersFuelFor100Km;

Console.WriteLine(hoursForFullJourney);
Console.WriteLine(litersFuelNeeded);