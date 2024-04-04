static string GetMiddleCharacter(string input)
{
    string middleCharacter = string.Empty;
    if (input.Length % 2 == 0)
    {
        int stringLength = input.Length;
        int middleCharacter1 = (stringLength / 2) - 1;
        int middleCharacter2 = stringLength / 2;
        middleCharacter = $"{input[middleCharacter1]}{input[middleCharacter2]}";
    }
    else
    {
        int stringLength = input.Length;
        int middleCharacter1 = stringLength / 2;
        middleCharacter = $"{input[middleCharacter1]}";
    }
    return middleCharacter;
}

string input = Console.ReadLine();
string middleCharacter = GetMiddleCharacter(input);
Console.WriteLine(middleCharacter);