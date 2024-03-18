int number = int.Parse(Console.ReadLine());

int[] fibonacci = new int[number + 1];
fibonacci[0] = 0;
fibonacci[1] = 1;

for (int i = 2; i < fibonacci.Length; i++)
{
    fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
}

Console.WriteLine(fibonacci[number]);