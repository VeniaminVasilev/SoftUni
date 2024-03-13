int key = int.Parse(Console.ReadLine());
int lines = int.Parse(Console.ReadLine());
string decryptedMessage = string.Empty;

for (int i = 0; i < lines; i++)
{
    char currentChar = char.Parse(Console.ReadLine());
    char decryptedChar = (char)(currentChar + key);
    decryptedMessage += decryptedChar;
}
Console.WriteLine(decryptedMessage);