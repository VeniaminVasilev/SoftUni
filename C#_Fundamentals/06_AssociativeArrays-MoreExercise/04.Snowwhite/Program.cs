namespace _04.Snowwhite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> hatColors = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Once upon a time") { break; }

                string[] tokens = command.Split(" <:> ");
                string dwarfName = tokens[0];
                string dwarfHatColor = tokens[1];
                int dwarfPhysics = int.Parse(tokens[2]);

                if (!hatColors.ContainsKey(dwarfHatColor))
                {
                    hatColors[dwarfHatColor] = new Dictionary<string, int>();
                    hatColors[dwarfHatColor].Add(dwarfName, dwarfPhysics);
                }
                else if (hatColors.ContainsKey(dwarfHatColor) && !hatColors[dwarfHatColor].ContainsKey(dwarfName))
                {
                    hatColors[dwarfHatColor].Add(dwarfName, dwarfPhysics);
                }
                else if (hatColors.ContainsKey(dwarfHatColor) && hatColors[dwarfHatColor].ContainsKey(dwarfName) && hatColors[dwarfHatColor][dwarfName] < dwarfPhysics)
                {
                    hatColors[dwarfHatColor][dwarfName] = dwarfPhysics;
                }
            }

            var orderedDwarfs = hatColors
                .SelectMany(x => x.Value.Select(y => new { HatColor = x.Key, DwarfName = y.Key, Physics = y.Value }))
                .OrderByDescending(x => x.Physics)
                .ThenByDescending(x => hatColors[x.HatColor].Count);

            foreach (var dwarf in orderedDwarfs)
            {
                Console.WriteLine($"({dwarf.HatColor}) {dwarf.DwarfName} <-> {dwarf.Physics}");
            }
        }
    }
}