int number = int.Parse(Console.ReadLine());
int times = int.Parse(Console.ReadLine());

for (int i = times; i <= 10; i++)
{
    Console.WriteLine($"{number} X {i} = {number * i}");
}

if (times > 10)
{
    Console.WriteLine($"{number} X {times} = {number * times}");
}