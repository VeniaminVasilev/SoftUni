namespace MyNamespace
{
    public class Song
    {
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());

            List<Song> songList = new List<Song>();

            for (int i = 0; i < numberOfSongs; i++)
            {
                string[] dataElements = Console.ReadLine().Split("_");

                string typeList = dataElements[0];
                string name = dataElements[1];
                string time = dataElements[2];

                Song song = new Song();

                song.TypeList = typeList;
                song.Name = name;
                song.Time = time;

                songList.Add(song);
            }

            string lastCommand = Console.ReadLine();

            if (lastCommand == "all")
            {
                for (int i = 0; i < songList.Count; i++)
                {
                    Console.WriteLine(songList[i].Name);
                }
            }
            else
            {
                for (int i = 0; i < songList.Count; i++)
                {
                    if (songList[i].TypeList == lastCommand)
                    {
                        Console.WriteLine(songList[i].Name);
                    }
                }
            }
        }
    }
}