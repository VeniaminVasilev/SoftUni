namespace _03.MOBAChallenger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> players = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Season end") { break; }

                string[] tokens = command.Split(" ");
                if (tokens.Length == 5)
                {
                    string player = tokens[0];
                    string position = tokens[2];
                    int skill = int.Parse(tokens[4]);

                    if (!players.ContainsKey(player))
                    {
                        players[player] = new Dictionary<string, int>();
                        players[player].Add(position, skill);
                    }
                    else if (players.ContainsKey(player) && !players[player].ContainsKey(position))
                    {
                        players[player][position] = skill;
                    }
                    else if (players.ContainsKey(player) && players[player].ContainsKey(position) && players[player][position] < skill)
                    {
                        players[player][position] = skill;
                    }
                }
                else if (tokens.Length == 3)
                {
                    string player1 = tokens[0];
                    string player2 = tokens[2];

                    if (players.ContainsKey(player1) && players.ContainsKey(player2))
                    {
                        int player1betterpositions = 0;
                        int player2betterpositions = 0;

                        foreach (string position in players[player1].Keys)
                        {
                            if (players[player2].ContainsKey(position))
                            {
                                int player1skill = players[player1][position];
                                int player2skill = players[player2][position];

                                if (player1skill > player2skill)
                                {
                                    player1betterpositions++;
                                }
                                else if (player2skill > player1skill)
                                {
                                    player2betterpositions++;
                                }
                            }
                        }

                        if (player1betterpositions > player2betterpositions)
                        {
                            players.Remove(player2);
                        }
                        else if (player2betterpositions > player1betterpositions)
                        {
                            players.Remove(player1);
                        }
                    }
                }
            }

            foreach (var player in players.OrderByDescending(p => p.Value.Values.Sum()).ThenBy(p => p.Key))
            {
                Console.WriteLine($"{player.Key}: {player.Value.Values.Sum()} skill");

                foreach (var position in players[player.Key].OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"- {position.Key} <::> {position.Value}");
                }
            }
        }
    }
}