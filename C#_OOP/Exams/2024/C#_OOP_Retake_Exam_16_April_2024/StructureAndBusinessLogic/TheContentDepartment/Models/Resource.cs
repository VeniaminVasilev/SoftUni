using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    public abstract class Resource : IResource
    {
        private string _name;
        private string _creator;
        private readonly int _priority;
        private bool _isTested;
        private bool _isApproved;

        public Resource(string name, string creator, int priority)
        {
            this.Name = name;
            this.Creator = creator;
            this._priority = priority;
            this.IsTested = false;
            this.IsApproved = false;
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

        public string Creator
        {
            get { return this._creator; }
            private set { this._creator = value; }
        }

        public int Priority
        {
            get { return this._priority; }
        }

        public bool IsTested
        {
            get { return this._isTested; }
            private set { this._isTested = value; }
        }

        public bool IsApproved
        {
            get { return this._isApproved; }
            private set { this._isApproved = value; }
        }

        public void Approve()
        {
            this.IsApproved = true;
        }

        public void Test()
        {
            if (IsTested == false) { IsTested = true; }
            else if (IsTested == true) { IsTested = false; }
        }

        public override string ToString()
        {
            return $"{this.Name} ({this.GetType().Name}), Created By: {this.Creator}";
        }
    }
}