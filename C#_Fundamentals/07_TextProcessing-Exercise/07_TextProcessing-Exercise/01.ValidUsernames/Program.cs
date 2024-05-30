namespace _01.ValidUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine()
                .Split(", ").ToArray();

            for (int i = 0; i < usernames.Length; i++)
            {
                bool validUsername = true;

                for (int j = 0; j < usernames[i].Length; j++)
                {
                    if (!char.IsLetterOrDigit(usernames[i][j]) && usernames[i][j] != '-' && usernames[i][j] != '_')
                    {
                        validUsername = false;
                    }
                }

                if (validUsername && usernames[i].Length >= 3 && usernames[i].Length <= 16)
                {
                    Console.WriteLine(usernames[i]);
                }
            }
        }
    }
}