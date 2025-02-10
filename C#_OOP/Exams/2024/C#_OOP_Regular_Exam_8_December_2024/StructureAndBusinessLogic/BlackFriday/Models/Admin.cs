namespace BlackFriday.Models
{
    public class Admin : User
    {
        public Admin(string userName, string email) : base(userName, email, true)
        {
        }

        public override bool HasDataAccess { get { return true; } }
    }
}