using System.Text;

namespace _03.Telephony
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> phoneNumbers = new List<string>(Console.ReadLine().Split(" "));
            List<string> websites = new List<string>(Console.ReadLine().Split(" "));

            for (int i = 0; i < phoneNumbers.Count; i++)
            {
                string phoneNumber = phoneNumbers[i];
                bool numberIsCorrect = true;
                for (int b = 0; b < phoneNumber.Length; b++)
                {
                    if (!char.IsDigit(phoneNumber[b]))
                    {
                        numberIsCorrect = false;
                    }
                }

                if (!numberIsCorrect)
                {
                    Console.WriteLine("Invalid number!");
                }
                else if (numberIsCorrect && phoneNumber.Length == 7)
                {
                    StationaryPhone stationary = new StationaryPhone();
                    Console.WriteLine(stationary.Call(phoneNumber));
                }
                else if (numberIsCorrect && phoneNumber.Length == 10)
                {
                    Smartphone smartphone = new Smartphone();
                    Console.WriteLine(smartphone.Call(phoneNumber));
                }
            }

            for (int i = 0; i < websites.Count; i++)
            {
                string website = websites[i];
                bool invalidWebsite = false;

                for (int b = 0; b < website.Length; b++)
                {
                    if (char.IsDigit(website[b]))
                    {
                        invalidWebsite = true;
                    }
                }

                if (invalidWebsite)
                {
                    Console.WriteLine("Invalid URL!");
                }
                else
                {
                    Smartphone smartphone = new Smartphone();
                    Console.WriteLine(smartphone.Browse(website));
                }
            }
        }
    }
}