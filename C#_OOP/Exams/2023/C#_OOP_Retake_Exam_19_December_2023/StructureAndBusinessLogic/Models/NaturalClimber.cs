namespace HighwayToPeak.Models
{
    public class NaturalClimber : Climber
    {
        private const int stamina = 6;

        public NaturalClimber(string name) : base(name, stamina)
        {
        }

        public override void Rest(int daysCount)
        {
            this.Stamina += (daysCount * 2);
        }
    }
}