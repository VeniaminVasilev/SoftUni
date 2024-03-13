int number1 = int.Parse(Console.ReadLine());
int number2 = int.Parse(Console.ReadLine());

int sum = 0;

for (int i = number1; i <= number2; i++)
{
    Console.Write($"{i} ");
    sum += i;
}
Console.WriteLine();
Console.WriteLine($"Sum: {sum}");