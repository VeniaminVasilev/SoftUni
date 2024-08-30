namespace _07.Tuple
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] line1 = Console.ReadLine().Split(" ");
            string firstName = line1[0];
            string lastName = line1[1];
            string fullName = $"{firstName} {lastName}";
            string address = line1[2];

            MyTuple<string, string> tuple1 = new MyTuple<string, string>(fullName, address);
            Console.WriteLine(tuple1);

            string[] line2 = Console.ReadLine().Split(" ");
            string name = line2[0];
            int litersBeer = int.Parse(line2[1]);

            MyTuple<string, int> tuple2 = new MyTuple<string, int>(name, litersBeer);
            Console.WriteLine(tuple2);

            string[] line3 = Console.ReadLine().Split(" ");
            int integer = int.Parse(line3[0]);
            double doubleNumber = double.Parse(line3[1]);

            MyTuple<int, double> tuple3 = new MyTuple<int, double>(integer, doubleNumber);
            Console.WriteLine(tuple3);
        }
    }
}