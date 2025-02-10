namespace BlackFriday.Models
{
    public class Client : User
    {
        private Dictionary<string, bool> _purchases;
        public Client(string userName, string email) : base(userName, email, false)
        {
            Purchases = new Dictionary<string, bool>();
        }

        public override bool HasDataAccess { get { return false; } }

        public IReadOnlyDictionary<string, bool> Purchases
        {   get { return _purchases; } 
            private set { _purchases = (Dictionary<string, bool>)value; }
        }

        public void PurchaseProduct(string productName, bool blackFridayFlag)
        {
            _purchases[productName] = blackFridayFlag;
        }
    }
}