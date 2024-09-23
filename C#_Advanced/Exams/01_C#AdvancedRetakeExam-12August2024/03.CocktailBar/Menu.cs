namespace CocktailBar
{
    public class Menu
    {
        public List<Cocktail> Cocktails { get; set; }
        public int BarCapacity { get; set; }

        public Menu(int barCapacity)
        {
            BarCapacity = barCapacity;
            Cocktails = new List<Cocktail>();
        }

        public void AddCocktail(Cocktail cocktail)
        {
            if (BarCapacity > Cocktails.Count)
            {
                string nameOfNewCocktail = cocktail.Name;

                if (!Cocktails.Exists(c => c.Name == nameOfNewCocktail))
                {
                    Cocktails.Add(cocktail);
                }
            }
        }

        public bool RemoveCocktail(string name)
        {
            if (Cocktails.Exists(c => c.Name == name))
            {
                Cocktails.RemoveAll(c => c.Name == name);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Cocktail GetMostDiverse()
        {
            return Cocktails.OrderByDescending(c => c.Ingredients.Count).FirstOrDefault();
        }

        public string Details(string cocktailName)
        {
            return Cocktails.FirstOrDefault(c => c.Name == cocktailName)?.ToString();
        }

        public string GetAll()
        {
            string allCocktails = "All Cocktails:";

            List<Cocktail> orderedCocktails = Cocktails.OrderBy(c => c.Name).ToList();

            for (int i = 0; i < orderedCocktails.Count; i++)
            {
                string name = orderedCocktails[i].Name;
                allCocktails += $"\n{name}";
            }

            return allCocktails;
        }
    }
}