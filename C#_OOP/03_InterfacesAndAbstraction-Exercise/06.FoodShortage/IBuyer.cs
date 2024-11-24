namespace _06.FoodShortage
{
    public interface IBuyer
    {
        string Name { get; }
        int Food { get; }

        void BuyFood();
    }
}