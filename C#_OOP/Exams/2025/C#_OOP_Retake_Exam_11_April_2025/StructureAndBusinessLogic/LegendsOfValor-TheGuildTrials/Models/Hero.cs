using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Utilities.Messages;

namespace LegendsOfValor_TheGuildTrials.Models
{
    public abstract class Hero : IHero
    {
        private string _name;
        private string _runeMark;
        private string _guildName;
        private int _power;
        private int _mana;
        private int _stamina;

        public Hero(string name, string runeMark, int power, int mana, int stamina)
        {
            this.Name = name;
            this.RuneMark = runeMark;
            this.Power = power;
            this.Mana = mana;
            this.Stamina = stamina;
        }

        public string Name
        {
            get { return _name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ErrorMessages.InvalidHeroName);
                }
                _name = value;
            }
        }

        public string RuneMark
        {
            get { return _runeMark; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ErrorMessages.InvalidHeroRuneMark);
                }
                _runeMark = value;
            }
        }

        public string GuildName
        {
            get { return _guildName; }
            private set
            {
                _guildName = value;
            }
        }

        public int Power
        {
            get { return _power; }
            protected set
            {
                _power = value;
            }
        }

        public int Mana
        {
            get { return _mana; }
            protected set
            {
                _mana = value;
            }
        }

        public int Stamina
        {
            get { return _stamina; }
            protected set
            {
                _stamina = value;
            }
        }

        public string Essence()
        {
            return $"Essence Revealed - Power [{Power}] Mana [{Mana}] Stamina [{Stamina}]";
        }

        public void JoinGuild(IGuild guild)
        {
            this.GuildName = guild.Name;
        }

        public abstract void Train();

        public override string ToString()
        {
            return $"Hero: [{Name}] of the Guild '{GuildName}' - RuneMark: {RuneMark}";
        }
    }
}