using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System.Collections.Generic;

namespace ChristmasPastryShop.Repositories
{
    public class BoothRepository : IRepository<IBooth>
    {
        private List<IBooth> _models;

        public BoothRepository()
        {
            this._models = new List<IBooth>();
        }

        public IReadOnlyCollection<IBooth> Models
        {
            get { return this._models.AsReadOnly(); }
        }
        public void AddModel(IBooth model)
        {
            this._models.Add(model);
        }
    }
}