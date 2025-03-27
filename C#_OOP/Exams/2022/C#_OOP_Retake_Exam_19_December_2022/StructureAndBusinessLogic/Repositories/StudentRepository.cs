using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        private List<IStudent> _models;

        public StudentRepository()
        {
            this._models = new List<IStudent>();
        }

        public IReadOnlyCollection<IStudent> Models
        {
            get { return this._models.AsReadOnly(); }
        }

        public void AddModel(IStudent model)
        {
            this._models.Add(model);
        }

        public IStudent FindById(int id)
        {
            return this._models.FirstOrDefault(m => m.Id == id);
        }

        public IStudent FindByName(string name)
        {
            string firstName = name.Split(' ')[0];
            string lastName = name.Split(' ')[1];

            IStudent student = this._models.FirstOrDefault(m => m.FirstName == firstName && m.LastName == lastName);

            return student;
        }
    }
}