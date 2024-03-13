int kilometers = int.Parse(Console.ReadLine());
string dayNight = Console.ReadLine();

double taxiDay = 0.70 + (0.79 * kilometers);
double taxiNight = 0.70 + (0.90 * kilometers);
double bus = 0.09 * kilometers; //Може да се използва за разстояния минимум 20 км.
double train = 0.06 * kilometers; //Може да се използва за разстояния минимум 100 км.

if (kilometers < 20 && dayNight == "day")
{
    Console.WriteLine($"{taxiDay:F2}");
} else if (kilometers < 20 && dayNight == "night")
{
    Console.WriteLine($"{taxiNight:F2}");
} else if (kilometers >= 20 && kilometers < 100)
{
    Console.WriteLine($"{bus:F2}");
} else if (kilometers >= 100)
{
    Console.WriteLine($"{train:F2}");
}