using _03.Raiding.Models;

namespace _03.Raiding.Factory
{
    public static class HeroFactory
    {
        public static BaseHero CreateHero(string type, string name)
        {
            return type switch
            {
                "Druid" => new Druid(name),
                "Paladin" => new Paladin(name),
                "Rogue" => new Rogue(name),
                "Warrior" => new Warrior(name),
                _ => null
            };
        }
    }
}