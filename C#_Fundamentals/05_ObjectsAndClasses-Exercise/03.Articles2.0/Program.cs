namespace _03.Articles2._0
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

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfArticles = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();
            
            for (int i = 0; i < numberOfArticles; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(", ")
                    .ToArray();

                string title = input[0];
                string content = input[1];
                string author = input[2];

                Article article = new Article(title, content, author);

                articles.Add(article);
            }

            for (int i = 0; i < articles.Count; i++)
            {
                Console.WriteLine(articles[i].ToString());
            }
        }
    }
}