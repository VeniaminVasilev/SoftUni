namespace _10.ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Example input commands:
            // {forceSide} | {forceUser}
            // {forceUser} -> {forceSide}
            Dictionary<string, SortedSet<string>> sides = new Dictionary<string, SortedSet<string>>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Lumpawaroo") { break; }

                string[] separators = { " | ", " -> " };
                string[] tokens = command.Split(separators, StringSplitOptions.None);

                bool rightForceSideContainsForceUser = false;

                if (command.Contains(" | "))
                {
                    string forceSide = tokens[0];
                    string forceUser = tokens[1];

                    bool forceUserExists = false;

                    foreach (var kvp in sides)
                    {
                        if (kvp.Value.Contains(forceUser))
                        {
                            forceUserExists = true;
                            break;
                        }
                    }

                    if (!sides.ContainsKey(forceSide) && !forceUserExists)
                    {
                        sides[forceSide] = new SortedSet<string>();
                        sides[forceSide].Add(forceUser);
                    }
                    else if (sides.ContainsKey(forceSide) && !forceUserExists)
                    {
                        sides[forceSide].Add(forceUser);
                    }
                }
                else if (command.Contains(" -> "))
                {
                    string forceUser = tokens[0];
                    string forceSide = tokens[1];

                    foreach (var kvp in sides)
                    {
                        if (kvp.Value.Contains(forceUser) && kvp.Key != forceSide)
                        {
                            sides[kvp.Key].Remove(forceUser);
                        }
                        else if (kvp.Value.Contains(forceUser) && kvp.Key == forceSide)
                        {
                            rightForceSideContainsForceUser = true;
                            break;
                        }
                    }

                    if (rightForceSideContainsForceUser) { continue; }

                    if (!sides.ContainsKey(forceSide))
                    {
                        sides[forceSide] = new SortedSet<string>();
                        sides[forceSide].Add(forceUser);
                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                    }
                    else if (sides.ContainsKey(forceSide) && !sides[forceSide].Contains(forceUser))
                    {
                        sides[forceSide].Add(forceUser);
                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                    }
                }
            }

            var sortedSides = sides
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var side in sortedSides)
            {
                if (side.Value.Count != 0)
                {
                    Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");
                    
                    foreach (string forceUser in side.Value)
                    {
                        Console.WriteLine($"! {forceUser}");
                    }
                }
            }
        }
    }
}