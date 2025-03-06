using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Repositories.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System.Text;

namespace NauticalCatchChallenge.Core
{
    public class Controller : IController
    {
        private IRepository<IDiver> _divers;
        private IRepository<IFish> _fish;

        public Controller()
        {
            this._divers = new DiverRepository();
            this._fish = new FishRepository();
        }

        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            if (_divers.GetModel(diverName) == null)
            {
                return String.Format(OutputMessages.DiverNotFound, _divers.GetType().Name, diverName);
            }

            if (_fish.GetModel(fishName) == null)
            {
                return String.Format(OutputMessages.FishNotAllowed, fishName);
            }

            IDiver diver = _divers.GetModel(diverName);
            IFish fish = _fish.GetModel(fishName);

            if (diver.HasHealthIssues == true)
            {
                return String.Format(OutputMessages.DiverHealthCheck, diverName);
            }

            if (diver.OxygenLevel < fish.TimeToCatch)
            {
                diver.Miss(fish.TimeToCatch);

                if (diver.OxygenLevel <= 0) { diver.UpdateHealthStatus(); }

                return String.Format(OutputMessages.DiverMisses, diverName, fishName);
            }
            else if (diver.OxygenLevel == fish.TimeToCatch)
            {
                if (isLucky == true)
                {
                    diver.Hit(fish);

                    if (diver.OxygenLevel <= 0) { diver.UpdateHealthStatus(); }

                    return String.Format(OutputMessages.DiverHitsFish, diverName, fish.Points, fishName);
                }
                else
                {
                    diver.Miss(fish.TimeToCatch);

                    if (diver.OxygenLevel <= 0) { diver.UpdateHealthStatus(); }

                    return String.Format(OutputMessages.DiverMisses, diverName, fishName);
                }
            }

            diver.Hit(fish);

            if (diver.OxygenLevel <= 0) { diver.UpdateHealthStatus(); }

            return String.Format(OutputMessages.DiverHitsFish, diverName, fish.Points, fishName);
        }

        public string CompetitionStatistics()
        {
            StringBuilder sb = new StringBuilder();

            List<IDiver> orderedDivers = this._divers
                .Models
                .Where(m => m.HasHealthIssues == false)
                .OrderByDescending(m => m.CompetitionPoints)
                .ThenByDescending(m => m.Catch.Count)
                .ThenBy(m => m.Name)
                .ToList();

            sb.AppendLine("**Nautical-Catch-Challenge**");

            foreach (IDiver diver in orderedDivers)
            {
                sb.AppendLine(diver.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string DiveIntoCompetition(string diverType, string diverName)
        {
            if (diverType != nameof(FreeDiver) && diverType != nameof(ScubaDiver))
            {
                return String.Format(OutputMessages.DiverTypeNotPresented, diverType);
            }

            if (_divers.GetModel(diverName) != null)
            {
                return String.Format(OutputMessages.DiverNameDuplication, diverName, _divers.GetType().Name);
            }

            IDiver diver;
            if (diverType == nameof(FreeDiver))
            {
                diver = new FreeDiver(diverName);
                _divers.AddModel(diver);
            }
            else if (diverType == nameof(ScubaDiver))
            {
                diver = new ScubaDiver(diverName);
                _divers.AddModel(diver);
            }

            return String.Format(OutputMessages.DiverRegistered, diverName, _divers.GetType().Name);
        }

        public string DiverCatchReport(string diverName)
        {
            StringBuilder sb = new StringBuilder();

            IDiver diver = _divers.GetModel(diverName);

            sb.AppendLine(diver.ToString());
            sb.AppendLine("Catch Report:");

            foreach (string currentFish in diver.Catch)
            {
                IFish fish = _fish.GetModel(currentFish);
                sb.AppendLine(fish.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string HealthRecovery()
        {
            int recoveredDivers = 0;

            foreach (var diver in _divers.Models)
            {
                if (diver.HasHealthIssues == true)
                {
                    diver.UpdateHealthStatus();
                    diver.RenewOxy();
                    recoveredDivers++;
                }
            }

            return String.Format(OutputMessages.DiversRecovered, recoveredDivers);
        }

        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            if (fishType != nameof(ReefFish) && fishType != nameof(DeepSeaFish) && fishType != nameof(PredatoryFish))
            {
                return String.Format(OutputMessages.FishTypeNotPresented, fishType);
            }

            if (_fish.GetModel(fishName) != null)
            {
                return String.Format(OutputMessages.FishNameDuplication, fishName, _fish.GetType().Name);
            }

            IFish fish;
            if (fishType == nameof(ReefFish))
            {
                fish = new ReefFish(fishName, points);
                _fish.AddModel(fish);
            }
            else if (fishType == nameof(DeepSeaFish))
            {
                fish = new DeepSeaFish(fishName, points);
                _fish.AddModel(fish);
            }
            else if (fishType == nameof(PredatoryFish))
            {
                fish = new PredatoryFish(fishName, points);
                _fish.AddModel(fish);
            }

            return String.Format(OutputMessages.FishCreated, fishName);
        }
    }
}