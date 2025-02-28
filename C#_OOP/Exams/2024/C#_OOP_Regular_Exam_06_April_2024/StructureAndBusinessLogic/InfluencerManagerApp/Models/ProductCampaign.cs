namespace InfluencerManagerApp.Models
{
    public class ProductCampaign : Campaign
    {
        private const double budget = 60000;

        public ProductCampaign(string brand) : base(brand, budget)
        {
        }
    }
}