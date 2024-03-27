string product = Console.ReadLine();
int quantity = int.Parse(Console.ReadLine());

static void TotalPrice(string product, int quantity)
{
    double price = 0;
    if (product == "coffee")
    { 
        price = 1.50 * quantity;
        Console.WriteLine($"{price:F2}");
    }
    else if (product == "water")
    {
        price = 1.00 * quantity;
        Console.WriteLine($"{price:F2}");
    }
    else if (product == "coke")
    {
        price = 1.40 * quantity;
        Console.WriteLine($"{price:F2}");
    }
    else if (product == "snacks")
    {
        price = 2.00 * quantity;
        Console.WriteLine($"{price:F2}");
    }
}

TotalPrice(product, quantity);