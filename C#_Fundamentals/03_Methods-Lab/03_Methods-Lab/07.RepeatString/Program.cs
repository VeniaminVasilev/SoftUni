static string RepeatString(string text, int repeat)
{
    string result = string.Empty;

    for (int i = 0; i < repeat; i++)
    {
        result += text;
    }

    return result;
}

string text = Console.ReadLine();
int repeat = int.Parse(Console.ReadLine());
string result = RepeatString(text, repeat);
Console.WriteLine(result);