using System.Text;

namespace _02.Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> participants = new Dictionary<string, int>();

            foreach (var name in Console.ReadLine().Split(", "))
            {
                participants.Add(name, 0);
            }

            while (true)
            {
                string information = Console.ReadLine();
                if (information == "end of race") { break; }

                StringBuilder sb = new StringBuilder();
                int distance = 0;

                for (int i = 0; i < information.Length; i++)
                {
                    char currentChar = information[i];

                    if (char.IsLetter(currentChar))
                    {
                        sb.Append(currentChar);
                    }
                    else if (char.IsDigit(currentChar))
                    {
                        distance += int.Parse(currentChar.ToString());
                    }
                }

                string currentName = sb.ToString();

                if (participants.ContainsKey(currentName))
                {
                    participants[currentName] += distance;
                }
            }

            Dictionary<string, int> topParticipants = participants.OrderByDescending(kvp => kvp.Value)
                .Take(3)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            Console.WriteLine($"1st place: {topParticipants.Keys.First()}");
            topParticipants.Remove(topParticipants.Keys.First());
            Console.WriteLine($"2nd place: {topParticipants.Keys.First()}");
            topParticipants.Remove(topParticipants.Keys.First());
            Console.WriteLine($"3rd place: {topParticipants.Keys.First()}");
        }
    }
}