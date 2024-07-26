int n = int.Parse(Console.ReadLine());
HashSet<string> usernames = new HashSet<string>();

for (int i = 0; i < n; i++)
{
    usernames.Add(Console.ReadLine());
}

Console.WriteLine(string.Join(Environment.NewLine, usernames));