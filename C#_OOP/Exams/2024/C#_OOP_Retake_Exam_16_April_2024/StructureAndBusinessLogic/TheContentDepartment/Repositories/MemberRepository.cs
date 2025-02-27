using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories.Contracts;

namespace TheContentDepartment.Repositories
{
    public class MemberRepository : IRepository<ITeamMember>
    {
        private List<ITeamMember> _models;

        public MemberRepository()
        {
            this._models = new List<ITeamMember>();
        }

        public IReadOnlyCollection<ITeamMember> Models
        {
            get { return this._models.AsReadOnly(); }
        }

        public void Add(ITeamMember model)
        {
            this._models.Add(model);
        }

        public ITeamMember TakeOne(string modelName)
        {
            ITeamMember teamMember = this._models.Where(m => m.Name == modelName).FirstOrDefault();

            if (teamMember == null)
            {
                return null;
            }
            return teamMember;
        }
    }
}