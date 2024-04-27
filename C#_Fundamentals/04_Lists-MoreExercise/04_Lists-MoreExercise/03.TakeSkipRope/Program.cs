string encryptedMessage = Console.ReadLine();
// example input: "T2exs15ti23ng1_3cT1h3e0_Roppe", "O{1ne1T2021wf312o13Th111xreve!!@!", "this forbidden mess of an age rating 0127504740"

List<char> chars = new List<char>(encryptedMessage.ToCharArray());
List<int> numbers = new List<int>();
List<int> takeList = new List<int>();
List<int> skipList = new List<int>();

for (int i = 0; i < chars.Count; i++)
{
    if (char.IsDigit(chars[i]))
    {
        numbers.Add(int.Parse(chars[i].ToString()));
        chars.RemoveAt(i);
        i--;
    }
}

for (int i = 0; i < numbers.Count; i++)
{
    if (i % 2 == 0)
    {
        takeList.Add(numbers[i]);
    }
    else
    {
        skipList.Add(numbers[i]);
    }
}

string decryptedMessage = string.Empty;

int currentChar = 0;

for (int i = 0; i < takeList.Count; i++)
{
    if (takeList[i] != 0)
    {
        int currentTake = takeList[i];

        for (int j = currentChar; j < currentChar + currentTake && j < chars.Count; j++)
        {
            decryptedMessage += chars[j];
        }
    }
    currentChar += takeList[i] + skipList[i];
}

Console.WriteLine(decryptedMessage);