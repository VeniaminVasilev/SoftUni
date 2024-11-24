namespace _08.CollectionHierarchy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AddCollection addCollection = new();
            AddRemoveCollection addRemoveCollection = new();
            MyList myList = new();

            string[] strings = Console.ReadLine().Split(" ");

            for (int i = 0; i < strings.Length; i++)
            {
                if (i > 0) { Console.Write(" "); }
                Console.Write(addCollection.Add(strings[i]));
            }
            Console.WriteLine();

            for (int i = 0; i < strings.Length; i++)
            {
                if (i > 0) { Console.Write(" "); }
                Console.Write(addRemoveCollection.Add(strings[i]));
            }
            Console.WriteLine();

            for (int i = 0; i < strings.Length; i++)
            {
                if (i > 0) { Console.Write(" "); }
                Console.Write(myList.Add(strings[i]));
            }
            Console.WriteLine();

            int removeOperations = int.Parse(Console.ReadLine());

            for (int i = 0; i < removeOperations; i++)
            {
                if (i > 0) { Console.Write(" "); }
                Console.Write(addRemoveCollection.Remove());
            }
            Console.WriteLine();

            for (int i = 0; i < removeOperations; i++)
            {
                if (i > 0) { Console.Write(" "); }
                Console.Write(myList.Remove());
            }
        }
    }
}