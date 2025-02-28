namespace InfluencerManagerApp.Models
{
    public class ServiceCampaign : Campaign
    {
        private const double budget = 30000;

        public ServiceCampaign(string brand) : base(brand, budget)
        {
        }
    }
}