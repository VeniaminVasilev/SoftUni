double desiredIncome = double.Parse(Console.ReadLine());

double income = 0;

while (true)
{
    string cocktail = Console.ReadLine();

    if (cocktail == "Party!")
    {
        Console.WriteLine($"We need {desiredIncome - income:F2} leva more.");
        break;
    }

    int numberOfCocktails = int.Parse(Console.ReadLine());

    int priceCocktail = cocktail.Length;

    double currentPurchase = priceCocktail * numberOfCocktails;

    if (currentPurchase % 2 != 0)
    {
        currentPurchase *= 0.75;
    }

    income += currentPurchase;

    if (income >= desiredIncome)
    {
        Console.WriteLine($"Target acquired.");
        break;
    }
}

Console.WriteLine($"Club income - {income:F2} leva.");