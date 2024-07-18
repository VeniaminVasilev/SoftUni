namespace _02.AverageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countStudents = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < countStudents; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = tokens[0];
                decimal grade = decimal.Parse(tokens[1]);

                if (students.ContainsKey(name))
                {
                    students[name].Add(grade);
                }
                else
                {
                    students[name] = new List<decimal>();
                    students[name].Add(grade);
                }
            }

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Key} -> {string.Join(" ", student.Value.Select(grade => grade.ToString("F2")))} (avg: {student.Value.Average():F2})");
            }
        }
    }
}