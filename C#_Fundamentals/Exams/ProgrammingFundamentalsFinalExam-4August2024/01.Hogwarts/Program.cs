namespace _01.Hogwarts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string spell = Console.ReadLine();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Abracadabra") { break; }

                string[] tokens = command.Split(" ").ToArray();
                string action = tokens[0];

                if (action == "Abjuration")
                {
                    spell = spell.ToUpper();
                    Console.WriteLine(spell);
                }
                else if (action == "Necromancy")
                {
                    spell = spell.ToLower();
                    Console.WriteLine(spell);
                }
                else if (action == "Illusion")
                {
                    int index = int.Parse(tokens[1]);
                    char letter = char.Parse(tokens[2]);

                    if (index >= 0 && index < spell.Length)
                    {
                        spell = spell.Remove(index, 1);
                        spell = spell.Insert(index, letter.ToString());
                        Console.WriteLine("Done!");
                    }
                    else
                    {
                        Console.WriteLine("The spell was too weak.");
                    }
                }
                else if (action == "Divination")
                {
                    string firstSubstring = tokens[1];
                    string secondSubstring = tokens[2];

                    if (spell.Contains(firstSubstring))
                    {
                        spell = spell.Replace(firstSubstring, secondSubstring);
                        Console.WriteLine(spell);
                    }
                }
                else if (action == "Alteration")
                {
                    string substring = tokens[1];

                    if (spell.Contains(substring))
                    {
                        spell = spell.Replace(substring, "");
                        Console.WriteLine(spell);
                    }
                }
                else
                {
                    Console.WriteLine("The spell did not work!");
                }
            }
        }
    }
}