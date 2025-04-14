using LegendsOfValor_TheGuildTrials.Core.Contracts;
using LegendsOfValor_TheGuildTrials.Models;
using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Repositories;
using LegendsOfValor_TheGuildTrials.Repositories.Contratcs;
using LegendsOfValor_TheGuildTrials.Utilities.Messages;
using System.Text;

namespace LegendsOfValor_TheGuildTrials.Core
{
    public class Controller : IController
    {
        private IRepository<IHero> heroes;
        private IRepository<IGuild> guilds;

        public Controller() 
        {
            this.heroes = new HeroRepository();
            this.guilds = new GuildRepository();
        }

        public string AddHero(string heroTypeName, string heroName, string runeMark)
        {
            if (heroTypeName != "Warrior" && heroTypeName != "Sorcerer" && heroTypeName != "Spellblade")
            {
                return string.Format(OutputMessages.InvalidHeroType, heroTypeName);
            }

            if (heroes.GetModel(runeMark) != null)
            {
                return string.Format(OutputMessages.HeroAlreadyExists, runeMark);
            }

            IHero hero;
            if (heroTypeName == "Warrior")
            {
                hero = new Warrior(heroName, runeMark);
                heroes.AddModel(hero);
            }
            else if (heroTypeName == "Sorcerer")
            {
                hero = new Sorcerer(heroName, runeMark);
                heroes.AddModel(hero);
            }
            else if (heroTypeName == "Spellblade")
            {
                hero = new Spellblade(heroName, runeMark);
                heroes.AddModel(hero);
            }

            return String.Format(OutputMessages.HeroAdded, heroTypeName, heroName, runeMark);
        }

        public string CreateGuild(string guildName)
        {
            if (guilds.GetModel(guildName) != null)
            {
                return String.Format(OutputMessages.GuildAlreadyExists, guildName);
            }

            IGuild guild = new Guild(guildName);
            guilds.AddModel(guild);
            return String.Format(OutputMessages.GuildCreated, guildName);
        }

        public string RecruitHero(string runeMark, string guildName)
        {
            if (heroes.GetModel(runeMark) == null)
            {
                return string.Format(OutputMessages.HeroNotFound, runeMark);
            }

            if (guilds.GetModel(guildName) == null)
            {
                return string.Format(OutputMessages.GuildNotFound, guildName);
            }

            IHero hero = heroes.GetModel(runeMark);
            IGuild guild = guilds.GetModel(guildName);

            if (hero.GuildName != null)
            {
                return String.Format(OutputMessages.HeroAlreadyInGuild, hero.Name);
            }

            if (guild.IsFallen == true)
            {
                return String.Format(OutputMessages.GuildIsFallen, guild.Name);
            }

            if (guild.Wealth < 500)
            {
                return string.Format(OutputMessages.GuildCannotAffordRecruitment, guild.Name);
            }

            if (hero.GetType().Name == nameof(Warrior) && guild.Name != "WarriorGuild" && guild.Name != "ShadowGuild")
            {
                return String.Format(OutputMessages.HeroTypeNotCompatible, hero.GetType().Name, guildName);
            }
            else if (hero.GetType().Name == nameof(Sorcerer) && guild.Name != "SorcererGuild" && guild.Name != "ShadowGuild")
            {
                return String.Format(OutputMessages.HeroTypeNotCompatible, hero.GetType().Name, guildName);
            }
            else if (hero.GetType().Name == nameof(Spellblade) && guild.Name != "SorcererGuild" && guild.Name != "WarriorGuild")
            {
                return String.Format(OutputMessages.HeroTypeNotCompatible, hero.GetType().Name, guildName);
            }

            hero.JoinGuild(guild);
            guild.RecruitHero(hero);
            return String.Format(OutputMessages.HeroRecruited, hero.Name, guildName);
        }

        public string StartWar(string attackerGuildName, string defenderGuildName)
        {
            if (guilds.GetModel(attackerGuildName) == null || guilds.GetModel(defenderGuildName) == null)
            {
                return String.Format(OutputMessages.OneOfTheGuildsDoesNotExist);
            }

            IGuild attacker = guilds.GetModel(attackerGuildName);
            IGuild defender = guilds.GetModel(defenderGuildName);

            if (attacker.IsFallen == true || defender.IsFallen == true)
            {
                return String.Format(OutputMessages.OneOfTheGuildsIsFallen);
            }

            int attackerCombatPower = 0;
            int defenderCombatPower = 0;

            foreach (string runeMark in attacker.Legion)
            {
                IHero hero = heroes.GetModel(runeMark);
                attackerCombatPower += hero.Power;
                attackerCombatPower += hero.Mana;
                attackerCombatPower += hero.Stamina;
            }

            foreach (string runeMark in defender.Legion)
            {
                IHero hero = heroes.GetModel(runeMark);
                defenderCombatPower += hero.Power;
                defenderCombatPower += hero.Mana;
                defenderCombatPower += hero.Stamina;
            }

            if (attackerCombatPower > defenderCombatPower)
            {
                int amountOfGold = defender.Wealth;
                attacker.WinWar(defender.Wealth);
                defender.LoseWar();

                return String.Format(OutputMessages.WarWon, attackerGuildName, defenderGuildName, amountOfGold);
            }

            int amountOfGoldFromAttacker = attacker.Wealth;
            defender.WinWar(attacker.Wealth);
            attacker.LoseWar();

            return String.Format(OutputMessages.WarLost, defenderGuildName, amountOfGoldFromAttacker, attackerGuildName);
        }

        public string TrainingDay(string guildName)
        {
            if (guilds.GetModel(guildName) == null)
            {
                return String.Format(OutputMessages.GuildNotFound, guildName);
            }

            IGuild guild = guilds.GetModel(guildName);

            if (guild.IsFallen == true)
            {
                return String.Format(OutputMessages.GuildTrainingDayIsFallen, guildName);
            }

            int totalTrainingCost = guild.Legion.Count * 200;

            if (guild.Wealth < totalTrainingCost)
            {
                return String.Format(OutputMessages.TrainingDayFailed, guildName);
            }

            List<IHero> heroesToTrain = new List<IHero>();

            foreach (string runeMark in guild.Legion)
            {
                IHero hero = heroes.GetModel(runeMark);
                heroesToTrain.Add(hero);
            }

            guild.TrainLegion(heroesToTrain);

            return String.Format(OutputMessages.TrainingDayStarted, guildName, heroesToTrain.Count, totalTrainingCost);
        }

        public string ValorState()
        {
            List<IGuild> orderedGuilds = guilds
                .GetAll()
                .OrderByDescending(g => g.Wealth)
                .ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Valor State:");

            foreach (IGuild guild in orderedGuilds)
            {
                sb.AppendLine($"{guild.Name} (Wealth: {guild.Wealth})");

                List<IHero> orderedHeroes = new List<IHero>();

                foreach (string runeMark in guild.Legion)
                {
                    IHero hero = heroes.GetModel(runeMark);
                    orderedHeroes.Add(hero);
                }

                orderedHeroes = orderedHeroes.OrderBy(h => h.Name).ToList();

                foreach (IHero hero in orderedHeroes)
                {
                    sb.AppendLine($"-{hero.ToString()}");
                    sb.AppendLine($"--{hero.Essence()}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}