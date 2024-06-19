namespace _03.HeroesOfCodeAndLogicVII
{
    class Hero
    {
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int ManaPoints { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Hero> heroes = new List<Hero>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] heroInformation = Console.ReadLine()
                    .Split(" ");
                string heroName = heroInformation[0];
                int hp = int.Parse(heroInformation[1]);
                int mp = int.Parse(heroInformation[2]);

                Hero newHero = new Hero()
                {
                    Name = heroName,
                    HitPoints = hp,
                    ManaPoints = mp
                };
                heroes.Add(newHero);
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End") { break; }

                string[] tokens = command.Split(" - ");
                string action = tokens[0];
                string heroName = tokens[1];

                Hero currentHero = heroes.FirstOrDefault(h => h.Name.Equals(heroName));

                if (action == "CastSpell")
                {
                    int manaPointsNeeded = int.Parse(tokens[2]);
                    string spellName = tokens[3];

                    if (currentHero.ManaPoints >= manaPointsNeeded)
                    {
                        currentHero.ManaPoints -= manaPointsNeeded;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {currentHero.ManaPoints} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }
                }
                else if (action == "TakeDamage")
                {
                    int damage = int.Parse(tokens[2]);
                    string attacker = tokens[3];
                    currentHero.HitPoints -= damage;

                    if (currentHero.HitPoints <= 0)
                    {
                        heroes.Remove(currentHero);
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                    }
                    else if (currentHero.HitPoints > 0)
                    {
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {currentHero.HitPoints} HP left!");
                    }
                }
                else if (action == "Recharge")
                {
                    int amount = int.Parse(tokens[2]);

                    if (currentHero.ManaPoints + amount > 200)
                    {
                        int manaUsed = 200 - currentHero.ManaPoints;
                        currentHero.ManaPoints = 200;
                        Console.WriteLine($"{heroName} recharged for {manaUsed} MP!");
                    }
                    else
                    {
                        currentHero.ManaPoints += amount;
                        Console.WriteLine($"{heroName} recharged for {amount} MP!");
                    }
                }
                else if (action == "Heal")
                {
                    int amount = int.Parse(tokens[2]);

                    if (currentHero.HitPoints + amount > 100)
                    {
                        int hitPointsUsed = 100 - currentHero.HitPoints;
                        currentHero.HitPoints = 100;
                        Console.WriteLine($"{heroName} healed for {hitPointsUsed} HP!");
                    }
                    else
                    {
                        currentHero.HitPoints += amount;
                        Console.WriteLine($"{heroName} healed for {amount} HP!");
                    }
                }
            }

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.Name);
                Console.WriteLine($"HP: {hero.HitPoints}");
                Console.WriteLine($"MP: {hero.ManaPoints}");
            }
        }
    }
}