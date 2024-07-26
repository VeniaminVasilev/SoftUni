namespace _08.Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            SortedDictionary<string, Dictionary<string, int>> users = new SortedDictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end of contests") { break; }

                string[] tokens = command.Split(":");
                string contest = tokens[0];
                string passwordForContest = tokens[1];

                contests[contest] = passwordForContest;
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end of submissions") { break; }

                string[] tokens = command.Split("=>");
                string contest = tokens[0];
                string password = tokens[1];
                string username = tokens[2];
                int points = int.Parse(tokens[3]);

                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    if (!users.ContainsKey(username))
                    {
                        users[username] = new Dictionary<string, int>();
                        users[username][contest] = points;
                    }
                    else if (users.ContainsKey(username) && !users[username].ContainsKey(contest))
                    {
                        users[username][contest] = points;
                    }
                    else if (users[username].ContainsKey(contest))
                    {
                        if (points > users[username][contest])
                        {
                            users[username][contest] = points;
                        }
                    }
                }
            }

            var bestUser = users
                .Select(user => new { Username = user.Key, TotalPoints = user.Value.Values.Sum() })
                .OrderByDescending(user => user.TotalPoints)
                .FirstOrDefault();

            string name = bestUser.Username;
            int totalPoints = bestUser.TotalPoints;

            Console.WriteLine($"Best candidate is {name} with total {totalPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var user in users)
            {
                Console.WriteLine(user.Key);

                var sortedContests = users[user.Key]
                    .OrderByDescending(x => x.Value)
                    .ToDictionary(x => x.Key, x => x.Value);

                foreach (var contest in sortedContests)
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}