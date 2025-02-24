using FootballManager.Models.Contracts;
using FootballManager.Utilities.Messages;

namespace FootballManager.Models
{
    public abstract class Manager : IManager
    {
        private string _name;
        private double _ranking;

        public Manager(string name, double ranking)
        {
            this.Name = name;
            this.Ranking = ranking;
        }

        public string Name
        {
            get { return _name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ManagerNameNull);
                }
                _name = value;
            }
        }

        public double Ranking
        {
            get { return _ranking; }
            protected set { _ranking = value; }
        }

        public abstract void RankingUpdate(double updateValue);

        public override string ToString()
        {
            return $"{this._name} - {this.GetType().Name} (Ranking: {this._ranking:F2})";
        }
    }
}