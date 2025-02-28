using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;

namespace InfluencerManagerApp.Repositories
{
    public class CampaignRepository : IRepository<ICampaign>
    {
        private List<ICampaign> _models;

        public CampaignRepository()
        {
            this._models = new List<ICampaign>();
        }

        public IReadOnlyCollection<ICampaign> Models
        {
            get { return this._models.AsReadOnly(); }
        }

        public void AddModel(ICampaign model)
        {
            this._models.Add(model);
        }

        public ICampaign FindByName(string name)
        {
            return this._models.FirstOrDefault(m => m.Brand == name);
        }

        public bool RemoveModel(ICampaign model)
        {
            return this._models.Remove(model);
        }
    }
}