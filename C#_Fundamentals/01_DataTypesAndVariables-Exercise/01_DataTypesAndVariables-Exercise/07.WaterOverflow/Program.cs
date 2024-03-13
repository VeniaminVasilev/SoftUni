int n = int.Parse(Console.ReadLine());
int tankCapacity = 255;
int litersInTheTank = 0;

for (int i = 0; i < n; i++)
{
    int currentLiters = int.Parse(Console.ReadLine());
    if (currentLiters + litersInTheTank > tankCapacity)
    {
        Console.WriteLine("Insufficient capacity!");
        continue;
    }
    litersInTheTank += currentLiters;
}
Console.WriteLine(litersInTheTank);