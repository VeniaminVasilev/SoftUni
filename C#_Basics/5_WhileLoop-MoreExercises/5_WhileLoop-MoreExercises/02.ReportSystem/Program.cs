int neededSum = int.Parse(Console.ReadLine());
int gatheredSum = 0;
int paymentCounter = 0;
int cashPaymentCounter = 0;
int cashSum = 0;
int cardPaymentCounter = 0;
int cardSum = 0;

while (gatheredSum < neededSum)
{
    string command = Console.ReadLine();
    
    if (command == "End")
    {
        Console.WriteLine("Failed to collect required money for charity.");
        break;
    }

    paymentCounter++;

    if (paymentCounter % 2 == 1)
    {
        int cashPayment = int.Parse(command);

        if (cashPayment > 100)
        {
            Console.WriteLine("Error in transaction!");
        } else
        {
            Console.WriteLine("Product sold!");
            cashPaymentCounter++;
            cashSum += cashPayment;
            gatheredSum += cashPayment;
        }
    } else if (paymentCounter % 2 == 0)
    {
        int cardPayment = int.Parse(command);

        if (cardPayment < 10)
        {
            Console.WriteLine("Error in transaction!");
        } else
        {
            Console.WriteLine("Product sold!");
            cardPaymentCounter++;
            cardSum += cardPayment;
            gatheredSum += cardPayment;
        }
    }
}

if (gatheredSum >= neededSum)
{
    Console.WriteLine($"Average CS: {(double)cashSum / cashPaymentCounter:F2}");
    Console.WriteLine($"Average CC: {(double)cardSum / cardPaymentCounter:F2}");
}