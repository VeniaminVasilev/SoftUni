double inheritedMoney = double.Parse(Console.ReadLine());
int year = int.Parse(Console.ReadLine());

int moneyNeeded = 0;

for (int i = 1800; i <= year; i++)
{
    if (i % 2 == 0)
    {
        moneyNeeded += 12000;
    } else if (i % 2 == 1)

    {
        moneyNeeded += 12000 + (50 * ((i - 1800) + 18));
    }
}

double difference = Math.Abs(inheritedMoney - moneyNeeded);

if (moneyNeeded <= inheritedMoney)
{
    Console.WriteLine($"Yes! He will live a carefree life and will have {difference:F2} dollars left.");
} else
{
    Console.WriteLine($"He will need {difference:F2} dollars to survive.");
}