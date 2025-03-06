namespace NauticalCatchChallenge.Models
{
    public class PredatoryFish : Fish
    {
        private const int timeToCatch = 60;

        public PredatoryFish(string name, double points) : base(name, points, timeToCatch)
        {
        }
    }
}