using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Repositories.Contracts;
using RobotService.Utilities.Messages;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private IRepository<ISupplement> supplements;
        private IRepository<IRobot> robots;

        public Controller()
        {
            this.supplements = new SupplementRepository();
            this.robots = new RobotRepository();
        }

        public string CreateRobot(string model, string typeName)
        {
            if (typeName != nameof(DomesticAssistant) && typeName != nameof(IndustrialAssistant))
            {
                return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }

            IRobot robot;
            if (typeName == nameof(DomesticAssistant))
            {
                robot = new DomesticAssistant(model);
                robots.AddNew(robot);
            }
            else if (typeName == nameof(IndustrialAssistant))
            {
                robot = new IndustrialAssistant(model);
                robots.AddNew(robot);
            }
            return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
        }

        public string CreateSupplement(string typeName)
        {
            if (typeName != nameof(SpecializedArm) && typeName != nameof(LaserRadar))
            {
                return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }

            ISupplement supplement;
            if (typeName == nameof(SpecializedArm))
            {
                supplement = new SpecializedArm();
                supplements.AddNew(supplement);
            }
            else if (typeName == nameof(LaserRadar))
            {
                supplement = new LaserRadar();
                supplements.AddNew(supplement);
            }
            return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            List<IRobot> robotsList = robots
                .Models()
                .Where(r => r.InterfaceStandards.Contains(intefaceStandard))
                .OrderByDescending(r => r.BatteryLevel)
                .ToList();
                
            if (robotsList.Count == 0)
            {
                return string.Format(OutputMessages.UnableToPerform, intefaceStandard);
            }

            int availablePower = robotsList.Sum(r => r.BatteryLevel);

            if (availablePower < totalPowerNeeded)
            {
                return string.Format(OutputMessages.MorePowerNeeded, serviceName, (totalPowerNeeded - availablePower));
            }

            int usedRobotsCount = 0;

            for (int i = 0; i < robotsList.Count; i++)
            {
                IRobot currentRobot = robotsList[i];

                if (currentRobot.BatteryLevel >= totalPowerNeeded)
                {
                    currentRobot.ExecuteService(totalPowerNeeded);
                    usedRobotsCount++;
                    break;
                }
                else if (currentRobot.BatteryLevel < totalPowerNeeded)
                {
                    totalPowerNeeded -= currentRobot.BatteryLevel;
                    currentRobot.ExecuteService(currentRobot.BatteryLevel);
                    usedRobotsCount++;
                }
            }

            return string.Format(OutputMessages.PerformedSuccessfully, serviceName, usedRobotsCount);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            List<IRobot> orderedRobots = this.robots
                .Models()
                .OrderByDescending(r => r.BatteryLevel)
                .ThenBy(r => r.BatteryCapacity)
                .ToList();

            foreach (IRobot robot in orderedRobots)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string RobotRecovery(string model, int minutes)
        {
            List<IRobot> robotsToBeFed = robots
                .Models()
                .Where(r => r.Model == model)
                .Where(r => r.BatteryLevel < (r.BatteryCapacity / 2))
                .ToList();

            foreach (IRobot robot in robotsToBeFed)
            {
                robot.Eating(minutes);
            }

            return string.Format(OutputMessages.RobotsFed, robotsToBeFed.Count);
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            List<ISupplement> listSupplements = supplements.Models().ToList();
            ISupplement firstSupplement = listSupplements.FirstOrDefault(s => s.GetType().Name == supplementTypeName);
            int interfaceStandard = firstSupplement.InterfaceStandard;

            List<IRobot> robotsForUpgrade = robots
                .Models()
                .Where(r => !r.InterfaceStandards.Contains(interfaceStandard))
                .Where(r => r.Model == model)
                .ToList();

            if (robotsForUpgrade.Count == 0)
            {
                return string.Format(OutputMessages.AllModelsUpgraded, model);
            }

            IRobot robotForUpgrade = robotsForUpgrade.First();
            robotForUpgrade.InstallSupplement(firstSupplement);
            supplements.RemoveByName(supplementTypeName);

            return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);
        }
    }
}