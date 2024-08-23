namespace _05.DateModifier
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string date1 = Console.ReadLine();
            string date2 = Console.ReadLine();

            DateModifier dateModifier = new DateModifier();
            int difference = dateModifier.CalculateDifferenceInDays(date1, date2);

            Console.WriteLine(difference);
        }
    }
}