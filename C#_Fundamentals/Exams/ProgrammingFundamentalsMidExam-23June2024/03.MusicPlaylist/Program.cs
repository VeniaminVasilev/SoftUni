namespace _03.MusicPlaylist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> songs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" * ");
                string command = tokens[0];

                if (command == "Add Song")
                {
                    string song = tokens[1];

                    if (!songs.Contains(song))
                    {
                        songs.Add(song);
                        Console.WriteLine($"{song} successfully added");
                    }
                }
                else if (command == "Delete Song")
                {
                    int numberOfSongs = int.Parse(tokens[1]);

                    if (numberOfSongs <= songs.Count)
                    {
                        List<string> removedSongs = new List<string>();
                        int counter = 0;
                        while (counter < numberOfSongs)
                        {
                            removedSongs.Add(songs[0]);
                            songs.RemoveAt(0);
                            counter++;
                        }
                        Console.WriteLine($"{string.Join(", ", removedSongs)} deleted");
                    }
                }
                else if (command == "Shuffle Songs")
                {
                    int indexSong1 = int.Parse(tokens[1]);
                    int indexSong2 = int.Parse(tokens[2]);

                    if (indexSong1 != indexSong2 && indexSong1 >= 0 && indexSong1 < songs.Count && indexSong2 >= 0 && indexSong2 < songs.Count)
                    {
                        string song1ToSwap = songs[indexSong1];
                        string song2ToSwap = songs[indexSong2];
                        songs.RemoveAt(indexSong1);
                        songs.Insert(indexSong1, song2ToSwap);
                        songs.RemoveAt(indexSong2);
                        songs.Insert(indexSong2, song1ToSwap);

                        Console.WriteLine($"{songs[indexSong1]} is swapped with {songs[indexSong2]}");
                    }
                }
                else if (command == "Insert")
                {
                    string song = tokens[1];
                    int songIndex = int.Parse(tokens[2]);

                    if (songIndex < 0 || songIndex >= songs.Count)
                    {
                        Console.WriteLine($"Index out of range");
                    }
                    else if (songIndex >= 0 && songIndex < songs.Count && songs.Contains(song))
                    {
                        Console.WriteLine($"Song is already in the playlist");
                    }
                    else if (songIndex >= 0 && songIndex < songs.Count && !songs.Contains(song))
                    {
                        songs.Insert(songIndex, song);
                        Console.WriteLine($"{song} successfully inserted");
                    }
                }
                else if (command == "Sort")
                {
                    songs = songs.OrderByDescending(s => s).ToList();
                }
                else if (command == "Play")
                {
                    Console.WriteLine("Songs to Play:");
                    foreach (string song in songs)
                    {
                        Console.WriteLine(song);
                    }
                }
            }
        }
    }
}