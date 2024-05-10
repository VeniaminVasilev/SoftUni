namespace _04.Students
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Grade { get; set; }

        public Student(string firstName, string lastName, decimal grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}: {this.Grade}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfStudents = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int i = 0; i < countOfStudents; i++)
            {
                string studentInformation = Console.ReadLine();
                string[] tokens = studentInformation.Split(" ");

                string firstName = tokens[0];
                string lastName = tokens[1];
                decimal grade = decimal.Parse(tokens[2]);

                Student student = new Student(firstName, lastName, grade);

                students.Add(student);
            }

            students = students.OrderByDescending(student => student.Grade).ToList();

            foreach(Student student1 in students)
            {
                Console.WriteLine(student1.ToString());
            }
        }
    }
}