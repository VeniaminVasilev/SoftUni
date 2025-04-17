using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System.Collections.Generic;

namespace ChristmasPastryShop.Repositories
{
    public class DelicacyRepository : IRepository<IDelicacy>
    {
        private List<IDelicacy> _models;

        public DelicacyRepository()
        {
            _models = new List<IDelicacy>();
        }

        public IReadOnlyCollection<IDelicacy> Models
        {
            get { return _models.AsReadOnly(); }
        }

        public void AddModel(IDelicacy model)
        {
            this._models.Add(model);
        }
    }
}