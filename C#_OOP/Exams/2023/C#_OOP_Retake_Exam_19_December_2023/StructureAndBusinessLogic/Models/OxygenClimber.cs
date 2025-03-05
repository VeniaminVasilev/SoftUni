namespace HighwayToPeak.Models
{
    public class OxygenClimber : Climber
    {
        private const int stamina = 10;

        public OxygenClimber(string name) : base(name, stamina)
        {
        }

        public override void Rest(int daysCount)
        {
            this.Stamina += daysCount;
        }
    }
}