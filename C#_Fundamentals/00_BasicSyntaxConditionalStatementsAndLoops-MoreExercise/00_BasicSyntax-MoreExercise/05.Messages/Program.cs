int numberOfCharacters = int.Parse(Console.ReadLine());

for (int i = 0; i < numberOfCharacters; i++)
{
    string input = Console.ReadLine();

    if (input == "0")
    {
        Console.Write(" ");
        continue;
    }

    int inputLength = input.Length;
    int mainDigit = int.Parse(input.Substring(0, 1));
    int offset = 0;

    if (mainDigit < 8)
    {
        offset = (mainDigit - 2) * 3;
    }
    else
    {
        offset = (mainDigit - 2) * 3 + 1;
    }

    int letterIndex = offset + inputLength - 1;
    char currentCharacter = (char)(letterIndex + 97);
    Console.Write(currentCharacter);
}