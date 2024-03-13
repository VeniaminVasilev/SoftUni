int age = int.Parse(Console.ReadLine());
double priceWashingMachine = double.Parse(Console.ReadLine());
int priceToy = int.Parse(Console.ReadLine());

int sumToys = 0;
int sumMoney = 0;

for (int i = 1; i <= age; i++)
{
    if (i % 2 == 1)
    {
        sumToys += priceToy;
    }
    else if (i % 2 == 0)
    {
        sumMoney += ((i / 2) * 10) - 1;
    }
}

double totalSum = sumToys + sumMoney;
double difference = Math.Abs(totalSum - priceWashingMachine);

if (totalSum >= priceWashingMachine)
{
    Console.WriteLine($"Yes! {difference:F2}");
} else
{
    Console.WriteLine($"No! {difference:F2}");
}