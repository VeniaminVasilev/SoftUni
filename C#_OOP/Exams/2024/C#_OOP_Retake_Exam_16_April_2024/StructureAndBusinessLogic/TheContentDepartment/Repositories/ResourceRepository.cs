using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories.Contracts;

namespace TheContentDepartment.Repositories
{
    public class ResourceRepository : IRepository<IResource>
    {
        private List<IResource> _models;

        public ResourceRepository()
        {
            this._models = new List<IResource>();
        }

        public IReadOnlyCollection<IResource> Models
        {
            get { return this._models.AsReadOnly(); }
        }

        public void Add(IResource model)
        {
            this._models.Add(model);
        }

        public IResource TakeOne(string modelName)
        {
            IResource model = this._models.Where(m => m.Name == modelName).FirstOrDefault();

            if (model == null)
            {
                return null;
            }
            return model;
        }
    }
}