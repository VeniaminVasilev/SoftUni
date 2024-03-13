string username = Console.ReadLine();

int usernameLength = username.Length;
string password = string.Empty;
int attempts = 0;

for (int i = usernameLength - 1; i >= 0; i--)
{
    char currentChar = username[i];
    password += username[i];
}

while (true)
{
    string passwordAttempt = Console.ReadLine();
    
    if (passwordAttempt == password)
    {
        Console.WriteLine($"User {username} logged in.");
        break;
    }
    else if (passwordAttempt != password && attempts == 3)
    {
        Console.WriteLine($"User {username} blocked!");
        break;
    }
    else if (passwordAttempt != password)
    {
        Console.WriteLine($"Incorrect password. Try again.");
    }

    attempts++;
}