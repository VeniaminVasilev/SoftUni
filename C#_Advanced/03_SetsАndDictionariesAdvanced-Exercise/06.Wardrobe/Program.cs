namespace _06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> colors = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" -> ")
                    .ToArray();
                string color = tokens[0];
                string[] clothes = tokens[1]
                    .Split(",")
                    .ToArray();

                for (int j = 0; j < clothes.Length; j++)
                {
                    if (colors.ContainsKey(color))
                    {
                        if (colors[color].ContainsKey(clothes[j]))
                        {
                            colors[color][clothes[j]]++;
                        }
                        else
                        {
                            colors[color][clothes[j]] = 1;
                        }
                    }
                    else
                    {
                        colors[color] = new Dictionary<string, int>();
                        colors[color][clothes[j]] = 1;
                    }
                }
            }

            string[] information = Console.ReadLine()
                .Split(" ")
                .ToArray();
            string colorSearch = information[0];
            string clothSearch = information[1];

            foreach (var color in colors)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var cloth in color.Value)
                {
                    Console.WriteLine($"* {cloth.Key} - {cloth.Value}" + (color.Key == colorSearch && cloth.Key == clothSearch ? " (found!)" : ""));
                }
            }
        }
    }
}