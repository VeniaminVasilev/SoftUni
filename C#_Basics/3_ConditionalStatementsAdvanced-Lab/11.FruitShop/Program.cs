string fruit = Console.ReadLine();
string day = Console.ReadLine();
double amount = double.Parse(Console.ReadLine());

if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
{
    switch (fruit)
    {
        case "banana":
            Console.WriteLine("{0:F2}", 2.50 * amount);
            break;
        case "apple":
            Console.WriteLine("{0:F2}", 1.20 * amount);
            break;
        case "orange":
            Console.WriteLine("{0:F2}", 0.85 * amount);
            break;
        case "grapefruit":
            Console.WriteLine("{0:F2}", 1.45 * amount);
            break;
        case "kiwi":
            Console.WriteLine("{0:F2}", 2.70 * amount);
            break;
        case "pineapple":
            Console.WriteLine("{0:F2}", 5.50 * amount);
            break;
        case "grapes":
            Console.WriteLine("{0:F2}", 3.85 * amount);
            break;
        default:
            Console.WriteLine("error");
            break;
    }
} else if (day == "Saturday" || day == "Sunday")
{
    switch (fruit)
    {
        case "banana":
            Console.WriteLine("{0:F2}", 2.70 * amount);
            break;
        case "apple":
            Console.WriteLine("{0:F2}", 1.25 * amount);
            break;
        case "orange":
            Console.WriteLine("{0:F2}", 0.90 * amount);
            break;
        case "grapefruit":
            Console.WriteLine("{0:F2}", 1.60 * amount);
            break;
        case "kiwi":
            Console.WriteLine("{0:F2}", 3.00 * amount);
            break;
        case "pineapple":
            Console.WriteLine("{0:F2}", 5.60 * amount);
            break;
        case "grapes":
            Console.WriteLine("{0:F2}", 4.20 * amount);
            break;
        default:
            Console.WriteLine("error");
            break;
    }
} else
{
    Console.WriteLine("error");
}