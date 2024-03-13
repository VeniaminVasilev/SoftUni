string city = Console.ReadLine();
double sales = double.Parse(Console.ReadLine());

if (city == "Sofia")
{
    switch (sales)
    {
        case double n when (n >= 0 && n <= 500):
            Console.WriteLine("{0:F2}", sales * 0.05);
            break;
        case double n when (n > 500 && n <= 1000):
            Console.WriteLine("{0:F2}", sales * 0.07);
            break;
        case double n when (n > 1000 && n <= 10000):
            Console.WriteLine("{0:F2}", sales * 0.08);
            break;
        case > 10000:
            Console.WriteLine("{0:F2}", sales * 0.12);
            break;
        default:
            Console.WriteLine("error");
            break;
    }
} else if (city == "Varna")
{
    switch (sales)
    {
        case double n when (n >= 0 && n <= 500):
            Console.WriteLine("{0:F2}", sales * 0.045);
            break;
        case double n when (n > 500 && n <= 1000):
            Console.WriteLine("{0:F2}", sales * 0.075);
            break;
        case double n when (n > 1000 && n <= 10000):
            Console.WriteLine("{0:F2}", sales * 0.10);
            break;
        case > 10000:
            Console.WriteLine("{0:F2}", sales * 0.13);
            break;
        default:
            Console.WriteLine("error");
            break;
    }
} else if (city == "Plovdiv")
{
    switch (sales)
    {
        case double n when (n >= 0 && n <= 500):
            Console.WriteLine("{0:F2}", sales * 0.055);
            break;
        case double n when (n > 500 && n <= 1000):
            Console.WriteLine("{0:F2}", sales * 0.08);
            break;
        case double n when (n > 1000 && n <= 10000):
            Console.WriteLine("{0:F2}", sales * 0.12);
            break;
        case > 10000:
            Console.WriteLine("{0:F2}", sales * 0.145);
            break;
        default:
            Console.WriteLine("error");
            break;
    }
} else
{
    Console.WriteLine("error");
}