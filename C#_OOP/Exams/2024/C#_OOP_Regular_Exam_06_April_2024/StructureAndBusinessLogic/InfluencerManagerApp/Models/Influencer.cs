using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Models
{
    public abstract class Influencer : IInfluencer
    {
        private string _username;
        private int _followers;
        private double _engagementRate;
        private double _income;
        private List<string> _participations;

        protected Influencer(string username, int followers, double engagementRate)
        {
            this.Username = username;
            this.Followers = followers;
            this.EngagementRate = engagementRate;
            this.Income = 0;
            this.Participations = new List<string>();
        }

        public string Username
        {
            get { return this._username; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.UsernameIsRequired);
                }
                _username = value;
            }
        }

        public int Followers
        {
            get { return this._followers; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.FollowersCountNegative);
                }
                _followers = value;
            }
        }

        public double EngagementRate
        {
            get { return this._engagementRate; }
            private set { this._engagementRate = value; }
        }

        public double Income
        {
            get { return this._income; }
            private set { this._income = value; }
        }

        public IReadOnlyCollection<string> Participations
        {
            get { return this._participations.AsReadOnly(); }
            private set { this._participations = value.ToList(); }
        }

        public abstract int CalculateCampaignPrice();

        public void EarnFee(double amount)
        {
            this.Income += amount;
        }

        public void EndParticipation(string brand)
        {
            this._participations.Remove(brand);
        }

        public void EnrollCampaign(string brand)
        {
            this._participations.Add(brand);
        }

        public override string ToString()
        {
            return $"{this.Username} - Followers: {this.Followers}, Total Income: {this.Income}";
        }
    }
}