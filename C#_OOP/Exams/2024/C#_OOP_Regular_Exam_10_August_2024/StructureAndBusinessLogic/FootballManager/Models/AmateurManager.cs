namespace FootballManager.Models
{
    public class AmateurManager : Manager
    {
        public AmateurManager(string name) : base(name, 15) { }

        public override void RankingUpdate(double updateValue)
        {
            this.Ranking += updateValue * 0.75;

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