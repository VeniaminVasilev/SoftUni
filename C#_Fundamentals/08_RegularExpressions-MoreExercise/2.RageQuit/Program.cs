using System.Text;

namespace _2.RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToUpper();

            string partText = "";

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                if (!char.IsDigit(text[i]))
                {
                    partText += text[i];
                }

                else if (char.IsDigit(text[i]))
                {
                    string number = text[i].ToString();

                    if (i + 1 < text.Length)
                    {
                        if (char.IsDigit(text[i + 1]))
                        {
                            number += text[i + 1];
                            i += 1;
                        }
                    }

                    int counter = int.Parse(number);

                    for (int j = 0; j < counter; j++)
                    {
                        builder.Append(partText);
                    }

                    partText = "";
                }
            }

            string rageMessage = builder.ToString();
            int uniqueSymbolsCount = rageMessage.Distinct().Count();

            Console.WriteLine($"Unique symbols used: {uniqueSymbolsCount}");
            Console.WriteLine(rageMessage);
        }
    }
}