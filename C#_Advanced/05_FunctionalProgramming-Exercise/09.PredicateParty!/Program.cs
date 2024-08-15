namespace _09.PredicateParty_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .ToList();

            Func<List<string>, string> partyMessage = p =>
            {
                return p.Count > 0 ?
                    $"{string.Join(", ", p)} are going to the party!" :
                    $"Nobody is going to the party!";
            };

            Func<string, string, bool> startsWith = (person, text) => person.StartsWith(text);
            Func<string, string, bool> endsWith = (person, text) => person.EndsWith(text);
            Func<string, int, bool> hasLength = (person, length) => person.Length == length;

            Action<List<string>, Func<string, bool>> removePeople = (list, condition) =>
            {
                list.RemoveAll(new Predicate<string>(condition));
            };

            Action<List<string>, Func<string, bool>> doublePeople = (list, condition) =>
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (condition(list[i]))
                    {
                        list.Insert(i, list[i]);
                        i++;
                    }
                }
            };

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Party!")
                {
                    Console.WriteLine(partyMessage(people));
                    break;
                }

                string[] tokens = command.Split(" ");
                string action = tokens[0];
                string condition = tokens[1];

                if (action == "Remove")
                {
                    if (condition == "StartsWith")
                    {
                        string text = tokens[2];
                        removePeople(people, p => startsWith(p, text));
                    }
                    else if (condition == "EndsWith")
                    {
                        string text = tokens[2];
                        removePeople(people, p => endsWith(p, text));
                    }
                    else if (condition == "Length")
                    {
                        int length = int.Parse(tokens[2]);
                        removePeople(people, p => hasLength(p, length));
                    }
                }
                else if (action == "Double")
                {
                    if (condition == "StartsWith")
                    {
                        string text = tokens[2];
                        doublePeople(people, p => startsWith(p, text));
                    }
                    else if (condition == "EndsWith")
                    {
                        string text = tokens[2];
                        doublePeople(people, p => endsWith(p, text));
                    }
                    else if (condition == "Length")
                    {
                        int length = int.Parse(tokens[2]);
                        doublePeople(people, p => hasLength(p, length));
                    }
                }
            }
        }
    }
}