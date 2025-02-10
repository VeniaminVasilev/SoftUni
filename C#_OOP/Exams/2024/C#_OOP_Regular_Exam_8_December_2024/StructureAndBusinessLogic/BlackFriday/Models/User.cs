using BlackFriday.Models.Contracts;
using BlackFriday.Utilities.Messages;

namespace BlackFriday.Models
{
    public abstract class User : IUser
    {
        private string _userName;
        private string _email;

        protected User(string userName, string email, bool hasDataAccess)
        {
            UserName = userName;
            Email = email;
            HasDataAccess = hasDataAccess;
        }

        public string UserName
        {
            get { return _userName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.UserNameRequired);
                }
                _userName = value;
            }
        }

        public virtual bool HasDataAccess { get; private set; }

        public string Email
        {
            get
            {
                if (HasDataAccess)
                {
                    return "hidden";
                }
                else
                {
                    return _email;
                }
            }
            private set
            {
                if (HasDataAccess)
                {
                    _email = value;
                }
                else if (HasDataAccess == false)
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        throw new ArgumentException(ExceptionMessages.EmailRequired);
                    }
                    _email = value;
                }
            }
        }

        public override string ToString()
        {
            return $"{UserName} - Status: {this.GetType().Name}, Contact Info: {Email}";
        }
    }
}