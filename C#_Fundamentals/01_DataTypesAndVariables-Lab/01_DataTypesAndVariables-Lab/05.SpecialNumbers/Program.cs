int n = int.Parse(Console.ReadLine());

for (int i = 1; i <= n; i++)
{
    int number = i;
    int sum = 0;
    while (true)
    {
        sum += number % 10;
        number /= 10;

        if (number == 0) { break; }
    }

    if (sum == 5 || sum == 7 || sum == 11)
    { 
        Console.WriteLine($"{i} -> True"); 
    }
    else
    {
        Console.WriteLine($"{i} -> False");
    }
}