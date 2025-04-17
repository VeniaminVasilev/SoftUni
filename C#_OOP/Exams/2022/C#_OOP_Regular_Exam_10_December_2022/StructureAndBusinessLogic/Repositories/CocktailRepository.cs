using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System.Collections.Generic;

namespace ChristmasPastryShop.Repositories
{
    public class CocktailRepository : IRepository<ICocktail>
    {
        private List<ICocktail> _models;

        public CocktailRepository()
        {
            this._models = new List<ICocktail>();
        }

        public IReadOnlyCollection<ICocktail> Models
        {
            get { return this._models.AsReadOnly(); }
        }

        public void AddModel(ICocktail model)
        {
            this._models.Add(model);
        }
    }
}