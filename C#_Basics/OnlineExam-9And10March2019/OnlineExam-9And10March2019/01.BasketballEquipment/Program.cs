int taxPerYear = int.Parse(Console.ReadLine());

double shoes = taxPerYear * 0.60;
double equipment = shoes * 0.80;
double ball = equipment * 0.25;
double accessories = ball * 0.20;
double allExpenses = taxPerYear + shoes + equipment + ball + accessories;

Console.WriteLine($"{allExpenses:F2}");