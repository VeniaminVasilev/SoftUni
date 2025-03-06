namespace NauticalCatchChallenge.Models
{
    public class ReefFish : Fish
    {
        private const int timeToCatch = 30;

        public ReefFish(string name, double points) : base(name, points, timeToCatch)
        {
        }
    }
}