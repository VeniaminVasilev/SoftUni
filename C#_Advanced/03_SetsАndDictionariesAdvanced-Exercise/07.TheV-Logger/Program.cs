namespace _07.TheV_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vloggers = new HashSet<string>();
            Dictionary<string, SortedSet<string>> following = new Dictionary<string, SortedSet<string>>();
            Dictionary<string, SortedSet<string>> followers = new Dictionary<string, SortedSet<string>>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Statistics") { break; }

                string[] tokens = command.Split(" ").ToArray();
                string vlogger = tokens[0];
                string action = tokens[1];

                if (action == "joined")
                {
                    vloggers.Add(vlogger);

                    if (!following.ContainsKey(vlogger))
                    {
                        following[vlogger] = new SortedSet<string>();
                    }

                    if (!followers.ContainsKey(vlogger))
                    {
                        followers[vlogger] = new SortedSet<string>();
                    }
                }
                else if (action == "followed")
                {
                    string vloggerThatIsFollowed = tokens[2];

                    if (vloggers.Contains(vlogger) && vloggers.Contains(vloggerThatIsFollowed) && vlogger != vloggerThatIsFollowed)
                    {
                        if (following.ContainsKey(vlogger) && !following[vlogger].Contains(vloggerThatIsFollowed))
                        {
                            following[vlogger].Add(vloggerThatIsFollowed);
                        }

                        if (followers.ContainsKey(vloggerThatIsFollowed) && !followers[vloggerThatIsFollowed].Contains(vlogger))
                        {
                            followers[vloggerThatIsFollowed].Add(vlogger);
                        }
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            Dictionary<string, int[]> vloggersInformation = new Dictionary<string, int[]>();

            foreach (string vlogger in vloggers)
            {
                vloggersInformation[vlogger] = new int[2];
                vloggersInformation[vlogger][0] = followers[vlogger].Count;
                vloggersInformation[vlogger][1] = following[vlogger].Count;
            }

            Dictionary<string, int[]> sortedVloggers = new Dictionary<string, int[]>();
            sortedVloggers = vloggersInformation
                .OrderByDescending(v => v.Value[0])
                .ThenBy(v => v.Value[1])
                .ToDictionary(pair => pair.Key, pair => pair.Value);

            int count = 1;
            foreach (var vlogger in sortedVloggers)
            {
                Console.WriteLine($"{count}. {vlogger.Key} : {vlogger.Value[0]} followers, {vlogger.Value[1]} following");

                if (count == 1 && vlogger.Value[0] != 0)
                {
                    foreach (string follower in followers[vlogger.Key])
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                count++;
            }
        }
    }
}