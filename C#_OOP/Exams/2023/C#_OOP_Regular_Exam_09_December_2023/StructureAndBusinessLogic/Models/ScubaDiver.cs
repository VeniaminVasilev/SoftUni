namespace NauticalCatchChallenge.Models
{
    public class ScubaDiver : Diver
    {
        private const int oxygenLevel = 540;

        public ScubaDiver(string name) : base(name, oxygenLevel)
        {
        }

        public override void Miss(int TimeToCatch)
        {
            this.OxygenLevel -= (int)Math.Round(TimeToCatch * 0.30, MidpointRounding.AwayFromZero);
        }

        public override void RenewOxy()
        {
            this.OxygenLevel = 540;
        }
    }
}