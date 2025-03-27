using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class SubjectRepository : IRepository<ISubject>
    {
        private List<ISubject> _models;

        public SubjectRepository()
        {
            this._models = new List<ISubject>();
        }

        public IReadOnlyCollection<ISubject> Models
        {
            get { return this._models.AsReadOnly(); }
        }

        public void AddModel(ISubject model)
        {
            this._models.Add(model);
        }

        public ISubject FindById(int id)
        {
            return this._models.FirstOrDefault(m => m.Id == id);
        }

        public ISubject FindByName(string name)
        {
            return this._models.FirstOrDefault(m => m.Name == name);
        }
    }
}