namespace CocktailBar
{
    public class Cocktail
    {
        private string _name;
        private decimal _price;
        private double _volume;
        private List<string> _ingredients;

        public Cocktail(string name, decimal price, double volume, string ingredients)
        {
            _name = name;
            _price = price;
            _volume = volume;
            _ingredients = ingredients.Split(", ").ToList();
        }

        public string Name { get => _name; }
        public decimal Price { get => _price; }
        public double Volume { get => _volume; }
        public List<string> Ingredients { get => _ingredients; }

        public override string ToString()
        {
            return $"{_name}, Price: {_price:F2} BGN, Volume: {_volume} ml\nIngredients: {string.Join(", ", _ingredients)}";
        }
    }
}