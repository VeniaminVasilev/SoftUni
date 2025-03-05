using HighwayToPeak.Models.Contracts;

namespace HighwayToPeak.Models
{
    public class BaseCamp : IBaseCamp
    {
        private List<string> _residents;

        public BaseCamp()
        {
            this._residents = new List<string>();
        }

        public IReadOnlyCollection<string> Residents
        {
            get { return this._residents.OrderBy(r => r).ToList().AsReadOnly(); }
        }

        public void ArriveAtCamp(string climberName)
        {
            this._residents.Add(climberName);
        }

        public void LeaveCamp(string climberName)
        {
            this._residents.Remove(climberName);
        }
    }
}