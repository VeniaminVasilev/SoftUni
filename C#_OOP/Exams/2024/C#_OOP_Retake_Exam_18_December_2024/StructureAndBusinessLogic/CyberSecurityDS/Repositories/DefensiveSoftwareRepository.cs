using CyberSecurityDS.Models.Contracts;
using CyberSecurityDS.Repositories.Contracts;

namespace CyberSecurityDS.Repositories
{
    public class DefensiveSoftwareRepository : IRepository<IDefensiveSoftware>
    {
        private List<IDefensiveSoftware> _models;

        public DefensiveSoftwareRepository()
        {
            _models = new List<IDefensiveSoftware>();
        }

        public IReadOnlyCollection<IDefensiveSoftware> Models => _models.AsReadOnly();

        public void AddNew(IDefensiveSoftware model)
        {
            _models.Add(model);
        }

        public bool Exists(string name)
        {
            return _models.Any(m => m.Name == name);
        }

        public IDefensiveSoftware GetByName(string name)
        {
            return _models.FirstOrDefault(m => m.Name == name);
        }
    }
}