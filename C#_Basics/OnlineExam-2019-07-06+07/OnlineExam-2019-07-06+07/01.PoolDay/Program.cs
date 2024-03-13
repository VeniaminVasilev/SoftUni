int numberPeople = int.Parse(Console.ReadLine());
double tax = double.Parse(Console.ReadLine());
double lounger = double.Parse(Console.ReadLine());
double umbrella = double.Parse(Console.ReadLine());

double sum = (numberPeople * tax) + (Math.Ceiling(numberPeople / 2.0) * umbrella) + (Math.Ceiling(numberPeople * 0.75) * lounger);

Console.WriteLine($"{sum:F2} lv.");