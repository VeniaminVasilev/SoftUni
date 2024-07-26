namespace _09.SoftUniExamResults
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> users = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> languages = new Dictionary<string, int>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "exam finished") { break; }

                string[] tokens = command.Split("-");
                string username = tokens[0];
                string language = tokens[1];

                if (language == "banned")
                {
                    users.Remove(username);
                }
                else
                {
                    int points = int.Parse(tokens[2]);

                    if (!users.ContainsKey(username))
                    {
                        users[username] = new Dictionary<string, int>();
                        users[username].Add(language, points);
                        
                        if (!languages.ContainsKey(language))
                        {
                            languages[language] = 1;
                        }
                        else
                        {
                            languages[language]++;
                        }
                    }
                    else if (users.ContainsKey(username) && !users[username].ContainsKey(language))
                    {
                        users[username].Add(language, points);

                        if (!languages.ContainsKey(language))
                        {
                            languages[language] = 1;
                        }
                        else
                        {
                            languages[language]++;
                        }
                    }
                    else if (users[username].ContainsKey(language) && points > users[username][language])
                    {
                        users[username][language] = points;
                        languages[language]++;
                    }
                    else if (users[username].ContainsKey(language))
                    {
                        languages[language]++;
                    }
                }
            }

            var sortedUsers = users
                .OrderByDescending(x => x.Value.Values.Max())
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            var sortedLanguages = languages
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Results:");
            foreach (var user in sortedUsers)
            {
                Console.WriteLine($"{user.Key} | {user.Value.Values.Max()}");
            }
            Console.WriteLine("Submissions:");
            foreach (var language in sortedLanguages)
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}