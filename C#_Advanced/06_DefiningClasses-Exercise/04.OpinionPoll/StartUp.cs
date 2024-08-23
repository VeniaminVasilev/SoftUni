namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ");
                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                if (age > 30)
                {
                    people.Add(new Person(name, age));
                }
            }

            List<Person> sortedPeople = people.OrderBy(p => p.Name).ToList();

            foreach (Person person in sortedPeople)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}