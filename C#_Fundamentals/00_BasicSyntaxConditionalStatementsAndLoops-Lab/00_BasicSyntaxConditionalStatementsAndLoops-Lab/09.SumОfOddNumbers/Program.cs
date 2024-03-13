int n = int.Parse(Console.ReadLine());
int sum = 0;

for (int counterOddNumbers = 1; counterOddNumbers <= n; counterOddNumbers++)
{
    int currentNumber = (counterOddNumbers * 2) - 1;
    Console.WriteLine(currentNumber);
    sum += currentNumber;
}
Console.WriteLine($"Sum: {sum}");