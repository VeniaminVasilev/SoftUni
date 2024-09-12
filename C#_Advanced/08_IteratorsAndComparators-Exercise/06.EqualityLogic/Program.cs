namespace _06.EqualityLogic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HashSet<Person> peopleHashSet = new HashSet<Person>();
            SortedSet<Person> peopleSortedSet = new SortedSet<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                Person newPerson = new Person(name, age);
                peopleHashSet.Add(newPerson);
                peopleSortedSet.Add(newPerson);
            }

            Console.WriteLine(peopleHashSet.Count);
            Console.WriteLine(peopleSortedSet.Count);
        }
    }
}