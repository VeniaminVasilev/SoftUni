using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private IRepository<IBooth> _booths;

        public Controller()
        {
            this._booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            IBooth booth = new Booth(_booths.Models.Count + 1, capacity);
            _booths.AddModel(booth);

            return string.Format(OutputMessages.NewBoothAdded, booth.BoothId, capacity);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            IBooth booth = _booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            if (cocktailTypeName != nameof(Hibernation) && cocktailTypeName != nameof(MulledWine))
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            if (size != "Small" && size != "Middle" && size != "Large")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }

            if (booth.CocktailMenu.Models.FirstOrDefault(c => c.Name == cocktailName && c.Size == size) != null)
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            ICocktail cocktail;

            if (cocktailTypeName == nameof(Hibernation))
            {
                cocktail = new Hibernation(cocktailName, size);
                booth.CocktailMenu.AddModel(cocktail);
            }
            else if (cocktailTypeName == nameof(MulledWine))
            {
                cocktail = new MulledWine(cocktailName, size);
                booth.CocktailMenu.AddModel(cocktail);
            }

            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            if (delicacyTypeName != nameof(Gingerbread) && delicacyTypeName != nameof(Stolen))
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            IBooth booth = _booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            if (booth.DelicacyMenu.Models.FirstOrDefault(d => d.Name == delicacyName) != null)
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            IDelicacy delicacy;

            if (delicacyTypeName == nameof(Gingerbread))
            {
                delicacy = new Gingerbread(delicacyName);
                booth.DelicacyMenu.AddModel(delicacy);
            }
            else if (delicacyTypeName == nameof(Stolen))
            {
                delicacy = new Stolen(delicacyName);
                booth.DelicacyMenu.AddModel(delicacy);
            }

            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = _booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            return booth.ToString();
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = _booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            double currentBill = booth.CurrentBill;
            booth.Charge();
            booth.ChangeStatus();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Bill {currentBill:f2} lv");
            sb.AppendLine($"Booth {booth.BoothId} is now available!");

            return sb.ToString().TrimEnd();
        }

        public string ReserveBooth(int countOfPeople)
        {
            IBooth booth = _booths
                .Models
                .Where(b => b.IsReserved == false && b.Capacity >= countOfPeople)
                .OrderBy(b => b.Capacity)
                .ThenByDescending(b => b.BoothId)
                .FirstOrDefault();

            if (booth == null)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            booth.ChangeStatus();
            return string.Format(OutputMessages.BoothReservedSuccessfully, booth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            string[] tokens = order.Split('/');
            string itemTypeName = tokens[0];
            string itemName = tokens[1];
            int countOrderedPieces = int.Parse(tokens[2]);

            IBooth booth = _booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            
            if (itemTypeName != nameof(Hibernation) && itemTypeName != nameof(MulledWine) 
                && itemTypeName != nameof(Gingerbread) && itemTypeName != nameof(Stolen))
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            if (booth.CocktailMenu.Models.FirstOrDefault(m => m.Name == itemName) == null
                && booth.DelicacyMenu.Models.FirstOrDefault(m => m.Name == itemName) == null)
            {
                return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
            }

            if (itemTypeName == nameof(Gingerbread))
            {
                IDelicacy gingerbread = booth
                    .DelicacyMenu
                    .Models
                    .FirstOrDefault(d => d.Name == itemName && d.GetType().Name == nameof(Gingerbread));

                if (gingerbread == null)
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }

                booth.UpdateCurrentBill(gingerbread.Price * countOrderedPieces);
            }
            else if (itemTypeName == nameof(Stolen))
            {
                IDelicacy stolen = booth
                    .DelicacyMenu
                    .Models
                    .FirstOrDefault(d => d.Name == itemName && d.GetType().Name == nameof(Stolen));

                if (stolen == null)
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }

                booth.UpdateCurrentBill(stolen.Price * countOrderedPieces);
            }
            else if (itemTypeName == nameof(Hibernation))
            {
                ICocktail hibernation = booth
                    .CocktailMenu
                    .Models
                    .FirstOrDefault(c => c.Name == itemName && c.Size == tokens[3] && c.GetType().Name == nameof(Hibernation));

                if (hibernation == null)
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, tokens[3], itemName);
                }

                booth.UpdateCurrentBill(hibernation.Price * countOrderedPieces);
            }
            else if (itemTypeName == nameof(MulledWine))
            {
                ICocktail mulledWine = booth
                    .CocktailMenu
                    .Models
                    .FirstOrDefault(c => c.Name == itemName && c.Size == tokens[3] && c.GetType().Name == nameof(MulledWine));

                if (mulledWine == null)
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, tokens[3], itemName);
                }

                booth.UpdateCurrentBill(mulledWine.Price * countOrderedPieces);
            }

            return string.Format(OutputMessages.SuccessfullyOrdered, boothId, countOrderedPieces, itemName);
        }
    }
}