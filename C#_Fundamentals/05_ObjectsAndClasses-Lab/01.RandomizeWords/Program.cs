string[] words = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToArray();

var rnd = new Random();

for (int currentIndex = 0; currentIndex < words.Length; currentIndex++)
{
    int randomIndex = rnd.Next(0, words.Length);

    string nextNumber = words[randomIndex];
    string currentNumber = words[currentIndex];

    words[currentIndex] = nextNumber;
    words[randomIndex] = currentNumber;
}

foreach (string word in words)
{
    Console.WriteLine(word);
}