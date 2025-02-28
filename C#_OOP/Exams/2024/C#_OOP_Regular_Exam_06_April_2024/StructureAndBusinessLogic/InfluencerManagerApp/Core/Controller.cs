using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories;
using InfluencerManagerApp.Repositories.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System.Text;

namespace InfluencerManagerApp.Core
{
    public class Controller : IController
    {
        private IRepository<IInfluencer> _influencers;
        private IRepository<ICampaign> _campaigns;

        public Controller()
        {
            this._influencers = new InfluencerRepository();
            this._campaigns = new CampaignRepository();
        }

        public string ApplicationReport()
        {
            StringBuilder sb = new StringBuilder();

            List<IInfluencer> influencers = _influencers
                .Models
                .OrderByDescending(m => m.Income)
                .ThenByDescending(m => m.Followers)
                .ToList();

            foreach (var influencer in influencers)
            {
                sb.AppendLine(influencer.ToString());

                if (influencer.Participations.Count > 0)
                {
                    sb.AppendLine("Active Campaigns:");

                    List<string> orderedParticipations = influencer.Participations.OrderBy(p => p).ToList();

                    foreach (string campaignName in orderedParticipations)
                    {
                        ICampaign campaign = _campaigns.FindByName(campaignName);
                        sb.AppendLine($"--{campaign.ToString()}");
                    }
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string AttractInfluencer(string brand, string username)
        {
            IInfluencer influencer = _influencers.FindByName(username);
            if (influencer == null)
            {
                return String.Format(OutputMessages.InfluencerNotFound, nameof(InfluencerRepository), username);
            }

            ICampaign campaign = _campaigns.FindByName(brand);
            if (campaign == null)
            {
                return String.Format(OutputMessages.CampaignNotFound, brand);
            }

            if (campaign.Contributors.Contains(username))
            {
                return String.Format(OutputMessages.InfluencerAlreadyEngaged, username, brand);
            }

            if (campaign.GetType().Name == nameof(ProductCampaign) && influencer.GetType().Name == nameof(BloggerInfluencer))
            {
                return String.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand);
            }

            if (campaign.GetType().Name == nameof(ServiceCampaign) && influencer.GetType().Name == nameof(FashionInfluencer))
            {
                return String.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand);
            }

            if ((campaign.Budget - influencer.CalculateCampaignPrice()) < 0)
            {
                return String.Format(OutputMessages.UnsufficientBudget, brand, username);
            }

            int price = influencer.CalculateCampaignPrice();
            influencer.EnrollCampaign(brand);
            influencer.EarnFee(price);

            campaign.Engage(influencer);

            return String.Format(OutputMessages.InfluencerAttractedSuccessfully, username, brand);
        }

        public string BeginCampaign(string typeName, string brand)
        {
            if (typeName != nameof(ProductCampaign) && typeName != nameof(ServiceCampaign))
            {
                return String.Format(OutputMessages.CampaignTypeIsNotValid, typeName);
            }

            if (_campaigns.FindByName(brand) != null)
            {
                return String.Format(OutputMessages.CampaignDuplicated, brand);
            }

            ICampaign campaign;
            if (typeName == nameof(ProductCampaign))
            {
                campaign = new ProductCampaign(brand);
                _campaigns.AddModel(campaign);
            }
            else if (typeName == nameof(ServiceCampaign))
            {
                campaign = new ServiceCampaign(brand);
                _campaigns.AddModel(campaign);
            }
            return String.Format(OutputMessages.CampaignStartedSuccessfully, brand, typeName);
        }

        public string CloseCampaign(string brand)
        {
            ICampaign campaign = _campaigns.FindByName(brand);

            if (campaign == null)
            {
                return String.Format(OutputMessages.InvalidCampaignToClose);
            }

            if (campaign.Budget <= 10000)
            {
                return String.Format(OutputMessages.CampaignCannotBeClosed, brand);
            }

            List<string> participants = campaign.Contributors.ToList();

            foreach (string participant in participants)
            {
                IInfluencer influencer = _influencers.FindByName(participant);
                influencer.EarnFee(2000);
                influencer.EndParticipation(brand);
            }

            _campaigns.RemoveModel(campaign);
            return String.Format(OutputMessages.CampaignClosedSuccessfully, brand);
        }

        public string ConcludeAppContract(string username)
        {
            IInfluencer influencer = _influencers.FindByName(username);

            if (influencer == null)
            {
                return String.Format(OutputMessages.InfluencerNotSigned, username);
            }

            if (influencer.Participations.Count > 0)
            {
                return String.Format(OutputMessages.InfluencerHasActiveParticipations, username);
            }

            _influencers.RemoveModel(influencer);
            return String.Format(OutputMessages.ContractConcludedSuccessfully, username);
        }

        public string FundCampaign(string brand, double amount)
        {
            ICampaign campaign = _campaigns.FindByName(brand);
            if (campaign == null)
            {
                return String.Format(OutputMessages.InvalidCampaignToFund);
            }

            if (amount <= 0)
            {
                return String.Format(OutputMessages.NotPositiveFundingAmount);
            }

            campaign.Gain(amount);
            return String.Format(OutputMessages.CampaignFundedSuccessfully, brand, amount);
        }

        public string RegisterInfluencer(string typeName, string username, int followers)
        {
            if (typeName != nameof(BusinessInfluencer) && typeName != nameof(FashionInfluencer) && typeName != nameof(BloggerInfluencer))
            {
                return String.Format(OutputMessages.InfluencerInvalidType, typeName);
            }

            if (this._influencers.FindByName(username) != null)
            {
                return String.Format(OutputMessages.UsernameIsRegistered, username, nameof(InfluencerRepository));
            }

            IInfluencer influencer;
            if (typeName == nameof(BusinessInfluencer))
            {
                influencer = new BusinessInfluencer(username, followers);
                _influencers.AddModel(influencer);
            }
            else if (typeName == nameof(FashionInfluencer))
            {
                influencer = new FashionInfluencer(username, followers);
                _influencers.AddModel(influencer);
            }
            else if (typeName == nameof(BloggerInfluencer))
            {
                influencer = new BloggerInfluencer(username, followers);
                _influencers.AddModel(influencer);
            }
            return String.Format(OutputMessages.InfluencerRegisteredSuccessfully, username);
        }
    }
}