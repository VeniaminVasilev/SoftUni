string sentence = string.Empty;
string word = string.Empty;
bool cFound = false;
bool oFound = false;
bool nFound = false;

while (true)
{
    string command = Console.ReadLine();

    if (command == "End")
    {
        break;
    }

    char ch = char.Parse(command);

    if (ch == 'c' && cFound == false)
    {
        cFound = true;
    } else if (ch == 'c' && cFound == true)
    {
        word += 'c';
    }

    if (ch == 'o' && oFound == false)
    {
        oFound = true;
    }
    else if (ch == 'o' && oFound == true)
    {
        word += 'o';
    }

    if (ch == 'n' && nFound == false)
    {
        nFound = true;
    }
    else if (ch == 'n' && nFound == true)
    {
        word += 'n';
    }

    if (cFound == true && oFound == true && nFound == true)
    {
        cFound = false;
        oFound = false;
        nFound = false;
        sentence += word + " ";
        word = string.Empty;
    }

    if (char.IsLetter(ch) && ch != 'c' && ch != 'o' && ch != 'n')
    {
        word += ch;
    } 
}

Console.WriteLine(sentence);