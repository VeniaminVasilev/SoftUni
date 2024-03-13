using System.Numerics;

int numberOfSnowballs = int.Parse(Console.ReadLine());

int bestSnow = int.MinValue;
int bestTime = int.MinValue;
int bestQuality = int.MinValue;
BigInteger bestValue = int.MinValue;

for (int i = 0; i < numberOfSnowballs; i++)
{
    int snowballSnow = int.Parse(Console.ReadLine());
    int snowballTime = int.Parse(Console.ReadLine());
    int snowballQuality = int.Parse(Console.ReadLine());

    if (snowballTime == 0) { continue; }

    BigInteger snowballValue = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);

    if (snowballValue >= bestValue)
    {
        bestValue = snowballValue;
        bestSnow = snowballSnow;
        bestTime = snowballTime;
        bestQuality = snowballQuality;
    }
}

Console.WriteLine($"{bestSnow} : {bestTime} = {bestValue} ({bestQuality})");