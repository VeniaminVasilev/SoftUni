namespace _06.SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> songs = Console.ReadLine()
                .Split(", ")
                .ToList();

            Queue<string> songsQueue = new Queue<string>();

            for (int i = 0; i < songs.Count; i++)
            {
                songsQueue.Enqueue(songs[i]);
            }

            while (true)
            {
                if (songsQueue.Count == 0)
                {
                    Console.WriteLine($"No more songs!");
                    break;
                }

                string command = Console.ReadLine();
                string[] tokens = command.Split(" ").ToArray();
                string action = tokens[0];

                if (action == "Play")
                {
                    songsQueue.Dequeue();
                }
                else if (action == "Add")
                {
                    string song = command.Substring(4);

                    if (songsQueue.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        songsQueue.Enqueue(song);
                    }
                }
                else if (action == "Show")
                {
                    Console.WriteLine(string.Join(", ", songsQueue));
                }
            }
        }
    }
}