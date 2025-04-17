using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        private int _boothId;
        private int _capacity;
        private IRepository<IDelicacy> _delicacyMenu;
        private IRepository<ICocktail> _cocktailMenu;
        private double _currentBill;
        private double _turnover;
        private bool _isReserved;

        public Booth(int boothId, int capacity)
        {
            this.BoothId = boothId;
            this.Capacity = capacity;
            this.DelicacyMenu = new DelicacyRepository();
            this.CocktailMenu = new CocktailRepository();
            this.CurrentBill = 0;
            this.Turnover = 0;
            this.IsReserved = false;
        }

        public int BoothId
        {
            get { return _boothId; }
            private set { _boothId = value; }
        }

        public int Capacity
        {
            get { return _capacity; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }
                _capacity = value;
            }
        }

        public IRepository<IDelicacy> DelicacyMenu
        {
            get { return _delicacyMenu; }
            private set { _delicacyMenu = value; }
        }

        public IRepository<ICocktail> CocktailMenu
        {
            get { return _cocktailMenu; }
            private set { _cocktailMenu = value; }
        }

        public double CurrentBill
        {
            get { return _currentBill; }
            private set { _currentBill = value; }
        }

        public double Turnover
        {
            get { return _turnover; }
            private set { _turnover = value; }
        }

        public bool IsReserved
        {
            get { return _isReserved; }
            private set { _isReserved = value; }
        }

        public void ChangeStatus()
        {
            if (_isReserved == true)
            {
                _isReserved = false;
            }
            else
            {
                _isReserved = true;
            }
        }

        public void Charge()
        {
            this.Turnover += CurrentBill;
            this.CurrentBill = 0;
        }

        public void UpdateCurrentBill(double amount)
        {
            this.CurrentBill += amount;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Booth: {this.BoothId}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Turnover: {this.Turnover:F2} lv");
            sb.AppendLine($"-Cocktail menu:");

            foreach (ICocktail cocktail in CocktailMenu.Models)
            {
                sb.AppendLine($"--{cocktail.ToString()}");
            }

            sb.AppendLine($"-Delicacy menu:");

            foreach (IDelicacy delicacy in DelicacyMenu.Models)
            {
                sb.AppendLine($"--{delicacy.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}