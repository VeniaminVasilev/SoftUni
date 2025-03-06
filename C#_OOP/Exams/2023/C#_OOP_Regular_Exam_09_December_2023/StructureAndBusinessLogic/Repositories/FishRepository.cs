using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories.Contracts;

namespace NauticalCatchChallenge.Repositories
{
    public class FishRepository : IRepository<IFish>
    {
        private List<IFish> _models;

        public FishRepository()
        {
            this._models = new List<IFish>();
        }

        public IReadOnlyCollection<IFish> Models
        {
            get { return this._models.AsReadOnly(); }
        }

        public void AddModel(IFish model)
        {
            this._models.Add(model);
        }

        public IFish GetModel(string name)
        {
            return this._models.FirstOrDefault(m => m.Name == name);
        }
    }
}