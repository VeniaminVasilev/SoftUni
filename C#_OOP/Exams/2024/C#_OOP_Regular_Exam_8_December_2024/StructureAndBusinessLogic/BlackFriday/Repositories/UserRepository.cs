using BlackFriday.Models.Contracts;
using BlackFriday.Repositories.Contracts;

namespace BlackFriday.Repositories
{
    public class UserRepository : IRepository<IUser>
    {
        private List<IUser> _models;

        public UserRepository() { this.Models = new List<IUser>(); }

        public IReadOnlyCollection<IUser> Models
        {
            get { return this._models; }
            private set { this._models = (List<IUser>)value; }
        }

        public void AddNew(IUser model)
        {
            this._models.Add(model);
        }

        public bool Exists(string name)
        {
            if (this._models.Any(m => m.UserName == name)) { return true; }
            return false;
        }

        public IUser GetByName(string name)
        {
            IUser user = _models.FirstOrDefault(m => m.UserName == name);

            if (user == null)
            {
                return null;
            }
            return user;
        }
    }
}