List<int> list = Console.ReadLine()
    .Split(" ")
    .Select(int.Parse)
    .ToList();

string sentence = Console.ReadLine();
List<char> charList = new List<char>(sentence.ToCharArray());

List<char> message = new List<char>();

for (int i = 0; i < list.Count; i++)
{
    int currentSumOfDigits = 0;
    string currentNumber = list[i].ToString();
    for (int j = 0; j < currentNumber.Length; j++)
    {
        currentSumOfDigits += int.Parse(currentNumber[j].ToString());
    }

    int index = currentSumOfDigits % charList.Count;
    message.Add(charList[index]);
    charList.RemoveAt(index);
}

Console.WriteLine(string.Join("", message));