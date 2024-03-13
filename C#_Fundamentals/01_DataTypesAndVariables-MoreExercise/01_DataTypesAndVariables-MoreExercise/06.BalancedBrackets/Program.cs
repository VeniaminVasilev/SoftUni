int lines = int.Parse(Console.ReadLine());
bool openedBrackets = false;
bool allBracketsAreClosed = true;
bool unbalanced = false;

for (int i = 0; i < lines; i++)
{
    string input = Console.ReadLine();

    if (char.TryParse(input, out char charValue))
    {
        if (charValue == '(' && openedBrackets == false)
        {
            openedBrackets = true;
            allBracketsAreClosed = false;
        }
        else if (charValue == '(' && openedBrackets == true)
        {
            allBracketsAreClosed = false;
            unbalanced = true;
        }
        else if (charValue == ')' && openedBrackets == true)
        {
            allBracketsAreClosed = true;
            openedBrackets = false;
        }
        else if (charValue == ')' && openedBrackets == false)
        {
            allBracketsAreClosed = false;
            unbalanced = true;
        }
    }
}

if (unbalanced == false && allBracketsAreClosed == true)
{
    Console.WriteLine("BALANCED");
}
else
{
    Console.WriteLine("UNBALANCED");
}