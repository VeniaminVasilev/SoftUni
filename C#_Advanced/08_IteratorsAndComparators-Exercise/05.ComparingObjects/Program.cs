namespace _05.ComparingObjects
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Person> peopleList = new List<Person>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                {
                    break;
                }

                string[] tokens = command.Split(" ");
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string town = tokens[2];

                Person person = new Person(name, age, town);
                peopleList.Add(person);
            }

            int n = int.Parse(Console.ReadLine());
            Person specialPerson = peopleList[n - 1];

            EqualPeopleCollection equalPeople = new EqualPeopleCollection(peopleList, specialPerson);

            if (equalPeople.Count < 2)
            {
                Console.WriteLine($"No matches");
            }
            else
            {
                Console.WriteLine($"{equalPeople.Count} {peopleList.Count - equalPeople.Count} {peopleList.Count}");
            }
        }
    }
}