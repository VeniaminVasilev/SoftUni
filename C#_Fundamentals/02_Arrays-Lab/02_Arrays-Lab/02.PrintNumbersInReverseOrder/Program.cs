int n = int.Parse(Console.ReadLine());

int[] array = new int[n];

for (int i = 0; i < n; i++)
{
    int currentNumber = int.Parse(Console.ReadLine());
    array[i] = currentNumber;
}

for (int i = n - 1; i >= 0; i--)
{
    Console.Write($"{array[i]} ");
}