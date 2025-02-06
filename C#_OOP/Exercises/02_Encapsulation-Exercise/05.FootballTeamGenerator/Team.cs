namespace _05.FootballTeamGenerator
{
    public class Team
    {
        private readonly List<Player> _players;

        public Team(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("A name should not be empty.");
            }

            this.Name = name;

            this._players = new List<Player>();
            this.Players = this._players.AsReadOnly();
        }

        public string Name { get; }
        public IReadOnlyCollection<Player> Players { get; }
        public int Rating
        {
            get
            {
                return (int)Math.Round(this._players.Average(p => p.SkillLevel));
            }
        }

        public void AddPlayer(Player player)
        {
            this._players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            this._players.RemoveAll(p => p.Name == name);
        }
    }
}