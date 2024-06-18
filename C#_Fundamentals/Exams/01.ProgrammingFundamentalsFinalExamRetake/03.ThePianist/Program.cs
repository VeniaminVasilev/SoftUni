namespace _03.ThePianist
{
    class MusicPiece
    {
        public string PieceName { get; set; }
        public string Composer { get; set; }
        public string Key { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPieces = int.Parse(Console.ReadLine());
            List<MusicPiece> musicPieces = new List<MusicPiece>();

            for (int i = 0; i < numberOfPieces; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split("|")
                    .ToArray();
                string piece = tokens[0];
                string composer = tokens[1];
                string key = tokens[2];

                MusicPiece musicPiece = new MusicPiece
                {
                    PieceName = piece,
                    Composer = composer,
                    Key = key
                };

                musicPieces.Add(musicPiece);
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Stop") { break; }

                string[] tokens = command.Split("|");
                string action = tokens[0];
                string pieceName = tokens[1];

                if (action == "Add")
                {
                    string composer = tokens[2];
                    string key = tokens[3];

                    if (musicPieces.Any(p => p.PieceName.Equals(pieceName)))
                    {
                        Console.WriteLine($"{pieceName} is already in the collection!");
                    }
                    else
                    {
                        MusicPiece musicPiece = new MusicPiece
                        {
                            PieceName = pieceName,
                            Composer = composer,
                            Key = key
                        };
                        musicPieces.Add(musicPiece);

                        Console.WriteLine($"{pieceName} by {composer} in {key} added to the collection!");
                    }
                }
                else if (action == "Remove")
                {
                    if (musicPieces.Any(p => p.PieceName.Equals(pieceName)))
                    {
                        musicPieces.RemoveAll(p => p.PieceName.Equals(pieceName));
                        Console.WriteLine($"Successfully removed {pieceName}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                    }
                }
                else if (action == "ChangeKey")
                {
                    string newKey = tokens[2];

                    if (musicPieces.Any(p => p.PieceName.Equals(pieceName)))
                    {
                        MusicPiece pieceToUpdate = musicPieces.FirstOrDefault(p => p.PieceName.Equals(pieceName));

                        pieceToUpdate.Key = newKey;

                        Console.WriteLine($"Changed the key of {pieceName} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                    }
                }
            }

            foreach (var piece in musicPieces)
            {
                Console.WriteLine($"{piece.PieceName} -> Composer: {piece.Composer}, Key: {piece.Key}");
            }
        }
    }
}