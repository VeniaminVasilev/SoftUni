using FootballManager.Core.Contracts;
using FootballManager.Models;
using FootballManager.Models.Contracts;
using FootballManager.Repositories;
using FootballManager.Utilities.Messages;
using System.Text;

namespace FootballManager.Core
{
    public class Controller : IController
    {
        private TeamRepository _championship;

        public Controller() 
        {
            this._championship = new TeamRepository();
        }

        public string ChampionshipRankings()
        {
            StringBuilder sb = new StringBuilder();
            List<ITeam> teams = _championship
                .Models
                .OrderByDescending(t => t.ChampionshipPoints)
                .ThenByDescending(t => t.PresentCondition)
                .ToList();

            sb.AppendLine("***Ranking Table***");

            for (int i = 0; i < teams.Count; i++)
            {
                sb.AppendLine($"{i + 1}. {teams[i].ToString()}/{teams[i].TeamManager.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }

        public string JoinChampionship(string teamName)
        {
            if (_championship.Models.Count == _championship.Capacity)
            {
                return String.Format(OutputMessages.ChampionshipFull);
            }

            if (_championship.Exists(teamName))
            {
                return String.Format(OutputMessages.TeamWithSameNameExisting, teamName);
            }

            ITeam team = new Team(teamName);
            this._championship.Add(team);
            return String.Format(OutputMessages.TeamSuccessfullyJoined, teamName);
        }

        public string MatchBetween(string teamOneName, string teamTwoName)
        {
            bool bothTeamsExist = false;
            if (_championship.Models.Any(t => t.Name == teamOneName) && _championship.Models.Any(t => t.Name == teamTwoName))
            {
                bothTeamsExist = true;
            }

            if (bothTeamsExist == false)
            {
                return String.Format(OutputMessages.OneOfTheTeamDoesNotExist);
            }

            ITeam teamOne = _championship.Models.Where(t => t.Name == teamOneName).FirstOrDefault();
            ITeam teamTwo = _championship.Models.Where(t => t.Name == teamTwoName).FirstOrDefault();

            if (teamOne.PresentCondition > teamTwo.PresentCondition)
            {
                teamOne.GainPoints(3);

                if (teamOne.TeamManager != null)
                {
                    teamOne.TeamManager.RankingUpdate(5);
                }

                if (teamTwo.TeamManager != null)
                {
                    teamTwo.TeamManager.RankingUpdate(-5);
                }

                return String.Format(OutputMessages.TeamWinsMatch, teamOneName, teamTwoName);
            }
            else if (teamOne.PresentCondition < teamTwo.PresentCondition)
            {
                teamTwo.GainPoints(3);

                if (teamTwo.TeamManager != null)
                {
                    teamTwo.TeamManager.RankingUpdate(5);
                }

                if (teamOne.TeamManager != null)
                {
                    teamOne.TeamManager.RankingUpdate(-5);
                }

                return String.Format(OutputMessages.TeamWinsMatch, teamTwoName, teamOneName);
            }
            else if (teamOne.PresentCondition == teamTwo.PresentCondition)
            {
                teamOne.GainPoints(1);
                teamTwo.GainPoints(1);

                return String.Format(OutputMessages.MatchIsDraw, teamOneName, teamTwoName);
            }
            return String.Empty;
        }

        public string PromoteTeam(string droppingTeamName, string promotingTeamName, string managerTypeName, string managerName)
        {
            if (!_championship.Exists(droppingTeamName))
            {
                return String.Format(OutputMessages.DroppingTeamDoesNotExist, droppingTeamName);
            }

            if (_championship.Exists(promotingTeamName))
            {
                return String.Format(OutputMessages.TeamWithSameNameExisting, promotingTeamName);
            }

            ITeam promotingTeam = new Team(promotingTeamName);
            List<ITeam> teams = _championship.Models.ToList();
            bool managerAlreadyTaken = false;
            bool managerNotValidType = false;

            if (managerTypeName != "AmateurManager" && managerTypeName != "SeniorManager" && managerTypeName != "ProfessionalManager")
            {
                managerNotValidType = true;
            }

            foreach (var t in teams)
            {
                if (t.TeamManager != null)
                {
                    if (t.TeamManager.Name == managerName)
                    {
                        managerAlreadyTaken = true;
                    }
                }
            }

            if (managerAlreadyTaken == false && managerNotValidType == false)
            {
                if (managerTypeName == "AmateurManager")
                {
                    AmateurManager manager = new AmateurManager(managerName);
                    promotingTeam.SignWith(manager);
                }
                else if (managerTypeName == "SeniorManager")
                {
                    SeniorManager manager = new SeniorManager(managerName);
                    promotingTeam.SignWith(manager);
                }
                else if (managerTypeName == "ProfessionalManager")
                {
                    ProfessionalManager manager = new ProfessionalManager(managerName);
                    promotingTeam.SignWith(manager);
                }
            }

            foreach (var t in teams)
            {
                t.ResetPoints();
            }

            _championship.Remove(droppingTeamName);
            _championship.Add(promotingTeam);

            return String.Format(OutputMessages.TeamHasBeenPromoted, promotingTeamName);
        }

        public string SignManager(string teamName, string managerTypeName, string managerName)
        {
            if (!_championship.Models.Any(t => t.Name == teamName))
            {
                return String.Format(OutputMessages.TeamDoesNotTakePart, teamName);
            }

            ITeam team = _championship.Models.Where(t => t.Name == teamName).FirstOrDefault();

            if (managerTypeName != "AmateurManager" && managerTypeName != "SeniorManager" && managerTypeName != "ProfessionalManager")
            {
                return String.Format(OutputMessages.ManagerTypeNotPresented, managerTypeName);
            }

            if (team.TeamManager != null)
            {
                string currentManagerName = team.TeamManager.Name;
                return String.Format(OutputMessages.TeamSignedWithAnotherManager, teamName, currentManagerName);
            }

            List<ITeam> teams = _championship.Models.ToList();

            for (int i = 0; i < teams.Count; i++)
            {
                if (teams[i].TeamManager != null)
                {
                    if (teams[i].TeamManager.Name == managerName)
                    {
                        return String.Format(OutputMessages.ManagerAssignedToAnotherTeam, managerName);
                    }
                }
            }

            if (managerTypeName == "AmateurManager")
            {
                AmateurManager manager = new AmateurManager(managerName);
                team.SignWith(manager);
            }

            if (managerTypeName == "SeniorManager")
            {
                SeniorManager manager = new SeniorManager(managerName);
                team.SignWith(manager);
            }

            if (managerTypeName == "ProfessionalManager")
            {
                ProfessionalManager manager = new ProfessionalManager(managerName);
                team.SignWith(manager);
            }

            return String.Format(OutputMessages.TeamSuccessfullySignedWithManager, managerName, teamName);
        }
    }
}