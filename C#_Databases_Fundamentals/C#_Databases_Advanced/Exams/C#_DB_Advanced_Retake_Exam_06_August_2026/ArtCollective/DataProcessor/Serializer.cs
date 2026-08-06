using System.Xml.Serialization;
using System.Xml;
using ArtCollective.Data;
using Newtonsoft.Json;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using ArtCollective.DataProcessor.ExportDTOs;
using ArtCollective.Utilities;

namespace ArtCollective.DataProcessor
{
    public class Serializer
    {
        public static string ExportArtistsWithCollaborationsCountAndTheirArtworks(ArtCollectiveDbContext dbContext)
        {
            const string xmlRootName = "Artists";

            ExportArtistDto[] artistsWithCollaborationsCountAndTheirArtworks = dbContext
                .Artists
                .AsNoTracking()
                .Select(a => new ExportArtistDto
                {
                    Username = a.Username,
                    Collaborations = dbContext.Collaborations
                        .Count(c => c.ArtistOneId == a.Id || c.ArtistTwoId == a.Id),
                    Artworks = a.Artworks
                        .OrderBy(aw => aw.Id)
                        .Select(aw => new ExportArtistArtworkDto
                        {
                            Title = aw.Title,
                            CreatedOn = aw.CreatedOn.ToString("yyyy-MM-dd")
                        })
                        .ToArray()
                })
                .OrderBy(a => a.Username)
                .ToArray();

            string xmlResult = XmlSerializerWrapper
                .Serialize(artistsWithCollaborationsCountAndTheirArtworks, xmlRootName);

            return xmlResult;
        }

        public static string ExportGroupsWithFeedbacksChronologically(ArtCollectiveDbContext dbContext)
        {
            var groupsWithFeedbacksChronologically = dbContext
                .Groups
                .Include(g => g.Feedbacks)
                .ThenInclude(f => f.Artist)
                .AsNoTracking()
                .OrderBy(g => g.StartedOn)
                .ToList()
                .Select(g => new
                {
                    g.Id,
                    g.Title,
                    StartedOn = g.StartedOn.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Feedbacks = g.Feedbacks
                        .OrderBy(f => f.GivenOn)
                        .Select(f => new
                        {
                            f.Content,
                            GivenOn = f.GivenOn.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                            f.Status,
                            ArtistUsername = f.Artist.Username
                        })
                        .ToList()
                })
                .ToList();

            string jsonResult = JsonConvert
                .SerializeObject(groupsWithFeedbacksChronologically, Newtonsoft.Json.Formatting.Indented);

            return jsonResult;
        }
    }
}
