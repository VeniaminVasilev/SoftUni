namespace _08.Threeuple
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] line1 = Console.ReadLine().Split(" ");
            string fullName = $"{line1[0]} {line1[1]}";
            string address = line1[2];
            string town = line1[3];

            if (line1.Length > 4)
            {
                town = $"{line1[3]} {line1[4]}";
            }

            Threeuple<string, string, string> threeuple1 = new Threeuple<string, string, string>(fullName, address, town);
            Console.WriteLine(threeuple1);

            string[] line2 = Console.ReadLine().Split(" ");
            string name = line2[0];
            int litersBeer = int.Parse(line2[1]);
            bool isDrunk = false;
            string information = line2[2];

            if (information == "drunk")
            {
                isDrunk = true;
            }
            else
            {
                isDrunk = false;
            }

            Threeuple<string, int, bool> threeuple2 = new Threeuple<string, int, bool>(name, litersBeer, isDrunk);
            Console.WriteLine(threeuple2);

            string[] line3 = Console.ReadLine().Split(" ");
            string name2 = line3[0];
            double accountBalance = double.Parse(line3[1]);
            string bankName = line3[2];

            Threeuple<string, double, string> threeuple3 = new Threeuple<string, double, string>(name2, accountBalance, bankName);
            Console.WriteLine(threeuple3);
        }
    }
}