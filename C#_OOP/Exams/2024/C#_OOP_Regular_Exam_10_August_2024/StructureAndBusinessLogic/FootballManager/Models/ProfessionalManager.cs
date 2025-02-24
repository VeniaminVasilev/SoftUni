namespace FootballManager.Models
{
    public class ProfessionalManager : Manager
    {
        public ProfessionalManager(string name) : base(name, 60) { }

        public override void RankingUpdate(double updateValue)
        {
            this.Ranking += updateValue * 1.5;

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