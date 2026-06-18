namespace Footballers.DataProcessor
{
    using Data;
    using Footballers.Data.Models;
    using Footballers.DataProcessor.ExportDto;
    using Footballers.Utilities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using Newtonsoft.Json;
    using System.Globalization;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            const string xmlRootName = "Coaches";

            ExportCoachDto[] coachesWithTheirFootballers = context
                .Coaches
                .Where(c => c.Footballers.Count >= 1)
                .ToArray()
                .Select(c => new ExportCoachDto()
                {
                    CoachName = c.Name,
                    FootballersCount = c.Footballers.Count,
                    Footballers = c.Footballers
                        .Select(f => new ExportCoachFootballerDto
                        {
                            Name = f.Name,
                            Position = f.PositionType.ToString()
                        })
                        .OrderBy(f => f.Name)
                        .ToArray(),
                })
                .OrderByDescending(c => c.FootballersCount)
                .ThenBy(c => c.CoachName)
                .ToArray();

            string xmlResult = XmlSerializerWrapper.Serialize(coachesWithTheirFootballers, xmlRootName);
            return xmlResult;
        }


        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teamsWithMostFootballers = context
                .Teams
                .Include(t => t.TeamsFootballers)
                .ThenInclude(tf => tf.Footballer)
                .AsNoTracking()
                .ToArray()
                .Where(t => t.TeamsFootballers.Any(tf => tf.Footballer.ContractStartDate >= date))
                .Select(t => new
                {
                    Name = t.Name,
                    Footballers = t.TeamsFootballers
                        .Where(tf => tf.Footballer.ContractStartDate >= date)
                        .Select(tf => tf.Footballer)
                        .OrderByDescending(f => f.ContractEndDate)
                        .ThenBy(f => f.Name)
                        .Select(f => new
                        {
                            FootballerName = f.Name,
                            ContractStartDate = f.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                            ContractEndDate = f.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                            BestSkillType = f.BestSkillType.ToString(),
                            PositionType = f.PositionType.ToString()
                        })
                        .ToArray()
                })
                .OrderByDescending(t => t.Footballers.Length)
                .ThenBy(t => t.Name)
                .Take(5)
                .ToArray();

            string jsonResult = JsonConvert.SerializeObject(teamsWithMostFootballers, Formatting.Indented);
            return jsonResult;
        }
    }
}
