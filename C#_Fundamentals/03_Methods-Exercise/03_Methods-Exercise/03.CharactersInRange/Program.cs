static string GetCharactersBetweenTwoCharacters(char character1, char character2)
{
    string result = string.Empty;
    if (character1 < character2)
    {
        for (int i = character1 + 1; i < character2; i++)
        {
            char currentCharacter = (char)i;
            result += $"{currentCharacter} ";
        }
    }
    else if (character1 > character2)
    {
        for (int i = character2 + 1; i < character1; i++)
        {
            char currentCharacter = (char)i;
            result += $"{currentCharacter} ";
        }
    }
    return result;
}

char character1 = char.Parse(Console.ReadLine());
char character2 = char.Parse(Console.ReadLine());
string result = GetCharactersBetweenTwoCharacters(character1, character2);
Console.WriteLine(result);