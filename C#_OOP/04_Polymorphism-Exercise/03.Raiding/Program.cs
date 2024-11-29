using _03.Raiding.Factory;
using _03.Raiding.Models;

namespace _03.Raiding
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<BaseHero> raidGroup = new List<BaseHero>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                BaseHero hero = HeroFactory.CreateHero(heroType, heroName);

                if (hero == null)
                {
                    Console.WriteLine("Invalid hero!");
                    i--;
                }
                else
                {
                    raidGroup.Add(hero);
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            int raidGroupPower = 0;

            foreach (BaseHero hero in raidGroup)
            {
                Console.WriteLine(hero.CastAbility());
                raidGroupPower += hero.Power;
            }

            if (raidGroupPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}