namespace _06.Quicksort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            Quick.Sort(numbers);
            Console.WriteLine(string.Join(" ", numbers));
        }
    }

    public class Quick
    {
        public static void Sort<T>(T[] a) where T : IComparable<T>
        {
            Shuffle(a); // Shuffle the array to guarantee performance
            Sort(a, 0, a.Length - 1);
        }

        private static void Sort<T>(T[] a, int lo, int hi) where T : IComparable<T>
        {
            if (lo >= hi)
            {
                return;
            }

            int p = Partition(a, lo, hi);
            Sort(a, lo, p - 1);
            Sort(a, p + 1, hi);
        }

        private static int Partition<T>(T[] a, int lo, int hi) where T : IComparable<T>
        {
            if (lo >= hi)
            {
                return lo;
            }

            int i = lo;
            int j = hi + 1;

            while (true)
            {
                // Move i to the right, as long as a[i] is less than a[lo]
                while (Less(a[++i], a[lo]))
                {
                    if (i == hi) break;
                }

                // Move j to the left, as long as a[j] is greater than a[lo]
                while (Less(a[lo], a[--j]))
                {
                    if (j == lo) break;
                }

                // If pointers cross, break the loop
                if (i >= j) break;

                // Swap elements
                Swap(a, i, j);
            }

            // Swap the partitioning element with a[j]
            Swap(a, lo, j);
            return j; // Return the partition index
        }

        // Compare two elements (a < b)
        private static bool Less<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) < 0;
        }

        // Swap two elements in the array
        private static void Swap<T>(T[] a, int i, int j)
        {
            T temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }

        // Shuffle the array using Fisher-Yates algorithm to ensure performance guarantees
        private static void Shuffle<T>(T[] a)
        {
            Random rand = new Random();
            for (int i = 0; i < a.Length; i++)
            {
                int r = rand.Next(i, a.Length); // Pick a random index from i to the end
                Swap(a, i, r);
            }
        }
    }
}