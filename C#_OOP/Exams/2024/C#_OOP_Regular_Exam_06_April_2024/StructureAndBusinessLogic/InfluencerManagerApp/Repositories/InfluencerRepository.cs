using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;

namespace InfluencerManagerApp.Repositories
{
    public class InfluencerRepository : IRepository<IInfluencer>
    {
        private List<IInfluencer> _models;

        public InfluencerRepository()
        {
            this._models = new List<IInfluencer>();
        }

        public IReadOnlyCollection<IInfluencer> Models
        {
            get { return this._models.AsReadOnly(); }
        }

        public void AddModel(IInfluencer model)
        {
            this._models.Add(model);
        }

        public IInfluencer FindByName(string name)
        {
            return this._models.FirstOrDefault(m => m.Username == name);
        }

        public bool RemoveModel(IInfluencer model)
        {
            return this._models.Remove(model);
        }
    }
}