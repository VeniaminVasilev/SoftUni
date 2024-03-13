string input = Console.ReadLine();

double[] numbers = input.Split(' ').Select(double.Parse).ToArray();

foreach (double number in numbers)
{
    int rounded = (int)Math.Round(number, MidpointRounding.AwayFromZero);
    Console.WriteLine("{0} => {1}", number, rounded);
}