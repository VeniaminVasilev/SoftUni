string input = Console.ReadLine();

int inputLength = input.Length;

for (int i = inputLength - 1; i >= 0; i--)
{
    char currentChar = input[i];
    Console.Write(currentChar);
}