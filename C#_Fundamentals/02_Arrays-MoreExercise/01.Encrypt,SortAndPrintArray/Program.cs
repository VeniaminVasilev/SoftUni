int numberStrings = int.Parse(Console.ReadLine());
int[] numbers = new int[numberStrings];

for (int i = 0; i < numberStrings; i++)
{
    string currentName = Console.ReadLine();
    int sumCurrentName = 0;

    for (int j = 0; j < currentName.Length; j++)
    {
        char c = currentName[j];

        if ("aeiouAEIOU".IndexOf(c) >= 0)
        {
            int vowelValue = currentName.Length * (int)c;
            sumCurrentName += vowelValue;
        }
        else //if (Char.IsLetter(c))
        {
            int consonantValue = (int)c / currentName.Length;
            sumCurrentName += consonantValue;
        }
    }

    numbers[i] = sumCurrentName;
}

Array.Sort(numbers);

foreach (int number in numbers)
{
    Console.WriteLine(number);
}