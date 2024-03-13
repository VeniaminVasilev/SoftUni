string result1 = Console.ReadLine();
string result2 = Console.ReadLine();
string result3 = Console.ReadLine();

int wins = 0;
int loses = 0;
int draws = 0;

if (result1[0] == result1[2])
{
    draws++;
} else if (result1[0] > result1[2])
{
    wins++;
}
else if (result1[0] < result1[2])
{
    loses++;
}

if (result2[0] == result2[2])
{
    draws++;
}
else if (result2[0] > result2[2])
{
    wins++;
}
else if (result2[0] < result2[2])
{
    loses++;
}

if (result3[0] == result3[2])
{
    draws++;
}
else if (result3[0] > result3[2])
{
    wins++;
}
else if (result3[0] < result3[2])
{
    loses++;
}

Console.WriteLine($"Team won {wins} games.");
Console.WriteLine($"Team lost {loses} games.");
Console.WriteLine($"Drawn games: {draws}");