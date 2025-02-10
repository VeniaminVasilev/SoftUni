using BlackFriday.Models.Contracts;
using BlackFriday.Repositories.Contracts;

namespace BlackFriday.Repositories
{
    public class ProductRepository : IRepository<IProduct>
    {
        private List<IProduct> _models;

        public ProductRepository() { this.Models = new List<IProduct>(); }

        public IReadOnlyCollection<IProduct> Models
        {   get { return this._models; }
            private set { this._models = (List<IProduct>)value; }
        }

        public void AddNew(IProduct model)
        {
            this._models.Add(model);
        }

        public bool Exists(string name)
        {
            if (this._models.Any(m => m.ProductName == name))
            { 
                return true;
            }
            return false;
        }

        public IProduct GetByName(string name)
        {
            IProduct product = _models.FirstOrDefault(m => m.ProductName == name);

            if (product == null) {
                return null; }

            return product;
        }
    }
}