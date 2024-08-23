namespace _09.PokemonTrainer
{
    public class Trainer
    {
        public string Name { get; set; }
        public int BadgesCount { get; set; } = 0;
        public List<Pokemon> PokemonCollection { get; set; } = new List<Pokemon>();

        public Trainer(string name, List<Pokemon> pokemonCollection)
        {
            Name = name;
            PokemonCollection = pokemonCollection;
        }
    }
}