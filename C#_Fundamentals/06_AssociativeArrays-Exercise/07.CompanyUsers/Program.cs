namespace _07.CompanyUsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End") { break; }

                string[] tokens = command.Split(" -> ").ToArray();
                string companyName = tokens[0];
                string employeeId = tokens[1];
                
                if (!companies.ContainsKey(companyName))
                {
                    companies[companyName] = new List<string>() { employeeId };
                }
                else if (!companies[companyName].Contains(employeeId))
                {
                    companies[companyName].Add(employeeId);
                }
            }

            foreach (var company in companies)
            {
                Console.WriteLine($"{company.Key}");
                
                foreach (string id in company.Value)
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }
    }
}