namespace InfluencerManagerApp.Models
{
    public class BusinessInfluencer : Influencer
    {
        private const double engagementRate = 3.0;

        public BusinessInfluencer(string username, int followers) 
            : base(username, followers, engagementRate)
        {
        }

        public override int CalculateCampaignPrice()
        {
            return (int)Math.Floor(Followers * EngagementRate * 0.15);
        }
    }
}