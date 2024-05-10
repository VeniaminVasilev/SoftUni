namespace _05.TeamworkProjects
{
    class Team
    {
        public string Creator { get; set; }
        public string TeamName { get; set; }
        public List<string> Members { get; set; }

        public Team(string creator, string teamName)
        {
            this.Creator = creator;
            this.TeamName = teamName;
            this.Members = new List<string>();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfTeams = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();
            List<Team> disbandedTeams = new List<Team>();

            for (int i = 0; i < countOfTeams; i++)
            {
                string teamInformation = Console.ReadLine();
                string[] tokens = teamInformation.Split("-");

                string creator = tokens[0];
                string teamName = tokens[1];

                bool teamCanBeCreated = true;

                for (int j = 0; j < teams.Count; j++)
                {
                    if (teams[j].TeamName == teamName)
                    {
                        Console.WriteLine($"Team {teamName} was already created!");
                        teamCanBeCreated = false;
                    }

                    if (teams[j].Creator == creator)
                    {
                        Console.WriteLine($"{creator} cannot create another team!");
                        teamCanBeCreated = false;
                    }
                }

                if (teamCanBeCreated == true)
                {
                    Team team = new Team(creator, teamName);

                    teams.Add(team);
                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end of assignment") { break; }

                string[] tokens = command.Split("->");

                string user = tokens[0];
                string team = tokens[1];

                bool teamExists = false;

                for (int i = 0; i < teams.Count; i++)
                {
                    if (teams[i].TeamName == team)
                    {
                        teamExists = true;
                    }
                }

                if (teamExists == false)
                {
                    Console.WriteLine($"Team {team} does not exist!");
                }

                bool userCanJoinTeam = true;

                for (int i = 0; i < teams.Count; i++)
                {

                    if (teams[i].Creator == user)
                    {
                        Console.WriteLine($"Member {user} cannot join team {team}!");
                        userCanJoinTeam = false;
                        break;
                    }

                    for (int j = 0; j < teams[i].Members.Count; j++)
                    {
                        if (teams[i].Members[j] == user)
                        {
                            Console.WriteLine($"Member {user} cannot join team {team}!");
                            userCanJoinTeam = false;
                            break;
                        }
                    }

                    if (userCanJoinTeam == false) { break; };
                }

                if (userCanJoinTeam == false) { continue; }

                for (int i = 0; i < teams.Count; i++)
                {
                    if (teams[i].TeamName == team && userCanJoinTeam == true)
                    {
                        teams[i].Members.Add(user);
                    }
                }
            }

            for (int i = 0; i < teams.Count; i++)
            {
                if (teams[i].Members.Count == 0)
                {
                    disbandedTeams.Add(teams[i]);
                    teams.RemoveAt(i);
                    i--;
                }
            }

            teams = teams.OrderByDescending(team => team.Members.Count).ThenBy(team => team.TeamName).ToList();
            disbandedTeams = disbandedTeams.OrderBy(team => team.TeamName).ToList();

            for (int i = 0; i < teams.Count; i++)
            {
                Console.WriteLine(teams[i].TeamName);
                Console.WriteLine($"- {teams[i].Creator}");
                for (int j = 0; j < teams[i].Members.Count; j++)
                {
                    Console.WriteLine($"-- {teams[i].Members[j]}");
                }
            }

            Console.WriteLine("Teams to disband:");

            for (int i = 0; i < disbandedTeams.Count; i++)
            {
                Console.WriteLine(disbandedTeams[i].TeamName);
            }
        }
    }
}