namespace NauticalCatchChallenge.Models
{
    public class DeepSeaFish : Fish
    {
        private const int timeToCatch = 180;

        public DeepSeaFish(string name, double points) : base(name, points, timeToCatch)
        {
        }
    }
}