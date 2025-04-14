using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Repositories.Contratcs;

namespace LegendsOfValor_TheGuildTrials.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private List<IHero> _models;

        public HeroRepository() 
        {
            this._models = new List<IHero>();
        }

        public void AddModel(IHero entity)
        {
            this._models.Add(entity);
        }

        public IReadOnlyCollection<IHero> GetAll()
        {
            return this._models.AsReadOnly();
        }

        public IHero GetModel(string runeMarkOrGuildName)
        {
            return this._models.FirstOrDefault(m => m.RuneMark == runeMarkOrGuildName);
        }
    }
}