namespace _05.FootballTeamGenerator
{
    public class Player
    {
        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("A name should not be empty.");
            }

            if (endurance < 0 || endurance > 100)
            {
                throw new ArgumentException($"Endurance should be between 0 and 100.");
            }

            if (sprint < 0 || sprint > 100)
            {
                throw new ArgumentException($"Sprint should be between 0 and 100.");
            }

            if (dribble < 0 || dribble > 100)
            {
                throw new ArgumentException($"Dribble should be between 0 and 100.");
            }

            if (passing < 0 || passing > 100)
            {
                throw new ArgumentException($"Passing should be between 0 and 100.");
            }

            if (shooting < 0 || shooting > 100)
            {
                throw new ArgumentException($"Shooting should be between 0 and 100.");
            }

            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public string Name { get; }
        public int Endurance { get; }
        public int Sprint { get; }
        public int Dribble { get; }
        public int Passing { get; }
        public int Shooting { get; }
        public double SkillLevel
        {
            get
            {
                return (Endurance + Sprint + Dribble + Passing + Shooting) / 5.0;
            }
        }
    }
}