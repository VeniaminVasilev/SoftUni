namespace _02.CharacterMultiplier
{
    internal class Program
    {
        static int CharacterMultiplier(string one, string two)
        {
            int sum = 0;
            if (one.Length == two.Length)
            {
                for (int i = 0; i < one.Length; i++)
                {
                    sum += one[i] * two[i];
                }
            }
            else
            {
                string longerInput = one.Length > two.Length ? longerInput = one : longerInput = two;
                string shorterInput = one.Length > two.Length ? shorterInput = two : shorterInput = one;

                for (int i = 0; i < shorterInput.Length; i++)
                {
                    sum += one[i] * two[i];
                }

                for (int i = longerInput.Length - 1; i >= shorterInput.Length; i--)
                {
                    sum += longerInput[i];
                }
            }
            return sum;
        }

        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split(" ").ToArray();

            int sum = CharacterMultiplier(strings[0], strings[1]);
            Console.WriteLine(sum);
        }
    }
}