namespace _05.FilterByAge
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = ReadPeople(n);
            
            string condition = Console.ReadLine();
            int ageThreshold = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Person, bool> filter = CreateFilter(condition, ageThreshold);
            Action<Person> printer = CreatePrinter(format);

            PrintFilteredPeople(people, filter, printer);
        }

        static List<Person> ReadPeople(int n)
        {
            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] information = Console.ReadLine()
                    .Split(", ")
                    .ToArray();

                string name = information[0];
                int age = int.Parse(information[1]);

                people.Add(new Person(name, age));
            }

            return people;
        }

        static Func<Person, bool> CreateFilter(string condition, int ageThreshold)
        {
            if (condition == "younger")
            {
                return p => p.Age < ageThreshold;
            }
            else if (condition == "older")
            {
                return p => p.Age >= ageThreshold;
            }
            else
            {
                throw new ArgumentException("Invalid condition");
            }
        }

        static Action<Person> CreatePrinter(string format)
        {
            if (format == "name")
            {
                return p => Console.WriteLine(p.Name);
            }
            else if (format == "age")
            {
                return p => Console.WriteLine(p.Age);
            }
            else if (format == "name age")
            {
                return p => Console.WriteLine($"{p.Name} - {p.Age}");
            }
            else
            {
                throw new ArgumentException("Invalid format");
            }
        }

        static void PrintFilteredPeople(List<Person> people, Func<Person, bool> filter, Action<Person> printer)
        {
            foreach (Person person in people)
            {
                if (filter(person))
                {
                    printer(person);
                }
            }
        }
    }
}