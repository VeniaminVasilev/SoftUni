using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Utilities.Messages;

namespace LegendsOfValor_TheGuildTrials.Models
{
    public class Guild : IGuild
    {
        private string _name;
        private int _wealth;
        private List<string> _legion;
        private bool _isFallen;

        public Guild(string name)
        {
            this.Name = name;
            this._legion = new List<string>();
            this.Wealth = 5000;
            this.IsFallen = false;
        }

        public string Name
        {
            get { return this._name; }
            private set
            {
                if (value != "WarriorGuild" && value != "SorcererGuild" && value != "ShadowGuild")
                {
                    throw new ArgumentException(ErrorMessages.InvalidGuildName);
                }
                this._name = value;
            }
        }

        public int Wealth
        {
            get { return this._wealth; }
            private set
            {
                if (value < 0)
                {
                    this._wealth = 0;
                }
                this._wealth = value;
            }
        }

        public IReadOnlyCollection<string> Legion
        {
            get { return this._legion.AsReadOnly(); }
        }

        public bool IsFallen
        {
            get { return this._isFallen; }
            private set
            {
                _isFallen = value;
            }
        }

        public void LoseWar()
        {
            this.IsFallen = true;
            this.Wealth = 0;
        }

        public void RecruitHero(IHero hero)
        {
            this._legion.Add(hero.RuneMark);
            this.Wealth -= 500;
        }

        public void TrainLegion(ICollection<IHero> heroesToTrain)
        {
            foreach (IHero hero in heroesToTrain)
            {
                hero.Train();
                this.Wealth -= 200;
            }
        }

        public void WinWar(int goldAmount)
        {
            this.Wealth += goldAmount;
        }
    }
}