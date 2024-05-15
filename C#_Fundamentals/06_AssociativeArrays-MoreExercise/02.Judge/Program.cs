namespace _02.Judge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> contests = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, Dictionary<string, int>> individualStandings = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "no more time") { break; }

                string[] tokens = command.Split(" -> ");
                string username = tokens[0];
                string contestName = tokens[1];
                int points = int.Parse(tokens[2]);

                if (!contests.ContainsKey(contestName))
                {
                    contests[contestName] = new Dictionary<string, int>();
                    contests[contestName].Add(username, points);
                }
                else if (contests.ContainsKey(contestName) && contests[contestName].ContainsKey(username) && contests[contestName][username] < points)
                {
                    contests[contestName][username] = points;
                }
                else if (contests.ContainsKey(contestName) && !contests[contestName].ContainsKey(username))
                {
                    contests[contestName][username] = points;
                }

                if (!individualStandings.ContainsKey(username))
                {
                    individualStandings[username] = new Dictionary<string, int>();
                    individualStandings[username].Add(contestName, points);
                }
                else if (individualStandings.ContainsKey(username) && individualStandings[username].ContainsKey(contestName) && individualStandings[username][contestName] < points)
                {
                    individualStandings[username][contestName] = points;
                }
                else if (individualStandings.ContainsKey(username) && !individualStandings[username].ContainsKey(contestName))
                {
                    individualStandings[username][contestName] = points;
                }
            }

            foreach (var contest in contests)
            {
                Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");

                int position = 1;
                foreach (var participant in contests[contest.Key].OrderByDescending(p => p.Value).ThenBy(p => p.Key))
                {
                    Console.WriteLine($"{position}. {participant.Key} <::> {participant.Value}");
                    position++;
                }
            }

            Console.WriteLine("Individual standings:");
            int count = 1;
            foreach (var user in individualStandings.OrderByDescending(u => u.Value.Values.Sum()).ThenBy(u => u.Key))
            {
                int totalPoints = individualStandings[user.Key].Values.Sum();
                Console.WriteLine($"{count}. {user.Key} -> {totalPoints}");
                count++;
            }
        }
    }
}