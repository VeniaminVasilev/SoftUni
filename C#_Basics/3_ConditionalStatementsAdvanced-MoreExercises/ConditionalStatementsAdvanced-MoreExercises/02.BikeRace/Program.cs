int juniors = int.Parse(Console.ReadLine());
int seniors = int.Parse(Console.ReadLine());
string track = Console.ReadLine(); //"trail", "cross-country", "downhill" или "road"

double money = 0.00;

if (track == "trail")
{
    money = (juniors * 5.50) + (seniors * 7.00);
} else if (track == "cross-country")
{
    money = (juniors * 8.00) + (seniors * 9.50);
} else if (track == "downhill")
{
    money = (juniors * 12.25) + (seniors * 13.75);
} else if (track == "road")
{
    money = (juniors * 20.00) + (seniors * 21.50);
}

if (track == "cross-country" && (seniors + juniors) >= 50)
{
    money = money * 0.75;
}

money = money * 0.95;

Console.WriteLine($"{money:F2}");