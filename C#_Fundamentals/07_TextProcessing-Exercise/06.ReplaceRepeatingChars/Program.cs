List<char> charList = new List<char>();
string line = Console.ReadLine();

char lastCharacter = line[0];

for (int i = 0; i < line.Length; i++)
{
    if (i == 0)
    {
        charList.Add(line[i]);
        lastCharacter = line[i];
    }
    else if (lastCharacter != line[i])
    {
        charList.Add(line[i]);
        lastCharacter = line[i];
    }
}

Console.WriteLine(string.Join(string.Empty, charList));