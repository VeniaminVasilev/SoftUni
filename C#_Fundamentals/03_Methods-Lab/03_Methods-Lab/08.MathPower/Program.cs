double baseNumber = double.Parse(Console.ReadLine());
int power = int.Parse(Console.ReadLine());

static double RaiseToPower(double baseNumber, int power)
{
    double result = Math.Pow(baseNumber, power);
    return result;
}

double result = RaiseToPower(baseNumber, power);
Console.WriteLine(result);