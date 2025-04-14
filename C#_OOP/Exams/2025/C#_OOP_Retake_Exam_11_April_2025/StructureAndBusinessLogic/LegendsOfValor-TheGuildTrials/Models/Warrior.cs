namespace LegendsOfValor_TheGuildTrials.Models
{
    public class Warrior : Hero
    {
        private const int power = 60;
        private const int mana = 0;
        private const int stamina = 100;

        public Warrior(string name, string runeMark) : base(name, runeMark, power, mana, stamina)
        {
        }

        public override void Train()
        {
            this.Power += 30;
            this.Stamina += 10;
        }

        // Allowed guilds: "WarriorGuild", "ShadowGuild"
    }
}