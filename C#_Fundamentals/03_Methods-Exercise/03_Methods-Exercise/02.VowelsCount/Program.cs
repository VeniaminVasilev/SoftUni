string input = Console.ReadLine();

static int GetVowelsCount(string input)
{
    string vowels = "AEIOUaeiou";
    int vowelsCount = 0;
    for (int i = 0; i < input.Length; i++)
    {
        if (vowels.Contains(input[i]))
        {
            vowelsCount++;
        }
    }
    return vowelsCount;
}

int vowelsCount = GetVowelsCount(input);
Console.WriteLine(vowelsCount);