namespace _02.Articles
{
    class Article
    { 
        public string Title { get; set; }   
        public string Content { get; set; }
        public string Author { get; set; }

        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public void Edit(string newContent)
        {
            this.Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            this.Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            this.Title = newTitle;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // The input is in the format: "{title}, {content}, {author}".
            string[] input = Console.ReadLine()
                .Split(", ")
                .ToArray();

            int numberOfCommands = int.Parse(Console.ReadLine());

            string title = input[0];
            string content = input[1];
            string author = input[2];

            Article article = new Article(title, content, author);

            for (int i = 0; i < numberOfCommands; i++)
            {
                string command = Console.ReadLine();

                string[] tokens = command.Split(": ");

                if (tokens[0] == "Edit")
                {
                    article.Edit(tokens[1]);
                }
                else if (tokens[0] == "ChangeAuthor")
                {
                    article.ChangeAuthor(tokens[1]);
                }
                else if (tokens[0] == "Rename")
                {
                    article.Rename(tokens[1]);
                }
            }

            Console.WriteLine(article.ToString());
        }
    }
}