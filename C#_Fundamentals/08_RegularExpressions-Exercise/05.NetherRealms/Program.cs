using System.Text.RegularExpressions;

namespace _05.NetherRealms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex lettersRegex = new Regex(@"([^\d\+\-\*/\.])");
            Regex numbersRegex = new Regex(@"((\+|\-)?(\d+(\.\d+)?))");
            Regex multAndDivRegex = new Regex(@"(/|\*)");

            List<string> demons = Console.ReadLine()
                .Split(new char[] { ',', ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            foreach (var demon in demons.OrderBy(x => x))
            {
                string demonLetters = string.Empty;

                foreach (var letter in lettersRegex.Matches(demon))
                {
                    demonLetters += letter.ToString();
                }

                int health = 0;

                foreach (var symbol in demonLetters)
                {
                    health += symbol;
                }

                List<Match> numbers = numbersRegex.Matches(demon).ToList();

                decimal damage = 0;

                if (numbers.Count > 0)
                {
                    foreach (var number in numbers)
                    {
                        damage += decimal.Parse(number.ToString());
                    }

                    MatchCollection multAndDiv = multAndDivRegex.Matches(demon);

                    if (multAndDiv.Count > 0)
                    {
                        foreach (var symbol in multAndDiv)
                        {
                            if (symbol.ToString() == "*")
                            {
                                damage *= 2;
                            }
                            else if (symbol.ToString() == "/")
                            {
                                damage /= 2;
                            }
                        }
                    }
                }

                Console.WriteLine($"{demon} - {health} health, {damage:F2} damage");
            }
        }
    }
}