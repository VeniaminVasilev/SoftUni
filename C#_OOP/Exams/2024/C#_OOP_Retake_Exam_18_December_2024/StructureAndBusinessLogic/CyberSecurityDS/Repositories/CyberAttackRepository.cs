using CyberSecurityDS.Models.Contracts;
using CyberSecurityDS.Repositories.Contracts;

namespace CyberSecurityDS.Repositories
{
    public class CyberAttackRepository : IRepository<ICyberAttack>
    {
        private List<ICyberAttack> _models;

        public CyberAttackRepository()
        {
            _models = new List<ICyberAttack>();
        }

        public IReadOnlyCollection<ICyberAttack> Models => _models.AsReadOnly();

        public void AddNew(ICyberAttack model)
        {
            _models.Add(model);
        }

        public bool Exists(string name)
        {
            return _models.Any(m => m.AttackName == name);
        }

        public ICyberAttack GetByName(string name)
        {
            return _models.FirstOrDefault(m => m.AttackName == name);
        }
    }
}