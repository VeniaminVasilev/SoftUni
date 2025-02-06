namespace _05.FootballTeamGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END") { break; }

                string[] tokens = command.Split(";");
                string action = tokens[0];

                if (action == "Team")
                {
                    try
                    {
                        string teamName = tokens[1];
                        Team team = new Team(teamName);
                        teams.Add(team);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (action == "Add")
                {
                    string teamName = tokens[1];
                    string playerName = tokens[2];
                    int endurance = int.Parse(tokens[3]);
                    int sprint = int.Parse(tokens[4]);
                    int dribble = int.Parse(tokens[5]);
                    int passing = int.Parse(tokens[6]);
                    int shooting = int.Parse(tokens[7]);

                    try
                    {
                        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                        if (!teams.Exists(t => t.Name == teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                        else
                        {
                            Team currentTeam = teams.FirstOrDefault(t => t.Name == teamName);

                            if (!currentTeam.Players.Any(p => p.Name == playerName))
                            {
                                currentTeam.AddPlayer(player);
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (action == "Remove")
                {
                    string teamName = tokens[1];
                    string playerName = tokens[2];

                    Team currentTeam = teams.FirstOrDefault(t => t.Name == teamName);

                    if (!currentTeam.Players.Any(p => p.Name == playerName))
                    {
                        Console.WriteLine($"Player {playerName} is not in {teamName} team.");
                    }
                    else
                    {
                        currentTeam.RemovePlayer(playerName);
                    }
                }
                else if (action == "Rating")
                {
                    string teamName = tokens[1];

                    if (!teams.Exists(t => t.Name == teamName))
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                    }
                    else
                    {
                        Team currentTeam = teams.FirstOrDefault(t => t.Name == teamName);

                        if (currentTeam.Players.Count == 0)
                        {
                            Console.WriteLine($"{currentTeam.Name} - 0");
                        }
                        else
                        {
                            Console.WriteLine($"{currentTeam.Name} - {currentTeam.Rating}");
                        }
                    }
                }
            }
        }
    }
}