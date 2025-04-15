using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        public int BoothId => throw new System.NotImplementedException();

        public int Capacity => throw new System.NotImplementedException();

        public IRepository<IDelicacy> DelicacyMenu => throw new System.NotImplementedException();

        public IRepository<ICocktail> CocktailMenu => throw new System.NotImplementedException();

        public double CurrentBill => throw new System.NotImplementedException();

        public double Turnover => throw new System.NotImplementedException();

        public bool IsReserved => throw new System.NotImplementedException();

        public void ChangeStatus()
        {
            throw new System.NotImplementedException();
        }

        public void Charge()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCurrentBill(double amount)
        {
            throw new System.NotImplementedException();
        }
    }
}