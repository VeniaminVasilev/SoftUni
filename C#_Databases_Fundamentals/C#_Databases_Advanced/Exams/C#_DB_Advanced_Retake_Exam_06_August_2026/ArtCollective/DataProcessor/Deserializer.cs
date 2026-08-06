using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using ArtCollective.Data;
using ArtCollective.Data.Models;
using ArtCollective.Data.Models.Enums;
using ArtCollective.DataProcessor.ImportDTOs;
using ArtCollective.Utilities;
using Newtonsoft.Json;

namespace ArtCollective.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format.";
        private const string DuplicatedData = "Data is duplicated.";
        private const string SuccessfullyImportedFeedbackEntity = "Successfully imported feedback (Given on: {0}, Status: {1})";
        private const string SuccessfullyImportedArtworkEntity = "Successfully imported artwork (Artist: {0}, Created on: {1})";

        public static string ImportFeedbacks(ArtCollectiveDbContext dbContext, string xmlString)
        {
            const string xmlRootName = "Feedbacks";

            StringBuilder output = new StringBuilder();
            ICollection<Feedback> feedbacksToImport = new List<Feedback>();

            IEnumerable<ImportFeedbackDto>? feedbackDtos =
                XmlSerializerWrapper.Deserialize<ImportFeedbackDto[]>(xmlString, xmlRootName);

            if (feedbackDtos != null)
            {
                foreach (ImportFeedbackDto feedbackDto in feedbackDtos)
                {
                    if (!IsValid(feedbackDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isGivenOnDateValid = DateTime
                        .TryParseExact(feedbackDto.GivenOn, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out DateTime givenOnValue);

                    bool isStatusValid = Enum
                        .TryParse<Status>(feedbackDto.Status, out Status statusValue);

                    if ((!isGivenOnDateValid) || (!isStatusValid))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool groupExists = dbContext
                        .Groups
                        .Any(g => g.Id == feedbackDto.GroupId);

                    bool artistExists = dbContext
                        .Artists
                        .Any(a => a.Id == feedbackDto.ArtistId);

                    if ((!groupExists) || (!artistExists))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool feedbackExistsInSameGroup = dbContext
                        .Feedbacks
                        .Any(f =>
                            f.GroupId == feedbackDto.GroupId &&
                            f.Content == feedbackDto.Content &&
                            f.GivenOn == givenOnValue &&
                            f.Status == statusValue &&
                            f.ArtistId == feedbackDto.ArtistId);

                    bool feedbackAlreadyImported = feedbacksToImport
                        .Any(f =>
                            f.GroupId == feedbackDto.GroupId &&
                            f.Content == feedbackDto.Content &&
                            f.GivenOn == givenOnValue &&
                            f.Status == statusValue &&
                            f.ArtistId == feedbackDto.ArtistId);

                    if (feedbackExistsInSameGroup || feedbackAlreadyImported)
                    {
                        output.AppendLine(DuplicatedData);
                        continue;
                    }

                    Feedback newFeedback = new Feedback()
                    {
                        GivenOn = givenOnValue,
                        Content = feedbackDto.Content,
                        Status = statusValue,
                        GroupId = feedbackDto.GroupId,
                        ArtistId = feedbackDto.ArtistId
                    };
                    feedbacksToImport.Add(newFeedback);

                    output.AppendLine(string.Format(SuccessfullyImportedFeedbackEntity, 
                        newFeedback.GivenOn.ToString("yyyy-MM-dd"), 
                        feedbackDto.Status));
                }

                dbContext.Feedbacks.AddRange(feedbacksToImport);
                dbContext.SaveChanges();
            }

            return output.ToString().TrimEnd();
        }

        public static string ImportArtworks(ArtCollectiveDbContext dbContext, string jsonString)
        {
            StringBuilder output = new StringBuilder();
            ICollection<Artwork> artworksToImport = new List<Artwork>();

            IEnumerable<ImportArtworkDto>? artworkDtos = JsonConvert.DeserializeObject<ImportArtworkDto[]>(jsonString);

            if (artworkDtos != null)
            {
                foreach (ImportArtworkDto artworkDto in artworkDtos)
                {
                    if (!IsValid(artworkDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isCreatedOnDateValid = DateTime
                        .TryParseExact(artworkDto.CreatedOn, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out DateTime createdOnValue);

                    bool artistExists = dbContext
                        .Artists
                        .Any(a => a.Id == artworkDto.ArtistId);

                    if (!isCreatedOnDateValid || !artistExists)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool artworkExists = dbContext
                        .Artworks
                        .Any(a => a.Title == artworkDto.Title && a.ArtistId == artworkDto.ArtistId);

                    bool artworkAlreadyImported = artworksToImport
                        .Any(a => a.Title == artworkDto.Title && a.ArtistId == artworkDto.ArtistId);

                    if (artworkExists || artworkAlreadyImported)
                    {
                        output.AppendLine(DuplicatedData);
                        continue;
                    }

                    Artwork newArtwork = new Artwork()
                    {
                        Title = artworkDto.Title,
                        Description = artworkDto.Description,
                        CreatedOn = createdOnValue,
                        ArtistId = artworkDto.ArtistId
                    };
                    artworksToImport.Add(newArtwork);

                    string artistUsername = dbContext
                        .Artists
                        .FirstOrDefault(a => a.Id == newArtwork.ArtistId)!
                        .Username;

                    output.AppendLine(string.Format(SuccessfullyImportedArtworkEntity, artistUsername, createdOnValue.ToString("yyyy-MM-dd")));
                }

                dbContext.Artworks.AddRange(artworksToImport);
                dbContext.SaveChanges();
            }

            return output.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            ValidationContext validationContext = new ValidationContext(dto);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            List<string> errorMessages = new List<string>();
            bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, true);

            errorMessages = validationResults.Select(r => r.ErrorMessage!).ToList();

            return isValid;
        }
    }
}
