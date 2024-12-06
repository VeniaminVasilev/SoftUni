namespace _03.Cards
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Card> cards = new List<Card>();

            string[] information = Console.ReadLine()
                .Split(", ");

            for (int i = 0; i < information.Length; i++)
            {
                string[] currentCard = information[i].Split(" ");
                string face = currentCard[0];
                string suit = currentCard[1];

                try
                {
                    Card newCard = CreateCard(face, suit);
                    cards.Add(newCard);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(string.Join(" ", cards));
        }

        public static Card CreateCard(string face, string suit)
        {
            List<string> allowedFaces = new List<string> { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

            if (!allowedFaces.Contains(face))
            {
                throw new ArgumentException("Invalid card!");
            }

            if (suit != "S" && suit != "H" && suit != "D" && suit != "C")
            {
                throw new ArgumentException("Invalid card!");
            }

            string utfSuite = string.Empty;

            if (suit == "S")
            {
                utfSuite = "\u2660";
            }
            else if (suit == "H")
            {
                utfSuite = "\u2665";
            }
            else if (suit == "D")
            {
                utfSuite = "\u2666";
            }
            else if (suit == "C")
            {
                utfSuite = "\u2663";
            }

            Card newCard = new Card(face, utfSuite);

            return newCard;
        }
    }

    public class Card
    {
        public string Face { get; private set; }
        public string Suit { get; private set; }

        public Card(string face, string suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public override string ToString()
        {
            return $"[{this.Face}{this.Suit}]";
        }
    }
}