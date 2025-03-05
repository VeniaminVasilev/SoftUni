using HighwayToPeak.Core.Contracts;
using HighwayToPeak.Models;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories;
using HighwayToPeak.Repositories.Contracts;
using HighwayToPeak.Utilities.Messages;
using System.Text;

namespace HighwayToPeak.Core
{
    public class Controller : IController
    {
        private IRepository<IPeak> _peakRepository;
        private IRepository<IClimber> _climberRepository;
        private IBaseCamp _baseCamp;

        public Controller()
        {
            this._peakRepository = new PeakRepository();
            this._climberRepository = new ClimberRepository();
            this._baseCamp = new BaseCamp();
        }

        public string AddPeak(string name, int elevation, string difficultyLevel)
        {
            if (_peakRepository.Get(name) != null)
            {
                return String.Format(OutputMessages.PeakAlreadyAdded, name);
            }

            if (difficultyLevel != "Extreme" && difficultyLevel != "Hard" && difficultyLevel != "Moderate")
            {
                return String.Format(OutputMessages.PeakDiffucultyLevelInvalid, difficultyLevel);
            }

            IPeak peak = new Peak(name, elevation, difficultyLevel);
            _peakRepository.Add(peak);
            return String.Format(OutputMessages.PeakIsAllowed, name, _peakRepository.GetType().Name);
        }

        public string AttackPeak(string climberName, string peakName)
        {
            if (_climberRepository.Get(climberName) == null)
            {
                return String.Format(OutputMessages.ClimberNotArrivedYet, climberName);
            }

            if (_peakRepository.Get(peakName) == null)
            {
                return String.Format(OutputMessages.PeakIsNotAllowed, peakName);
            }

            if (!_baseCamp.Residents.Contains(climberName))
            {
                return String.Format(OutputMessages.ClimberNotFoundForInstructions, climberName, peakName);
            }

            IPeak peak = _peakRepository.Get(peakName);
            IClimber climber = _climberRepository.Get(climberName);

            if (peak.DifficultyLevel == "Extreme" && climber.GetType().Name == nameof(NaturalClimber))
            {
                return String.Format(OutputMessages.NotCorrespondingDifficultyLevel, climberName, peakName);
            }

            _baseCamp.LeaveCamp(climberName);
            climber.Climb(peak);

            if (climber.Stamina == 0)
            {
                return String.Format(OutputMessages.NotSuccessfullAttack, climberName);
            }
            
            _baseCamp.ArriveAtCamp(climberName);
            return String.Format(OutputMessages.SuccessfulAttack, climberName, peakName);
        }

        public string BaseCampReport()
        {
            if (_baseCamp.Residents.Count == 0)
            {
                return "BaseCamp is currently empty.";
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("BaseCamp residents:");

            foreach (string climberName in _baseCamp.Residents)
            {
                IClimber climber = _climberRepository.Get(climberName);

                sb.AppendLine($"Name: {climber.Name}, Stamina: {climber.Stamina}, Count of Conquered Peaks: {climber.ConqueredPeaks.Count}");
            }

            return sb.ToString().TrimEnd();
        }

        public string CampRecovery(string climberName, int daysToRecover)
        {
            if (!_baseCamp.Residents.Contains(climberName))
            {
                return String.Format(OutputMessages.ClimberIsNotAtBaseCamp, climberName);
            }

            IClimber climber = _climberRepository.Get(climberName);
            if (climber.Stamina == 10)
            {
                return String.Format(OutputMessages.NoNeedOfRecovery, climberName);
            }

            climber.Rest(daysToRecover);
            return String.Format(OutputMessages.ClimberRecovered, climberName, daysToRecover);
        }

        public string NewClimberAtCamp(string name, bool isOxygenUsed)
        {
            if (_climberRepository.Get(name) != null)
            {
                return String.Format(OutputMessages.ClimberCannotBeDuplicated, name, _climberRepository.GetType().Name);
            }

            IClimber climber;
            if (isOxygenUsed == true)
            {
                climber = new OxygenClimber(name);
                _climberRepository.Add(climber);
            }
            else
            {
                climber = new NaturalClimber(name);
                _climberRepository.Add(climber);
            }

            _baseCamp.ArriveAtCamp(name);
            return $"{name} has arrived at the BaseCamp and will wait for the best conditions.";
        }

        public string OverallStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***Highway-To-Peak***");

            List<IClimber> climbers = _climberRepository
                .All
                .OrderByDescending(c => c.ConqueredPeaks.Count)
                .ThenBy(c => c.Name)
                .ToList();

            foreach (var climber in climbers)
            {
                sb.AppendLine(climber.ToString());

                List<IPeak> peaks = new List<IPeak>();

                foreach (string peakName in climber.ConqueredPeaks)
                {
                    IPeak peak = _peakRepository.Get(peakName);
                    peaks.Add(peak);
                }

                peaks = peaks.OrderByDescending(p => p.Elevation).ToList();

                foreach (var peak in peaks)
                {
                    sb.AppendLine(peak.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}