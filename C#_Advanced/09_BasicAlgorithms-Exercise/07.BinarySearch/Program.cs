namespace _07.BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sortedArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int element = int.Parse(Console.ReadLine());

            int indexOfElement = BinarySearch.IndexOf(sortedArray, element);

            Console.WriteLine(indexOfElement);
        }
    }

    public class BinarySearch
    {
        public static int IndexOf(int[] arr, int key)
        {
            int lo = 0;
            int hi = arr.Length - 1;
            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;

                if (key < arr[mid])
                {
                    hi = mid - 1;
                }
                else if (key > arr[mid])
                {
                    lo = mid + 1;
                }
                else
                {
                    return mid;
                }
            }

            return -1;
        }
    }
}