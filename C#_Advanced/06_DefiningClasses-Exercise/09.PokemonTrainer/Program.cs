namespace _09.PokemonTrainer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Tournament") { break; }

                string[] tokens = input.Split(" ");
                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);

                Pokemon newPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (trainers.Exists(x => x.Name == trainerName))
                {
                    Trainer currentTrainer = trainers.Where(x => x.Name == trainerName).FirstOrDefault();

                    currentTrainer.PokemonCollection.Add(newPokemon);
                }
                else
                {
                    List<Pokemon> pokemons = new List<Pokemon>();

                    Trainer newTrainer = new Trainer(trainerName, pokemons);
                    newTrainer.PokemonCollection.Add(newPokemon);

                    trainers.Add(newTrainer);
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End") { break; }

                if (input == "Fire" || input == "Water" || input == "Electricity")
                {
                    foreach (Trainer trainer in trainers)
                    {
                        bool hasElement = false;
                        foreach (Pokemon pokemon in trainer.PokemonCollection)
                        {
                            if (pokemon.Element == input)
                            {
                                hasElement = true;
                                break;
                            }
                        }

                        if (hasElement)
                        {
                            trainer.BadgesCount++;
                        }
                        else
                        {
                            for (int i = 0; i < trainer.PokemonCollection.Count; i++)
                            {
                                trainer.PokemonCollection[i].Health -= 10;

                                if (trainer.PokemonCollection[i].Health <= 0)
                                {
                                    trainer.PokemonCollection.Remove(trainer.PokemonCollection[i]);
                                    i--;
                                }
                            }
                        }
                    }
                }
            }

            List<Trainer> sortedTrainers = trainers.OrderByDescending(x => x.BadgesCount).ToList();

            foreach (Trainer trainer in sortedTrainers)
            {
                Console.WriteLine($"{trainer.Name} {trainer.BadgesCount} {trainer.PokemonCollection.Count}");
            }
        }
    }
}