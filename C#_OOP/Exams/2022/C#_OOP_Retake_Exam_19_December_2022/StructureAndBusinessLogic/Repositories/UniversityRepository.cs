using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class UniversityRepository : IRepository<IUniversity>
    {
        private List<IUniversity> _models;

        public UniversityRepository()
        {
            this._models = new List<IUniversity>();
        }

        public IReadOnlyCollection<IUniversity> Models
        {
            get { return this._models.AsReadOnly(); }
        }

        public void AddModel(IUniversity model)
        {
            this._models.Add(model);
        }

        public IUniversity FindById(int id)
        {
            return this._models.FirstOrDefault(m => m.Id == id);
        }

        public IUniversity FindByName(string name)
        {
            return this._models.FirstOrDefault(m => m.Name == name);
        }
    }
}