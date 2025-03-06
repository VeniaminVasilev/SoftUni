using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories.Contracts;

namespace NauticalCatchChallenge.Repositories
{
    public class DiverRepository : IRepository<IDiver>
    {
        private List<IDiver> _models;

        public DiverRepository()
        {
            this._models = new List<IDiver>();
        }

        public IReadOnlyCollection<IDiver> Models
        {
            get { return this._models.AsReadOnly(); }
        }

        public void AddModel(IDiver model)
        {
            this._models.Add(model);
        }

        public IDiver GetModel(string name)
        {
            return this._models.FirstOrDefault(m => m.Name == name);
        }
    }
}