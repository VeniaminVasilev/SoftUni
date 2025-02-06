namespace _07.MilitaryElite.Interfaces
{
    public interface ICommando
    {
        Dictionary<string, string> Missions { get; }

        void CompleteMission(string codeName);
    }
}