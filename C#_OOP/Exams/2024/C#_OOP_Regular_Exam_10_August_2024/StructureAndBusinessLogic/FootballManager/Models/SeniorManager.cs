namespace FootballManager.Models
{
    public class SeniorManager : Manager
    {
        public SeniorManager(string name) : base(name, 30) { }

        public override void RankingUpdate(double updateValue)
        {
            this.Ranking += updateValue;

            if (this.Ranking < 0)
            {
                this.Ranking = 0;
            }
            else if (this.Ranking > 100)
            {
                this.Ranking = 100;
            }
        }
    }
}