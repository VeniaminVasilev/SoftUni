namespace GenericScale
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int number1 = 10;
            int number2 = 20;
            EqualityScale<int> intScale = new EqualityScale<int>(number1, number2);
            bool areIntsEqual = intScale.AreEqual();
            Console.WriteLine($"Are the integers equal? {areIntsEqual}");

            string str1 = "Hello";
            string str2 = "Hello";
            EqualityScale<string> stringScale = new EqualityScale<string>(str1, str2);
            bool areStringsEqual = stringScale.AreEqual();
            Console.WriteLine($"Are the strings equal? {areStringsEqual}");
        }
    }
}