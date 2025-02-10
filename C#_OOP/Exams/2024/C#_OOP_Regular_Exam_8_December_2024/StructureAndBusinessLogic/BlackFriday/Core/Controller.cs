using BlackFriday.Core.Contracts;
using BlackFriday.Models;
using BlackFriday.Models.Contracts;
using BlackFriday.Utilities.Messages;
using System.Diagnostics;
using System.Text;

namespace BlackFriday.Core
{
    public class Controller : IController
    {
        private IApplication _application;

        public Controller() { this._application = new Application(); }

        public string AddProduct(string productType, string productName, string userName, double basePrice)
        {
            if (productType != "Item" && productType != "Service")
            {
                return String.Format(OutputMessages.ProductIsNotPresented, productType);
            }

            if (_application.Products.Models.Any(p => p.ProductName == productName))
            {
                return String.Format(OutputMessages.ProductNameDuplicated, productName);
            }

            if (!_application.Users.Models.Any(u => u.UserName == userName)
                || _application.Users.Models.FirstOrDefault(u => u.UserName == userName).HasDataAccess == false)
            {
                return String.Format(OutputMessages.UserIsNotAdmin, userName);
            }

            if (productType == "Item")
            {
                IProduct item = new Item(productName, basePrice);
                _application.Products.AddNew(item);
                return $"{productType}: {productName} is added in the application. Price: {basePrice:F2}";
            }
            else if (productType == "Service")
            {
                IProduct service = new Service(productName, basePrice);
                _application.Products.AddNew(service);
                return $"{productType}: {productName} is added in the application. Price: {basePrice:F2}";
            }

            return "";
        }

        public string ApplicationReport()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Application administration:");

            List<IUser> admins = _application
                .Users
                .Models
                .Where(u => u.HasDataAccess == true)
                .OrderBy(u => u.UserName)
                .ToList();

            foreach (IUser admin in admins)
            {
                sb.AppendLine(admin.ToString());
            }

            sb.AppendLine("Clients:");

            List<IUser> clients = _application
                .Users
                .Models
                .Where(u => u.HasDataAccess == false)
                .OrderBy(u => u.UserName)
                .ToList();

            foreach (Client client in clients)
            {
                sb.AppendLine(client.ToString());

                bool hasBlackFridayPurchases = client.Purchases.Any(p => p.Value == true);
                Dictionary<string, bool> blackFridayPurchases = client
                    .Purchases
                    .Where(p => p.Value == true)
                    .ToDictionary(p => p.Key, p => p.Value);

                if (hasBlackFridayPurchases == true)
                {
                    sb.AppendLine($"-Black Friday Purchases: {blackFridayPurchases.Count}");

                    foreach (var kvp in blackFridayPurchases)
                    {
                        sb.AppendLine($"--{kvp.Key}");
                    }
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string PurchaseProduct(string userName, string productName, bool blackFridayFlag)
        {
            if (!_application.Users.Models.Any(u => u.UserName == userName)
                || _application.Users.Models.FirstOrDefault(u => u.UserName == userName).HasDataAccess == true)
            {
                return String.Format(OutputMessages.UserIsNotClient, userName);
            }

            if (!_application.Products.Models.Any(p => p.ProductName == productName))
            {
                return String.Format(OutputMessages.ProductDoesNotExist, productName);
            }

            if (_application.Products.Models.FirstOrDefault(p => p.ProductName == productName).IsSold == true)
            {
                return String.Format(OutputMessages.ProductOutOfStock, productName);
            }

            IProduct product = _application.Products.Models.FirstOrDefault(p => p.ProductName == productName);
            Client client = (Client)_application.Users.Models.FirstOrDefault(u => u.UserName == userName);

            client.PurchaseProduct(productName, blackFridayFlag);
            product.ToggleStatus();

            if (blackFridayFlag == true)
            {
                return $"{userName} purchased {productName}. Price: {product.BlackFridayPrice:F2}";
            }
            else
            {
                return $"{userName} purchased {productName}. Price: {product.BasePrice:F2}";
            }
        }

        public string RefreshSalesList(string userName)
        {
            if (!_application.Users.Models.Any(u => u.UserName == userName)
                || _application.Users.Models.FirstOrDefault(u => u.UserName == userName).HasDataAccess == false)
            {
                return String.Format(OutputMessages.UserIsNotAdmin, userName);
            }

            List<IProduct> soldProducts = _application.Products.Models.Where(p => p.IsSold == true).ToList();

            foreach (IProduct product in soldProducts)
            {
                product.ToggleStatus();
            }

            return String.Format(OutputMessages.SalesListRefreshed, soldProducts.Count);
        }

        public string RegisterUser(string userName, string email, bool hasDataAccess)
        {
            if (_application.Users.Models.Any(u => u.UserName == userName))
            {
                return String.Format(OutputMessages.UserAlreadyRegistered, userName);
            }

            if (_application.Users.Models.Any(u => u.Email == email))
            {
                return String.Format(OutputMessages.SameEmailIsRegistered, email);
            }

            if (hasDataAccess == true)
            {
                if (_application.Users.Models.Count(u => u.HasDataAccess == true) == 2)
                {
                    return String.Format(OutputMessages.AdminCountLimited);
                }
                IUser admin = new Admin(userName, email);
                _application.Users.AddNew(admin);
                return String.Format(OutputMessages.AdminRegistered, userName);
            }

            IUser client = new Client(userName, email);
            _application.Users.AddNew(client);
            return String.Format(OutputMessages.ClientRegistered, userName);
        }

        public string UpdateProductPrice(string productName, string userName, double newPriceValue)
        {
            if (!_application.Products.Models.Any(p => p.ProductName == productName))
            {
                return String.Format(OutputMessages.ProductDoesNotExist, productName);
            }

            if (!_application.Users.Models.Any(u => u.UserName == userName)
                || _application.Users.Models.FirstOrDefault(u => u.UserName == userName).HasDataAccess == false)
            {
                return String.Format(OutputMessages.UserIsNotAdmin, userName);
            }

            IProduct product = _application.Products.Models.FirstOrDefault(p => p.ProductName == productName);
            double oldPriceValue = product.BasePrice;
            product.UpdatePrice(newPriceValue);

            return $"{productName} -> Price is updated: {oldPriceValue:F2} -> {newPriceValue:F2}";
        }
    }
}