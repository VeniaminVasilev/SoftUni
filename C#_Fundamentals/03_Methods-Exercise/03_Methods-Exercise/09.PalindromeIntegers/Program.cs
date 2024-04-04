static bool CheckIfIntegerIsPalindrome(int number)
{
    bool isPalindromeInteger = true;
    string numberToString = number.ToString();
    int onePartLength = numberToString.Length / 2;

    for (int i = 0; i < onePartLength; i++)
    {
        if (numberToString[i] != numberToString[numberToString.Length - i - 1])
        {
            isPalindromeInteger = false;
            break;
        }
    }
    return isPalindromeInteger;
}

while (true)
{
    string command = Console.ReadLine();
    if (command == "END") { break; }

    int number = int.Parse(command);
    bool isPalindromeInteger = CheckIfIntegerIsPalindrome(number);

    Console.WriteLine(isPalindromeInteger.ToString().ToLower());
}