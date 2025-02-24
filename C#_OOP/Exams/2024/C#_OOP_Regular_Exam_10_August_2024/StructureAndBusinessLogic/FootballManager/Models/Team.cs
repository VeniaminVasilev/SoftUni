using FootballManager.Models.Contracts;
using FootballManager.Utilities.Messages;

namespace FootballManager.Models
{
    public class Team : ITeam
    {
        private string _name;
        private int _championshipPoints;
        private IManager _teamManager;

        public Team(string name)
        {
            this.Name = name;
            this.ChampionshipPoints = 0;
        }

        public string Name
        {
            get { return this._name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.TeamNameNull);
                }
                this._name = value;
            }
        }

        public int ChampionshipPoints
        {
            get { return this._championshipPoints; }
            private set
            {
                this._championshipPoints = value;
            }
        }

        public IManager TeamManager
        {
            get { return this._teamManager; }
            private set
            {
                this._teamManager = value;
            }
        }

        public int PresentCondition
        {
            get
            {
                if (this.TeamManager == null)
                {
                    return 0;
                }

                if (this.ChampionshipPoints == 0)
                {
                    return (int)Math.Round(this.TeamManager.Ranking);
                }

                return (int)Math.Round(this.ChampionshipPoints * this.TeamManager.Ranking);
            }
        }

        public void GainPoints(int points)
        {
            this.ChampionshipPoints += points;
        }

        public void ResetPoints()
        {
            this.ChampionshipPoints = 0;
        }

        public void SignWith(IManager manager)
        {
            this.TeamManager = manager;
        }

        public override string ToString()
        {
            return $"Team: {this.Name} Points: {this.ChampionshipPoints}";
        }
    }
}