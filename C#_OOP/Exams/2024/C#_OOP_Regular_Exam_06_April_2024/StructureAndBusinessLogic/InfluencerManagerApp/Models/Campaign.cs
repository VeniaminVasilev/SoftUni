using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Models
{
    public abstract class Campaign : ICampaign
    {
        private string _brand;
        private double _budget;
        private List<string> _contributors;

        public Campaign(string brand, double budget)
        {
            this.Brand = brand;
            this.Budget = budget;
            this.Contributors = new List<string>();
        }

        public string Brand
        {
            get { return this._brand; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BrandIsrequired);
                }
                this._brand = value;
            }
        }

        public double Budget
        {
            get { return this._budget; }
            private set { this._budget = value; }
        }

        public IReadOnlyCollection<string> Contributors
        {
            get { return this._contributors.AsReadOnly(); }
            private set { this._contributors = value.ToList(); }
        }

        public void Engage(IInfluencer influencer)
        {
            this._contributors.Add(influencer.Username);
            int campaignPrice = influencer.CalculateCampaignPrice();
            this.Budget -= campaignPrice;
        }

        public void Gain(double amount)
        {
            this.Budget += amount;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} - Brand: {Brand}, Budget: {Budget}, Contributors: {Contributors.Count}";
        }
    }
}