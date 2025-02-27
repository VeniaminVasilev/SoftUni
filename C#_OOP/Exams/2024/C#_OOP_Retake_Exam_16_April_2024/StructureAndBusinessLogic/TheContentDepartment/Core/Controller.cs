using System.IO;
using System.Text;
using TheContentDepartment.Core.Contracts;
using TheContentDepartment.Models;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories;
using TheContentDepartment.Repositories.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Core
{
    public class Controller : IController
    {
        private IRepository<IResource> _resources;
        private IRepository<ITeamMember> _members;

        public Controller()
        {
            this._resources = new ResourceRepository();
            this._members = new MemberRepository();
        }

        public string ApproveResource(string resourceName, bool isApprovedByTeamLead)
        {
            IResource resource = _resources.TakeOne(resourceName);

            if (resource.IsTested == false)
            {
                return String.Format(OutputMessages.ResourceNotTested, resourceName);
            }

            ITeamMember teamLead = _members.Models.Where(m => m.Path == "Master").FirstOrDefault();

            if (isApprovedByTeamLead == true)
            {
                resource.Approve();
                teamLead.FinishTask(resourceName);

                return string.Format(OutputMessages.ResourceApproved, teamLead.Name, resourceName);
            }

            resource.Test();

            return string.Format(OutputMessages.ResourceReturned, teamLead.Name, resourceName);
        }

        public string CreateResource(string resourceType, string resourceName, string path)
        {
            if (resourceType != "Exam" && resourceType != "Workshop" && resourceType != "Presentation")
            {
                return String.Format(OutputMessages.ResourceTypeInvalid, resourceType);
            }

            ITeamMember teamMember = _members.Models.Where(m => m.Path == path).FirstOrDefault();

            if (teamMember == null)
            {
                return String.Format(OutputMessages.NoContentMemberAvailable, resourceName);
            }

            if (teamMember.InProgress.Contains(resourceName))
            {
                return String.Format(OutputMessages.ResourceExists, resourceName);
            }

            IResource resource = null;
            if (resourceType == "Exam")
            {
                resource = new Exam(resourceName, teamMember.Name);
            }
            else if (resourceType == "Workshop")
            {
                resource = new Workshop(resourceName, teamMember.Name);
            }
            else if (resourceType == "Presentation")
            {
                resource = new Presentation(resourceName, teamMember.Name);
            }

            teamMember.WorkOnTask(resourceName);
            _resources.Add(resource);
            return String.Format(OutputMessages.ResourceCreatedSuccessfully,
                teamMember.Name, resourceType, resourceName);
        }

        public string DepartmentReport()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Finished Tasks:");

            List<IResource> approvedResources = _resources.Models.Where(r => r.IsApproved == true).ToList();

            foreach (var resource in approvedResources)
            {
                sb.AppendLine($"--{resource.ToString()}");
            }

            sb.AppendLine("Team Report:");

            ITeamMember teamLead = _members.Models.Where(m => m.Path == "Master").FirstOrDefault();
            sb.AppendLine($"--{teamLead.ToString()}");

            List<ITeamMember> contentMembers = _members
                .Models
                .Where(m => m.Path == "CSharp" || m.Path == "JavaScript" || m.Path == "Python" || m.Path == "Java")
                .ToList();

            foreach (var contentMember in contentMembers)
            {
                sb.AppendLine(contentMember.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string JoinTeam(string memberType, string memberName, string path)
        {
            if (memberType != "TeamLead" && memberType != "ContentMember")
            {
                return String.Format(OutputMessages.MemberTypeInvalid, memberType);
            }

            if (this._members.Models.Any(m => m.Path == path))
            {
                return String.Format(OutputMessages.PositionOccupied);
            }

            if (this._members.Models.Any(m => m.Name == memberName))
            {
                return String.Format(OutputMessages.MemberExists, memberName);
            }

            ITeamMember newTeamMember = null;
            if (memberType == nameof(TeamLead))
            {
                newTeamMember = new TeamLead(memberName, path);
            }
            else
            {
                newTeamMember = new ContentMember(memberName, path);
            }
            this._members.Add(newTeamMember);
            return String.Format(OutputMessages.MemberJoinedSuccessfully, memberName);
        }

        public string LogTesting(string memberName)
        {
            if (_members.TakeOne(memberName) == null)
            {
                return String.Format(OutputMessages.WrongMemberName);
            }

            ITeamMember creator = _members.TakeOne(memberName);

            IResource resource = _resources
                .Models
                .Where(r => r.Creator == memberName)
                .Where(r => r.IsTested == false)
                .OrderBy(r => r.Priority)
                .FirstOrDefault();

            if (resource == null)
            {
                return String.Format(OutputMessages.NoResourcesForMember, memberName);
            }

            ITeamMember teamLead = _members.Models.Where(m => m.Path == "Master").FirstOrDefault();

            creator.FinishTask(resource.Name);
            teamLead.WorkOnTask(resource.Name);
            resource.Test();

            return String.Format(OutputMessages.ResourceTested, resource.Name);
        }
    }
}