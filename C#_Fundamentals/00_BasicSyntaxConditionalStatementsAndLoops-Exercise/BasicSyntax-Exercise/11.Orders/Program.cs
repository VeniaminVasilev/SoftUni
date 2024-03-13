int numberOfOrders = int.Parse(Console.ReadLine());

double totalPrice = 0;

for (int i = 1; i <= numberOfOrders; i++)
{
    double pricePerCapsule = double.Parse(Console.ReadLine());
    int days = int.Parse(Console.ReadLine());
    int capsulesCount = int.Parse(Console.ReadLine());

    double priceCoffee = ((days * capsulesCount) * pricePerCapsule);

    Console.WriteLine($"The price for the coffee is: ${priceCoffee:F2}");

    totalPrice += priceCoffee;
}

Console.WriteLine($"Total: ${totalPrice:F2}");