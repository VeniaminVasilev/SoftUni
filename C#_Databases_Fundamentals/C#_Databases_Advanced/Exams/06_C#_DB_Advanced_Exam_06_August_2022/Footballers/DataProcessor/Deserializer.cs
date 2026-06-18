namespace Footballers.DataProcessor
{
    using Footballers.Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Footballers.Utilities;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            const string xmlRootName = "Coaches";

            StringBuilder output = new StringBuilder();
            ICollection<Coach> coachesToImport = new List<Coach>();

            // the following may be nullable
            IEnumerable<ImportCoachDto>? coachesDtos =
                XmlSerializerWrapper.Deserialize<ImportCoachDto[]>(xmlString, xmlRootName);

            if (coachesDtos != null)
            {
                foreach (ImportCoachDto coachDto in coachesDtos)
                {
                    if (!IsValid(coachDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    Coach newCoach = new Coach()
                    {
                        Name = coachDto.Name,
                        Nationality = coachDto.Nationality,
                        Footballers = new List<Footballer>()
                    };

                    foreach (ImportCoachFootballerDto footballerDto in coachDto.Footballers)
                    {
                        if (!IsValid(footballerDto)) 
                        {
                            output.AppendLine(ErrorMessage);
                            continue;
                        }

                        bool isContractStartDateValid = DateTime.TryParseExact(
                            footballerDto.ContractStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var contractStartDate);

                        bool isContractEndDateValid = DateTime.TryParseExact(
                            footballerDto.ContractEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var contractEndDate);

                        if (!isContractStartDateValid || !isContractEndDateValid || contractEndDate < contractStartDate)
                        {
                            output.AppendLine(ErrorMessage);
                            continue;
                        }

                        Footballer newFootballer = new Footballer()
                        {
                            Name = footballerDto.Name,
                            ContractStartDate = contractStartDate,
                            ContractEndDate = contractEndDate,
                            PositionType = (PositionType)footballerDto.PositionType,
                            BestSkillType = (BestSkillType)footballerDto.BestSkillType
                        };

                        newCoach.Footballers.Add(newFootballer);
                    }

                    coachesToImport.Add(newCoach);
                    output.AppendLine(string.Format(SuccessfullyImportedCoach, newCoach.Name, newCoach.Footballers.Count));
                }

                context.Coaches.AddRange(coachesToImport);
                context.SaveChanges();
            }

            return output.ToString().TrimEnd();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            StringBuilder output = new StringBuilder();
            ICollection<Team> teamsToImport = new List<Team>();

            // nullable
            IEnumerable<ImportTeamDto>? teamsDtos = JsonConvert.DeserializeObject<ImportTeamDto[]>(jsonString);

            if (teamsDtos != null)
            {
                foreach (ImportTeamDto teamDto in teamsDtos)
                {
                    if (!IsValid(teamDto) || teamDto.Trophies <= 0)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    Team newTeam = new Team()
                    {
                        Name = teamDto.Name,
                        Nationality = teamDto.Nationality,
                        Trophies = teamDto.Trophies,
                        TeamsFootballers = new List<TeamFootballer>()
                    };

                    foreach (int footballerId in teamDto.Footballers.Distinct())
                    {
                        Footballer? footballer = context.Footballers.Find(footballerId);
                        if (footballer == null)
                        {
                            output.AppendLine(ErrorMessage);
                            continue;
                        }

                        newTeam.TeamsFootballers.Add(new TeamFootballer { FootballerId = footballerId });
                    }

                    teamsToImport.Add(newTeam);
                    output.AppendLine(string.Format(SuccessfullyImportedTeam, newTeam.Name, newTeam.TeamsFootballers.Count));
                }

                context.Teams.AddRange(teamsToImport);
                context.SaveChanges();
            }

            return output.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
