int pokePowerN = int.Parse(Console.ReadLine());
int distanceM = int.Parse(Console.ReadLine());
int exhaustionFactorY = int.Parse(Console.ReadLine());

int currentPower = pokePowerN;
int countOfTargetsPoked = 0;

while (true)
{
    if (currentPower * 2 == pokePowerN && exhaustionFactorY != 0)
    {
        currentPower /= exhaustionFactorY;
    }

    if (distanceM > currentPower) { break; }

    currentPower -= distanceM;
    countOfTargetsPoked++;
}

Console.WriteLine(currentPower);
Console.WriteLine(countOfTargetsPoked);