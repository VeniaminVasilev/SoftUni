namespace _01.BonusScoringSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());
            int lectures = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());

            decimal maxBonus = 0;
            int attendancesOfStudentWithMaxBonus = 0;

            for (int i = 0; i < students; i++)
            {
                int attendances = int.Parse(Console.ReadLine());
                decimal totalBonus = ((decimal)attendances / lectures) * (5 + additionalBonus);

                if (totalBonus > maxBonus)
                {
                    maxBonus = totalBonus;
                    attendancesOfStudentWithMaxBonus = attendances;
                }
            }

            decimal roundedMaxBonus = Math.Ceiling(maxBonus);
            Console.WriteLine($"Max Bonus: {roundedMaxBonus}.");
            Console.WriteLine($"The student has attended {attendancesOfStudentWithMaxBonus} lectures.");
        }
    }
}