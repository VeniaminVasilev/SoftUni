using CyberSecurityDS.Models.Contracts;
using CyberSecurityDS.Repositories;
using CyberSecurityDS.Repositories.Contracts;

namespace CyberSecurityDS.Models
{
    public class SystemManager : ISystemManager
    {
        private IRepository<ICyberAttack> _cyberAttacks;
        private IRepository<IDefensiveSoftware> _defensiveSoftwares;

        public SystemManager()
        {
            CyberAttacks = new CyberAttackRepository();
            DefensiveSoftwares = new DefensiveSoftwareRepository();
        }

        public IRepository<ICyberAttack> CyberAttacks
        {
            get { return _cyberAttacks; }
            private set { _cyberAttacks = value; }
        }

        public IRepository<IDefensiveSoftware> DefensiveSoftwares
        {
            get { return _defensiveSoftwares; }
            private set { _defensiveSoftwares = value; }
        }
    }
}