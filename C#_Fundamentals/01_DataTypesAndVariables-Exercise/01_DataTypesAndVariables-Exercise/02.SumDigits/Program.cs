int number = int.Parse(Console.ReadLine());
string numberString = number.ToString();
int sum = 0;

for (int i = 0; i < numberString.Length; i++)
{
    char currentChar = numberString[i];
    int currentNumber = int.Parse(currentChar.ToString());
    sum += currentNumber;
}

Console.WriteLine(sum);