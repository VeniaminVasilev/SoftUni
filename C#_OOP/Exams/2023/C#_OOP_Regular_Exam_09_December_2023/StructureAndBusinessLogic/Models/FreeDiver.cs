namespace NauticalCatchChallenge.Models
{
    public class FreeDiver : Diver
    {
        private const int oxygenLevel = 120;

        public FreeDiver(string name) : base(name, oxygenLevel)
        {
        }

        public override void Miss(int TimeToCatch)
        {
            this.OxygenLevel -= (int)Math.Round(TimeToCatch * 0.60, MidpointRounding.AwayFromZero);
        }

        public override void RenewOxy()
        {
            this.OxygenLevel = 120;
        }
    }
}