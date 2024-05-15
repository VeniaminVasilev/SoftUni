namespace _01.Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> users = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end of contests") { break; }

                string[] tokens = command.Split(":");
                string contest = tokens[0];
                string passwordForContest = tokens[1];

                if (!contests.ContainsKey(contest))
                {
                    contests[contest] = passwordForContest;
                }
            }
            
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end of submissions") { break; }

                string[] tokens = command.Split("=>");
                string contest = tokens[0];
                string passwordForContest = tokens[1];
                string username = tokens[2];
                int points = int.Parse(tokens[3]);

                if (contests.ContainsKey(contest) && contests[contest] == passwordForContest)
                {
                    if (users.ContainsKey(username) && users[username].ContainsKey(contest) && users[username][contest] < points)
                    {
                        users[username][contest] = points;
                    }
                    else if (users.ContainsKey(username) && !users[username].ContainsKey(contest))
                    {
                        users[username][contest] = points;
                    }
                    else if (!users.ContainsKey(username))
                    {
                        users[username] = new Dictionary<string, int>();
                        users[username][contest] = points;
                    }
                }
            }

            string bestUser = string.Empty;
            int bestSum = 0;

            foreach (var user in users)
            {
                int sum = users[user.Key].Values.Sum();

                if (sum > bestSum)
                {
                    bestUser = user.Key;
                    bestSum = sum;
                }
            }

            Console.WriteLine($"Best candidate is {bestUser} with total {bestSum} points.");
            Console.WriteLine("Ranking:");

            foreach (var user in users.OrderBy(u => u.Key))
            {
                Console.WriteLine(user.Key);

                foreach (var contest in user.Value.OrderByDescending(c => c.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}