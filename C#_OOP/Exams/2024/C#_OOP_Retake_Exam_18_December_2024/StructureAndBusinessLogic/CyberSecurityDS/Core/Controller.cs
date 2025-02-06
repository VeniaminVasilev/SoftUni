using CyberSecurityDS.Core.Contracts;
using CyberSecurityDS.Models;
using CyberSecurityDS.Models.Contracts;
using System.Text;

namespace CyberSecurityDS.Core
{
    public class Controller : IController
    {
        private readonly ISystemManager systemManager;

        public Controller()
        {
            systemManager = new SystemManager();
        }
        public string AddCyberAttack(string attackType, string attackName, int severityLevel, string extraParam)
        {
            if (attackType != "PhishingAttack" && attackType != "MalwareAttack")
                return $"{attackType} is not a valid type for the system.";

            if (systemManager.CyberAttacks.Models.Any(a => a.AttackName == attackName))
                return $"{attackName} already exists in the system.";

            ICyberAttack attack = attackType == "PhishingAttack"
                ? new PhishingAttack(attackName, severityLevel, extraParam)
                : new MalwareAttack(attackName, severityLevel, extraParam);
            systemManager.CyberAttacks.AddNew(attack);

            return $"{attackType}: {attackName} is added to the system.";
        }

        public string AddDefensiveSoftware(string softwareType, string softwareName, int effectiveness)
        {
            if (softwareType != "Firewall" && softwareType != "Antivirus")
                return $"{softwareType} is not a valid type for the system.";

            if (systemManager.DefensiveSoftwares.Models.Any(s => s.Name == softwareName))
                return $"{softwareName} already exists in the system.";

            IDefensiveSoftware soft = softwareType == "Firewall"
                ? new Firewall(softwareName, effectiveness)
                : new Antivirus(softwareName, effectiveness);

            systemManager.DefensiveSoftwares.AddNew(soft);

            return $"{softwareType}: {softwareName} is added to the system.";
        }

        public string AssignDefense(string cyberAttackName, string defensiveSoftwareName)
        {
            var attack = systemManager.CyberAttacks.GetByName(cyberAttackName);
            if (attack == null)
                return $"{cyberAttackName} does not exist in the system.";

            var soft = systemManager.DefensiveSoftwares.GetByName(defensiveSoftwareName);
            if (soft == null)
                return $"{defensiveSoftwareName} does not exist in the system.";

            var model = systemManager.DefensiveSoftwares.Models.FirstOrDefault(s => s.AssignedAttacks.Contains(attack.AttackName));
            if (model != null)
                return $"{cyberAttackName} is already assigned to {model.Name}.";

            soft.AssignAttack(attack.AttackName);

            return $"{cyberAttackName} is assigned to {defensiveSoftwareName}.";
        }

        public string GenerateReport()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Security:");
            foreach (var soft in systemManager.DefensiveSoftwares.Models
                                                      .OrderBy(s => s.Name))
            {
                sb.AppendLine(soft.ToString());
            }

            sb.AppendLine("Threads:");
            sb.AppendLine("-Mitigated:");
            foreach (var attack in systemManager.CyberAttacks.Models
                                                .Where(a => a.Status)
                                                .OrderBy(a => a.AttackName))
            {
                sb.AppendLine(attack.ToString());
            }

            sb.AppendLine("-Pending:");
            foreach (var attack in systemManager.CyberAttacks.Models
                                                .Where(a => !a.Status)
                                                .OrderBy(a => a.AttackName))
            {
                sb.AppendLine(attack.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string MitigateAttack(string cyberAttackName)
        {
            var attack = systemManager.CyberAttacks.GetByName(cyberAttackName);
            if (attack == null)
                return $"{cyberAttackName} does not exist in the system.";

            if (attack.Status)
                return $"{cyberAttackName} is already mitigated.";

            var soft = systemManager.DefensiveSoftwares.Models.FirstOrDefault(s => s.AssignedAttacks.Contains(cyberAttackName));
            if (soft == null)
                return $"{cyberAttackName} is not assigned yet.";

            var sotfName = soft.GetType().Name;
            var attackName = attack.GetType().Name;

            if (sotfName == "Firewall" && attackName != "MalwareAttack")
                return $"{sotfName} cannot mitigate {attackName}.";
            if (sotfName == "Antivirus" && attackName != "PhishingAttack")
                return $"{sotfName} cannot mitigate {attackName}.";

            if (soft.Effectiveness >= attack.SeverityLevel)
            {
                attack.MarkAsMitigated();
                return $"{cyberAttackName} is mitigated successfully.";
            }

            return $"{cyberAttackName} could not be mitigated by {soft.Name}.";
        }
    }
}