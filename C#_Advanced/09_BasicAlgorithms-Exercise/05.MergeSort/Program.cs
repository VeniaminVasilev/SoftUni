namespace ConsoleMergeSortApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            Mergesort<int>.Sort(numbers);
            Console.WriteLine(string.Join(" ", numbers));
        }
    }

    public class Mergesort<T> where T : IComparable
    {
        private static T[] aux;  // Auxiliary array used for merging

        public static void Sort(T[] arr)
        {
            aux = new T[arr.Length];  // Initialize the auxiliary array
            Sort(arr, 0, arr.Length - 1);  // Start sorting the whole array
        }

        private static void Sort(T[] arr, int lo, int hi)
        {
            if (lo >= hi)  // Base case: If subarray has one or zero elements, it's already sorted
            {
                return;
            }

            int mid = lo + (hi - lo) / 2;  // Find the middle of the current subarray

            Sort(arr, lo, mid);     // Recursively sort the left half
            Sort(arr, mid + 1, hi); // Recursively sort the right half

            Merge(arr, lo, mid, hi);  // Merge the sorted halves
        }

        private static void Merge(T[] arr, int lo, int mid, int hi)
        {
            // If the array is already in order, skip the merge (optimization)
            if (IsLess(arr[mid], arr[mid + 1]))
            {
                return;
            }

            // Copy the array into the auxiliary array
            for (int index = lo; index <= hi; index++)
            {
                aux[index] = arr[index];
            }

            int i = lo;       // Pointer for the left half
            int j = mid + 1;  // Pointer for the right half

            for (int k = lo; k <= hi; k++)
            {
                if (i > mid)  // Left half exhausted, take from right half
                {
                    arr[k] = aux[j++];
                }
                else if (j > hi)  // Right half exhausted, take from left half
                {
                    arr[k] = aux[i++];
                }
                else if (IsLess(aux[i], aux[j]))  // Take the smaller element from the two halves
                {
                    arr[k] = aux[i++];
                }
                else  // Take from the right half if it's smaller or equal
                {
                    arr[k] = aux[j++];
                }
            }
        }

        // Helper function to compare elements
        private static bool IsLess(T a, T b)
        {
            return a.CompareTo(b) < 0;
        }
    }
}