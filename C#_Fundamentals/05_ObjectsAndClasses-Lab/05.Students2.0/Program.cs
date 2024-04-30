namespace MyNamespace
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end") { break; }

                string[] tokens = command.Split(" ");

                string firstName = tokens[0];
                string lastName = tokens[1];
                int age = int.Parse(tokens[2]);
                string homeTown = tokens[3];

                Student student = new Student();

                student.FirstName = firstName;
                student.LastName = lastName;
                student.Age = age;
                student.HomeTown = homeTown;

                if (students.Count > 0)
                {
                    bool namesAreTheSame = false;

                    for (int i = 0; i < students.Count; i++)
                    {
                        if (students[i].FirstName == firstName && students[i].LastName == lastName)
                        {
                            students[i].Age = age;
                            students[i].HomeTown = homeTown;
                            namesAreTheSame = true;
                            break;
                        }
                    }

                    if (namesAreTheSame == false)
                    {
                        students.Add(student);
                    }
                }
                else
                {
                    students.Add(student);
                }
            }

            string cityName = Console.ReadLine();

            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].HomeTown == cityName)
                {
                    Console.WriteLine($"{students[i].FirstName} {students[i].LastName} is {students[i].Age} years old.");
                }
            }
        }
    }
}