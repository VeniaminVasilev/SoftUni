namespace LegendsOfValor_TheGuildTrials.Models
{
    public class Sorcerer : Hero
    {
        private const int power = 40;
        private const int mana = 120;
        private const int stamina = 0;

        public Sorcerer(string name, string runeMark) : base(name, runeMark, power, mana, stamina)
        {
        }

        public override void Train()
        {
            this.Power += 20;
            this.Mana += 25;
        }

        // Allowed guilds: "SorcererGuild", "ShadowGuild"
    }
}