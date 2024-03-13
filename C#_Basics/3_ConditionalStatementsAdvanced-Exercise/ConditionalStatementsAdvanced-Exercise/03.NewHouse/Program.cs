string typeOfFlowers = Console.ReadLine();
int numberOfFlowers = int.Parse(Console.ReadLine());
int budget = int.Parse(Console.ReadLine());

double price = 0.0;

if (typeOfFlowers == "Roses")
{
    if (numberOfFlowers > 80)
    {
        price = (numberOfFlowers * 5.0) * 0.9;
    } else
    {
        price = numberOfFlowers * 5.0;
    }
} else if (typeOfFlowers == "Dahlias")
{
    if (numberOfFlowers > 90)
    {
        price = (numberOfFlowers * 3.80) * 0.85;
    } else
    {
        price = numberOfFlowers * 3.80;
    }
} else if (typeOfFlowers == "Tulips")
{
    if (numberOfFlowers > 80)
    {
        price = (numberOfFlowers * 2.80) * 0.85;
    } else
    {
        price = numberOfFlowers * 2.80;
    }
} else if (typeOfFlowers == "Narcissus")
{
    if (numberOfFlowers < 120)
    {
        price = (numberOfFlowers * 3.0) * 1.15;
    } else
    {
        price = numberOfFlowers * 3.0;
    }
} else if (typeOfFlowers == "Gladiolus")
{
    if (numberOfFlowers < 80)
    {
        price = (numberOfFlowers * 2.50) * 1.20;
    } else
    {
        price = numberOfFlowers * 2.50;
    }
}

double difference = Math.Abs(price - budget);

if (budget >= price)
{
    Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers} {typeOfFlowers} and {difference:F2} leva left.");
} else
{
    Console.WriteLine($"Not enough money, you need {difference:F2} leva more.");
}