using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Repositories.Contracts;
using Handball.Utilities.Messages;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handball.Core
{
    public class Controller : IController
    {
        private IRepository<IPlayer> _players;
        private IRepository<ITeam> _teams;

        public Controller()
        {
            this._players = new PlayerRepository();
            this._teams = new TeamRepository();
        }

        public string LeagueStandings()
        {
            List<ITeam> orderedTeams = _teams
                .Models
                .OrderByDescending(m => m.PointsEarned)
                .ThenByDescending(m => m.OverallRating)
                .ThenBy(m => m.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***League Standings***");

            foreach (ITeam team in orderedTeams)
            {
                sb.AppendLine(team.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string NewContract(string playerName, string teamName)
        {
            if (!_players.ExistsModel(playerName))
            {
                return string.Format(OutputMessages.PlayerNotExisting, playerName, nameof(PlayerRepository));
            }

            if (!_teams.ExistsModel(teamName))
            {
                return string.Format(OutputMessages.TeamNotExisting, teamName, nameof(TeamRepository));
            }

            IPlayer player = _players.GetModel(playerName);
            ITeam team = _teams.GetModel(teamName);

            if (player.Team != null)
            {
                return string.Format(OutputMessages.PlayerAlreadySignedContract, playerName, player.Team);
            }

            player.JoinTeam(teamName);
            team.SignContract(player);

            return string.Format(OutputMessages.SignContract, playerName, teamName);
        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            ITeam firstTeam = _teams.GetModel(firstTeamName);
            ITeam secondTeam = _teams.GetModel(secondTeamName);

            if (firstTeam.OverallRating > secondTeam.OverallRating)
            {
                firstTeam.Win();
                secondTeam.Lose();
                return string.Format(OutputMessages.GameHasWinner, firstTeamName, secondTeamName);
            }
            else if (firstTeam.OverallRating < secondTeam.OverallRating)
            {
                firstTeam.Lose();
                secondTeam.Win();
                return string.Format(OutputMessages.GameHasWinner, secondTeamName, firstTeamName);
            }

            firstTeam.Draw();
            secondTeam.Draw();
            return string.Format(OutputMessages.GameIsDraw, firstTeamName, secondTeamName);
        }

        public string NewPlayer(string typeName, string name)
        {
            if (typeName != nameof(Goalkeeper) && typeName != nameof(CenterBack) && typeName != nameof(ForwardWing))
            {
                return string.Format(OutputMessages.InvalidTypeOfPosition, typeName);
            }

            if (_players.ExistsModel(name))
            {
                IPlayer existingPlayer = this._players.GetModel(name);
                return string.Format(OutputMessages.PlayerIsAlreadyAdded, name, _players.GetType().Name, existingPlayer.GetType().Name);
            }

            IPlayer player;
            if (typeName == nameof(Goalkeeper))
            {
                player = new Goalkeeper(name);
                _players.AddModel(player);
            }
            else if (typeName == nameof(CenterBack))
            {
                player = new CenterBack(name);
                _players.AddModel(player);
            }
            else if (typeName == nameof(ForwardWing))
            {
                player = new ForwardWing(name);
                _players.AddModel(player);
            }
            return string.Format(OutputMessages.PlayerAddedSuccessfully, name);
        }

        public string NewTeam(string name)
        {
            if (_teams.ExistsModel(name))
            {
                return string.Format(OutputMessages.TeamAlreadyExists, name, _teams.GetType().Name);
            }

            ITeam team = new Team(name);
            _teams.AddModel(team);
            return string.Format(OutputMessages.TeamSuccessfullyAdded, name, _teams.GetType().Name);
        }

        public string PlayerStatistics(string teamName)
        {
            ITeam team = _teams.GetModel(teamName);
            List<IPlayer> players = team.Players
                .OrderByDescending(p => p.Rating)
                .ThenBy(p => p.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"***{teamName}***");

            foreach (IPlayer player in players)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}