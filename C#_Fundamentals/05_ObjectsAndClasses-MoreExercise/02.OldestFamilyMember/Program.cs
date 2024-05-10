namespace _02.OldestFamilyMember
{
    class Person
    {
        public string PersonName { get; set; }
        public int PersonAge { get; set; }

        public Person(string personName, int personAge)
        {
            this.PersonName = personName;
            this.PersonAge = personAge;
        }
    }

    class Family
    {
        public List<Person> People { get; set; } = new List<Person>();

        public void AddMember(Person member)
        {
            People.Add(member);
        }

        public Person GetOldestMember()
        {
            int idOfOldestMember = int.MinValue;
            int maxAge = int.MinValue;
            for (int i = 0; i < People.Count; i++)
            {
                if (People[i].PersonAge > maxAge)
                {
                    maxAge = People[i].PersonAge;
                    idOfOldestMember = i;
                }
            }

            return People[idOfOldestMember];
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Family family = new Family();

            int numberOfPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPeople ; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ");
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                Person person = new Person(name, age);
               
                family.AddMember(person);
            }

            Person oldestPerson = family.GetOldestMember();

            Console.WriteLine($"{oldestPerson.PersonName} {oldestPerson.PersonAge}");
        }
    }
}