﻿int number = int.Parse(Console.ReadLine());
int sum = 0;

while (number > sum)
{
    int input = int.Parse(Console.ReadLine());
    sum += input;
}

Console.WriteLine(sum);