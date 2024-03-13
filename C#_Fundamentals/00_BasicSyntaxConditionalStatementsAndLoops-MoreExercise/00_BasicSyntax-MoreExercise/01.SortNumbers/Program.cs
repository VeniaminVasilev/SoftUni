int number1 = int.Parse(Console.ReadLine());
int number2 = int.Parse(Console.ReadLine());
int number3 = int.Parse(Console.ReadLine());

// 1 2 3; 1 3 2; 2 1 3; 2 3 1; 3 2 1; 3 1 2;

if (number1 >= number2 && number2 >= number3)
{
    Console.WriteLine(number1);
    Console.WriteLine(number2);
    Console.WriteLine(number3);
}
else if (number1 >= number3 && number3 >= number2)
{
    Console.WriteLine(number1);
    Console.WriteLine(number3);
    Console.WriteLine(number2);
}
else if (number2 >= number1 && number1 >= number3)
{
    Console.WriteLine(number2);
    Console.WriteLine(number1);
    Console.WriteLine(number3);
}
else if (number2 >= number3 && number3 >= number1)
{
    Console.WriteLine(number2);
    Console.WriteLine(number3);
    Console.WriteLine(number1);
}
else if (number3 >= number2 && number2 >= number1)
{
    Console.WriteLine(number3);
    Console.WriteLine(number2);
    Console.WriteLine(number1);
}
else if (number3 >= number1 && number1 >= number2)
{
    Console.WriteLine(number3);
    Console.WriteLine(number1);
    Console.WriteLine(number2);
}