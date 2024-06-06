using System.Text.RegularExpressions;

namespace _04.StarEnigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfMessages = int.Parse(Console.ReadLine());

            Regex decriptionKeyRegex = new Regex(@"[SsTtAaRr]");
            Regex pattern = new Regex(@"@([A-Z][a-z]+)[^@\-!:>]*:(\d+)[^@\-!:>]*!([A|D])![^@\-!:>]*->(\d+)");

            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            for (int i = 0; i < numberOfMessages; i++)
            {
                string encryptedMessage = Console.ReadLine();
                string decryptedMessage = string.Empty;

                int decryptionKey = decriptionKeyRegex.Matches(encryptedMessage).Count;

                foreach (char c in encryptedMessage)
                {
                    decryptedMessage += (char)(c - decryptionKey);
                }

                if (pattern.IsMatch(decryptedMessage))
                {
                    string planetName = pattern.Match(decryptedMessage).Groups[1].ToString();
                    char attackType = char.Parse(pattern.Match(decryptedMessage).Groups[3].ToString());

                    if (attackType == 'A')
                    {
                        attackedPlanets.Add(planetName);
                    }
                    else if (attackType == 'D')
                    {
                        destroyedPlanets.Add(planetName);
                    }
                }
            }
            attackedPlanets = attackedPlanets.OrderBy(x => x).ToList();
            destroyedPlanets = destroyedPlanets.OrderBy(x => x).ToList();

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            if (attackedPlanets.Count > 0)
            {
                for (int i = 0; i < attackedPlanets.Count; i++)
                {
                    Console.WriteLine($"-> {attackedPlanets[i]}");
                }
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            if (destroyedPlanets.Count > 0)
            {
                for (int i = 0; i < destroyedPlanets.Count; i++)
                {
                    Console.WriteLine($"-> {destroyedPlanets[i]}");
                }
            }
        }
    }
}