using System.Text.RegularExpressions;

static bool CheckIfPasswordLengthIsValid(string password)
{
    bool validPasswordLength = true;

    if (password.Length < 6 || password.Length > 10)
    {
        validPasswordLength = false;
        Console.WriteLine("Password must be between 6 and 10 characters");
    }
    return validPasswordLength;
}

static bool CheckIfPasswordContainsOnlyLettersAndDigits(string password)
{
    bool containsOnlyLettersAndDigits = Regex.IsMatch(password, "^[a-zA-Z0-9]+$");

    if (!containsOnlyLettersAndDigits)
    {
        Console.WriteLine($"Password must consist only of letters and digits");
    }
    return containsOnlyLettersAndDigits;
}

static bool CheckIfPasswordContainsAtLeastTwoDigits(string password)
{
    bool containsAtleastTwoDigits = Regex.IsMatch(password, "^(.*\\d){2,}.*$");

    if (!containsAtleastTwoDigits)
    {
        Console.WriteLine($"Password must have at least 2 digits");
    }
    return containsAtleastTwoDigits;
}

string password = Console.ReadLine();
bool validPasswordLength = CheckIfPasswordLengthIsValid(password);
bool containsOnlyLettersAndDigits = CheckIfPasswordContainsOnlyLettersAndDigits(password);
bool containsAtleastTwoDigits = CheckIfPasswordContainsAtLeastTwoDigits(password);

if (validPasswordLength && containsOnlyLettersAndDigits && containsAtleastTwoDigits)
{
    Console.WriteLine($"Password is valid");
}