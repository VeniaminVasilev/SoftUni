using CarDealership.Models.Contracts;
using CarDealership.Repositories.Contracts;

namespace CarDealership.Repositories
{
    public class CustomerRepository : IRepository<ICustomer>
    {
        private List<ICustomer> _models;

        public CustomerRepository()
        {
            this._models = new List<ICustomer>();
        }

        public IReadOnlyCollection<ICustomer> Models { get { return _models.AsReadOnly(); } }

        public void Add(ICustomer model)
        {
            _models.Add(model);
        }

        public bool Exists(string text)
        {
            return _models.Any(c => c.Name == text);
        }

        public ICustomer Get(string text)
        {
            ICustomer customer = _models.FirstOrDefault(c => c.Name == text);

            if (customer != null)
            {
                return customer;
            }
            return null;
        }

        public bool Remove(string text)
        {
            ICustomer customerToBeRemoved = _models.FirstOrDefault(c => c.Name == text);

            if (customerToBeRemoved != null)
            {
                _models.Remove(customerToBeRemoved);
                return true;
            }
            return false;
        }
    }
}