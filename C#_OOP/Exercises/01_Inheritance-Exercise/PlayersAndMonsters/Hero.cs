namespace PlayersAndMonsters
{
    public class Hero
    {
        private string _username;
        private int _level;

        public Hero(string username, int level)
        {
            _username = username;
            _level = level;
        }

        public string Username { get { return _username; } }
        public int Level { get { return _level; } }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";
        }
    }
}