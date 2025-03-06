using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handball.Models
{
    public class Team : ITeam
    {
        private string _name;
        private int _pointsEarned;
        private List<IPlayer> _players;

        public Team(string name)
        {
            this.Name = name;
            this.PointsEarned = 0;
            this._players = new List<IPlayer>();
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

        public int PointsEarned
        {
            get { return this._pointsEarned; }
            private set
            {
                this._pointsEarned = value;
            }
        }

        public double OverallRating
        {
            get 
            { 
                if (Players.Count == 0)
                {
                    return 0;
                }

                double sum = Players.Sum(m => m.Rating);

                return Math.Round((sum / Players.Count), 2);
            }
        }

        public IReadOnlyCollection<IPlayer> Players
        {
            get { return this._players.AsReadOnly(); }
        }

        public void Draw()
        {
            this.PointsEarned += 1;
            IPlayer goalKeeper = this.Players.FirstOrDefault(p => p.GetType().Name == nameof(Goalkeeper));
            goalKeeper.IncreaseRating();
        }

        public void Lose()
        {
            foreach (IPlayer player in Players)
            {
                player.DecreaseRating();
            }
        }

        public void SignContract(IPlayer player)
        {
            this._players.Add(player);
        }

        public void Win()
        {
            this.PointsEarned += 3;

            foreach (IPlayer player in Players)
            {
                player.IncreaseRating();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Team: {this.Name} Points: {this.PointsEarned}");
            sb.AppendLine($"--Overall rating: {this.OverallRating}");

            if (this.Players.Count == 0)
            {
                sb.AppendLine($"--Players: none");
            }
            else
            {
                List<string> playersNames = new List<string>();

                foreach (IPlayer player in Players)
                {
                    playersNames.Add(player.Name);
                }

                sb.AppendLine($"--Players: {string.Join(", ", playersNames)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}