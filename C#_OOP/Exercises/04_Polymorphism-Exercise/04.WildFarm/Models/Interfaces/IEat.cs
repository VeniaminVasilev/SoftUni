namespace _04.WildFarm.Models.Interfaces
{
    public interface IEat
    {
        bool EatVegetables(int quantity);
        bool EatFruits(int quantity);
        bool EatMeat(int quantity);
        bool EatSeeds(int quantity);
    }
}