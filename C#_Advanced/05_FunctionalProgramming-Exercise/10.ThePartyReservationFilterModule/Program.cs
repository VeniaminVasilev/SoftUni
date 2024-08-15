namespace _10.ThePartyReservationFilterModule
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> partyGoers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Dictionary<string, List<string>> filters = new Dictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Print")
                {
                    break;
                }
                //Input example: "{command;filter type;filter parameter}"
                string[] tokens = input.Split(";");
                string command = tokens[0];
                string filterType = tokens[1];

                if (command == "Add filter")
                {
                    string filterParameter = tokens[2];
                    if (!filters.ContainsKey(filterType))
                    {
                        filters[filterType] = new List<string>();
                        filters[filterType].Add(filterParameter);
                    }
                    else
                    {
                        filters[filterType].Add(filterParameter);
                    }
                }
                else if (command == "Remove filter")
                {
                    string filterParameter = tokens[2];
                    if (filters.ContainsKey(filterType) && filters[filterType].Contains(filterParameter))
                    {
                        filters[filterType].Remove(filterParameter);

                        if (filters[filterType].Count == 0)
                        {
                            filters.Remove(filterType);
                        }
                    }
                }
            }

            foreach (var filter in filters)
            {
                foreach (string filterParameter in filter.Value)
                {
                    if (filter.Key == "Length")
                    {
                        int length = int.Parse(filterParameter);

                        partyGoers.RemoveAll(p => p.Length == length);
                    }
                    else if (filter.Key == "Starts with")
                    {
                        partyGoers.RemoveAll(p => p.StartsWith(filterParameter));
                    }
                    else if (filter.Key == "Ends with")
                    {
                        partyGoers.RemoveAll(p => p.EndsWith(filterParameter));
                    }
                    else if (filter.Key == "Contains")
                    {
                        partyGoers.RemoveAll(p => p.Contains(filterParameter));
                    }
                }
            }

            Console.WriteLine(string.Join(" ", partyGoers));
        }
    }
}