using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    public abstract class TeamMember : ITeamMember
    {
        private string _name;
        private string _path;
        private readonly List<string> _inProgress;

        public TeamMember(string name, string path)
        {
            this.Name = name;
            this.Path = path;
            this._inProgress = new List<string>();
        }

        public string Name
        {
            get { return this._name; }
            private set
            { 
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhiteSpace);
                }
                this._name = value;
            }
        }

        public string Path
        {
            get { return this._path; }
            protected set { this._path = value; }
        }

        public IReadOnlyCollection<string> InProgress
        {
            get { return this._inProgress.AsReadOnly(); }
        }

        public void FinishTask(string resourceName)
        {
            this._inProgress.Remove(resourceName);
        }

        public void WorkOnTask(string resourceName)
        {
            if (!_inProgress.Contains(resourceName))
            {
                this._inProgress.Add(resourceName);
            }
        }
    }
}