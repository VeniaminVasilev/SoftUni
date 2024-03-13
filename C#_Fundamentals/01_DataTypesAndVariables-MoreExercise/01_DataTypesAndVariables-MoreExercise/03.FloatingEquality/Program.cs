double number1 = double.Parse(Console.ReadLine());
double number2 = double.Parse(Console.ReadLine());
double eps = 0.000001;

if (Math.Abs(number1 - number2) < eps)
{
    Console.WriteLine("True");
}
else
{
    Console.WriteLine("False");
}