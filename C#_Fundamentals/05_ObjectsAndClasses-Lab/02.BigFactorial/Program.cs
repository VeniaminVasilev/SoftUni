﻿using System.Numerics;

int n = int.Parse(Console.ReadLine());
BigInteger factorial = 1;

for (int i = 2; i <= n; i++)
{
    factorial *= i;
}

Console.WriteLine(factorial);