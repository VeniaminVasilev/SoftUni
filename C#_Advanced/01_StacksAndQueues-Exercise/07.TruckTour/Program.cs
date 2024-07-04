namespace _07.TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countPumps = int.Parse(Console.ReadLine());
            int[][] petrolPumps = new int[countPumps][];

            for (int i = 0; i < countPumps; i++)
            {
                int[] information = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                petrolPumps[i] = new int[] { information[0], information[1] };
            }

            Console.WriteLine(FindStartingPump(petrolPumps));
        }

        static int FindStartingPump(int[][] petrolPumps)
        {
            int startingPump = 0;
            int totalPetrol = 0;
            int currentPetrol = 0;

            for (int i = 0; i < petrolPumps.Length; i++)
            {
                totalPetrol += petrolPumps[i][0] - petrolPumps[i][1];
                currentPetrol += petrolPumps[i][0] - petrolPumps[i][1];

                if (currentPetrol < 0)
                {
                    currentPetrol = 0;
                    startingPump = i + 1;
                }
            }

            // If total petrol is less than total distance, it's not possible to complete the tour
            if (totalPetrol < 0)
            {
                return -1; // Not in the requirements of the problem. But could handle edge cases.
            }

            return startingPump;
        }
    }
}