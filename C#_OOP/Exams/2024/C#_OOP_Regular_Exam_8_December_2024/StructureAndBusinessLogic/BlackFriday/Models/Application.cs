using BlackFriday.Models.Contracts;
using BlackFriday.Repositories;
using BlackFriday.Repositories.Contracts;

namespace BlackFriday.Models
{
    public class Application : IApplication
    {
        public Application()
        {
            Products = new ProductRepository();
            Users = new UserRepository();
        }

        public IRepository<IProduct> Products { get; private set; }

        public IRepository<IUser> Users { get; private set; }
    }
}