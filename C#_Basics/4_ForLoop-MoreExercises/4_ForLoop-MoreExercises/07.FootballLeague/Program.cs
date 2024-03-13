int stadiumCapacity = int.Parse(Console.ReadLine());
int numberOfFans = int.Parse(Console.ReadLine());
int fansA = 0;
int fansB = 0;
int fansV = 0;
int fansG = 0;

for (int i = 0; i < numberOfFans; i++)
{
    char sector = char.Parse(Console.ReadLine());

    if (sector == 'A')
    {
        fansA++;
    }
    else if (sector == 'B')
    {
        fansB++;
    }
    else if (sector == 'V')
    {
        fansV++;
    }
    else if (sector == 'G')
    {
        fansG++;
    }
}

Console.WriteLine($"{((double)fansA / numberOfFans) * 100:F2}%");
Console.WriteLine($"{((double)fansB / numberOfFans) * 100:F2}%");
Console.WriteLine($"{((double)fansV / numberOfFans) * 100:F2}%");
Console.WriteLine($"{((double)fansG / numberOfFans) * 100:F2}%");
Console.WriteLine($"{((double)numberOfFans / stadiumCapacity) * 100:F2}%");