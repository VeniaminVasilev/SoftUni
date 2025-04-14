namespace LegendsOfValor_TheGuildTrials.Models
{
    public class Spellblade : Hero
    {
        private const int power = 50;
        private const int mana = 60;
        private const int stamina = 60;

        public Spellblade(string name, string runeMark) : base(name, runeMark, power, mana, stamina)
        {
        }

        public override void Train()
        {
            this.Power += 15;
            this.Mana += 10;
            this.Stamina += 10;
        }

        // Allowed guilds: "WarriorGuild", "SorcererGuild"
    }
}