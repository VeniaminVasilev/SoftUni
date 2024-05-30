namespace _04.CaesarCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string originalText = Console.ReadLine();
            string encryptedText = string.Empty;

            for (int i = 0; i < originalText.Length; i++)
            {
                int currentCharPosition = originalText[i];
                char encryptedChar = (char)(currentCharPosition + 3);
                encryptedText += encryptedChar;
            }
            Console.WriteLine(encryptedText);
        }
    }
}