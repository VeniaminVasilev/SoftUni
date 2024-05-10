namespace _07.OrderByAge
{
    class Person
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }

        public Person(string name, string id, int age)
        {
            this.Name = name;
            this.Id = id;
            this.Age = age;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End") { break; }

                string[] tokens = command.Split(" ");
                string name = tokens[0];
                string id = tokens[1];
                int age = int.Parse(tokens[2]);

                Person person = new Person(name, id, age);
                bool sameId = false;

                for (int i = 0; i < people.Count; i++)
                {
                    if (people[i].Id == id)
                    {
                        people[i].Name = name;
                        people[i].Age = age;
                        sameId = true;
                    }
                }

                if (sameId == false)
                {
                    people.Add(person);
                }
            }

            people = people.OrderBy(person => person.Age).ToList();

            foreach (Person person in people)
            {
                Console.WriteLine($"{person.Name} with ID: {person.Id} is {person.Age} years old.");
            }
        }
    }
}