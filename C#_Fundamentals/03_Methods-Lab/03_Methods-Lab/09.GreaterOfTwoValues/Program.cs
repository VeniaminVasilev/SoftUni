string type = Console.ReadLine();

if (type == "int")
{
    int number1 = int.Parse(Console.ReadLine());
    int number2 = int.Parse(Console.ReadLine());
    GetMaxInt(number1, number2);
}
else if (type == "char")
{
    char character1 = char.Parse(Console.ReadLine());
    char character2 = char.Parse(Console.ReadLine());
    GetMaxChar(character1, character2);
}
else if (type == "string")
{
    string string1 = Console.ReadLine();
    string string2 = Console.ReadLine();
    GetMaxString(string1, string2);
}

static void GetMaxInt(int number1, int number2)
{
    int resultInt = 0;
    if (number1 > number2)
    {
        resultInt = number1;
    }
    else if (number1 < number2)
    {
        resultInt = number2;
    }
    Console.WriteLine(resultInt);
}

static void GetMaxChar(char character1, char character2)
{
    char resultCharacter = 'a';
    if (character1 > character2)
    {
        resultCharacter = character1;
    }
    else if (character1 < character2)
    {
        resultCharacter = character2;
    }
    Console.WriteLine(resultCharacter);
}

static void GetMaxString(string string1, string string2)
{
    string resultString = string.Empty;
    if (string1.CompareTo(string2) > 0)
    {
        resultString = string1;
    }
    else if (string1.CompareTo(string2) < 0)
    {
        resultString = string2;
    }
    Console.WriteLine(resultString);
}